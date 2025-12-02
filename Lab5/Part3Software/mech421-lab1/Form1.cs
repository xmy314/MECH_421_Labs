using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mech421_lab1
{


    public partial class Mutli_Stepper_Controller : Form
    {

        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        int prior_length = 0;
        bool all_at_once = true;
        bool sending = false;
        public Mutli_Stepper_Controller()
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
            //comboBox1.Items.Clear();
            //comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            //if (comboBox1.Items.Count == 0)
            //    comboBox1.Text = "No COM ports!";
            //else
            //    comboBox1.SelectedIndex = 0;

            timer1.Enabled = true;

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                buttonConnect.Text = "Disconnect";

                serialPort1.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                serialPort1.Open();


                buttonStart.Enabled = true;
                buttonStop.Enabled = true;

            }
            else
            {
                buttonConnect.Text = "Connect";
                serialPort1.Close();

                buttonStart.Enabled = false;
                buttonStop.Enabled = false;
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
                if (v == 1 && all_at_once)
                {
                    //    sending = sendOne();
                    timer2.Enabled = false;
                    timer2.Interval = (int) Math.Min((float)prior_length *1.5f,100f);
                    timer2.Enabled = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            sendOne();
        }

        private void buttonSelectCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog save_dialog = new OpenFileDialog();

            save_dialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            save_dialog.FilterIndex = 2;
            save_dialog.RestoreDirectory = true;

            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxCSVPath.Text = save_dialog.FileName;
                buttonLoadCSV.Enabled = true;
                buttonSaveCSV.Enabled = true;
            }
        }

        private void textBoxXPos_TextChanged(object sender, EventArgs e)
        {
            int V;
            if (textBoxXPos.Text == "-")
            {
                return;
            }

            if (!int.TryParse(textBoxXPos.Text, out V))
            {
                textBoxXPos.Text = "";
                return;
            }

            if (V >= 1000)
            {
                textBoxXPos.Text = "999";
                return;
            }

            if (V <= -1000)
            {
                textBoxXPos.Text = "-999";
                return;

            }
        }

        private void textBoxYPos_TextChanged(object sender, EventArgs e)
        {
            int V;

            if (textBoxYPos.Text == "-")
            {
                return;
            }

            if (!int.TryParse(textBoxYPos.Text, out V))
            {
                textBoxYPos.Text = "";
                return;
            }

            if (V >= 1000)
            {
                textBoxXPos.Text = "999";
                return;
            }

            if (V <= -1000)
            {
                textBoxXPos.Text = "-999";
                return;

            }

        }
        
        private void textBoxVel_TextChanged(object sender, EventArgs e)
        {
            int V;

            if (!int.TryParse(textBoxVel.Text, out V))
            {
                textBoxVel.Text = "";
                return;
            }

            if (V > 100)
            {
                textBoxVel.Text = "100";
                return;
            }

            if (V <= 0)
            {
                textBoxVel.Text = "0";
                return;
            }
        }

        private void buttonAddToStash_Click(object sender, EventArgs e)
        {
            int x_pos,y_pos,vel;
            if (!int.TryParse(textBoxXPos.Text, out x_pos))
            {
                return;
            }

            if (!int.TryParse(textBoxYPos.Text, out y_pos))
            {
                return;
            }

            if (!int.TryParse(textBoxVel.Text, out vel))
            {
                return;
            }

            int escape = 0;

            if (x_pos < 0)
            {
                escape += 1;
            }

            if (y_pos < 0)
            {
                escape += 2;
            }

            int max_travel = Math.Max(Math.Abs(x_pos), Math.Abs(y_pos));
            int segment_count = max_travel/ 200;

            float whole_portion = segment_count * 200f / max_travel;
            int min_travel_step = (int)(whole_portion * (float)Math.Min(Math.Abs(x_pos), Math.Abs(y_pos))) / segment_count;

            for (int i = 0; i < segment_count; i++)
            {
                if (Math.Abs(x_pos) > Math.Abs(y_pos))
                {
                    textBoxCommandStash.Text += "255, 200," +min_travel_step.ToString() + "," + Math.Abs(vel).ToString() + "," + escape.ToString() + "\r\n";
                }
                else
                {
                    textBoxCommandStash.Text += "255, " + min_travel_step.ToString() + ",200," + Math.Abs(vel).ToString() + "," + escape.ToString() + "\r\n";
                }

            }

            if (Math.Abs(x_pos) > Math.Abs(y_pos))
            {
                textBoxCommandStash.Text += "255, " + (Math.Abs(x_pos)-200*segment_count).ToString() + "," + (Math.Abs(y_pos)-min_travel_step*segment_count).ToString() + "," + Math.Abs(vel).ToString() + "," + escape.ToString() + "\r\n";
            }
            else
            {
                textBoxCommandStash.Text += "255, " + (Math.Abs(x_pos) - min_travel_step * segment_count).ToString() + "," + (Math.Abs(y_pos)-200*segment_count).ToString() + "," + Math.Abs(vel).ToString() + "," + escape.ToString() + "\r\n";
            }

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            textBoxCommandQueue.Text = textBoxCommandStash.Text;
            if (all_at_once)
            {
                sending = sendOne();
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            textBoxCommandQueue.Text = "";
            sending = false;
        }

        private bool sendOne()
        {
            string text = textBoxCommandQueue.Text;

            if (text == "")
            {
                return false;
            }

            string firstLine;
            int newlineIndex = text.IndexOf('\n');

            if (newlineIndex >= 0)
            {
                firstLine = text.Substring(0, newlineIndex).Trim();
                textBoxCommandQueue.Text = text.Substring(newlineIndex + 1);
            }
            else
            {
                firstLine = text.Trim();
                textBoxCommandQueue.Text = ""; // remove it
            }

            string[] parts = firstLine.Split(',');

            if (parts.Length != 5)
            {
                MessageBox.Show("Expected exactly 5 numbers.");
                textBoxCommandQueue.Text = ""; // remove it
                return false;
            }

            // 4) Convert to byte array
            byte[] data = new byte[5];

            for (int i = 0; i < 5; i++)
            {
                if (!int.TryParse(parts[i], out int val))
                {
                    MessageBox.Show("Invalid number: must be 0–255.");
                    textBoxCommandQueue.Text = ""; // remove it
                    return false;
                }
                data[i] = (byte)val;
            }

            if (data[1] != 0 || data[2] != 0)
            {
                prior_length = (int)(data[1] + data[2]);
                serialPort1.Write(data, 0, 5);
            }
            else
            {
                sendOne();
            }
                return true;
        }

        private void buttonLoadCSV_Click(object sender, EventArgs e)
        {
            StreamReader in_file = new StreamReader(textBoxCSVPath.Text);

            textBoxCommandStash.Text = in_file.ReadToEnd();

            in_file.Close();
        }

        private void buttonSaveCSV_Click(object sender, EventArgs e)
        {

            StreamWriter out_file = new StreamWriter(textBoxCSVPath.Text);

            out_file.Write(textBoxCommandStash.Text);

            out_file.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (all_at_once)
            {
                button1.Text = "send all";
                all_at_once = false;
            
            }
            else
            {
                button1.Text = "to one at a time";
                all_at_once = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sendOne();
        }
    }
}

