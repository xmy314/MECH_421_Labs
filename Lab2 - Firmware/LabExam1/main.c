#include "MSP430.h"
#include "../FirmwareLibhelper/generalLib.h"

void main (void)
{
    int const TICK_NUM = 199;        // 200 ticks → 1 MHz / 200 = 5 kHz
    int const DUTY_CYCLE = TICK_NUM / 10; // 10% duty = 20 ticks

    Clock_Init_DCO_8MHz();
    Clock_Set_SMCLK_Divider(1);      // SMCLK = 8 MHz
    TimerB1_Init_UpMode_125kHz(TICK_NUM);
    TimerB1_SetupPWM(1, DUTY_CYCLE);

    while(1);


}
