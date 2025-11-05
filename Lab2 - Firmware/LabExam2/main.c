#include "MSP430.h"
#include "../FirmwareLibhelper/generalLib.h"

volatile unsigned char xAccel = 'X';

void ADC10Sample(int channel);

void main (void)
{
    WDTCTL = WDTPW | WDTHOLD;

    Clock_Init_DCO_8MHz();
    Clock_Set_SMCLK_Divider(8); // Sets up to 1Mhz
    LED_Init(ALL_LEDs);
    LED_TurnOff(ALL_LEDs);

    UART_Init_9600_without_interrupt();
    ADC10_TurnOnAccelerometer();

    ADC10_Init();
    // ADC10IE |= ADC10IE0;

    // ADC10_GetByte(12);

    TimerB1_Init_UpMode_125kHz(610);
    TB1CCTL0 |= CCIE; 

    __enable_interrupt();

    while(1);

}

#pragma vector = TIMER1_B0_VECTOR
__interrupt void TIMER_B1_ISR(void)
{   
    unsigned char result = 'E';

    LED_Toggle(LED5); // Reached this ISR
    ADC10Sample(12);

    result = ADC10MEM0 >> 2;

    while(!(UCA0IFG & UCTXIFG));
    UCA0TXBUF = result;

    TB0CCTL0 &= ~CCIFG;
}

void ADC10Sample(int channel){
    ADC10MCTL0 = 0;
    ADC10CTL0 &= ~ADC10ENC;
    ADC10MCTL0 = channel;
    ADC10CTL0 |= ADC10ENC | ADC10SC;
    while (!(ADC10IFG & BIT0));

}

