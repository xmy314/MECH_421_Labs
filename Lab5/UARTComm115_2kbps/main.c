#include "msp430.h"
#include "FirmwareLibhelper/generalLib.h"

volatile unsigned char startTransmit = 'p';
volatile unsigned int check = 0;

void main (void)
{
    // Stop watchdog timer
    WDTCTL = WDTPW | WDTHOLD;

    Clock_Init_DCO_8MHz(); // Sets up SMCLK to 8MHz
    //Clock_Set_SMCLK_Divider(8);

    // UART set up
    UCA1CTLW0 |= UCSWRST; // Hold UART state machine in reset state
    UCA1CTLW0 |= UCSSEL__SMCLK; // Link SMCLK to UART
    UCA1CTLW0 &= ~(BIT9|BITA); // Make sure it's UART Mode
    // Set Baud rate pg. 490
    UCA1BRW   = 4;                     // Prescaler
    UCA1MCTLW = 0x5551; // UCBRSx=0x55, UCBRFx=5, UCOS16=1
    check = UCA1MCTLW;

    UCA1CTLW0 &= ~UCPEN; // Disable Parity
    UCA1CTLW0 &= ~UC7BIT; // Enable 8 bit data stream
    UCA1CTLW0 &= ~UCSPB; // 1 stop bit
    // Set up P2.0 and P2.1
    // Set up the pins to be Tx and Rx: P2.0 transmit, P2.1 receives
    P2SEL0 &= ~(BIT5|BIT6); 
    P2SEL1 |= (BIT5|BIT6);
    UCA1CTLW0 &= ~UCSWRST; // Start UART

    // UCA0IE |= UCRXIE; // Enable UART receive interrupt

    // __enable_interrupt();

    // Configure P1.4 and P1.5 as Timer_B0 outputs
    P1DIR  |= (BIT4 | BIT5);
    P1SEL0 |= (BIT4 | BIT5);
    P1SEL1 &= ~(BIT4 | BIT5);

    // Setup Timer_B0 in up mode
    TB0CTL = TBCLR;                       // Clear timer
    TB0CTL = TBSSEL__SMCLK | MC__UP;      // SMCLK source, Up mode

    TB0CCR0 = 1000;                       // PWM period (adjust for frequency)

    // CCR1 → P1.4 (AIN1)
    TB0CCTL1 = OUTMOD_7;                   // Reset/Set mode
    TB0CCR1  = 500;                        // 50% duty cycle

    // CCR2 → P1.5 (AIN2)
    TB0CCTL2 = OUTMOD_7;                   // Reset/Set mode
    TB0CCR2  = 250;                        // 25% duty cycle

    while(1){
        // if (startTransmit == 1){
        //     while(!(UCA0IFG & UCTXIFG));
        //         UCA0TXBUF = 0xFF;
        // }
        while(!(UCA0IFG & UCTXIFG));
            UCA1TXBUF = 0x55;
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
            unsigned char RxByte = UCA1RXBUF;
            if (RxByte == 'A' || RxByte == 'a'){
                startTransmit = 1;
            }
            else if (RxByte == 'Z' || RxByte == 'z'){
                startTransmit = 0;
            }
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
