#include "msp430.h"
#include "stepperLib/stepper.h"
#include "FirmwareLibhelper/generalLib.h"

#define CCW false
#define CW true

STEPPER_STATE stepper_state = A1_xx;
volatile unsigned int continuous_speed = 1;
volatile bool continuous_run = false;
volatile unsigned char continuous_run_dir = CCW;

#define BUF_SIZE 50
static unsigned char buffer_mem[BUF_SIZE];
static CircularBuffer uartBuffer;
enum ByteSequence {IDLE, START, CMD, DATA1, DATA2, ESC};
volatile enum ByteSequence CurrentByte = IDLE;
volatile unsigned char poppedByte = 0x00;
volatile unsigned int combinedMessage = 0x0000;

typedef struct {
    volatile unsigned char start;   // start byte - I dont need to use this lowkey
    volatile unsigned char cmd;     // cmd
    volatile unsigned char byte1;   // Data Byte 1
    volatile unsigned char byte2;   // Data Byte 2
    volatile unsigned char esc;     // Bit 0: Byte 1 and Bit 1: Byte 2
} Packet;

Packet incomingPacket ={ .start = 0, .cmd = 0, .byte1 = 0, .byte2 = 0, .esc = 0};

void processMessagePacket(Packet *packet) {
    if (packet->esc & BIT1) {
        packet->byte1 = 0xFF;
    }
    if (packet->esc & BIT0) {
        packet->byte2 = 0xFF;
    }

    combinedMessage = ((packet->byte1 << 8) | packet->byte2);

    switch(packet->cmd) {
        // Continuous run CW
        case 0x03:
            continuous_run = true;
            continuous_run_dir = CW;
            continuous_speed = combinedMessage;
            break;
        // Continuous run CCW
        case 0x04:
            continuous_run = true;
            continuous_run_dir = CCW;
            continuous_speed = combinedMessage;
            break;
        case 0x05:
            continuous_run = false;
            // Zero duty cycle to start with
            STEPPER_A1 = 0;
            STEPPER_A2 = 0;
            STEPPER_B1 = 0;
            STEPPER_B2 = 0;
            break;
            
    }

    // Reset fields
    packet->cmd = 0;
    packet->byte1 = 0;
    packet->byte2 = 0;
    packet->esc = 0;
}

void main (void)
{
    // Stop watchdog timer
    WDTCTL = WDTPW | WDTHOLD;

    // Initialize circular Buffer
    cBuffer_init(&uartBuffer, buffer_mem, BUF_SIZE);

    CSCTL0 = 0xA500;                        // Write password to modify CS registers
    CSCTL1 = DCOFSEL0 + DCOFSEL1;           // DCO = 8 MHz
    CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1; // MCLK = DCO, ACLK = DCO, SMCLK = DCO
    CSCTL3 &= ~(BIT4 | BIT5 | BIT6);        // Clear relevant bits

    SetupStepperTimers();
    
    // Configure ports for UART
    P2SEL0 &= ~(BIT5 + BIT6);
    P2SEL1 |= BIT5 + BIT6;

    // Configure UART0
    UCA1CTLW0 |= UCSWRST;
    UCA1CTLW0 |= UCSSEL0;                    // Run the UART using ACLK
    UCA1MCTLW = UCOS16 + UCBRF0 + 0x4900;   // Baud rate = 9600 from an 8 MHz clock
    UCA1BRW = 52;
    UCA1CTLW0 &= ~UCSWRST;

    UCA1IE |= UCRXIE; // Enable UART receive interrupt
    _EINT();
    


    while(1){
        if(!Buffer_IsEmpty(&uartBuffer)) {
            poppedByte = Buffer_Pop(&uartBuffer);

            switch(CurrentByte) {
                case IDLE:
                    if (poppedByte == 0xFF) {
                        CurrentByte = CMD;
                    }
                    break;

                case CMD:
                    incomingPacket.cmd = poppedByte; 
                    if (incomingPacket.cmd == 0x01) {
                        // CounterClockwise Step
                        continuous_run = false;
                        IncrementHalfStep(&stepper_state, CCW);
                        CurrentByte = IDLE;
                    }
                    else if (incomingPacket.cmd == 0x02) {
                        // Clockwise Step
                        continuous_run = false;
                        IncrementHalfStep(&stepper_state, CW);
                        CurrentByte = IDLE;
                    }
                    else {
                        CurrentByte = DATA1;
                    }
                    break;

                case DATA1:
                    incomingPacket.byte1 = poppedByte;
                    CurrentByte = DATA2;
                    break;

                case DATA2:
                    incomingPacket.byte2 = poppedByte;
                    processMessagePacket(&incomingPacket);
                    CurrentByte = IDLE; // skip escape byte
                    break;

                //No escape byte in packet...
                case ESC:
                    incomingPacket.esc = poppedByte;
                    processMessagePacket(&incomingPacket);
                    CurrentByte = IDLE;
                    break;
            }

            // Clear poppedByte so it won’t be reused accidentally
            poppedByte = 0;
        }

        if (continuous_run){
            DelayHectoMicros_8Mhz(SpeedToDelay_HectoMicros(continuous_speed));
            IncrementHalfStep(&stepper_state, continuous_run_dir);
        }

    }

}

#pragma vector = USCI_A1_VECTOR 
__interrupt void USCI_A1_ISR(void) {
    if (UCA1IFG & UCRXIFG) {
        // on recv
        unsigned char RxByte = 0;
        RxByte = UCA1RXBUF; // Get the new byte from the Rx buffer
        Buffer_Push(&uartBuffer, RxByte);
        UCA1IFG &= ~UCRXIFG;
        UCA1TXBUF = RxByte;

    } else if (UCA1IFG & UCTXIFG) {
        // on tx complete
        // if (queue_has_data(&UART_TX_QUEUE)) {
        // UCA0TXBUF = dequeue(&UART_TX_QUEUE);
        // }
        UCA1IFG &= ~UCTXIFG;
    }
}


