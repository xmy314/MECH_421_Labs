using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mech421_lab1
{


    public partial class Single_Stepper_Controller : Form
    {

        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        int velocity;
        public Single_Stepper_Controller()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBox1.Items.Count == 0)
                comboBox1.Text = "No COM ports!";
            else
                comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBox1.Items.Count == 0)
                comboBox1.Text = "No COM ports!";
            else
                comboBox1.SelectedIndex = 0;

            timer1.Enabled = true;

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                buttonConnect.Text = "Disconnect";

                serialPort1.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                serialPort1.Open();

                trackBar_velocity.Enabled = true;

            }
            else
            {
                buttonConnect.Text = "Connect";
                serialPort1.Close();

                trackBar_velocity.Enabled = false;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead = serialPort1.BytesToRead;
            while (bytesToRead != 0)
            {
                newByte = serialPort1.ReadByte();
                dataQueue.Enqueue(newByte);
                bytesToRead = serialPort1.BytesToRead;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Int32 v;
            while (dataQueue.TryDequeue(out v))
            {
            }
        }


        private void timerClear_Tick(object sender, EventArgs e)
        {
            timerClear.Enabled = false;
        }

        private void buttonCCWStep_Click(object sender, EventArgs e)
        {

            byte[] TxByte = new byte[] { 255,1,0,0};
            serialPort1.Write(TxByte, 0, 3);
        }

        private void buttonCWStep_Click(object sender, EventArgs e)
        {

            byte[] TxByte = new byte[] { 255, 2, 0,0 };
            serialPort1.Write(TxByte, 0, 1);
        }
        private void textBoxVelocity_TextChanged(object sender, EventArgs e)
        {
            int test_velocity;

            if (! int.TryParse(textBoxVelocity.Text,out test_velocity)){
                textBoxVelocity.Text = "";
                return;
            }

            if (test_velocity > 16383)
            {
                textBoxVelocity.Text= 16383.ToString();
                velocity = 16383;
            }
            else if (test_velocity < -16383)
            {
                textBoxVelocity.Text = (-16383).ToString();
                velocity = -16383;
            }
            else
            {
                velocity = test_velocity;
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (velocity >= 0)
            {
                byte[] TxByte = new byte[] { 255, 3, (byte)(Math.Abs(velocity) >> 7), (byte)(Math.Abs(velocity) & 0x7f) };
                serialPort1.Write(TxByte, 0, 4);

            }
            else
            {
                byte[] TxByte = new byte[] { 255, 4, (byte)(Math.Abs(velocity) >> 7), (byte)(Math.Abs(velocity) & 0x7f) };
                serialPort1.Write(TxByte, 0, 4);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                buttonConnect.Text = "Connect";

                string transmit_close = "z"; // or "Z", both will work
                byte[] TxByte = Encoding.Unicode.GetBytes(transmit_close);
                serialPort1.Write(TxByte, 0, 1);

                serialPort1.Close();
            }
        }


        private void buttonStop_Click(object sender, EventArgs e)
        {
            byte[] TxByte = new byte[] { 255, 5, 0,0 };
            serialPort1.Write(TxByte, 0, 4);
        }

        private void trackBar_velocity_ValueChanged(object sender, EventArgs e)
        {
            int track_velocity = trackBar_velocity.Value;

            if (track_velocity > 0)
            {
                byte[] TxByte = new byte[] { 255, 3, (byte)(Math.Abs(track_velocity) >> 7), (byte)(Math.Abs(track_velocity) & 0x7f) };
                serialPort1.Write(TxByte, 0, 4);
            }
            else
            {
                byte[] TxByte = new byte[] { 255, 4, (byte)(Math.Abs(track_velocity) >> 7), (byte)(Math.Abs(track_velocity) & 0x7f) };
                serialPort1.Write(TxByte, 0, 4);
            }

        }
    }
}

