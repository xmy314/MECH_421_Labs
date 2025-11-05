#include "MSP430.h"
#include "../FirmwareLibhelper/generalLib.h"

volatile unsigned char previousValues[16];
volatile unsigned int head = 0;
volatile unsigned int size = 0;

void main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    Clock_Init_DCO_8MHz();
    Clock_Set_SMCLK_Divider(8); // Sets up to 1Mhz
    LED_Init(ALL_LEDs);
    LED_TurnOff(ALL_LEDs);

    ADC10_TurnOnAccelerometer();
    ADC10_Init();
    ADC10IE |= ADC10IE0;        // Enable interrupt when ADC done   (L) pg. 458

    // Need ADC10ENC = 0 so we can change channel           (L) pg. 455
    ADC10CTL0 &= ~ADC10ENC; // Disable conversion           (L) pg. 450

    // Clear the old analog channel selection               (L) pg. 455
    ADC10MCTL0 &= ADC10INCH_0;
    
    // Feed and start the ADC
    ADC10MCTL0 |= 12;  // ADC input ch             (L) pg. 455
    ADC10CTL0 |= ADC10ENC;  // Enable ADC conversion    (L) pg. 450
    ADC10CTL0 |= ADC10SC;   // Start conversion         (L) pg. 450
    // ADC10_Sample(12); // Start converting ch A12 (x)

    // Set up a timer interrupt to trigger an interrupt every 10 ms (100Hz)
    // I changed to every 10 ms and just transmit one part of the data packet at at time
    // Exercise instructions say every 40 ms and send all 4 parts of the packet
    TimerB1_Init_UpMode_125kHz(1250); // 125000 / x = 100
    TimerB1_SetupPWM(1, 312);       // 25% P3.4
    TB1CCTL0 |= CCIE;           // Enable interrupt                (L) pg. 375
    __enable_interrupt();       // Enable global interrupts

    while(1)
    {
        int i = 100;                  // reset counter each outer loop
        while(i-- > 0) {
            __delay_cycles(8000);     // 1 ms delay at 8 MHz
        }

        // Heart beat to display general program progression
        // If this stops, you are stuck in an interrupt
        LED_Toggle(LED1);
    }

}

#pragma vector = TIMER1_B0_VECTOR
__interrupt void TIMER_B1_ISR(void)
{
    volatile unsigned int total = 0;
    volatile unsigned int i = 0;

    //ToggleLED(LED2); // Reached this ISR

    // Start reading the X channel
    // Need ADC10ENC = 0 so we can change channel           (L) pg. 455
    ADC10CTL0 &= ~ADC10ENC; // Disable conversion           (L) pg. 450

    // Clear the old analog channel selection               (L) pg. 455
    ADC10MCTL0 &= ADC10INCH_0;
    
    // Feed and start the ADC
    ADC10MCTL0 |= 12;  // ADC input ch             (L) pg. 455
    ADC10CTL0 |= ADC10ENC;  // Enable ADC conversion    (L) pg. 450
    ADC10CTL0 |= ADC10SC;   // Start conversion         (L) pg. 450

    // If we have enough values, average and display them

    if (size >= 16)
    {

        //TurnOnLED(LED4);
        for (i = 0; i < 16; i++)
        {
            total += previousValues[i];
        }

        total = total >> 4; // divide by 16
        if (total >= 125)
        {
            total -= 125;
        } else {
            total = 0;
        }

        total = total * 48; // multiply by 48

        TimerB1_SetupPWM(1, total);
    }
}

// When the ADC has finished converting, save the value and begin the next one
#pragma vector = ADC10_VECTOR
__interrupt void ADC_ISR(void)
{
    //ToggleLED(LED3); // Reached this ISR
    unsigned char result = ADC10MEM0 >> 2;  // Read and shift 10-bit result to 8 bits

    previousValues[head] = result;

    // Count
    if (size < 16) {
        size++;
    }

    // Increment head with wraparound
    head = (head + 1) % 16;
}
