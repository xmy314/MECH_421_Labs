import serial

# Open the port
try:
    ser = serial.Serial('COM7', 9600, timeout=1)  # 1s read timeout
    if ser.is_open:
        print(f"Opened {ser.portstr} at {ser.baudrate} baud")
except serial.SerialException as e:
    print(f"Error opening port: {e}")
    exit(1)

# Define packet
packet = bytes([0xFF, 0x01, 0x7F, 0x00, 0x01])

# Send packet
bytes_written = ser.write(packet)
ser.flush()  # ensure it's pushed out of the buffer
print(f"Sent {bytes_written} bytes: {[hex(b) for b in packet]}")

ser.close()
print("Port closed")
