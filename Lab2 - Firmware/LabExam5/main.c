#include "MSP430.h"
#include "../FirmwareLibhelper/generalLib.h"

typedef enum PACKET_PART {
    START_BYTE,
    COM_BYTE,
    DATA_BYTE,
} PACKET_PART;

typedef struct {
    volatile unsigned char comm;
    volatile unsigned char data;
} MessagePacket;

MessagePacket IncomingPacket = { .comm = 0, .data = 0};
volatile PACKET_PART ExpectedRead = START_BYTE;


volatile unsigned int maxCycle = 100;
volatile unsigned int currentCycle = 0;
volatile signed char upCount = 1;
volatile signed char period = 10;

volatile signed char sawtooth = 1;

void ProcessCompletePacket() {
    //TurnOnLED(LED8);
    period = IncomingPacket.data;
    maxCycle = 100;

    if (IncomingPacket.comm == 4)
    {
        // Orb goes dark
        maxCycle = 0;
        currentCycle = 0;
        upCount = 1;
        TimerB1_SetupPWM(1, currentCycle);
    } else if (IncomingPacket.comm == 2)
    {
        // Orb turns bright to dark
        sawtooth = 0;
        currentCycle = maxCycle;
        upCount = -1;
        TimerB1_SetupPWM(1, currentCycle);
    } else if (IncomingPacket.comm == 1)
    {
        // Orb turns dark to bright
        sawtooth = 1;
        currentCycle = 0;
        upCount = 1;
        TimerB1_SetupPWM(1, currentCycle);
    }
}

void ReceiveStateMachine(volatile unsigned char RxByte) {

    if (RxByte == 255)
    {
        ExpectedRead = COM_BYTE;
        return;
    }

    switch(ExpectedRead) {
    case START_BYTE:
        break;
    case COM_BYTE:
        IncomingPacket.comm = RxByte;
        break;
    case DATA_BYTE:
        IncomingPacket.data = RxByte;
        ProcessCompletePacket();
        break;
    default:
        break;
    }

    // Increment next read
    if (ExpectedRead >= DATA_BYTE)
        ExpectedRead = START_BYTE;
    else
        ExpectedRead++;
}

void main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    Clock_Init_DCO_8MHz();
    LED_Init(ALL_LEDs);
    LED_TurnOff(ALL_LEDs);

    TimerB1_Init_UpMode_125kHz(100);
    TimerB1_SetupPWM(1, 0);         // 50% duty cycle, P3.4 output

    UART_Init_9600_without_interrupt();
    UCA0IE |= UCRXIE;           // Enable RX interrupt
    __enable_interrupt();       // Enable global interrupts

    while(1)
        {
            int i = period;                  // reset counter each outer loop
            while(i-- > 0) {
                __delay_cycles(8000);     // 1 ms delay at 8 MHz
            }

            if (maxCycle != 0)
            {

                if (sawtooth > 0)
                {
                    upCount = 1;
                    if (currentCycle == maxCycle)
                    {
                        currentCycle = 0;
                    }

                } else
                {
                    upCount = -1;
                    if (currentCycle == 0)
                    {
                        currentCycle = maxCycle;
                    }

                }

                currentCycle += 2*upCount;
                TimerB1_SetupPWM(1, currentCycle);
            }
        }

}

#pragma vector = USCI_A0_VECTOR
__interrupt void uart_ISR(void) {
    if (UCA0IV == USCI_UART_UCRXIFG)    // Receive buffer full. (L) pg. 504
    {
        volatile unsigned char RxByte = UCA0RXBUF; // Read from the receive buffer

        ReceiveStateMachine(RxByte);

        return;

    }
    else if (UCA0IV == USCI_UART_UCTXIFG || UCA0IV == USCI_UART_UCTXCPTIFG)     // Transmit buffer empty OR Transmit complete. (L) pg. 504
    {
        LED_TurnOn(LED7);

        return;
    }
    else if (UCA0IV == USCI_UART_UCSTTIFG)  // Start bit received. (L) pg. 504
    {
        return;
    }
}
