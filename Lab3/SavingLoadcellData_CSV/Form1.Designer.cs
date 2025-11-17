namespace SavingAccDataCSV
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label_SerialDataStream = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.buttonConnectSerial = new System.Windows.Forms.Button();
            this.label_SerialBytesToRead = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Az = new System.Windows.Forms.TextBox();
            this.textBox_Ay = new System.Windows.Forms.TextBox();
            this.label_Az = new System.Windows.Forms.Label();
            this.label_Ay = new System.Windows.Forms.Label();
            this.label_Ax = new System.Windows.Forms.Label();
            this.textBox_Ax = new System.Windows.Forms.TextBox();
            this.tempChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar_weight = new System.Windows.Forms.ProgressBar();
            this.serialPort_MSP430 = new System.IO.Ports.SerialPort(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_SerialBytestoRead = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempChart)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.72199F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.27801F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_SerialDataStream, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCOMPorts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonConnectSerial, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_SerialBytesToRead, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tempChart, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.progressBar_weight, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.39713F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.781737F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.373206F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.393286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.851675F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.658375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.177033F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.7177F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(482, 603);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 40);
            this.label3.TabIndex = 30;
            this.label3.Text = "Weight Range (0 - 3000 g):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_SerialDataStream
            // 
            this.label_SerialDataStream.AutoSize = true;
            this.label_SerialDataStream.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SerialDataStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SerialDataStream.Location = new System.Drawing.Point(3, 199);
            this.label_SerialDataStream.Name = "label_SerialDataStream";
            this.label_SerialDataStream.Size = new System.Drawing.Size(170, 34);
            this.label_SerialDataStream.TabIndex = 16;
            this.label_SerialDataStream.Text = "Live Weight Measurement:";
            this.label_SerialDataStream.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 8);
            this.label1.TabIndex = 3;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxCOMPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(3, 3);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(170, 24);
            this.comboBoxCOMPorts.TabIndex = 0;
            this.comboBoxCOMPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxCOMPorts_SelectedIndexChanged);
            // 
            // buttonConnectSerial
            // 
            this.buttonConnectSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConnectSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnectSerial.Location = new System.Drawing.Point(179, 3);
            this.buttonConnectSerial.Name = "buttonConnectSerial";
            this.buttonConnectSerial.Size = new System.Drawing.Size(300, 57);
            this.buttonConnectSerial.TabIndex = 1;
            this.buttonConnectSerial.Text = "Connect Serial";
            this.buttonConnectSerial.UseVisualStyleBackColor = true;
            this.buttonConnectSerial.Click += new System.EventHandler(this.buttonConnectSerial_Click);
            // 
            // label_SerialBytesToRead
            // 
            this.label_SerialBytesToRead.AutoSize = true;
            this.label_SerialBytesToRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SerialBytesToRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SerialBytesToRead.Location = new System.Drawing.Point(3, 71);
            this.label_SerialBytesToRead.Name = "label_SerialBytesToRead";
            this.label_SerialBytesToRead.Size = new System.Drawing.Size(170, 39);
            this.label_SerialBytesToRead.TabIndex = 2;
            this.label_SerialBytesToRead.Text = "Is it stable?";
            this.label_SerialBytesToRead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.7563F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.43698F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.59664F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.59664F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.38655F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.06723F));
            this.tableLayoutPanel2.Controls.Add(this.textBox_Az, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Ay, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_Az, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_Ay, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_Ax, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Ax, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 497);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(476, 45);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // textBox_Az
            // 
            this.textBox_Az.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Az.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Az.Location = new System.Drawing.Point(392, 3);
            this.textBox_Az.Multiline = true;
            this.textBox_Az.Name = "textBox_Az";
            this.textBox_Az.Size = new System.Drawing.Size(81, 39);
            this.textBox_Az.TabIndex = 7;
            this.textBox_Az.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Ay
            // 
            this.textBox_Ay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Ay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ay.Location = new System.Drawing.Point(237, 3);
            this.textBox_Ay.Multiline = true;
            this.textBox_Ay.Name = "textBox_Ay";
            this.textBox_Ay.Size = new System.Drawing.Size(72, 39);
            this.textBox_Ay.TabIndex = 6;
            this.textBox_Ay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Az
            // 
            this.label_Az.AutoSize = true;
            this.label_Az.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Az.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Az.Location = new System.Drawing.Point(315, 0);
            this.label_Az.Name = "label_Az";
            this.label_Az.Size = new System.Drawing.Size(71, 45);
            this.label_Az.TabIndex = 4;
            this.label_Az.Text = "Error:";
            this.label_Az.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Ay
            // 
            this.label_Ay.AutoSize = true;
            this.label_Ay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Ay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ay.Location = new System.Drawing.Point(159, 0);
            this.label_Ay.Name = "label_Ay";
            this.label_Ay.Size = new System.Drawing.Size(72, 45);
            this.label_Ay.TabIndex = 2;
            this.label_Ay.Text = "Mass (g):";
            this.label_Ay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Ax
            // 
            this.label_Ax.AutoSize = true;
            this.label_Ax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Ax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ax.Location = new System.Drawing.Point(3, 0);
            this.label_Ax.Name = "label_Ax";
            this.label_Ax.Size = new System.Drawing.Size(68, 45);
            this.label_Ax.TabIndex = 0;
            this.label_Ax.Text = "Raw Voltage:";
            this.label_Ax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Ax
            // 
            this.textBox_Ax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Ax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ax.Location = new System.Drawing.Point(77, 3);
            this.textBox_Ax.Multiline = true;
            this.textBox_Ax.Name = "textBox_Ax";
            this.textBox_Ax.Size = new System.Drawing.Size(76, 39);
            this.textBox_Ax.TabIndex = 5;
            this.textBox_Ax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tempChart
            // 
            chartArea3.Name = "ChartArea1";
            this.tempChart.ChartAreas.Add(chartArea3);
            this.tableLayoutPanel1.SetColumnSpan(this.tempChart, 2);
            this.tempChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.tempChart.Legends.Add(legend3);
            this.tempChart.Location = new System.Drawing.Point(3, 236);
            this.tempChart.Name = "tempChart";
            this.tempChart.Size = new System.Drawing.Size(476, 236);
            this.tempChart.TabIndex = 26;
            this.tempChart.Text = "tempChart";
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(178, 547);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(302, 54);
            this.button2.TabIndex = 27;
            this.button2.Text = "Tare (Zero Measurement)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar_weight
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.progressBar_weight, 2);
            this.progressBar_weight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar_weight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar_weight.Location = new System.Drawing.Point(3, 153);
            this.progressBar_weight.Maximum = 2000;
            this.progressBar_weight.Name = "progressBar_weight";
            this.progressBar_weight.Size = new System.Drawing.Size(476, 36);
            this.progressBar_weight.TabIndex = 28;
            // 
            // serialPort_MSP430
            // 
            this.serialPort_MSP430.PortName = "COM7";
            this.serialPort_MSP430.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_MSP430_DataReceived);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.89958F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.10042F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.textBox_SerialBytestoRead, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(179, 74);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(300, 33);
            this.tableLayoutPanel3.TabIndex = 31;
            // 
            // textBox_SerialBytestoRead
            // 
            this.textBox_SerialBytestoRead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_SerialBytestoRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_SerialBytestoRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SerialBytestoRead.Location = new System.Drawing.Point(3, 3);
            this.textBox_SerialBytestoRead.Multiline = true;
            this.textBox_SerialBytestoRead.Name = "textBox_SerialBytestoRead";
            this.textBox_SerialBytestoRead.Size = new System.Drawing.Size(32, 27);
            this.textBox_SerialBytestoRead.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 603);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempChart)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Button buttonConnectSerial;
        private System.Windows.Forms.Label label_SerialBytesToRead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_SerialDataStream;
        private System.IO.Ports.SerialPort serialPort_MSP430;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_Az;
        private System.Windows.Forms.Label label_Ay;
        private System.Windows.Forms.Label label_Ax;
        private System.Windows.Forms.TextBox textBox_Ax;
        private System.Windows.Forms.TextBox textBox_Az;
        private System.Windows.Forms.TextBox textBox_Ay;
        private System.Windows.Forms.DataVisualization.Charting.Chart tempChart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar_weight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBox_SerialBytestoRead;
    }
}

