#include "msp430.h"

void main (void)
{
    // Convert tick number to frequency
    int const TICK_NUM = 249; 
    int const SQUARE_WAVEFREQ = TICK_NUM/2;

    // Stop watchdog timer
    WDTCTL = WDTPW | WDTHOLD;

    // Set up SMCLK on DCO
    CSCTL0 = CSKEY; // Set default password to clock 
    CSCTL1 |= DCOFSEL_3; // Select lower frequency range from DCORSEL - 8MHz
    CSCTL2 |= SELS__DCOCLK; // Set SMCLK to DCO
    CSCTL3 |= DIVS__8; // Set the Div to 8 - 1MHz 

    // Set up clock - Compare Mode/ No Capture
    TB1CTL |= TBCLR; // Clear reset 
    TB1CTL |= (BIT4); // Set up up mode 
    TB1CTL |= TBSSEL__SMCLK; // Set the clock of the sub main
    TB1CTL |= (BIT6|BIT7); // input Divider
    TB1CCR0 |= TICK_NUM-1; // 250 ticks at every 8 microsec to reach max cycle time of 2 milliseconds (- 1) to account counting from 0

    // Create PWM and output on P3.4
    TB1CCTL1 = OUTMOD_7; // Reset/Set Mode - Timer resets after hitting target
    TB1CCR1 = SQUARE_WAVEFREQ;

    // Output TB1.1 on P3.4 
    P3DIR  |=  (BIT4);
    P3SEL1 &= ~(BIT4);
    P3SEL0 |=  (BIT4);

    // Create PWM and output on P3.4
    TB1CCTL2 = OUTMOD_7; // Reset/Set Mode - Timer resets after hitting target
    TB1CCR2 = SQUARE_WAVEFREQ/2;

    // Output TB1.1 on P3.5
    P3DIR  |=  (BIT5);
    P3SEL1 &= ~(BIT5);
    P3SEL0 |=  (BIT5);

    while(1){

        _NOP();
    }
}
