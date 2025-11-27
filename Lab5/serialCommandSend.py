import serial
import time

ser = serial.Serial('COM6', baudrate=115200, timeout=1)

try:
    packet = bytes([0xFF, 0x01, 0x00, 0x00])
    
    # Write and check how many bytes were written
    written = ser.write(packet)
    if written == len(packet):
        print(f"Successfully queued {written} bytes: {packet.hex()}")
    else:
        print(f"Only {written} of {len(packet)} bytes were queued!")

    time.sleep(0.1)

finally:
    ser.close()