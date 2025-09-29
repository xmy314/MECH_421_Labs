#include "msp430.h"

void main (void)
{   
    WDTCTL = WDTPW | WDTHOLD;	// stop watchdog timer

    // Set up the clock 
    CSCTL0 = CSKEY; // Set default password to clock 
    CSCTL1 |= DCOFSEL_3; // Select lower frequency range from DCORSEL
    CSCTL2 |= SELS__DCOCLK; // Set SMCLK to DCO
    CSCTL3 |= DIVS__1; // Set the Div to 1
    
    // Configure pins to output/ LEDs
    PJDIR |= BIT0 | BIT1 | BIT2 | BIT3;
    PJSEL0 &=  ~(BIT0 | BIT1 | BIT2 | BIT3);
    PJSEL1 &= ~(BIT0 | BIT1 | BIT2 | BIT3);

    P3DIR |= BIT4 | BIT5 | BIT6 | BIT7;
    P3SEL0 &= ~(BIT4 | BIT5 | BIT6 | BIT7);
    P3SEL1 &= ~(BIT4 | BIT5 | BIT6 | BIT7);

    PJOUT |= (BIT0 | BIT3);
    P3OUT |= (BIT6 | BIT7);

    while(1)
    { 

        PJOUT ^= (BIT1|BIT2);
        P3OUT ^= (BIT4|BIT5);

        _delay_cycles(1000000);

    }
}
