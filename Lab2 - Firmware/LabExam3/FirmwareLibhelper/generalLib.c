#include "generalLib.h"
#include "MSP430.h"


// Bool Definitions
#define true 1
#define false 0

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
    switch(div) {
        case 1:  CSCTL3 = DIVS__1; break;
        case 2:  CSCTL3 = DIVS__2; break;
        case 4:  CSCTL3 = DIVS__4; break;
        case 8:  CSCTL3 = DIVS__8; break;
        case 16: CSCTL3 = DIVS__16; break;
        case 32: CSCTL3 = DIVS__32; break;
        default: CSCTL3 = DIVS__1; break; // safe fallback
    }
}

void Clock_Output_SMCLK(void){
    //
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

void BoolToLED(unsigned char value, unsigned char mask)
{
    if (value == 1) { LED_TurnOn(mask);}
    else {LED_TurnOff(mask);}
}

void LED_Thermometer(unsigned char level)
{
    return;
}

//
// ─── SWITCHES AND INTERRUPTS ──────────────────────────────────────────────────
//
void Switch_Init_P4(unsigned char selectionMask){
    // Make sure only BIT0 and BIT1 are passed in
    selectionMask &= BIT0 | BIT1;

    // S1 and S2 are connected to P4.0 and P4.1         (S) pg. 17

    // Configure P4.0 and P4.1 as a digital input       (M) pg. 83 and 84
	P4DIR &=  ~(selectionMask);
    P4SEL1 &= ~(selectionMask);
    P4SEL0 &= ~(selectionMask);

    // (S) pg. 17: see the switches bridge to GND, so we need to pullup.
    P4OUT |= (selectionMask);   // Pullup               (L) pg. 314
    P4REN |= (selectionMask);   // Enable resistors     (L) pg. 315
    
}

void Switch_EnableInterrupts(unsigned char selectionMask){
    // Interrupt from a rising edge (user lets go of the button)
    P4IES &= ~(selectionMask); // Rising edge detection (L) pg. 316
}

//
// ─── UART COMMUNICATION ───────────────────────────────────────────────────────
//
void UART_Init_9600_without_interrupt(void)
{
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
}

void UART_Enable_Receive_Interrupt(void){
    UCA0IE |= UCRXIE; // Enable UART receive interrupt
}

void UART_transmitByte(unsigned char byte){
    while(!(UCA0IFG & UCTXIFG));
        UCA0TXBUF = byte;
}

void UART_SendPacket(unsigned char* data, unsigned char length){
    unsigned int i;

    for (i = 0; i < length; i++) {
        UART_transmitByte(data[i]);
    }
}

void UART_CommandHandler(unsigned char command);
void UART_EchoByte(unsigned char byte);

//
// ─── TIMER CONFIGURATION ──────────────────────────────────────────────────────
//
void TimerB0_Init_UpMode_125kHz(unsigned int upCountTarget){
    TB0CTL |= TBCLR; // Clear reset 
    TB0CTL |= TBSSEL_2; // set SMCLK as source
    TB0CTL |= MC_1; // MC_1 sets up mode MC=01b
    TB0CCTL0 |= CCIE; // enable interrupt; No divider needed
    TB0CCR0 = upCountTarget; // period of timer B: 1MHz/100Hz = 10000 - Timer will interrupt everytime it resets
}

void TimerB1_Init_UpMode_125kHz(unsigned int upCountTarget){
    // Setup Timer B in the "up count" mode
    TB1CTL |= TBCLR;            // Clear Timer B            (L) pg.372
    TB1CTL |= (BIT4);           // Up mode                  (L) pg. 372
    TB1CTL |= TBSSEL__SMCLK;    // Clock source select      (L) pg. 372
    TB1CTL |= (BIT7 | BIT6);    // 1/8 divider (125 kHz)    (L) pg. 372
    TB1CCR0 = upCountTarget;    // What we count to         (L) pg. 377
    // 65535 = ~1.9 Hz
    // 249 = 496 Hz
    // 247 = 500 Hz
    // 245 = 504 Hz
    // 10  = ~12.5 kHz
}

void TimerB1_Update_CountTarget(unsigned int upCountTarget){
    TB1CCR0 = upCountTarget;
}

void TimerB1_SetupPWM(unsigned char channel, unsigned int dutyCycleCounter)
{
    if (channel == 1)
    {
        TB1CCTL1 = OUTMOD_7;        // Reset/Set mode           (L) pg. 365, 366, and 375
        TB1CCR1 = dutyCycleCounter;

        // Output TB1.1 on P3.4         (M) pg. 81
        P3DIR  |=  (BIT4);
        P3SEL1 &= ~(BIT4);
        P3SEL0 |=  (BIT4);
    }
    else
    {
        TB1CCTL2 = OUTMOD_7;        // Reset/Set mode           (L) pg. 365, 366, and 375
        TB1CCR2 = dutyCycleCounter;

        // Output TB1.2 on P3.5         (M) pg. 81
        P3DIR  |=  (BIT5);
        P3SEL1 &= ~(BIT5);
        P3SEL0 |=  (BIT5);
    }
}

void TimerA_Init_Capture(unsigned int EdgeType){
    // Set up Timer A0
    TA0CTL |= TACLR; // Clear Timer A0
    TA0CTL |= MC_2; // Set up in Continuous Mode
    TA0CTL |= TASSEL__SMCLK; // Assign SMCLK to Timer

    // Capture Register set
    TA0CCTL1  |= EdgeType; // Capture rising edge
    TA0CCTL1  |= SCS; // Manual Recommends synchronize, async creates race condition
    TA0CCTL1  |= CAP; // Capture Mode on
    TA0CCTL1  |= CCIE; // Enable Interrupt 
    TA0CCTL1  |= CCIS_0; // Selecting default input pin CCIxA P1.0
}

unsigned int TimerA_GetPulseWidth(void){
    static unsigned int risingEdgeValue = 0;
    static unsigned int fallingEdgeValue = 0;
    static unsigned int lastWasRising = 0;
    unsigned int pulseWidth = 0;
    unsigned int captured = TA0CCR1;

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

    return pulseWidth;
}

//
// ─── ADC10_B SAMPLING ─────────────────────────────────────────────────────────
//
void ADC10_TurnOnAccelerometer(void){
    P2DIR |= BIT7;
    P2SEL1 &= ~BIT7;
    P2SEL0 &= ~BIT7;
    P2OUT  |=  BIT7;            // P2.7 output high

}

void ADC10_Init(void){
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

}

unsigned char ADC10_Sample(unsigned char channel){
    ADC10MCTL0 = 0;
    ADC10CTL0 &= ~ADC10ENC;
    ADC10MCTL0 = channel;
    ADC10CTL0 |= ADC10ENC | ADC10SC;
    while (!(ADC10IFG & BIT0));
    return ADC10MEM0;
}

unsigned char ADC10_GetByte(unsigned char channel) {
    return (unsigned char)(ADC10_Sample(channel) >> 2);
}

unsigned char ADC10_SampleNTC(void){
    // Configure ADC A4
    P1SEL0 |= BIT4;
    P1SEL1 |= BIT4;
    return ADC10_Sample(4);

}

//
// ─── CIRCULAR BUFFER ──────────────────────────────────────────────────────────
//
void cBuffer_init(CircularBuffer *cb, unsigned char *buf, unsigned int size)
{
    cb->buffer = buf;
    cb->size   = size;
    cb->head   = 0;
    cb->tail   = 0;
    cb->full   = 0;   // use 0/1 instead of bool
}

unsigned char Buffer_IsFull(CircularBuffer *cb)
{
    return (cb->full ? 1 : 0);
}

unsigned char Buffer_IsEmpty(CircularBuffer *cb)
{
    return ((cb->head == cb->tail) && (cb->full == 0)) ? 1 : 0;
}

void Buffer_Push(CircularBuffer *cb, unsigned char byte)
{
    if (Buffer_IsFull(cb)) {
        // Buffer overrun: trying to push when full
        UART_SendPacket((unsigned char*)"ERR: Buffer Overrun\r\n", 21);
        return; // discard or handle differently
    }

    cb->buffer[cb->head] = byte;
    cb->head = (cb->head + 1) % cb->size;

    cb->full = (cb->head == cb->tail) ? 1 : 0;
}

unsigned char Buffer_Pop(CircularBuffer *cb)
{
    if (Buffer_IsEmpty(cb)) {
        // Buffer underrun: trying to pop when empty
        UART_SendPacket((unsigned char*)"ERR: Buffer Underrun\r\n", 22);
        return 0; // return dummy value
    }

    unsigned char val = cb->buffer[cb->tail];
    cb->tail = (cb->tail + 1) % cb->size;

    cb->full = 0;
    return val;
}

void Buffer_HandleCarriageReturn(CircularBuffer *cb)
{
    UART_transmitByte(Buffer_Pop(cb));

}

//
// ─── PACKET PROCESSING ────────────────────────────────────────────────────────
//
unsigned char Packet_Available(void);
void Packet_Extract(unsigned char* cmd, unsigned int* value);
void Packet_ApplyEscape(unsigned char* data, unsigned char escape);
void Packet_ExecuteCommand(unsigned char cmd, unsigned int value);

//
// ─── Manual Delay ────────────────────────────────────────────────────────
//
void DelayMillis_8Mhz(unsigned int millis)
{
    // Assumes 8Mhz clock cycle
    while(millis-- > 0)
    {
        __delay_cycles(8000);
    }
}

void DelayMillis_1Mhz(unsigned int millis)
{
    // Assumes 1Mhz clock cycle
    while(millis-- > 0)
    {
        __delay_cycles(1000);
    }
}

void DelaySeconds_8Mhz(unsigned int seconds)
{
    // Assumes 8Mhz clock cycle
    while(seconds-- > 0)
    {
        __delay_cycles(8000000);
    }
}

void DelaySeconds_1Mhz(unsigned int seconds)
{
    // Assumes 1Mhz clock cycle
    while(seconds-- > 0)
    {
        __delay_cycles(1000000);
    }
}
