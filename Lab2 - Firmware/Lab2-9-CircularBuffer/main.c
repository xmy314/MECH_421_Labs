#include "MSP430.h"
#include "../FirmwareLibhelper/generalLib.h"

#define BUF_SIZE 50
static unsigned char buffer_mem[BUF_SIZE];
static CircularBuffer uartBuffer;

void main (void)
{
    // Stop watchdog timer
    WDTCTL = WDTPW | WDTHOLD;

    // Initialize circular Buffer
    cBuffer_init(&uartBuffer, buffer_mem, BUF_SIZE);

    Clock_Init_DCO_8MHz();
    Clock_Set_SMCLK_Divider(8);

    // UART set up
    UART_Init_9600_without_interrupt(); // This links it to SMCLK
    UART_Enable_Receive_Interrupt(); // Enable UART receive interrupt

    __enable_interrupt(); // Enable global interrupts

    while(1);
}

// ISR
# pragma vector=USCI_A0_VECTOR
__interrupt void uart_ISR(void){
    if (UCA0IV == USCI_UART_UCRXIFG){ // Receive buffer is triggered
        // read Receive buffer
        unsigned char RxByte = UCA0RXBUF;
        
        if (RxByte == '\r'){
            Buffer_HandleCarriageReturn(&uartBuffer);
        }
        else{
            // Push received byte to buffer
            Buffer_Push(&uartBuffer, RxByte);
        }

    }
}
