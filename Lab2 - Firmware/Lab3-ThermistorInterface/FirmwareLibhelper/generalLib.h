#ifndef GENERALLIB_H
#define GENERALLIB_H

#include <MSP430.h>
#include <stdbool.h>

// --- STRUCT FOR CIRCULAR BUFFER ------------------------------------------
typedef struct {
    unsigned char *buffer;   // pointer to buffer memory
    volatile unsigned int head;       // write index
    volatile unsigned int tail;       // read index
    unsigned int size;       // total buffer size
    volatile unsigned int full;       // 0 = not full, 1 = full
} CircularBuffer;

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

//
// ─── CLOCK CONFIGURATION ──────────────────────────────────────────────────────
//
void Clock_Init_DCO_8MHz(void);
void Clock_Set_SMCLK_Divider(unsigned char div);
void Clock_Output_SMCLK(void);

//
// ─── DIGITAL I/O AND LED CONTROL ──────────────────────────────────────────────
//
void LED_Init(unsigned char mask);
void LED_TurnOn(unsigned char mask);
void LED_TurnOff(unsigned char mask);
void LED_Blink(unsigned char mask);
void LED_Toggle(unsigned char mask);
//void LED_BoolToLED(bool value, unsigned char mask);
void LED_Thermometer(unsigned char level); // Not implemented yet

//
// ─── SWITCHES AND INTERRUPTS ──────────────────────────────────────────────────
//
void Switch_Init_P4(unsigned char selectionMask);
void Switch_EnableInterrupts(unsigned char selectionMask);

//
// ─── UART COMMUNICATION ───────────────────────────────────────────────────────
//
void UART_Init_9600_without_interrupt(void);
void UART_Enable_Receive_Interrupt(void);
void UART_transmitByte(unsigned char byte);
void UART_SendPacket(unsigned char* data, unsigned char length);
void UART_CommandHandler(unsigned char command);
void UART_EchoByte(unsigned char byte);

//
// ─── TIMER CONFIGURATION ──────────────────────────────────────────────────────
//
void TimerB1_Init_UpMode_125kHz(unsigned int upCountTarget);
void TimerB1_SetupPWM(unsigned char channel, unsigned int dutyCycleCounter);
void TimerB1_Update_CountTarget(unsigned int upCountTarget);
void TimerA_Init_Capture(unsigned int EdgeType);
unsigned int TimerA_GetPulseWidth(void);

//
// ─── ADC10_B SAMPLING ─────────────────────────────────────────────────────────
//
void ADC10_TurnOnAccelerometer(void);
void ADC10_Init(void);
unsigned char ADC10_Sample(unsigned char channel);
unsigned char ADC10_GetByte(void);
unsigned char ADC10_SampleNTC(void);

//
// ─── CIRCULAR BUFFER ──────────────────────────────────────────────────────────
//
void cBuffer_init(CircularBuffer *cb, unsigned char *buf, unsigned int size);
void Buffer_Push(CircularBuffer *cb, unsigned char byte);
unsigned char Buffer_Pop(CircularBuffer *cb);
unsigned char Buffer_IsFull(CircularBuffer *cb);   // returns 1 if full, 0 if not
unsigned char Buffer_IsEmpty(CircularBuffer *cb);  // returns 1 if empty, 0 if not
void Buffer_HandleCarriageReturn(CircularBuffer *cb);

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
void DelayMillis_8Mhz(unsigned int millis);
void DelayMillis_1Mhz(unsigned int millis);
void DelaySeconds_8Mhz(unsigned int seconds);
void DelaySeconds_1Mhz(unsigned int seconds);

#endif 
