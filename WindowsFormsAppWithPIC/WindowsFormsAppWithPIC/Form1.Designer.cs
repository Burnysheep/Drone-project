namespace WindowsFormsAppWithPIC
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
            this.humidDisplay = new System.Windows.Forms.TextBox();
            this.obstructDisplay = new System.Windows.Forms.TextBox();
            this.selectPort = new System.Windows.Forms.ComboBox();
            this.buttConnect = new System.Windows.Forms.Button();
            this.buttExit = new System.Windows.Forms.Button();
            this.buttOpen = new System.Windows.Forms.Button();
            this.buttClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serialComp = new System.IO.Ports.SerialPort(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tempDisplay = new System.Windows.Forms.TextBox();
            this.buttDisconnect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.compStatus = new System.Windows.Forms.TextBox();
            this.buttLisence = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttReset = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.staffDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // humidDisplay
            // 
            this.humidDisplay.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.humidDisplay.Location = new System.Drawing.Point(190, 104);
            this.humidDisplay.Name = "humidDisplay";
            this.humidDisplay.Size = new System.Drawing.Size(150, 34);
            this.humidDisplay.TabIndex = 0;
            this.humidDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // obstructDisplay
            // 
            this.obstructDisplay.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.obstructDisplay.Location = new System.Drawing.Point(190, 228);
            this.obstructDisplay.Name = "obstructDisplay";
            this.obstructDisplay.Size = new System.Drawing.Size(150, 34);
            this.obstructDisplay.TabIndex = 2;
            this.obstructDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // selectPort
            // 
            this.selectPort.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPort.FormattingEnabled = true;
            this.selectPort.Location = new System.Drawing.Point(569, 44);
            this.selectPort.Name = "selectPort";
            this.selectPort.Size = new System.Drawing.Size(108, 33);
            this.selectPort.TabIndex = 3;
            // 
            // buttConnect
            // 
            this.buttConnect.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttConnect.Location = new System.Drawing.Point(438, 100);
            this.buttConnect.Name = "buttConnect";
            this.buttConnect.Size = new System.Drawing.Size(84, 42);
            this.buttConnect.TabIndex = 4;
            this.buttConnect.Text = "Connect";
            this.buttConnect.UseVisualStyleBackColor = true;
            this.buttConnect.Click += new System.EventHandler(this.buttConnect_Click);
            // 
            // buttExit
            // 
            this.buttExit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttExit.Location = new System.Drawing.Point(696, 100);
            this.buttExit.Name = "buttExit";
            this.buttExit.Size = new System.Drawing.Size(84, 42);
            this.buttExit.TabIndex = 6;
            this.buttExit.Text = "Exit";
            this.buttExit.UseVisualStyleBackColor = true;
            this.buttExit.Click += new System.EventHandler(this.buttExit_Click);
            // 
            // buttOpen
            // 
            this.buttOpen.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttOpen.Location = new System.Drawing.Point(438, 160);
            this.buttOpen.Name = "buttOpen";
            this.buttOpen.Size = new System.Drawing.Size(84, 42);
            this.buttOpen.TabIndex = 7;
            this.buttOpen.Text = "Open";
            this.buttOpen.UseVisualStyleBackColor = true;
            this.buttOpen.Click += new System.EventHandler(this.buttOpen_Click);
            // 
            // buttClose
            // 
            this.buttClose.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttClose.Location = new System.Drawing.Point(569, 160);
            this.buttClose.Name = "buttClose";
            this.buttClose.Size = new System.Drawing.Size(84, 42);
            this.buttClose.TabIndex = 8;
            this.buttClose.Text = "Close";
            this.buttClose.UseVisualStyleBackColor = true;
            this.buttClose.Click += new System.EventHandler(this.buttClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Temperature :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Humidity       :";
            // 
            // serialComp
            // 
            this.serialComp.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialComp_DataReceived);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(433, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Select Port :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Obstructions :";
            // 
            // tempDisplay
            // 
            this.tempDisplay.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempDisplay.Location = new System.Drawing.Point(190, 44);
            this.tempDisplay.Name = "tempDisplay";
            this.tempDisplay.Size = new System.Drawing.Size(150, 34);
            this.tempDisplay.TabIndex = 15;
            this.tempDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttDisconnect
            // 
            this.buttDisconnect.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttDisconnect.Location = new System.Drawing.Point(569, 100);
            this.buttDisconnect.Name = "buttDisconnect";
            this.buttDisconnect.Size = new System.Drawing.Size(84, 42);
            this.buttDisconnect.TabIndex = 16;
            this.buttDisconnect.Text = "Disconnect";
            this.buttDisconnect.UseVisualStyleBackColor = true;
            this.buttDisconnect.Click += new System.EventHandler(this.buttDisconnect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Comp Status :";
            // 
            // compStatus
            // 
            this.compStatus.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compStatus.Location = new System.Drawing.Point(190, 292);
            this.compStatus.Name = "compStatus";
            this.compStatus.Size = new System.Drawing.Size(150, 34);
            this.compStatus.TabIndex = 17;
            this.compStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttLisence
            // 
            this.buttLisence.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttLisence.Location = new System.Drawing.Point(696, 160);
            this.buttLisence.Name = "buttLisence";
            this.buttLisence.Size = new System.Drawing.Size(84, 42);
            this.buttLisence.TabIndex = 19;
            this.buttLisence.Text = "Lisence";
            this.buttLisence.UseVisualStyleBackColor = true;
            this.buttLisence.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(346, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "°C";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(346, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 25);
            this.label7.TabIndex = 21;
            this.label7.Text = "%";
            // 
            // buttReset
            // 
            this.buttReset.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttReset.Location = new System.Drawing.Point(569, 224);
            this.buttReset.Name = "buttReset";
            this.buttReset.Size = new System.Drawing.Size(84, 42);
            this.buttReset.TabIndex = 22;
            this.buttReset.Text = "Reset";
            this.buttReset.UseVisualStyleBackColor = true;
            this.buttReset.Click += new System.EventHandler(this.buttReset_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 25);
            this.label8.TabIndex = 24;
            this.label8.Text = "Staff              :";
            // 
            // staffDisplay
            // 
            this.staffDisplay.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffDisplay.Location = new System.Drawing.Point(190, 164);
            this.staffDisplay.Name = "staffDisplay";
            this.staffDisplay.Size = new System.Drawing.Size(150, 34);
            this.staffDisplay.TabIndex = 23;
            this.staffDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 376);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.staffDisplay);
            this.Controls.Add(this.buttReset);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttLisence);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.compStatus);
            this.Controls.Add(this.buttDisconnect);
            this.Controls.Add(this.tempDisplay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttClose);
            this.Controls.Add(this.buttOpen);
            this.Controls.Add(this.buttExit);
            this.Controls.Add(this.buttConnect);
            this.Controls.Add(this.selectPort);
            this.Controls.Add(this.obstructDisplay);
            this.Controls.Add(this.humidDisplay);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Display interface and device control";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox humidDisplay;
        private System.Windows.Forms.TextBox obstructDisplay;
        private System.Windows.Forms.ComboBox selectPort;
        private System.Windows.Forms.Button buttConnect;
        private System.Windows.Forms.Button buttExit;
        private System.Windows.Forms.Button buttOpen;
        private System.Windows.Forms.Button buttClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.IO.Ports.SerialPort serialComp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tempDisplay;
        private System.Windows.Forms.Button buttDisconnect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox compStatus;
        private System.Windows.Forms.Button buttLisence;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttReset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox staffDisplay;
    }
}

