#include "MSP430.h"
#include "../FirmwareLibhelper/generalLib.h"

volatile unsigned short falling = 1;

volatile unsigned int startTime = 0;
volatile unsigned int endTime = 0;
volatile unsigned int pulseWidth = 0;

volatile unsigned int overflows = 0;

void main (void){
    WDTCTL = WDTPW | WDTHOLD;

    Clock_Init_DCO_8MHz();
    Clock_Set_SMCLK_Divider(8); // Sets up to 1Mhz
    LED_Init(ALL_LEDs);
    LED_TurnOff(ALL_LEDs);

    UART_Init_9600_without_interrupt();
    Switch_Init_P4((SWITCH_1|SWITCH_2));
    P4IES |= (SWITCH_1 | SWITCH_2); // Falling edge detection (L) pg. 316
    falling = 1;
    P4IE |=   (SWITCH_1);    // Enable switch interrupts     (L) pg. 316

    //Switch_EnableInterrupts((SWITCH_1|SWITCH_2));
    __enable_interrupt();       // Enable global interrupts

    // Timer for timing length
    TimerB1_Init_UpMode_125kHz(65534);

    while(1) {
        int i = 500;                  // reset counter each outer loop
        while(i-- > 0) {
            __delay_cycles(8000);     // 1 ms delay at 8 MHz
        }
        overflows++;                  // increments every ~524 ms
    }
}

// ISR to toggle LED7 and LED8 after receiving rising edges from S1 and S2 respectively
#pragma vector=PORT4_VECTOR
__interrupt void Port_4(void)
{
    LED_TurnOn(LED2);
    P4IFG &= ~BIT0;     // Clear interrupt flag for P4.0
    P4IFG &= ~BIT1;     // Clear interrupt flag for P4.1

    unsigned long i = 0;

    if (falling > 0) {
        LED_TurnOn(LED3);
        // Just got a falling edge (button pressed)
        P4IES &= ~(SWITCH_1 | SWITCH_2); // Rising edge detection (L) pg. 316
        falling = 0;

        TB1CTL |= TBCLR;            // Clear Timer B            (L) pg.372
        overflows = 0;

    } else {
        LED_TurnOn(LED4);
        // Just got a rising edge (button released)
        P4IES |= (SWITCH_1 | SWITCH_2); // Falling edge detection (L) pg. 316
        falling = 1;

        endTime = TB1R;

        volatile unsigned char BROADCAST = 0;

        for (i = 0; i < overflows; i++)
        {
            BROADCAST += 64;
        }

        for (i = 0; i < endTime; i += 1000)
        {
            BROADCAST += 1;
        }

        if (overflows >= 4)
        {
            BROADCAST = 255;
        }

        // Broadcast the number
        UART_transmitByte(BROADCAST);

    }

}
