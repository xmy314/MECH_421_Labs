namespace ParsingDataFromMSP430
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
            this.textBox_TempStringLength = new System.Windows.Forms.TextBox();
            this.label_ItemsInQueue = new System.Windows.Forms.Label();
            this.label_TempStringLength = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.buttonConnectSerial = new System.Windows.Forms.Button();
            this.label_SerialBytesToRead = new System.Windows.Forms.Label();
            this.textBox_SerialBytestoRead = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Az = new System.Windows.Forms.TextBox();
            this.textBox_Ay = new System.Windows.Forms.TextBox();
            this.label_Az = new System.Windows.Forms.Label();
            this.label_Ay = new System.Windows.Forms.Label();
            this.label_Ax = new System.Windows.Forms.Label();
            this.textBox_Ax = new System.Windows.Forms.TextBox();
            this.label_Orientation = new System.Windows.Forms.Label();
            this.textBox_Orientation = new System.Windows.Forms.TextBox();
            this.serialPort_MSP430 = new System.IO.Ports.SerialPort(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.75933F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.24067F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_Data, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label_SerialDataStream, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.ItemsInQueue, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_TempStringLength, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_ItemsInQueue, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_TempStringLength, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCOMPorts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonConnectSerial, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_SerialBytesToRead, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_SerialBytestoRead, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label_Orientation, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Orientation, 1, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.301824F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.824212F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.462687F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.131011F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.131011F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.658375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.131011F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.19403F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(643, 742);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox_Data
            // 
            this.textBox_Data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_Data, 2);
            this.textBox_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Data.Location = new System.Drawing.Point(4, 251);
            this.textBox_Data.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Data.Multiline = true;
            this.textBox_Data.Name = "textBox_Data";
            this.textBox_Data.Size = new System.Drawing.Size(635, 388);
            this.textBox_Data.TabIndex = 21;
            // 
            // label_SerialDataStream
            // 
            this.label_SerialDataStream.AutoSize = true;
            this.label_SerialDataStream.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SerialDataStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SerialDataStream.Location = new System.Drawing.Point(4, 201);
            this.label_SerialDataStream.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_SerialDataStream.Name = "label_SerialDataStream";
            this.label_SerialDataStream.Size = new System.Drawing.Size(234, 46);
            this.label_SerialDataStream.TabIndex = 16;
            this.label_SerialDataStream.Text = "Serial Data Stream:";
            this.label_SerialDataStream.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemsInQueue
            // 
            this.ItemsInQueue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemsInQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsInQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemsInQueue.Location = new System.Drawing.Point(246, 149);
            this.ItemsInQueue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ItemsInQueue.Multiline = true;
            this.ItemsInQueue.Name = "ItemsInQueue";
            this.ItemsInQueue.Size = new System.Drawing.Size(393, 38);
            this.ItemsInQueue.TabIndex = 12;
            // 
            // textBox_TempStringLength
            // 
            this.textBox_TempStringLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_TempStringLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_TempStringLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TempStringLength.Location = new System.Drawing.Point(246, 103);
            this.textBox_TempStringLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_TempStringLength.Multiline = true;
            this.textBox_TempStringLength.Name = "textBox_TempStringLength";
            this.textBox_TempStringLength.Size = new System.Drawing.Size(393, 38);
            this.textBox_TempStringLength.TabIndex = 11;
            // 
            // label_ItemsInQueue
            // 
            this.label_ItemsInQueue.AutoSize = true;
            this.label_ItemsInQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ItemsInQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ItemsInQueue.Location = new System.Drawing.Point(4, 145);
            this.label_ItemsInQueue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ItemsInQueue.Name = "label_ItemsInQueue";
            this.label_ItemsInQueue.Size = new System.Drawing.Size(234, 46);
            this.label_ItemsInQueue.TabIndex = 8;
            this.label_ItemsInQueue.Text = "Items In Queue";
            this.label_ItemsInQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_TempStringLength
            // 
            this.label_TempStringLength.AutoSize = true;
            this.label_TempStringLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_TempStringLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TempStringLength.Location = new System.Drawing.Point(4, 99);
            this.label_TempStringLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_TempStringLength.Name = "label_TempStringLength";
            this.label_TempStringLength.Size = new System.Drawing.Size(234, 46);
            this.label_TempStringLength.TabIndex = 6;
            this.label_TempStringLength.Text = "Temp String Length";
            this.label_TempStringLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 11);
            this.label1.TabIndex = 3;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxCOMPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(4, 4);
            this.comboBoxCOMPorts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(234, 28);
            this.comboBoxCOMPorts.TabIndex = 0;
            this.comboBoxCOMPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxCOMPorts_SelectedIndexChanged);
            // 
            // buttonConnectSerial
            // 
            this.buttonConnectSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConnectSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnectSerial.Location = new System.Drawing.Point(246, 4);
            this.buttonConnectSerial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonConnectSerial.Name = "buttonConnectSerial";
            this.buttonConnectSerial.Size = new System.Drawing.Size(393, 32);
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
            this.label_SerialBytesToRead.Location = new System.Drawing.Point(4, 51);
            this.label_SerialBytesToRead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_SerialBytesToRead.Name = "label_SerialBytesToRead";
            this.label_SerialBytesToRead.Size = new System.Drawing.Size(234, 48);
            this.label_SerialBytesToRead.TabIndex = 2;
            this.label_SerialBytesToRead.Text = "Serial Bytes to Read";
            this.label_SerialBytesToRead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_SerialBytestoRead
            // 
            this.textBox_SerialBytestoRead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_SerialBytestoRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_SerialBytestoRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SerialBytestoRead.Location = new System.Drawing.Point(246, 55);
            this.textBox_SerialBytestoRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_SerialBytestoRead.Multiline = true;
            this.textBox_SerialBytestoRead.Name = "textBox_SerialBytestoRead";
            this.textBox_SerialBytestoRead.Size = new System.Drawing.Size(393, 40);
            this.textBox_SerialBytestoRead.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel2.Controls.Add(this.textBox_Az, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Ay, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_Az, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_Ay, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_Ax, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Ax, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 658);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(635, 38);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // textBox_Az
            // 
            this.textBox_Az.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Az.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Az.Location = new System.Drawing.Point(490, 4);
            this.textBox_Az.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Az.Multiline = true;
            this.textBox_Az.Name = "textBox_Az";
            this.textBox_Az.Size = new System.Drawing.Size(141, 30);
            this.textBox_Az.TabIndex = 7;
            // 
            // textBox_Ay
            // 
            this.textBox_Ay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Ay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ay.Location = new System.Drawing.Point(279, 4);
            this.textBox_Ay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Ay.Multiline = true;
            this.textBox_Ay.Name = "textBox_Ay";
            this.textBox_Ay.Size = new System.Drawing.Size(139, 30);
            this.textBox_Ay.TabIndex = 6;
            // 
            // label_Az
            // 
            this.label_Az.AutoSize = true;
            this.label_Az.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Az.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Az.Location = new System.Drawing.Point(426, 0);
            this.label_Az.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Az.Name = "label_Az";
            this.label_Az.Size = new System.Drawing.Size(56, 38);
            this.label_Az.TabIndex = 4;
            this.label_Az.Text = "Az:";
            this.label_Az.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Ay
            // 
            this.label_Ay.AutoSize = true;
            this.label_Ay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Ay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ay.Location = new System.Drawing.Point(215, 0);
            this.label_Ay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Ay.Name = "label_Ay";
            this.label_Ay.Size = new System.Drawing.Size(56, 38);
            this.label_Ay.TabIndex = 2;
            this.label_Ay.Text = "Ay:";
            this.label_Ay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Ax
            // 
            this.label_Ax.AutoSize = true;
            this.label_Ax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Ax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ax.Location = new System.Drawing.Point(4, 0);
            this.label_Ax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Ax.Name = "label_Ax";
            this.label_Ax.Size = new System.Drawing.Size(56, 38);
            this.label_Ax.TabIndex = 0;
            this.label_Ax.Text = "Ax:";
            this.label_Ax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Ax
            // 
            this.textBox_Ax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Ax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ax.Location = new System.Drawing.Point(68, 4);
            this.textBox_Ax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Ax.Multiline = true;
            this.textBox_Ax.Name = "textBox_Ax";
            this.textBox_Ax.Size = new System.Drawing.Size(139, 30);
            this.textBox_Ax.TabIndex = 5;
            // 
            // label_Orientation
            // 
            this.label_Orientation.AutoSize = true;
            this.label_Orientation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Orientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Orientation.Location = new System.Drawing.Point(4, 700);
            this.label_Orientation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Orientation.Name = "label_Orientation";
            this.label_Orientation.Size = new System.Drawing.Size(234, 42);
            this.label_Orientation.TabIndex = 23;
            this.label_Orientation.Text = "Orientation: ";
            this.label_Orientation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Orientation
            // 
            this.textBox_Orientation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Orientation.Location = new System.Drawing.Point(246, 704);
            this.textBox_Orientation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Orientation.Multiline = true;
            this.textBox_Orientation.Name = "textBox_Orientation";
            this.textBox_Orientation.Size = new System.Drawing.Size(393, 34);
            this.textBox_Orientation.TabIndex = 24;
            // 
            // serialPort_MSP430
            // 
            this.serialPort_MSP430.PortName = "COM7";
            this.serialPort_MSP430.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_MSP430_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 742);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.TextBox textBox_TempStringLength;
        private System.IO.Ports.SerialPort serialPort_MSP430;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_Az;
        private System.Windows.Forms.Label label_Ay;
        private System.Windows.Forms.Label label_Ax;
        private System.Windows.Forms.TextBox textBox_Ax;
        private System.Windows.Forms.TextBox textBox_Az;
        private System.Windows.Forms.TextBox textBox_Ay;
        private System.Windows.Forms.Label label_Orientation;
        private System.Windows.Forms.TextBox textBox_Orientation;
    }
}

