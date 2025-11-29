#include "msp430.h"
#include "stepperLib/stepper.h"
#include "FirmwareLibhelper/generalLib.h"
#include "math.h"

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
enum ByteSequence {IDLE, START, XPOS, YPOS, SPEED, DIR};
volatile enum ByteSequence CurrentByte = IDLE;
volatile unsigned char poppedByte = 0x00;
volatile unsigned int combinedMessage = 0x0000;

typedef struct {
    volatile unsigned char start;  // start byte - I dont need to use this lowkey
    volatile unsigned char xpos;   // Data Byte 1
    volatile unsigned char ypos;   // Data Byte 2
    volatile unsigned char speed;  // translation speed (percentage)
    volatile unsigned char dir;
} Packet;

Packet incomingPacket ={ .start = 0, .xpos = 0, .ypos = 0, .speed = 0, .dir = 0};

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
    return position;
}

unsigned int convertTranslationSpeedTodelay(unsigned int speedPercent){
    unsigned int maxDelay = SpeedToDelay_HectoMicros(1); // slowest, in µs
    unsigned int minDelay = SpeedToDelay_HectoMicros(420);  // fastest, in µs
    return maxDelay - ((speedPercent * (maxDelay - minDelay)) / 100);
}

void processMessagePacket(Packet *packet) 
{
    // --- Convert packet data into step counts ---
    int targetXsteps = (int)convertPositionToHalfStepNum(packet->xpos);
    int targetYsteps = (int)convertPositionToHalfStepNum(packet->ypos);

    // --- Extract direction bits ---
    bool dirX = (packet->dir & BIT0);  // X direction
    bool dirY = (packet->dir & BIT1);  // Y direction

    int dx = abs(targetXsteps);
    int dy = abs(targetYsteps);

    // --- Compute vector length ---
    int L = (int)sqrtf((float)(dx*dx + dy*dy));
    if (L == 0) {
        UART_SendPacket("No movement.", 12);
        return;
    }

    // --- Base delay from absolute speed ---
    unsigned int baseDelay = SpeedToDelay_HectoMicros(packet->speed);

    // --- Bresenham setup ---
    int err = dx - dy;
    int x = dx;
    int y = dy;

    TA1CCR2 = (STEPPER_UPCOUNT_TARGET >> 2);

    while (x > 0 || y > 0) 
    {
        int e2 = 2 * err;

        if (e2 > -dy) {
            err -= dy;
            if (x > 0) {
                IncrementHalfStep(&stepper_state, dirX);
                x--;
            }
        }

        if (e2 < dx) {
            err += dx;
            if (y > 0) {
                IncrementHalfStep2(&stepper2_state, dirY);
                y--;
            }
        }

        DelayHectoMicros_8Mhz(baseDelay);
    }

    UART_transmitByte(0x01);

    // --- Reset fields (optional cleanup) ---
    packet->xpos  = 0;
    packet->ypos  = 0;
    packet->speed = 0;
    packet->dir   = 0;
    TA1CCR2 = 0;
    STEPPER_A1 = 0;
    STEPPER_A2 = 0;
    STEPPER_B1 = 0;
    STEPPER_B2 = 0;

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
    TA1CCR2  = 0; 
    
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
        if(!Buffer_IsEmpty(&uartBuffer)) {
            poppedByte = Buffer_Pop(&uartBuffer);

            if (poppedByte == 0xFF) {
                CurrentByte = IDLE;
            }

            switch(CurrentByte) {
                case IDLE:
                    if (poppedByte == 0xFF) {
                        CurrentByte = XPOS;
                    }
                    break;
                case XPOS:
                    incomingPacket.xpos = poppedByte; 
                    CurrentByte = YPOS;
                    break;
                case YPOS:
                    incomingPacket.ypos = poppedByte;
                    CurrentByte = SPEED;
                    break;
                case SPEED:
                    incomingPacket.speed = poppedByte;
                    CurrentByte = DIR; 
                    break;
                case DIR:
                    incomingPacket.dir = poppedByte;
                    processMessagePacket(&incomingPacket);
                    CurrentByte = IDLE;
                    break;
            }

            // Clear poppedByte so it won’t be reused accidentally
            poppedByte = 0;
        }
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


