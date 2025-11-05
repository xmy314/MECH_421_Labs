#include "MSP430.h"
#include "../FirmwareLibhelper/generalLib.h"

void main (void)
{
    // Stop watchdog timer
    WDTCTL = WDTPW | WDTHOLD;

    // Set up SMCLK on DCO
    CSCTL0 = CSKEY; // Set default password to clock 
    CSCTL1 |= DCOFSEL_3; // Select lower frequency range from DCORSEL - 8MHz
    CSCTL2 |= SELS__DCOCLK; // Set SMCLK to DCO
    CSCTL3 |= DIVS__8; // Set the Div to 8 - 1MHz 

    // Configure pins to output/ LEDs
    PJDIR |= BIT0|BIT1;
    PJSEL0 &= ~(BIT0|BIT1);
    PJSEL1 &= ~(BIT0|BIT1);
    PJOUT &= ~(BIT0);

    // // UART set up
    // UCA0CTLW0 |= UCSWRST; // Hold UART state machine in reset state
    // UCA0CTLW0 |= UCSSEL__SMCLK; // Link SMCLK to UART
    // UCA0CTLW0 &= ~(BIT9|BITA); // Make sure it's UART Mode
    // // Set Baud rate pg. 490
    // UCA0BRW = 6; // Prescaler
    // UCA0MCTLW = 0x2081; // Setting up 9600 baud rate
    // UCA0CTLW0 &= ~UCPEN; // Disable Parity
    // UCA0CTLW0 &= ~UC7BIT; // Enable 8 bit data stream
    // UCA0CTLW0 &= ~UCSPB; // 1 stop bit

    // // Set up P2.0 and P2.1
    // P2DIR |= (BIT0|BIT1);
    // // Set up the pins to be Tx and Rx: P2.0 transmit, P2.1 receives
    // P2SEL0 &= ~(BIT0|BIT1); 
    // P2SEL1 |= (BIT0|BIT1);

    // UCA0CTLW0 &= ~UCSWRST; // Start UART
    // UCA0IE |= UCRXIE; // Enable UART receive interrupt

    UART_Init_9600_without_interrupt();
    UART_Enable_Receive_Interrupt();

    __enable_interrupt(); // Enable global interrupts

    while(1){

        PJOUT ^= BIT1;
        // transmit 'a' periodically
        _delay_cycles(500000);
        
        while(!(UCA0IFG & UCTXIFG));
        UCA0TXBUF = 'a';
        
    }
}

// ISR
# pragma vector=USCI_A0_VECTOR
__interrupt void uart_ISR(void){
    if (UCA0IV == USCI_UART_UCRXIFG){ // Receive buffer is triggered
        // read Receive buffer
        unsigned char RxByte = UCA0RXBUF;
        
        // Echo received data
        UART_transmitByte(RxByte);
        // while(!(UCA0IFG & UCTXIFG));
        // UCA0TXBUF = RxByte;
        
        // Send next byte data
        UART_transmitByte(RxByte + 1);
        // while(!(UCA0IFG & UCTXIFG));
        // UCA0TXBUF = RxByte + 1;

        if (RxByte == 'j'){
            PJOUT |= BIT0; // TUrn on LED1
        }

        if (RxByte == 'k'){
            PJOUT &= ~BIT0; // Turn Off LED1
        }
    }
}
