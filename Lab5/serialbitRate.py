import serial
import time

def measure_bitrate(port="COM6", baudrate=115200, duration=5):
    # Open the serial port
    ser = serial.Serial(port, baudrate, timeout=0)
    print(f"Opened {port} at {baudrate} baud")

    # Flush any existing data
    ser.reset_input_buffer()

    start_time = time.time()
    total_bytes = 0

    while time.time() - start_time < duration:
        # Read whatever is available
        data = ser.read(1024)  # read up to 1024 bytes at a time
        total_bytes += len(data)

    elapsed = time.time() - start_time
    ser.close()

    # Each UART frame = 10 bits (start + 8 data + stop)
    bitrate = (total_bytes * 10) / elapsed
    print(f"Measured bitrate ≈ {bitrate:.0f} bps over {elapsed:.2f} seconds")

if __name__ == "__main__":
    measure_bitrate(port="COM6", baudrate=115200, duration=10)
