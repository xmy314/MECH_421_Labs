#include <msp430.h> 
#include <stepper.h>

#define true 1
#define false 0
typedef short bool;

typedef enum STEPPER_STATE {
    A1_xx,
    A1_B1,
    xx_B1,
    A2_B1,
    A2_xx,
    A2_B2,
    xx_B2,
    A1_B2
} STEPPER_STATE;
// 65535 = ~121 Hz
// 8191 = ~1 kHz
// 245 = 32 kHz
#define STEPPER_UPCOUNT_TARGET 8191
// STEPPER_UPCOUNT_TARGET / 4
#define MAX_STEPPER_PHASE_DUTY (STEPPER_UPCOUNT_TARGET >> 2)

#define STEPPER_A1 TB0CCR2
#define STEPPER_A2 TB0CCR1
#define STEPPER_B1 TB1CCR2
#define STEPPER_B2 TB1CCR1


unsigned int SpeedToDelay_HectoMicros(unsigned int speed)
{
    if (speed > 50)
        return 10;
    if (speed < 1)
        return 500;
    return 500 / speed;
}

void SetupStepperTimers()
{
    // A1 = TIMERB0.2 = P1.5
    // A2 = TIMERB0.1 = P1.4
    // B1 = TIMERB1.2 = P3.5
    // B2 = TIMERB1.1 = P3.4

    // Setup Timer B0 in the "up count" mode
    TB0CTL |= TBCLR;            // Clear Timer B            (L) pg.372
    TB0CTL |= (BIT4);           // Up mode                  (L) pg. 372
    TB0CTL |= TBSSEL__ACLK;    // Clock source select      (L) pg. 372
    //TB0CTL |= (BIT7 | BIT6);    // 1/8 divider (125 kHz)    (L) pg. 372
    TB0CCR0 = STEPPER_UPCOUNT_TARGET;    // What we count to         (L) pg. 377
    // Setup Timer B1 in the "up count" mode
    TB1CTL |= TBCLR;            // Clear Timer B            (L) pg.372
    TB1CTL |= (BIT4);           // Up mode                  (L) pg. 372
    TB1CTL |= TBSSEL__ACLK;    // Clock source select      (L) pg. 372
    //TB1CTL |= (BIT7 | BIT6);    // 1/8 divider (125 kHz)    (L) pg. 372
    TB1CCR0 = STEPPER_UPCOUNT_TARGET;    // What we count to         (L) pg. 377

    // Reset/Set mode           (L) pg. 365, 366, and 375
    TB1CCTL1 = OUTMOD_7;
    TB1CCTL2 = OUTMOD_7;
    TB0CCTL1 = OUTMOD_7;
    TB0CCTL2 = OUTMOD_7;
    // Output TB1.1 on P3.4 & TB1.2 on P3.5         (M) pg. 81
    // Output TB0.1 on P1.4 & TB0.2 on P1.5         (M) pg. 72
    P3DIR  |=  (BIT4 + BIT5);
    P3SEL1 &= ~(BIT4 + BIT5);
    P3SEL0 |=  (BIT4 + BIT5);
    P1DIR  |=  (BIT4 + BIT5);
    P1SEL1 &= ~(BIT4 + BIT5);
    P1SEL0 |=  (BIT4 + BIT5);

    // Zero duty cycle to start with
    STEPPER_A1 = MAX_STEPPER_PHASE_DUTY;
    STEPPER_A2 = 0;
    STEPPER_B1 = 0;
    STEPPER_B2 = 0;
}

void UpdatePinsBasedOnStepperState(STEPPER_STATE *currentState)
{
    
    int A1_PWM = 0;
    int A2_PWM = 0;
    int B1_PWM = 0;
    int B2_PWM = 0;

    switch (*currentState)
    {
        case A1_xx:
            A1_PWM = MAX_STEPPER_PHASE_DUTY;
            break;
        case A1_B1:
            A1_PWM = MAX_STEPPER_PHASE_DUTY;
            B1_PWM = MAX_STEPPER_PHASE_DUTY;
            break;
        case xx_B1:
            B1_PWM = MAX_STEPPER_PHASE_DUTY;
            break;
        case A2_B1:
            A2_PWM = MAX_STEPPER_PHASE_DUTY;
            B1_PWM = MAX_STEPPER_PHASE_DUTY;
            break;
        case A2_xx:
            A2_PWM = MAX_STEPPER_PHASE_DUTY;
            break;
        case A2_B2:
            A2_PWM = MAX_STEPPER_PHASE_DUTY;
            B2_PWM = MAX_STEPPER_PHASE_DUTY;
            break;
        case xx_B2:
            B2_PWM = MAX_STEPPER_PHASE_DUTY;
            break;
        case A1_B2:
            A1_PWM = MAX_STEPPER_PHASE_DUTY;
            B2_PWM = MAX_STEPPER_PHASE_DUTY;
            break;
    }

    STEPPER_A1 = A1_PWM;
    STEPPER_A2 = A2_PWM;
    STEPPER_B1 = B1_PWM;
    STEPPER_B2 = B2_PWM;
}

void IncrementHalfStep(STEPPER_STATE *currentState, bool directionCW)
{
    // Clockwise
    if (directionCW)
    {
        if (*currentState == A1_B2)
            *currentState = A1_xx;
        else
            *currentState = *currentState + 1;
    }
    // Counterclockwise
    else
    {
        if (*currentState == A1_xx)
            *currentState = A1_B2;
        else
            *currentState = *currentState - 1;
    }

    UpdatePinsBasedOnStepperState(currentState);
}