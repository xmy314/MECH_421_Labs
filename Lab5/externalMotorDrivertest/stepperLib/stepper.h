#ifndef STEPPERLIB_H
#define STEPPERLIB_H

#include <msp430.h>
#include <stdbool.h>

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
#define STEPPER_UPCOUNT_TARGET 4095
// STEPPER_UPCOUNT_TARGET / 4
#define MAX_STEPPER_PHASE_DUTY (STEPPER_UPCOUNT_TARGET >> 2)

#define STEPPER_A1 TB0CCR2
#define STEPPER_A2 TB0CCR1
#define STEPPER_B1 TB1CCR2
#define STEPPER_B2 TB1CCR1

void SetupStepperTimers();
// Sets up Timer B0 and Timer B1 to control the stepper motor
// A1 = TB0.2, A2 = TB0.1, B1 = TB1.2, B2 = TB1.1

void IncrementHalfStep(STEPPER_STATE *currentState, bool directionCW);
// Increments the stepper motor half step in the given direction

void UpdatePinsBasedOnStepperState(STEPPER_STATE *currentState);
// Sets the PWM to the 4 output pins depending on the current state of the stepper motor

unsigned int SpeedToDelay_HectoMicros(unsigned int speed);
// Converts a speed value to a delay in hecto-microseconds
// Speed is in the range [1, 50]
// 1 hecto-microsecond = 100 microseconds = 0.1 milliseconds


void DelayHectoMicros_8Mhz(unsigned int hectomicros);


#endif
