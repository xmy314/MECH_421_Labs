#include "msp430.h"
#include "../FirmwareLibhelper/generalLib.h"

void main (void)
{   
    WDTCTL = WDTPW | WDTHOLD;	// stop watchdog timer

    Clock_Init_DCO_8MHz();
    LED_Init(ALL_LEDs);
    LED_TurnOn((LED1|LED4|LED7|LED8));
    LED_TurnOff((LED2|LED3|LED5|LED6));

    // // Configure pins to output/ LEDs
    // PJDIR |= BIT0 | BIT1 | BIT2 | BIT3;
    // PJSEL0 &=  ~(BIT0 | BIT1 | BIT2 | BIT3);
    // PJSEL1 &= ~(BIT0 | BIT1 | BIT2 | BIT3);

    // P3DIR |= BIT4 | BIT5 | BIT6 | BIT7;
    // P3SEL0 &= ~(BIT4 | BIT5 | BIT6 | BIT7);
    // P3SEL1 &= ~(BIT4 | BIT5 | BIT6 | BIT7);

    // PJOUT |= (BIT0 | BIT3);
    // P3OUT |= (BIT6 | BIT7);

    while(1)
    { 

        // PJOUT ^= (BIT1|BIT2);
        // P3OUT ^= (BIT4|BIT5);

        LED_Toggle((LED2|LED3|LED5|LED6));

        _delay_cycles(1000000);

    }
}
