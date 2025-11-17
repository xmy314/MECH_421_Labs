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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.buttonConnectSerial = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Error = new System.Windows.Forms.TextBox();
            this.textBox_temperature = new System.Windows.Forms.TextBox();
            this.label_Az = new System.Windows.Forms.Label();
            this.label_Ay = new System.Windows.Forms.Label();
            this.label_Ax = new System.Windows.Forms.Label();
            this.textBox_voltage = new System.Windows.Forms.TextBox();
            this.checkBox_saveFile = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_Filename = new System.Windows.Forms.TextBox();
            this.tempChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.serialPort_MSP430 = new System.IO.Ports.SerialPort(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempChart)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.72199F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.27801F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCOMPorts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonConnectSerial, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_saveFile, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Filename, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.tempChart, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.31169F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.781737F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.631579F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.15311F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.870813F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.658375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.373206F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.70335F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(482, 603);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 7);
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
            this.buttonConnectSerial.Size = new System.Drawing.Size(300, 49);
            this.buttonConnectSerial.TabIndex = 1;
            this.buttonConnectSerial.Text = "Connect Serial";
            this.buttonConnectSerial.UseVisualStyleBackColor = true;
            this.buttonConnectSerial.Click += new System.EventHandler(this.buttonConnectSerial_Click);
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
            this.tableLayoutPanel2.Controls.Add(this.textBox_Error, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_temperature, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_Az, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_Ay, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_Ax, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_voltage, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 445);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(476, 40);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // textBox_Error
            // 
            this.textBox_Error.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Error.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Error.Location = new System.Drawing.Point(392, 3);
            this.textBox_Error.Multiline = true;
            this.textBox_Error.Name = "textBox_Error";
            this.textBox_Error.Size = new System.Drawing.Size(81, 34);
            this.textBox_Error.TabIndex = 7;
            this.textBox_Error.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_temperature
            // 
            this.textBox_temperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_temperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_temperature.Location = new System.Drawing.Point(237, 3);
            this.textBox_temperature.Multiline = true;
            this.textBox_temperature.Name = "textBox_temperature";
            this.textBox_temperature.Size = new System.Drawing.Size(72, 34);
            this.textBox_temperature.TabIndex = 6;
            this.textBox_temperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Az
            // 
            this.label_Az.AutoSize = true;
            this.label_Az.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Az.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Az.Location = new System.Drawing.Point(315, 0);
            this.label_Az.Name = "label_Az";
            this.label_Az.Size = new System.Drawing.Size(71, 40);
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
            this.label_Ay.Size = new System.Drawing.Size(72, 40);
            this.label_Ay.TabIndex = 2;
            this.label_Ay.Text = "Temp (Celsius):";
            this.label_Ay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Ax
            // 
            this.label_Ax.AutoSize = true;
            this.label_Ax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Ax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ax.Location = new System.Drawing.Point(3, 0);
            this.label_Ax.Name = "label_Ax";
            this.label_Ax.Size = new System.Drawing.Size(68, 40);
            this.label_Ax.TabIndex = 0;
            this.label_Ax.Text = "Raw Voltage:";
            this.label_Ax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_voltage
            // 
            this.textBox_voltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_voltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_voltage.Location = new System.Drawing.Point(77, 3);
            this.textBox_voltage.Multiline = true;
            this.textBox_voltage.Name = "textBox_voltage";
            this.textBox_voltage.Size = new System.Drawing.Size(76, 34);
            this.textBox_voltage.TabIndex = 5;
            this.textBox_voltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox_saveFile
            // 
            this.checkBox_saveFile.AutoSize = true;
            this.checkBox_saveFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_saveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_saveFile.Location = new System.Drawing.Point(3, 491);
            this.checkBox_saveFile.Name = "checkBox_saveFile";
            this.checkBox_saveFile.Size = new System.Drawing.Size(170, 48);
            this.checkBox_saveFile.TabIndex = 23;
            this.checkBox_saveFile.Text = "Save to File";
            this.checkBox_saveFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_saveFile.UseVisualStyleBackColor = true;
            this.checkBox_saveFile.CheckedChanged += new System.EventHandler(this.checkBox_saveFile_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 545);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 55);
            this.button1.TabIndex = 24;
            this.button1.Text = "Select Filename";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_Filename
            // 
            this.textBox_Filename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Filename.Location = new System.Drawing.Point(179, 545);
            this.textBox_Filename.Multiline = true;
            this.textBox_Filename.Name = "textBox_Filename";
            this.textBox_Filename.Size = new System.Drawing.Size(300, 55);
            this.textBox_Filename.TabIndex = 25;
            // 
            // tempChart
            // 
            chartArea1.Name = "ChartArea1";
            this.tempChart.ChartAreas.Add(chartArea1);
            this.tableLayoutPanel1.SetColumnSpan(this.tempChart, 2);
            this.tempChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.tempChart.Legends.Add(legend1);
            this.tempChart.Location = new System.Drawing.Point(3, 138);
            this.tempChart.Name = "tempChart";
            this.tempChart.Size = new System.Drawing.Size(476, 277);
            this.tempChart.TabIndex = 26;
            this.tempChart.Text = "tempChart";
            // 
            // serialPort_MSP430
            // 
            this.serialPort_MSP430.PortName = "COM7";
            this.serialPort_MSP430.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_MSP430_DataReceived);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(170, 35);
            this.label11.TabIndex = 38;
            this.label11.Text = "Live Temperature:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Button buttonConnectSerial;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort_MSP430;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_Az;
        private System.Windows.Forms.Label label_Ay;
        private System.Windows.Forms.Label label_Ax;
        private System.Windows.Forms.TextBox textBox_voltage;
        private System.Windows.Forms.TextBox textBox_Error;
        private System.Windows.Forms.TextBox textBox_temperature;
        private System.Windows.Forms.CheckBox checkBox_saveFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_Filename;
        private System.Windows.Forms.DataVisualization.Charting.Chart tempChart;
        private System.Windows.Forms.Label label11;
    }
}

