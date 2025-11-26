namespace mech421_lab1
{
    partial class Single_Stepper_Controller
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxVelocity = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.buttonCWStep = new System.Windows.Forms.Button();
            this.buttonCCWStep = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(139, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(100, 23);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Step Per Second";
            // 
            // textBoxVelocity
            // 
            this.textBoxVelocity.Location = new System.Drawing.Point(139, 70);
            this.textBoxVelocity.Name = "textBoxVelocity";
            this.textBoxVelocity.Size = new System.Drawing.Size(100, 20);
            this.textBoxVelocity.TabIndex = 6;
            this.textBoxVelocity.TextChanged += new System.EventHandler(this.textBoxVelocity_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerClear
            // 
            this.timerClear.Interval = 1000;
            this.timerClear.Tick += new System.EventHandler(this.timerClear_Tick);
            // 
            // buttonCWStep
            // 
            this.buttonCWStep.Location = new System.Drawing.Point(139, 41);
            this.buttonCWStep.Name = "buttonCWStep";
            this.buttonCWStep.Size = new System.Drawing.Size(100, 23);
            this.buttonCWStep.TabIndex = 21;
            this.buttonCWStep.Text = "CW Step";
            this.buttonCWStep.UseVisualStyleBackColor = true;
            this.buttonCWStep.Click += new System.EventHandler(this.buttonCWStep_Click);
            // 
            // buttonCCWStep
            // 
            this.buttonCCWStep.Location = new System.Drawing.Point(15, 41);
            this.buttonCCWStep.Name = "buttonCCWStep";
            this.buttonCCWStep.Size = new System.Drawing.Size(100, 23);
            this.buttonCCWStep.TabIndex = 22;
            this.buttonCCWStep.Text = "CCW Step";
            this.buttonCCWStep.UseVisualStyleBackColor = true;
            this.buttonCCWStep.Click += new System.EventHandler(this.buttonCCWStep_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(139, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Constant Velocity";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(15, 96);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(100, 23);
            this.buttonStop.TabIndex = 24;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // Single_Stepper_Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 137);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonCCWStep);
            this.Controls.Add(this.buttonCWStep);
            this.Controls.Add(this.textBoxVelocity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBox1);
            this.Name = "Single_Stepper_Controller";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxVelocity;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerClear;
        private System.Windows.Forms.Button buttonCWStep;
        private System.Windows.Forms.Button buttonCCWStep;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonStop;
    }
}

