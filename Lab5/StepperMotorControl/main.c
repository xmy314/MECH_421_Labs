#include "msp430.h"
#include "stepperLib/stepper.h"
#include "FirmwareLibhelper/generalLib.h"

void main (void)
{
    // Stop watchdog timer
    WDTCTL = WDTPW | WDTHOLD;

    Clock_Init_DCO_8MHz(); // Sets up SMCLK to 8MHz

    UART_Init_115200_without_interrupt();
    UART_Enable_Receive_Interrupt();
    __enable_interrupt();

    while(1){

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
            unsigned char RxByte = UCA1RXBUF;
            
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
