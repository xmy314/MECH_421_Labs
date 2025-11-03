#include "MSP430.h"
#include "../FirmwareLibhelper/generalLib.h"

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
        case 0x01:
            TimerB1_SetupPWM(1, combinedMessage);
            break;
        case 0x02:
            LED_TurnOn(LED1);
            break;
        case 0x03:
            LED_TurnOff(LED1);
            break;
        case 0x04:
            TimerB1_Update_CountTarget(combinedMessage);
            
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

    Clock_Init_DCO_8MHz();
    Clock_Set_SMCLK_Divider(8);

    // Initialize LED
    LED_Init(LED1);

    // Set up Timer B
    TimerB1_Init_UpMode_125kHz(0xFFFF);
    TimerB1_SetupPWM(1,0xFFFF/2); // 50% duty cycle

    // UART set up
    UART_Init_9600_without_interrupt(); // This links it to SMCLK
    UART_Enable_Receive_Interrupt(); // Enable UART receive interrupt

    __enable_interrupt(); // Enable global interrupts

    while(1) {
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
                    if (incomingPacket.cmd == 0x02 || incomingPacket.cmd == 0x03) {
                        processMessagePacket(&incomingPacket);
                        CurrentByte = IDLE;
                    } else {
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
    }

}

 #pragma vector = USCI_A0_VECTOR 
 __interrupt void USCI_A0_ISR(void) {
    switch(__even_in_range(UCA0IV,18)) {
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
        default: break;
    }
 }
