#include <msp430.h>
#include <stdint.h>

volatile unsigned int risingEdgeValue = 0;
volatile unsigned int fallingEdgeValue = 0;
volatile unsigned int pulseWidth = 0;
volatile unsigned int lastWasRising = 0;

void main (void)
{
    // Convert tick number to frequency
    int const TICK_NUM = 248; //248 - 500 Hz 
    int const SQUARE_WAVEFREQ = TICK_NUM/2; // 50% duty cycle

    // Stop watchdog timer
    WDTCTL = WDTPW | WDTHOLD;

    //------ Exercise 5 ------
    // Set up SMCLK on DCO
    CSCTL0 = CSKEY; // Set default password to clock 
    CSCTL1 |= DCOFSEL_3; // Select lower frequency range from DCORSEL - 8MHz
    CSCTL2 |= SELS__DCOCLK; // Set SMCLK to DCO
    CSCTL3 |= DIVS__8; // Set the Div to 8 - 1MHz 

    // Timer B1 Set up clock - Compare Mode/ No Capture
    TB1CTL |= TBCLR; // Clear reset 
    TB1CTL |= (BIT4); // Set up up mode 
    TB1CTL |= TBSSEL__SMCLK; // Set the clock of the sub main
    TB1CTL |= (BIT6|BIT7); // input Divider
    TB1CCR0 |= TICK_NUM; // 250 ticks at every 8 microsec to reach max cycle time of 2 milliseconds (- 1) to account counting from 0

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

    // --- Exercise 6 -----
    P1DIR  &= ~BIT0;             // Set P1.0 to TA0.CCI1A function   
    P1SEL1 &= ~BIT0;
    P1SEL0 |=  BIT0;

    // Set up Timer A0
    TA0CTL |= TACLR; // Clear Timer A0
    TA0CTL |= MC_2; // Set up in Continuous Mode
    TA0CTL |= TASSEL__SMCLK; // Assign SMCLK to Timer

    // Capture Register set
    TA0CCTL1  |= CM_1; // Capture rising edge
    TA0CCTL1  |= SCS; // Manual Recommends synchronize, async creates race condition
    TA0CCTL1  |= CAP; // Capture Mode on
    TA0CCTL1  |= CCIE; // Enable Interrupt 
    TA0CCTL1  |= CCIS_0; // Selecting default input pin CCIxA P1.0

    _enable_interrupt();

    while(1){

        _NOP();
    }

}

#pragma vector = TIMER0_A1_VECTOR
__interrupt void TriggerTimer (void){
    uint16_t captured = TA0CCR1;
    if (TA0IV == TA0IV_TACCR1){
        // CCI gives current value of the pin (high or low)
        // This condition is for the level being high meaning that I just detected a rising edge
        if((TA0CCTL1 & CCI) && (lastWasRising == 0)){
            lastWasRising = 1;
            risingEdgeValue = captured; // Store value from the value copied on capture
            TA0CCTL1  |= CM_2; // switch to triggering on falling edge

        } 
        else if((lastWasRising == 1)){
            lastWasRising = 0;
            // Once falling edge is detected and stored
            fallingEdgeValue = captured;

            // Calculate pulse width
            if (fallingEdgeValue >= risingEdgeValue){
                pulseWidth = fallingEdgeValue - risingEdgeValue;
            }

            TA0CCTL1  |= CM_1; // switch to triggering on rising edge again
        }
    }
    _NOP();
    TA0CCTL1 &= ~CCIFG;
}

// it seems to skip some high wave forms... ^^
