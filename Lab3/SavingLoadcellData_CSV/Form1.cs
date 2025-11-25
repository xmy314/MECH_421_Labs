using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SavingAccDataCSV
{
    public partial class Form1 : Form
    {
        private string serialDataString = "";
        private Timer myTimer = new Timer();
        private enum DataStream { LEAD, HiByte, LoByte};
        private DataStream nextDataStream;
        private int MSB, LSB;
        int sampleIndex = 0;
        double distance;
        double avg;

        private ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        private ConcurrentQueue<Int32> dataQueueVolt = new ConcurrentQueue<Int32>();

        private StreamWriter streamWriter;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());

            tempChart.Series.Clear();

            Series tempSeries = new Series
            {
                Name = "Distance",
                Color = Color.Blue,
                IsVisibleInLegend = true,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Line, 
                XValueType = ChartValueType.Int32, 
                YValueType = ChartValueType.Double
            };

            Series ADCSeries = new Series
            {
                Name = "ADC",
                Color = Color.Red,
                IsVisibleInLegend = true,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Int32,
                YValueType = ChartValueType.Double
            };

            tempChart.Series.Add(tempSeries);
            tempChart.Series.Add(ADCSeries);

            tempChart.ChartAreas[0].AxisX.Title = "Sample Number";
            tempChart.ChartAreas[0].AxisY.Title ="ADC/Distance (mm)";

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
            myTimer.Interval = 100;// Fires every 100ms
            myTimer.Tick += UpdateQueues; // Hook up the event
            myTimer.Start(); // Start the timer
        }

        // Timer Tick Event Handler
        private void UpdateQueues(object sender, EventArgs e)
        {
            //if (serialPort_MSP430.IsOpen)
            //    textBox_SerialBytestoRead.Text = serialPort_MSP430.BytesToRead.ToString();
            //textBox_TempStringLength.Text = serialDataString.Length.ToString();
            //ItemsInQueue.Text = dataQueue.Count.ToString(); // counting characters in the Queue
            serialDataString = "";

            // Display contents of queue container
            while (dataQueue.TryDequeue(out int value))
            {   
                //textBox_Data.AppendText(value.ToString() + ", ");
                processDataQueue(value);

            }
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
                    serialPort_MSP430.Write(TxByte, 0, 1);

                    buttonConnectSerial.Text = "Disconnect Serial";
                    comboBoxCOMPorts.Enabled = false; // Disable port selection while connected
                    //MessageBox.Show("Successfully Connected.");
                }
                else
                {
                    // Disconnect from serial port
                    string transmit = "z";
                    byte[] TxByte = Encoding.Unicode.GetBytes(transmit);
                    serialPort_MSP430.Write(TxByte, 0, 1);
                    serialPort_MSP430.Close();
                    
                    buttonConnectSerial.Text = "Connect Serial";
                    comboBoxCOMPorts.Enabled = true; // Re-enable port selection
                    //MessageBox.Show("Successfully Disconnected.");
                    tempChart.Series["Distance"].Points.Clear();
                    tempChart.Series["ADC"].Points.Clear();
                    sampleIndex = 0;

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

        private void checkBox_saveFile_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox_saveFile.Checked)
            //{
            //    startStreamingToFile();
            //}
            //else
            //{
            //    stopWritingToFile();
            //}
        }

        // Save File Dialog implementation
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        //    {
        //        // Configure the SaveFileDialog
        //        saveFileDialog.Title = "Save CSV Data File";
        //        saveFileDialog.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*";
        //        saveFileDialog.FilterIndex = 1; // Default to CSV files
        //        saveFileDialog.DefaultExt = "csv";
        //        saveFileDialog.AddExtension = true;

        //        // Set initial directory
        //        saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //        // Set default filename with timestamp
        //        saveFileDialog.FileName = $"MassData_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

        //        // If textbox already has a filename, use it
        //        if (!string.IsNullOrWhiteSpace(textBox_Filename.Text))
        //        {
        //            try
        //            {
        //                // If it's a full path, extract filename and directory
        //                if (Path.IsPathRooted(textBox_Filename.Text))
        //                {
        //                    saveFileDialog.FileName = Path.GetFileName(textBox_Filename.Text);
        //                    string directory = Path.GetDirectoryName(textBox_Filename.Text);
        //                    if (Directory.Exists(directory))
        //                    {
        //                        saveFileDialog.InitialDirectory = directory;
        //                    }
        //                }
        //                else
        //                {
        //                    // Just a filename
        //                    saveFileDialog.FileName = textBox_Filename.Text;
        //                }
        //            }
        //            catch
        //            {
        //                // If there's any error with the existing path, use defaults
        //            }
        //        }

        //        // Show the dialog
        //        DialogResult result = saveFileDialog.ShowDialog();

        //        if (result == DialogResult.OK)
        //        {
        //            // Update the textbox with the selected filename
        //            textBox_Filename.Text = saveFileDialog.FileName;

        //            // Optional: Show confirmation message
        //            MessageBox.Show($"File path selected: {saveFileDialog.FileName}",
        //                          "File Selected",
        //                          MessageBoxButtons.OK,
        //                          MessageBoxIcon.Information);
        //        }
        //    }
        //}

        private void serialPort_MSP430_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            while (serialPort_MSP430.BytesToRead > 0 && serialPort_MSP430.IsOpen)
            {
                newByte = serialPort_MSP430.ReadByte();
                dataQueue.Enqueue(newByte);
                serialDataString = serialDataString + newByte.ToString() + ", ";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                if (serialPort_MSP430.IsOpen)
                {
                    // Cancel the close temporarily to do async cleanup
                    e.Cancel = true;

                    // Disable the form to prevent user interaction
                    this.Enabled = false;

                    //// Stop file writing
                    //if (checkBox_saveFile.Checked)
                    //{
                    //    stopWritingToFile();
                    //}

                    // Re-enable form and close
                    this.Enabled = true;
                    e.Cancel = false;

                    // Close the form properly
                    this.Close();
                }
                else
                {
                    // Just stop file writing if no serial connection
                    //if (checkBox_saveFile.Checked)
                    //{
                    //    stopWritingToFile();
                    //}
                }
            }
            catch (Exception ex)
            {
                // Log error but allow form to close
                System.Diagnostics.Debug.WriteLine("Error closing form: " + ex.Message);
            }
        }

        // Helper methods for file writing
        //private void startStreamingToFile()
        //{
        //    try
        //    {
        //        // Validate filename
        //        if (string.IsNullOrWhiteSpace(textBox_Filename.Text))
        //        {
        //            MessageBox.Show("Please enter a filename");
        //            checkBox_saveFile.Checked = false;
        //            return;
        //        }

        //        // Create directory if it doesn't exist
        //        string directory = Path.GetDirectoryName(textBox_Filename.Text);
        //        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        //        {
        //            Directory.CreateDirectory(directory);
        //        }

        //        streamWriter = new StreamWriter(textBox_Filename.Text);
        //        // Write CSV header
        //        streamWriter.WriteLine("Mass (Kilograms), Voltage(V), Timestamp");

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error starting file writing: {ex.Message}");
        //        checkBox_saveFile.Checked = false;
        //    }
        //}

        //private void stopWritingToFile()
        //{
        //    try
        //    {

        //        if (streamWriter != null)
        //        {
        //            streamWriter.Flush();
        //            streamWriter.Close();
        //            streamWriter.Dispose();
        //            streamWriter = null;
        //        }

        //        MessageBox.Show("File recording stopped and file closed.");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error stopping file recording: {ex.Message}");
        //    }
        //}

        // Process incoming data stream and display instantaneous values
        private void processDataQueue(int value)
        {   
            // Check for LEAD byte
            if (value == 255)
            {
                nextDataStream = DataStream.HiByte; // Expect Ax next
            }
            else
            {
                switch (nextDataStream)
                {
                    case DataStream.HiByte:
                        MSB = value;
                        nextDataStream = DataStream.LoByte; // Expect LoByte next
                        
                        break;
                    case DataStream.LoByte:


                        LSB = value;
                        int combinedValue = ((MSB << 5) | LSB); // Combine MSB and LSB

                        tempChart.Series["ADC"].Points.AddXY(sampleIndex++, combinedValue);
                        if (tempChart.Series["ADC"].Points.Count > 200)
                        {
                            tempChart.Series["ADC"].Points.RemoveAt(0);
                        }

                        //textBox_Ax.Text = combinedValue.ToString();
                        dataQueueVolt.Enqueue(combinedValue);

                        textBox_Ax.Text = combinedValue.ToString();

                        if (dataQueueVolt.Count >= 5)
                        {
                            if (IsStable(dataQueueVolt.ToArray().Select(x => (double)x).ToList(), 3.0))
                            {
                                textBox_SerialBytestoRead.BackColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                textBox_SerialBytestoRead.BackColor = System.Drawing.Color.Red;
                            }

                        }

                        if (dataQueueVolt.Count >= 20)
                        {
                            // Compute average of all items currently in the queue
                            avg = dataQueueVolt.Average();
                            distance = convertTomm(avg);

                            if ((distance > 220.0) || (distance < 29.0))
                            {
                                textBox_Status.Text = "Out of Range";
                            }
                            else
                            {
                                textBox_Status.Text = "";
                                textBox_Distance.Text = distance.ToString("F2"); // Temperature display
                            }

                            // Clear the queue for the next batch
                            while (dataQueueVolt.TryDequeue(out _)) { }
                        }
                        
                        tempChart.Series["Distance"].Points.AddXY(sampleIndex++, distance);
                        if (tempChart.Series["Distance"].Points.Count > 200)
                        {
                            tempChart.Series["Distance"].Points.RemoveAt(0);
                        }

                        tempChart.ResetAutoValues();

                        //if (checkBox_saveFile.Checked && streamWriter != null)
                        //{
                        //    // Write the latest Ax, Ay, Az values to file with timestamp
                        //    string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
                        //    streamWriter.WriteLine($"{mass}, {avg}, {timestamp}");
                        //}

                        nextDataStream = DataStream.LEAD; // Expect LEAD
                        break;
                }
            }
        }

        private double convertTomm(double rawVoltage) // Need to calibrate that....
        {

            return (2359.1 * Math.Pow(rawVoltage, -0.659));      // Convert to Celsius

        }

        public static bool IsStable(IList<double> samples, double stabilityThreshold)
        {
            if (samples == null || samples.Count == 0)
                return false;

            // Compute mean
            double sum = 0;
            foreach (var v in samples) sum += v;
            double mean = sum / samples.Count;

            // Compute variance
            double variance = 0;
            foreach (var v in samples)
            {
                double diff = v - mean;
                variance += diff * diff;
            }
            variance /= samples.Count;

            double stddev = Math.Sqrt(variance);
            return stddev < stabilityThreshold;
        }
    }
}
