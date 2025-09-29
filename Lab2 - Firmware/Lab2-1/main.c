#include "msp430.h"

// #define WDTPW     (0x5A00)  /* Watchdog Timer Password */
// #define WDTHOLD   (0x0080)  /* Watchdog Timer Hold */

void main (void)
{
    WDTCTL = WDTPW | WDTHOLD;   // Stop watchdog timer

    CSCTL0 = CSKEY; // Set default password to clock 

    CSCTL1 |= DCOFSEL_3; // Select lower frequency range from DCORSEL

    CSCTL2 |= SELS__DCOCLK; // Set SMCLK to DCO

    CSCTL3 |= DIVS__32; // Set the Div to 32 - 250kHz

    // Set up P3.4 to output tertiary function SMCLK
    P3DIR |= BIT4;
    P3SEL0 |= BIT4;
    P3SEL1 |= BIT4;

    // Super loop (optional here, but good practice)
    while (1) {
        _NOP();       // CPU idle, clock keeps running on P3.4
    }

}
