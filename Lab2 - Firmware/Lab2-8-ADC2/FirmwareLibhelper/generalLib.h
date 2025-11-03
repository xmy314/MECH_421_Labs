#ifndef FIRMWARE_UTILS_H
#define FIRMWARE_UTILS_H

#include <MSP430.h>

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
void Switch_Init_P4(void);
void Switch_EnableInterrupts(void);

//
// ─── UART COMMUNICATION ───────────────────────────────────────────────────────
//
void UART_Init_9600(void);
void UART_SendByte(unsigned char byte);
void UART_SendPacket(unsigned char* data, unsigned char length);
void UART_CommandHandler(unsigned char command);
void UART_EchoByte(unsigned char byte);

//
// ─── TIMER CONFIGURATION ──────────────────────────────────────────────────────
//
void TimerB_Init_UpMode(unsigned int period);
void TimerB_SetupPWM(unsigned char channel, unsigned int period, unsigned int duty);
void TimerA_Init_Capture(void);
unsigned int TimerA_GetPulseWidth(void);

//
// ─── ADC10_B SAMPLING ─────────────────────────────────────────────────────────
//
void ADC10_Init(void);
void ADC10_Sample(unsigned char channel);
unsigned char ADC10_GetByte(void);
void ADC10_SampleAccelerometer(unsigned char* x, unsigned char* y, unsigned char* z);
unsigned char ADC10_SampleNTC(void);

//
// ─── CIRCULAR BUFFER ──────────────────────────────────────────────────────────
//
void Buffer_Init(void);
void Buffer_Push(unsigned char byte);
unsigned char Buffer_Pop(void);
unsigned char Buffer_IsFull(void);   // returns 1 if full, 0 if not
unsigned char Buffer_IsEmpty(void);  // returns 1 if empty, 0 if not
void Buffer_HandleCarriageReturn(void);

//
// ─── PACKET PROCESSING ────────────────────────────────────────────────────────
//
unsigned char Packet_Available(void);
void Packet_Extract(unsigned char* cmd, unsigned int* value);
void Packet_ApplyEscape(unsigned char* data, unsigned char escape);
void Packet_ExecuteCommand(unsigned char cmd, unsigned int value);

#endif // FIRMWARE_UTILS_H
