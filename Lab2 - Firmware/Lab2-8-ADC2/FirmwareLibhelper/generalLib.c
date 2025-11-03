#include "generalLib.h"
#include "MSP430.h"

// Bool Definitions

#define true 1
#define false 0
typedef short bool;

// LED definitions

#define LED1 BIT0
#define LED2 BIT1
#define LED3 BIT2
#define LED4 BIT3
#define LED5 BIT4
#define LED6 BIT5
#define LED7 BIT6
#define LED8 BIT7
#define ALL_LEDs 255

// Switch Definition
#define SWITCH_1 BIT0
#define SWITCH_2 BIT1

void Clock_Init_DCO_8MHz(void){
    CSCTL0 = CSKEY; // Set default password to clock 
    CSCTL1 |= DCOFSEL_3; // Select lower frequency range from DCORSEL - 8MHz
    CSCTL2 |= SELS__DCOCLK; // Set SMCLK to DCO
    // No divider applied

}

void Clock_Set_SMCLK_Divider(unsigned char div){
    CSCTL3 |= DIVS__8; // Set the Div to 8 - 1MHz 
}

void Clock_Output_SMCLK(void){

}


// Initializes all LED
void LED_Init(unsigned char mask)
{
    // (S) page 17 to see the PINS to LEDs
    // PJ.0 = LED1, PJ.3 = LED4
    // P3.4 = LED5, P3.7 = LED8

    // Setup LED1 - LED4
    // Configure PJ.0, PJ.1, PJ.2, and PJ.3 as digital outputs
    // (M) page 86
    PJDIR |=   (mask & (BIT0 | BIT1 | BIT2 | BIT3));
    PJSEL1 &= ~(mask & (BIT0 | BIT1 | BIT2 | BIT3));
    PJSEL0 &= ~(mask & (BIT0 | BIT1 | BIT2 | BIT3));

	// Setup LED5 - LED8
    // Configure P3.4, P3.5, P3.6, and P3.7 as digital outputs
	// (M) page 81, 82
	P3DIR |=   (mask & (BIT4 | BIT5 | BIT6 | BIT7));
	P3SEL1 &= ~(mask & (BIT4 | BIT5 | BIT6 | BIT7));
	P3SEL0 &= ~(mask & (BIT4 | BIT5 | BIT6 | BIT7));
}

void LED_TurnOn(unsigned char mask)
{
    PJOUT |= (mask & (BIT0 | BIT1 | BIT2 | BIT3));
    P3OUT |= (mask & (BIT4 | BIT5 | BIT6 | BIT7));
}

void LED_TurnOff(unsigned char mask)
{
    PJOUT &= ~(mask & (BIT0 | BIT1 | BIT2 | BIT3));
    P3OUT &= ~(mask & (BIT4 | BIT5 | BIT6 | BIT7));
}

void LED_Toggle(unsigned char mask)
{
    PJOUT ^= (mask & (BIT0 | BIT1 | BIT2 | BIT3));
    P3OUT ^= (mask & (BIT4 | BIT5 | BIT6 | BIT7));
}

void BoolToLED(bool value, unsigned char mask)
{
    if (value) { LED_TurnOn(mask);}
    else {LED_TurnOff(mask);}
}

void LED_Thermometer(unsigned char level)
{
    return;
}

