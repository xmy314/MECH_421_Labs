namespace mech421_lab1
{
    partial class Mutli_Stepper_Controller
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxCommandStash = new System.Windows.Forms.TextBox();
            this.textBoxCommandQueue = new System.Windows.Forms.TextBox();
            this.buttonLoadCSV = new System.Windows.Forms.Button();
            this.buttonSaveCSV = new System.Windows.Forms.Button();
            this.buttonSelectCSV = new System.Windows.Forms.Button();
            this.textBoxCSVPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxXPos = new System.Windows.Forms.TextBox();
            this.textBoxYPos = new System.Windows.Forms.TextBox();
            this.textBoxVel = new System.Windows.Forms.TextBox();
            this.buttonAddToStash = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
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
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxCommandStash
            // 
            this.textBoxCommandStash.Location = new System.Drawing.Point(265, 24);
            this.textBoxCommandStash.Multiline = true;
            this.textBoxCommandStash.Name = "textBoxCommandStash";
            this.textBoxCommandStash.Size = new System.Drawing.Size(227, 131);
            this.textBoxCommandStash.TabIndex = 25;
            // 
            // textBoxCommandQueue
            // 
            this.textBoxCommandQueue.Location = new System.Drawing.Point(265, 203);
            this.textBoxCommandQueue.Multiline = true;
            this.textBoxCommandQueue.Name = "textBoxCommandQueue";
            this.textBoxCommandQueue.ReadOnly = true;
            this.textBoxCommandQueue.Size = new System.Drawing.Size(227, 143);
            this.textBoxCommandQueue.TabIndex = 26;
            // 
            // buttonLoadCSV
            // 
            this.buttonLoadCSV.Enabled = false;
            this.buttonLoadCSV.Location = new System.Drawing.Point(12, 70);
            this.buttonLoadCSV.Name = "buttonLoadCSV";
            this.buttonLoadCSV.Size = new System.Drawing.Size(100, 23);
            this.buttonLoadCSV.TabIndex = 29;
            this.buttonLoadCSV.Text = "CSV to Stash";
            this.buttonLoadCSV.UseVisualStyleBackColor = true;
            this.buttonLoadCSV.Click += new System.EventHandler(this.buttonLoadCSV_Click);
            // 
            // buttonSaveCSV
            // 
            this.buttonSaveCSV.Enabled = false;
            this.buttonSaveCSV.Location = new System.Drawing.Point(139, 70);
            this.buttonSaveCSV.Name = "buttonSaveCSV";
            this.buttonSaveCSV.Size = new System.Drawing.Size(100, 23);
            this.buttonSaveCSV.TabIndex = 28;
            this.buttonSaveCSV.Text = "Stash To CSV";
            this.buttonSaveCSV.UseVisualStyleBackColor = true;
            this.buttonSaveCSV.Click += new System.EventHandler(this.buttonSaveCSV_Click);
            // 
            // buttonSelectCSV
            // 
            this.buttonSelectCSV.Location = new System.Drawing.Point(139, 41);
            this.buttonSelectCSV.Name = "buttonSelectCSV";
            this.buttonSelectCSV.Size = new System.Drawing.Size(100, 23);
            this.buttonSelectCSV.TabIndex = 30;
            this.buttonSelectCSV.Text = "Select CSV";
            this.buttonSelectCSV.UseVisualStyleBackColor = true;
            this.buttonSelectCSV.Click += new System.EventHandler(this.buttonSelectCSV_Click);
            // 
            // textBoxCSVPath
            // 
            this.textBoxCSVPath.Location = new System.Drawing.Point(12, 44);
            this.textBoxCSVPath.Name = "textBoxCSVPath";
            this.textBoxCSVPath.ReadOnly = true;
            this.textBoxCSVPath.Size = new System.Drawing.Size(121, 20);
            this.textBoxCSVPath.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Command Stash";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Command In Queue";
            // 
            // textBoxXPos
            // 
            this.textBoxXPos.Location = new System.Drawing.Point(12, 123);
            this.textBoxXPos.Name = "textBoxXPos";
            this.textBoxXPos.Size = new System.Drawing.Size(64, 20);
            this.textBoxXPos.TabIndex = 35;
            this.textBoxXPos.TextChanged += new System.EventHandler(this.textBoxXPos_TextChanged);
            // 
            // textBoxYPos
            // 
            this.textBoxYPos.Location = new System.Drawing.Point(93, 123);
            this.textBoxYPos.Name = "textBoxYPos";
            this.textBoxYPos.Size = new System.Drawing.Size(64, 20);
            this.textBoxYPos.TabIndex = 36;
            this.textBoxYPos.TextChanged += new System.EventHandler(this.textBoxYPos_TextChanged);
            // 
            // textBoxVel
            // 
            this.textBoxVel.Location = new System.Drawing.Point(174, 123);
            this.textBoxVel.Name = "textBoxVel";
            this.textBoxVel.Size = new System.Drawing.Size(64, 20);
            this.textBoxVel.TabIndex = 37;
            this.textBoxVel.TextChanged += new System.EventHandler(this.textBoxVel_TextChanged);
            // 
            // buttonAddToStash
            // 
            this.buttonAddToStash.Location = new System.Drawing.Point(138, 149);
            this.buttonAddToStash.Name = "buttonAddToStash";
            this.buttonAddToStash.Size = new System.Drawing.Size(100, 23);
            this.buttonAddToStash.TabIndex = 38;
            this.buttonAddToStash.Text = "Add To Stash";
            this.buttonAddToStash.UseVisualStyleBackColor = true;
            this.buttonAddToStash.Click += new System.EventHandler(this.buttonAddToStash_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "X Pos [mm]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Y Pos [mm]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Vel [%]";
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(265, 161);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 23);
            this.buttonStart.TabIndex = 44;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(392, 161);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(100, 23);
            this.buttonStop.TabIndex = 43;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 45;
            this.button1.Text = "to one at a time";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(139, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 46;
            this.button2.Text = "send one";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Mutli_Stepper_Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 352);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonAddToStash);
            this.Controls.Add(this.textBoxVel);
            this.Controls.Add(this.textBoxYPos);
            this.Controls.Add(this.textBoxXPos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCSVPath);
            this.Controls.Add(this.buttonSelectCSV);
            this.Controls.Add(this.buttonLoadCSV);
            this.Controls.Add(this.buttonSaveCSV);
            this.Controls.Add(this.textBoxCommandQueue);
            this.Controls.Add(this.textBoxCommandStash);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBox1);
            this.Name = "Mutli_Stepper_Controller";
            this.Text = "Dual Stepper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxCommandStash;
        private System.Windows.Forms.TextBox textBoxCommandQueue;
        private System.Windows.Forms.Button buttonLoadCSV;
        private System.Windows.Forms.Button buttonSaveCSV;
        private System.Windows.Forms.Button buttonSelectCSV;
        private System.Windows.Forms.TextBox textBoxCSVPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxXPos;
        private System.Windows.Forms.TextBox textBoxYPos;
        private System.Windows.Forms.TextBox textBoxVel;
        private System.Windows.Forms.Button buttonAddToStash;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer2;
    }
}

