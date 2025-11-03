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
