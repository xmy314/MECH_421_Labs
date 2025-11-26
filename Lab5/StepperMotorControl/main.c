#include "msp430.h"
#include "stepperLib/stepper.h"
#include "FirmwareLibhelper/generalLib.h"

#define CCW false
#define CW true

STEPPER_STATE stepper_state = A1_xx;
volatile unsigned int continuous_speed = 1;
volatile unsigned char continuous_run = false;
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

    Clock_Init_DCO_8MHz(); // Sets up SMCLK to 8MHz

    SetupStepperTimers();

    UART_Init_115200_without_interrupt();
    UART_Enable_Receive_Interrupt();
    __enable_interrupt();

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
                        IncrementHalfStep(&stepper_state, false);
                        CurrentByte = IDLE;
                    }
                    else if (incomingPacket.cmd == 0x02) {
                        // Clockwise Step
                        continuous_run = false;
                        IncrementHalfStep(&stepper_state, true);
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
                    CurrentByte = ESC;
                    break;

                case ESC:
                    incomingPacket.esc = poppedByte;
                    processMessagePacket(&incomingPacket);
                    CurrentByte = IDLE;
                    break;
            }

            // Clear poppedByte so it won’t be reused accidentally
            poppedByte = 0;
        }

        if (continuous_run == 1){
            DelayHectoMicros_8Mhz(SpeedToDelay_HectoMicros(continuous_speed));
            IncrementHalfStep(&stepper_state, continuous_run_dir);
        }

    }

}

#pragma vector = USCI_A1_VECTOR 
__interrupt void USCI_A1_ISR(void) {
    switch(__even_in_range(UCA1IV,18)) {
        case 0x00:
            // Vector 0: No interrupts
            break;
        case 0x02:  // Vector 2: UCRXIFG
        {   // read Receive buffer
            unsigned char RxByte = UCA0RXBUF;
            
            // Push received byte to buffer
            Buffer_Push(&uartBuffer, RxByte);
            break;
        }
        case 0x04: // Vector 4: UCTXIFG
            break;
        case 0x06: // Vector 6: UCSTTIFG
            break;
        case 0x08: // Vector 8: UCTXCPTIFG
            break;
        default: 
            break;
    }
}
