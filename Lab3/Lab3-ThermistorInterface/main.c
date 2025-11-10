#include "MSP430.h"
#include "FirmwareLibhelper/generalLib.h"

volatile unsigned int temperature_volt = 0;
volatile unsigned char LoByte = 0;
volatile unsigned char HiByte = 0;
volatile unsigned int startTransmit = 0;

void main (void)
{
    // Stop watchdog timer
    WDTCTL = WDTPW | WDTHOLD;

    Clock_Init_DCO_8MHz();
    Clock_Set_SMCLK_Divider(8); // Sets up to 1Mhz
    LED_Init(ALL_LEDs);
    LED_TurnOff(ALL_LEDs);

    // Initialize pin 1.1 - Analog 1
    P1SEL1 |= BIT1;
    P1SEL0 |= BIT1;

    UART_Init_9600_without_interrupt();
    UART_Enable_Receive_Interrupt();

    // Configure ADC
    // ADC10CTL0 &= ~ADC10ENC;
    // ADC10CTL1 |= ADC10SHP + ADC10SSEL_3 + ADC10CONSEQ_0;// ADCCLK = SMCLK; sampling timer; single sample mode
    // ADC10CTL0 &= ~ADC10SHT_2;
    // ADC10CTL0 |= ADC10ON;  // ADC 10 On, sample and hold time = 16 ADC clks
    // ADC10CTL2 |= ADC10RES; // 10 bit resolution
    // ADC10MCTL0 |= ADC10SREF_0; // 0-Vcc reference voltage (0-3.3V)
    ADC10_Init();
    __enable_interrupt();
    
    while(1){

        if (startTransmit == 1){
            temperature_volt = ADC10_Sample(1);

            LoByte = (temperature_volt & 0x1F);
            HiByte = ((temperature_volt >> 5) & 0x1F);

            UART_transmitByte(0xFF);
            UART_transmitByte(HiByte);
            UART_transmitByte(LoByte);

            __delay_cycles(80000);
        }
        
    }

}

 #pragma vector = USCI_A0_VECTOR 
 __interrupt void USCI_A0_ISR(void) {
    switch(__even_in_range(UCA0IV,18)) {
        case 0x00:
            // Vector 0: No interrupts
            break;
        case 0x02:  // Vector 2: UCRXIFG
        {   // read Receive buffer
            unsigned char RxByte = UCA0RXBUF;
            
            if (RxByte == 'A' || RxByte == 'a'){
                startTransmit = 1;
            }
            else if (RxByte == 'Z' || RxByte == 'z'){
                startTransmit = 0;
            }

            break;
        }
        case 0x04: // Vector 4: UCTXIFG
            break;
        case 0x06: // Vector 6: UCSTTIFG
            break;
        case 0x08: // Vector 8: UCTXCPTIFG
            break;
        default: 
            break;
    }
 }
