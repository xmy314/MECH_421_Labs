#include "msp430.h"
#include "stepperLib/stepper.h"
#include "FirmwareLibhelper/generalLib.h"

#define CCW false
#define CW true

STEPPER_STATE stepper_state = A1_xx;
STEPPER_STATE stepper2_state = A1_xx;
volatile unsigned int halfstepCount = 0;
volatile unsigned int continuous_speed = 1;
volatile bool continuous_run = false;
volatile unsigned char continuous_run_dir = CCW;
volatile unsigned int currentX, currentY = 0;

#define BUF_SIZE 50
static unsigned char buffer_mem[BUF_SIZE];
static CircularBuffer uartBuffer;
enum ByteSequence {IDLE, START, XPOS, YPOS, SPEED};
volatile enum ByteSequence CurrentByte = IDLE;

void external_Stepper_driver_pinupdate(STEPPER_STATE *currentState){
    unsigned char mask = 0;

    switch (*currentState)
    {
        case A1_xx:
            mask = BIT0;                        // A1 only
            break;
        case A1_B1:
            mask = BIT0 | BIT2;                 // A1 + B1
            break;
        case xx_B1:
            mask = BIT2;                        // B1 only
            break;
        case A2_B1:
            mask = BIT2 | BIT1;                 // A2 + B1
            break;
        case A2_xx:
            mask = BIT1;                        // A2 only
            break;
        case A2_B2:
            mask = BIT1 | BIT3;                 // A2 + B2
            break;
        case xx_B2:
            mask = BIT3;                        // B2 only
            break;
        case A1_B2:
            mask = BIT0 | BIT3;                 // A1 + B2
            break;
    }

    PJOUT = mask;   // directly drive PJ.0–PJ.3
}

void IncrementHalfStep2(STEPPER_STATE *currentState, bool directionCW)
{
    // Clockwise
    if (directionCW)
    {
        if (*currentState == A1_B2)
            *currentState = A1_xx;
        else
            *currentState = (STEPPER_STATE)(*currentState + 1);
    }
    // Counterclockwise
    else
    {
        if (*currentState == A1_xx)
            *currentState = A1_B2;
        else
            *currentState = (STEPPER_STATE)(*currentState - 1);
    }

    external_Stepper_driver_pinupdate(currentState);
}

unsigned int convertPositionToHalfStepNum(unsigned char position){
    // 1mm = 10 half steps
    return 10*position;
}

unsigned int convertTranslationSpeedTodelay(unsigned int speedPercent){
    unsigned int maxDelay = SpeedToDelay_HectoMicros(1); // slowest, in µs
    unsigned int minDelay = SpeedToDelay_HectoMicros(420);  // fastest, in µs
    return maxDelay - ((speedPercent * (maxDelay - minDelay)) / 100);
}

void main (void)
{
    // Stop watchdog timer
    WDTCTL = WDTPW | WDTHOLD;

    // Initialize circular Buffer
    cBuffer_init(&uartBuffer, buffer_mem, BUF_SIZE);

    // Setup pins as output for external Motor Driver
    PJDIR |= (BIT0 + BIT1 + BIT2 + BIT3);
    PJSEL0 &= ~(BIT0 + BIT1 + BIT2 + BIT3);
    PJSEL1 &= ~(BIT0 + BIT1 + BIT2 + BIT3);

    CSCTL0 = 0xA500;                        // Write password to modify CS registers
    CSCTL1 = DCOFSEL0 + DCOFSEL1;           // DCO = 8 MHz
    CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1; // MCLK = DCO, ACLK = DCO, SMCLK = DCO
    CSCTL3 &= ~(BIT4 | BIT5 | BIT6);        // Clear relevant bits

    SetupStepperTimers();

    // Configure PWM on Timer A pin 1.3
    // Timer_A1 setup for PWM on P1.3 (TA0.2)
    TA1CTL  = TACLR;                  // Clear Timer_A
    TA1CTL |= MC__UP;                 // Up mode
    TA1CTL |= TASSEL__ACLK;           // Clock source = ACLK

    TA1CCR0  = STEPPER_UPCOUNT_TARGET; // PWM period
    TA1CCTL2 = OUTMOD_7;              // Reset/Set mode
    TA1CCR2  = (STEPPER_UPCOUNT_TARGET >> 2);                     // Start with 0% duty

    P1DIR  |= BIT3;                   // P1.3 output
    P1SEL0 |= BIT3;                   // Select TA1.2 function
    P1SEL1 &= ~BIT3;                  // Clear secondary select
    
    // Configure ports for UART
    P2SEL0 &= ~(BIT5 + BIT6);
    P2SEL1 |= BIT5 + BIT6;

    // Configure UART0
    UCA1CTLW0 |= UCSWRST;
    UCA1CTLW0 |= UCSSEL0;                    // Run the UART using ACLK
    UCA1MCTLW = UCOS16 + UCBRF0 + 0x4900;   // Baud rate = 9600 from an 8 MHz clock
    UCA1BRW = 52;
    UCA1CTLW0 &= ~UCSWRST;

    UCA1IE |= UCRXIE; // Enable UART receive interrupt
    _EINT();

    while(1){
        DelayHectoMicros_8Mhz(500);
        IncrementHalfStep2(&stepper2_state, true);
    }
}

#pragma vector = USCI_A1_VECTOR 
__interrupt void USCI_A1_ISR(void) {
    if (UCA1IFG & UCRXIFG) {
        // on recv
        unsigned char RxByte = 0;
        RxByte = UCA1RXBUF; // Get the new byte from the Rx buffer
        Buffer_Push(&uartBuffer, RxByte);
        UCA1IFG &= ~UCRXIFG;
        UCA1TXBUF = RxByte;

    } else if (UCA1IFG & UCTXIFG) {
        // on tx complete
        // if (queue_has_data(&UART_TX_QUEUE)) {
        // UCA0TXBUF = dequeue(&UART_TX_QUEUE);
        // }
        UCA1IFG &= ~UCTXIFG;
    }
}


