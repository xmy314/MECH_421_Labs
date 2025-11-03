#include "msp430.h"
#include "../FirmwareLibhelper/generalLib.h"

volatile unsigned int currentTemp = 0;

#define ROOM_TEMP 167

void ADC10Sample(int channel);

void main (void)
{
    // Stop watchdog timer
    WDTCTL = WDTPW | WDTHOLD;

    // Set up SMCLK on DCO - Sampling at 1MHz
    CSCTL0 = CSKEY; // Set default password to clock 
    CSCTL1 |= DCOFSEL_3; // Select lower frequency range from DCORSEL - 8MHz
    CSCTL2 |= SELS__DCOCLK; // Set SMCLK to DCO
    CSCTL3 |= DIVS__8; // Set the Div to 8 - 1MHz

    // --------- SET UP LEDS------------//
    LED_Init(255); // Initialize all LEDs
    LED_TurnOff(255);
    LED_TurnOn(BIT0);

    // ------------ TIMER B -------------//
    // Timer TB0.0 enabled
    P2DIR |= BIT5;
    P2SEL0 |= BIT5;
    P2SEL1 &= ~BIT5;
    // Timer B - data rate of 100 Hz

    TB0CCR0 = 10000; // period of timer B: 1MHz/100Hz = 10000 - Timer will interrupt everytime it resets
    TB0CTL |= TBCLR; // Clear reset 
    TB0CTL |= TBSSEL_2; // set SMCLK as source
    TB0CTL |= MC_1; // MC_1 sets up mode MC=01b
    TB0CCTL0 |= CCIE; // enable interrupt; No divider needed

    // Turn on Accelerometer - Also powers the NTC
    P2DIR |= BIT7;
    P2SEL1 &= ~BIT7;
    P2SEL0 &= ~BIT7;
    P2OUT  |=  BIT7;            // P2.7 output high

    // ------------ UART --------------//
    // Set up UART for communication
    // UART set up
    UCA0CTLW0 |= UCSWRST; // Hold UART state machine in reset state
    UCA0CTLW0 |= UCSSEL__SMCLK; // Link SMCLK to UART
    UCA0CTLW0 &= ~(BIT9|BITA); // Make sure it's UART Mode
    // Set Baud rate pg. 490
    UCA0BRW = 6; // Prescaler
    UCA0MCTLW = 0x2081; // Setting up 9600 baud rate
    UCA0CTLW0 &= ~UCPEN; // Disable Parity
    UCA0CTLW0 &= ~UC7BIT; // Enable 8 bit data stream
    UCA0CTLW0 &= ~UCSPB; // 1 stop bit

    // Set up P2.0 and P2.1
    P2DIR |= (BIT0|BIT1);
    // Set up the pins to be Tx and Rx: P2.0 transmit, P2.1 receives
    P2SEL0 &= ~(BIT0|BIT1); 
    P2SEL1 |= (BIT0|BIT1);

    UCA0CTLW0 &= ~UCSWRST; // Start UART

    // ---------- ADC -----------//
    // Configure ADC A4
    P1SEL0 |= BIT4;
    P1SEL1 |= BIT4;

    // Set up ADC
    // --- Reference setup ---
    while (REFCTL0 & REFGENBUSY);     // Wait if reference generator is busy
    REFCTL0 |= REFVSEL_0;            // Select internal 1.5V reference
    REFCTL0 |= REFON;                // Turn on reference generator
    __delay_cycles(400);             // Allow reference to settle

    // --- ADC core setup ---
    ADC10CTL0 &= ~ADC10ENC;          // Disable ADC before config
    ADC10CTL0 |= ADC10ON;            // Turn on ADC
    ADC10CTL0 |= ADC10SHT_6;         // Sample-and-hold time = 128 ADC10CLK cycles

    ADC10CTL1 |= ADC10SHP            // Use sampling timer
            |  ADC10SSEL_3        // ADC10CLK = SMCLK (assumed 1MHz)
            |  ADC10CONSEQ_0;     // Single-channel, single-conversion

    ADC10CTL2 |= ADC10RES;           // 10-bit resolution
    ADC10MCTL0 |= ADC10SREF_1;       // Use internal 1.5V reference as V+

    while(1){

        int i;
        int refTemp = ROOM_TEMP;
        
        __delay_cycles(1000);
        ADC10Sample(4);
        currentTemp = (ADC10MEM0);

        while(!(UCA0IFG & UCTXIFG));
        UCA0TXBUF = currentTemp;

        for (i = 1; i < 8; i++)
        {
            if (currentTemp < refTemp)
            {
                LED_TurnOn(1 << i);
            } else {
                LED_TurnOff(1 << i);
            }
            refTemp -= 1;
        }
    }
}

void ADC10Sample(int channel){
    ADC10MCTL0 = 0;
    ADC10CTL0 &= ~ADC10ENC;
    ADC10MCTL0 = channel;
    ADC10CTL0 |= ADC10ENC | ADC10SC;
    while (!(ADC10IFG & BIT0));
}
