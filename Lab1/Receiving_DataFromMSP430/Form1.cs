using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Receiving_DataFromMSP430
{
    public partial class Form1 : Form
    {
        private string serialDataString = "";
        private Timer myTimer = new Timer();
        private ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();

        private int bytesReceivedThisInterval = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
            {
                comboBoxCOMPorts.Text = "No COM ports!";
            }
            else
            {
                comboBoxCOMPorts.SelectedIndex = 0;
            }
                
            // Initialize button text
            buttonConnectSerial.Text = "Connect Serial";

            // Setting up a timer
            myTimer.Interval = 100; // Fires every 100ms
            myTimer.Tick += UpdateQueue; // Hook up the event
            myTimer.Start(); // Start the timer
        }

        private void UpdateQueue(object sender, EventArgs e)
        {
            if (serialPort_MSP430.IsOpen)
                textBox_SerialBytestoRead.Text = serialPort_MSP430.BytesToRead.ToString();

            ItemsInQueue.Text = dataQueue.Count.ToString();

            int count = 0;
            // Display queue contents
            while (dataQueue.TryDequeue(out int value))
            {
                count++;
                textBox_Data.AppendText(value.ToString() + ", ");
            }

            double bitrate = count * 10; // 10 bits per UART frame, 1 second interval
            textBox_bitRate.Text = $"{bitrate:F0} bps";

        }

        private void comboBoxCOMPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCOMPorts.SelectedItem != null)
            {
                serialPort_MSP430.PortName = comboBoxCOMPorts.SelectedItem.ToString();
            }
        }

        private void buttonConnectSerial_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort_MSP430.IsOpen)
                {
                    // Connect to serial port
                    string transmit = "a"; // or "A", both will work 
                    byte[] TxByte = Encoding.Unicode.GetBytes(transmit);

                    serialPort_MSP430.Open();
                    //serialPort_MSP430.Write(TxByte, 0, 1);

                    buttonConnectSerial.Text = "Disconnect Serial";
                    comboBoxCOMPorts.Enabled = false; // Disable port selection while connected
                    //MessageBox.Show("Successfully Connected.");
                }
                else
                {
                    // Disconnect from serial port
                    string transmit = "z";
                    byte[] TxByte = Encoding.Unicode.GetBytes(transmit);
                    //serialPort_MSP430.Write(TxByte, 0, 1);
                    serialPort_MSP430.Close();

                    buttonConnectSerial.Text = "Connect Serial";
                    comboBoxCOMPorts.Enabled = true; // Re-enable port selection
                    //MessageBox.Show("Successfully Disconnected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

                // Ensure UI state is consistent even if an error occurs
                if (serialPort_MSP430.IsOpen)
                {
                    buttonConnectSerial.Text = "Disconnect Serial";
                    comboBoxCOMPorts.Enabled = false;
                }
                else
                {
                    buttonConnectSerial.Text = "Connect Serial";
                    comboBoxCOMPorts.Enabled = true;
                }
            }
        }

        private void serialPort_MSP430_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead;
            bytesToRead = serialPort_MSP430.BytesToRead;
            while (bytesToRead != 0)
            {
                newByte = serialPort_MSP430.ReadByte();
                dataQueue.Enqueue(newByte);
                //// Count bytes for bitrate calculation
                //System.Threading.Interlocked.Increment(ref bytesReceivedThisInterval);

                serialDataString = serialDataString + newByte.ToString() + ", ";
                bytesToRead = serialPort_MSP430.BytesToRead;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (serialPort_MSP430.IsOpen)
                {
                    string transmit_close = "z"; // or "Z", both will work 
                    byte[] TxByte = Encoding.Unicode.GetBytes(transmit_close);
                    //serialPort_MSP430.Write(TxByte, 0, 1);
                    serialPort_MSP430.Close();

                }
            }
            catch (Exception ex)
            {
                // Log error if needed, but don't prevent form from closing
                System.Diagnostics.Debug.WriteLine("Error closing serial port: " + ex.Message);

            }
        }
    }
}
