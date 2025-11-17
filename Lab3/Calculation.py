import math

#convertVoltage = ((0.64*(rawVoltage-300))/180) + 1.06
#(-10000 * convertVoltage) /(convertVoltage - 3.65)
T0 = 300.0
B = 3435.0
Rt = 3600
R0 = 10000.0

invT = (1.0 / T0) + (1.0 / B) * math.log(Rt / R0)
T = 1.0 / invT  # Temperature in Kelvin

print("Temperature in Kelvin: ", T-273.15)