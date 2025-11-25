namespace Receiving_DataFromMSP430
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Data = new System.Windows.Forms.TextBox();
            this.label_SerialDataStream = new System.Windows.Forms.Label();
            this.ItemsInQueue = new System.Windows.Forms.TextBox();
            this.textBox_bitRate = new System.Windows.Forms.TextBox();
            this.label_ItemsInQueue = new System.Windows.Forms.Label();
            this.label_TempStringLength = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.buttonConnectSerial = new System.Windows.Forms.Button();
            this.label_SerialBytesToRead = new System.Windows.Forms.Label();
            this.textBox_SerialBytestoRead = new System.Windows.Forms.TextBox();
            this.serialPort_MSP430 = new System.IO.Ports.SerialPort(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.75933F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.24067F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_Data, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label_SerialDataStream, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.ItemsInQueue, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_bitRate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_ItemsInQueue, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_TempStringLength, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCOMPorts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonConnectSerial, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_SerialBytesToRead, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_SerialBytestoRead, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.301824F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.824212F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.462687F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.131011F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.131011F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.658375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.131011F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.19403F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(482, 603);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox_Data
            // 
            this.textBox_Data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_Data, 2);
            this.textBox_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Data.Location = new System.Drawing.Point(3, 236);
            this.textBox_Data.Multiline = true;
            this.textBox_Data.Name = "textBox_Data";
            this.textBox_Data.Size = new System.Drawing.Size(476, 364);
            this.textBox_Data.TabIndex = 21;
            // 
            // label_SerialDataStream
            // 
            this.label_SerialDataStream.AutoSize = true;
            this.label_SerialDataStream.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SerialDataStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SerialDataStream.Location = new System.Drawing.Point(3, 190);
            this.label_SerialDataStream.Name = "label_SerialDataStream";
            this.label_SerialDataStream.Size = new System.Drawing.Size(175, 43);
            this.label_SerialDataStream.TabIndex = 16;
            this.label_SerialDataStream.Text = "Serial Data Stream:";
            this.label_SerialDataStream.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemsInQueue
            // 
            this.ItemsInQueue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemsInQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsInQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemsInQueue.Location = new System.Drawing.Point(184, 140);
            this.ItemsInQueue.Multiline = true;
            this.ItemsInQueue.Name = "ItemsInQueue";
            this.ItemsInQueue.Size = new System.Drawing.Size(295, 37);
            this.ItemsInQueue.TabIndex = 12;
            // 
            // textBox_bitRate
            // 
            this.textBox_bitRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_bitRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_bitRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_bitRate.Location = new System.Drawing.Point(184, 97);
            this.textBox_bitRate.Multiline = true;
            this.textBox_bitRate.Name = "textBox_bitRate";
            this.textBox_bitRate.Size = new System.Drawing.Size(295, 37);
            this.textBox_bitRate.TabIndex = 11;
            // 
            // label_ItemsInQueue
            // 
            this.label_ItemsInQueue.AutoSize = true;
            this.label_ItemsInQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ItemsInQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ItemsInQueue.Location = new System.Drawing.Point(3, 137);
            this.label_ItemsInQueue.Name = "label_ItemsInQueue";
            this.label_ItemsInQueue.Size = new System.Drawing.Size(175, 43);
            this.label_ItemsInQueue.TabIndex = 8;
            this.label_ItemsInQueue.Text = "Items In Queue";
            this.label_ItemsInQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_TempStringLength
            // 
            this.label_TempStringLength.AutoSize = true;
            this.label_TempStringLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_TempStringLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TempStringLength.Location = new System.Drawing.Point(3, 94);
            this.label_TempStringLength.Name = "label_TempStringLength";
            this.label_TempStringLength.Size = new System.Drawing.Size(175, 43);
            this.label_TempStringLength.TabIndex = 6;
            this.label_TempStringLength.Text = "Bit Rate:";
            this.label_TempStringLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 11);
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
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(140, 24);
            this.comboBoxCOMPorts.TabIndex = 0;
            this.comboBoxCOMPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxCOMPorts_SelectedIndexChanged);
            // 
            // buttonConnectSerial
            // 
            this.buttonConnectSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConnectSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnectSerial.Location = new System.Drawing.Point(184, 3);
            this.buttonConnectSerial.Name = "buttonConnectSerial";
            this.buttonConnectSerial.Size = new System.Drawing.Size(295, 32);
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
            this.label_SerialBytesToRead.Location = new System.Drawing.Point(3, 49);
            this.label_SerialBytesToRead.Name = "label_SerialBytesToRead";
            this.label_SerialBytesToRead.Size = new System.Drawing.Size(175, 45);
            this.label_SerialBytesToRead.TabIndex = 2;
            this.label_SerialBytesToRead.Text = "Serial Bytes to Read";
            this.label_SerialBytesToRead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_SerialBytestoRead
            // 
            this.textBox_SerialBytestoRead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_SerialBytestoRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_SerialBytestoRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SerialBytestoRead.Location = new System.Drawing.Point(184, 52);
            this.textBox_SerialBytestoRead.Multiline = true;
            this.textBox_SerialBytestoRead.Name = "textBox_SerialBytestoRead";
            this.textBox_SerialBytestoRead.Size = new System.Drawing.Size(295, 39);
            this.textBox_SerialBytestoRead.TabIndex = 9;
            // 
            // serialPort_MSP430
            // 
            this.serialPort_MSP430.BaudRate = 115200;
            this.serialPort_MSP430.PortName = "COM7";
            this.serialPort_MSP430.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_MSP430_DataReceived);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Button buttonConnectSerial;
        private System.Windows.Forms.Label label_SerialBytesToRead;
        private System.Windows.Forms.Label label_ItemsInQueue;
        private System.Windows.Forms.Label label_TempStringLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_SerialBytestoRead;
        private System.Windows.Forms.TextBox textBox_Data;
        private System.Windows.Forms.Label label_SerialDataStream;
        private System.Windows.Forms.TextBox ItemsInQueue;
        private System.Windows.Forms.TextBox textBox_bitRate;
        private System.IO.Ports.SerialPort serialPort_MSP430;
    }
}

