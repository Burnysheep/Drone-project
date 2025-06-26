using System.Drawing;

namespace UAV
{
    partial class Drone
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this.connectButt = new System.Windows.Forms.Button();
            this.exitButt = new System.Windows.Forms.Button();
            this.angleButt = new System.Windows.Forms.Button();
            this.rateButt = new System.Windows.Forms.Button();
            this.sendButt = new System.Windows.Forms.Button();
            this.emerButt = new System.Windows.Forms.Button();
            this.calibButt = new System.Windows.Forms.Button();
            this.rollBox = new System.Windows.Forms.TextBox();
            this.pitchBox = new System.Windows.Forms.TextBox();
            this.yawBox = new System.Windows.Forms.TextBox();
            this.throttleBox = new System.Windows.Forms.TextBox();
            this.kpRollPitchAngleBox = new System.Windows.Forms.TextBox();
            this.kiRollPitchAngleBox = new System.Windows.Forms.TextBox();
            this.kdRollPitchAngleBox = new System.Windows.Forms.TextBox();
            this.kpYawAngleBox = new System.Windows.Forms.TextBox();
            this.kiYawAngleBox = new System.Windows.Forms.TextBox();
            this.kdYawAngleBox = new System.Windows.Forms.TextBox();
            this.kpRollPitchRateBox = new System.Windows.Forms.TextBox();
            this.kiRollPitchRateBox = new System.Windows.Forms.TextBox();
            this.kdRollPitchRateBox = new System.Windows.Forms.TextBox();
            this.kpYawRateBox = new System.Windows.Forms.TextBox();
            this.kiYawRateBox = new System.Windows.Forms.TextBox();
            this.kdYawRateBox = new System.Windows.Forms.TextBox();
            this.titleLable = new System.Windows.Forms.Label();
            this.rollLable = new System.Windows.Forms.Label();
            this.pitchLable = new System.Windows.Forms.Label();
            this.yawLable = new System.Windows.Forms.Label();
            this.throttleLable = new System.Windows.Forms.Label();
            this.kpLable = new System.Windows.Forms.Label();
            this.kiLable = new System.Windows.Forms.Label();
            this.kdLable = new System.Windows.Forms.Label();
            this.angleRollPitchLable = new System.Windows.Forms.Label();
            this.angleYawLable = new System.Windows.Forms.Label();
            this.rateRollPitchLable = new System.Windows.Forms.Label();
            this.rateYawLable = new System.Windows.Forms.Label();
            this.EspIP = new System.Windows.Forms.TextBox();
            this.EspPort = new System.Windows.Forms.TextBox();
            this.Esp32IP = new System.Windows.Forms.Label();
            this.Esp32Port = new System.Windows.Forms.Label();
            this.sendSPButt = new System.Windows.Forms.Button();
            this.panelTopRight = new System.Windows.Forms.Panel();
            this.ChartRoll = new ZedGraph.ZedGraphControl();
            this.panelBottomLeft = new System.Windows.Forms.Panel();
            this.ChartPitch = new ZedGraph.ZedGraphControl();
            this.panelBottomRight = new System.Windows.Forms.Panel();
            this.ChartYaw = new ZedGraph.ZedGraphControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTopLeft.SuspendLayout();
            this.panelTopRight.SuspendLayout();
            this.panelBottomLeft.SuspendLayout();
            this.panelBottomRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelTopLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelTopRight, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelBottomLeft, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelBottomRight, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTopLeft
            // 
            this.panelTopLeft.BackColor = System.Drawing.Color.LightBlue;
            this.panelTopLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopLeft.Controls.Add(this.connectButt);
            this.panelTopLeft.Controls.Add(this.exitButt);
            this.panelTopLeft.Controls.Add(this.angleButt);
            this.panelTopLeft.Controls.Add(this.rateButt);
            this.panelTopLeft.Controls.Add(this.sendButt);
            this.panelTopLeft.Controls.Add(this.emerButt);
            this.panelTopLeft.Controls.Add(this.calibButt);
            this.panelTopLeft.Controls.Add(this.rollBox);
            this.panelTopLeft.Controls.Add(this.pitchBox);
            this.panelTopLeft.Controls.Add(this.yawBox);
            this.panelTopLeft.Controls.Add(this.throttleBox);
            this.panelTopLeft.Controls.Add(this.kpRollPitchAngleBox);
            this.panelTopLeft.Controls.Add(this.kiRollPitchAngleBox);
            this.panelTopLeft.Controls.Add(this.kdRollPitchAngleBox);
            this.panelTopLeft.Controls.Add(this.kpYawAngleBox);
            this.panelTopLeft.Controls.Add(this.kiYawAngleBox);
            this.panelTopLeft.Controls.Add(this.kdYawAngleBox);
            this.panelTopLeft.Controls.Add(this.kpRollPitchRateBox);
            this.panelTopLeft.Controls.Add(this.kiRollPitchRateBox);
            this.panelTopLeft.Controls.Add(this.kdRollPitchRateBox);
            this.panelTopLeft.Controls.Add(this.kpYawRateBox);
            this.panelTopLeft.Controls.Add(this.kiYawRateBox);
            this.panelTopLeft.Controls.Add(this.kdYawRateBox);
            this.panelTopLeft.Controls.Add(this.titleLable);
            this.panelTopLeft.Controls.Add(this.rollLable);
            this.panelTopLeft.Controls.Add(this.pitchLable);
            this.panelTopLeft.Controls.Add(this.yawLable);
            this.panelTopLeft.Controls.Add(this.throttleLable);
            this.panelTopLeft.Controls.Add(this.kpLable);
            this.panelTopLeft.Controls.Add(this.kiLable);
            this.panelTopLeft.Controls.Add(this.kdLable);
            this.panelTopLeft.Controls.Add(this.angleRollPitchLable);
            this.panelTopLeft.Controls.Add(this.angleYawLable);
            this.panelTopLeft.Controls.Add(this.rateRollPitchLable);
            this.panelTopLeft.Controls.Add(this.rateYawLable);
            this.panelTopLeft.Controls.Add(this.EspIP);
            this.panelTopLeft.Controls.Add(this.EspPort);
            this.panelTopLeft.Controls.Add(this.Esp32IP);
            this.panelTopLeft.Controls.Add(this.Esp32Port);
            this.panelTopLeft.Controls.Add(this.sendSPButt);
            this.panelTopLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopLeft.Location = new System.Drawing.Point(3, 3);
            this.panelTopLeft.Name = "panelTopLeft";
            this.panelTopLeft.Size = new System.Drawing.Size(394, 294);
            this.panelTopLeft.TabIndex = 0;
            // 
            // connectButt
            // 
            this.connectButt.AutoSize = true;
            this.connectButt.BackColor = System.Drawing.Color.LawnGreen;
            this.connectButt.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButt.Location = new System.Drawing.Point(10, 50);
            this.connectButt.Name = "connectButt";
            this.connectButt.Size = new System.Drawing.Size(150, 50);
            this.connectButt.TabIndex = 0;
            this.connectButt.Text = "Connect";
            this.connectButt.UseVisualStyleBackColor = false;
            this.connectButt.Click += new System.EventHandler(this.connectButt_Click);
            // 
            // exitButt
            // 
            this.exitButt.AutoSize = true;
            this.exitButt.BackColor = System.Drawing.Color.Red;
            this.exitButt.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButt.Location = new System.Drawing.Point(200, 50);
            this.exitButt.Name = "exitButt";
            this.exitButt.Size = new System.Drawing.Size(150, 50);
            this.exitButt.TabIndex = 1;
            this.exitButt.Text = "Exit";
            this.exitButt.UseVisualStyleBackColor = false;
            this.exitButt.Click += new System.EventHandler(this.exitButt_Click);
            // 
            // angleButt
            // 
            this.angleButt.AutoSize = true;
            this.angleButt.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.angleButt.Location = new System.Drawing.Point(10, 120);
            this.angleButt.Name = "angleButt";
            this.angleButt.Size = new System.Drawing.Size(150, 50);
            this.angleButt.TabIndex = 2;
            this.angleButt.Text = "Tune Angle";
            this.angleButt.Click += new System.EventHandler(this.angleButt_Click);
            // 
            // rateButt
            // 
            this.rateButt.AutoSize = true;
            this.rateButt.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rateButt.Location = new System.Drawing.Point(200, 120);
            this.rateButt.Name = "rateButt";
            this.rateButt.Size = new System.Drawing.Size(150, 50);
            this.rateButt.TabIndex = 3;
            this.rateButt.Text = "Tune Rate";
            this.rateButt.Click += new System.EventHandler(this.rateButt_Click);
            // 
            // sendButt
            // 
            this.sendButt.AutoSize = true;
            this.sendButt.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButt.Location = new System.Drawing.Point(200, 300);
            this.sendButt.Name = "sendButt";
            this.sendButt.Size = new System.Drawing.Size(150, 50);
            this.sendButt.TabIndex = 4;
            this.sendButt.Text = "Apply PID";
            this.sendButt.Click += new System.EventHandler(this.sendButt_Click);
            // 
            // emerButt
            // 
            this.emerButt.AutoSize = true;
            this.emerButt.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emerButt.Location = new System.Drawing.Point(10, 370);
            this.emerButt.Name = "emerButt";
            this.emerButt.Size = new System.Drawing.Size(150, 50);
            this.emerButt.TabIndex = 4;
            this.emerButt.Text = "Emergency";
            this.emerButt.Click += new System.EventHandler(this.emerButt_Click);
            // 
            // calibButt
            // 
            this.calibButt.AutoSize = true;
            this.calibButt.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibButt.Location = new System.Drawing.Point(200, 370);
            this.calibButt.Name = "calibButt";
            this.calibButt.Size = new System.Drawing.Size(150, 50);
            this.calibButt.TabIndex = 4;
            this.calibButt.Text = "Calibrate";
            this.calibButt.Click += new System.EventHandler(this.calibButt_Click);
            // 
            // rollBox
            // 
            this.rollBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollBox.Location = new System.Drawing.Point(500, 60);
            this.rollBox.Name = "rollBox";
            this.rollBox.Size = new System.Drawing.Size(150, 33);
            this.rollBox.TabIndex = 5;
            // 
            // pitchBox
            // 
            this.pitchBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pitchBox.Location = new System.Drawing.Point(500, 120);
            this.pitchBox.Name = "pitchBox";
            this.pitchBox.Size = new System.Drawing.Size(150, 33);
            this.pitchBox.TabIndex = 6;
            // 
            // yawBox
            // 
            this.yawBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yawBox.Location = new System.Drawing.Point(800, 60);
            this.yawBox.Name = "yawBox";
            this.yawBox.Size = new System.Drawing.Size(150, 33);
            this.yawBox.TabIndex = 7;
            // 
            // throttleBox
            // 
            this.throttleBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.throttleBox.Location = new System.Drawing.Point(800, 120);
            this.throttleBox.Name = "throttleBox";
            this.throttleBox.Size = new System.Drawing.Size(150, 33);
            this.throttleBox.TabIndex = 8;
            // 
            // kpRollPitchAngleBox
            // 
            this.kpRollPitchAngleBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kpRollPitchAngleBox.Location = new System.Drawing.Point(550, 250);
            this.kpRollPitchAngleBox.Name = "kpRollPitchAngleBox";
            this.kpRollPitchAngleBox.Size = new System.Drawing.Size(100, 33);
            this.kpRollPitchAngleBox.TabIndex = 9;
            // 
            // kiRollPitchAngleBox
            // 
            this.kiRollPitchAngleBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kiRollPitchAngleBox.Location = new System.Drawing.Point(700, 250);
            this.kiRollPitchAngleBox.Name = "kiRollPitchAngleBox";
            this.kiRollPitchAngleBox.Size = new System.Drawing.Size(100, 33);
            this.kiRollPitchAngleBox.TabIndex = 10;
            // 
            // kdRollPitchAngleBox
            // 
            this.kdRollPitchAngleBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kdRollPitchAngleBox.Location = new System.Drawing.Point(850, 250);
            this.kdRollPitchAngleBox.Name = "kdRollPitchAngleBox";
            this.kdRollPitchAngleBox.Size = new System.Drawing.Size(100, 33);
            this.kdRollPitchAngleBox.TabIndex = 11;
            // 
            // kpYawAngleBox
            // 
            this.kpYawAngleBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kpYawAngleBox.Location = new System.Drawing.Point(550, 300);
            this.kpYawAngleBox.Name = "kpYawAngleBox";
            this.kpYawAngleBox.Size = new System.Drawing.Size(100, 33);
            this.kpYawAngleBox.TabIndex = 12;
            // 
            // kiYawAngleBox
            // 
            this.kiYawAngleBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kiYawAngleBox.Location = new System.Drawing.Point(700, 300);
            this.kiYawAngleBox.Name = "kiYawAngleBox";
            this.kiYawAngleBox.Size = new System.Drawing.Size(100, 33);
            this.kiYawAngleBox.TabIndex = 13;
            // 
            // kdYawAngleBox
            // 
            this.kdYawAngleBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kdYawAngleBox.Location = new System.Drawing.Point(850, 300);
            this.kdYawAngleBox.Name = "kdYawAngleBox";
            this.kdYawAngleBox.Size = new System.Drawing.Size(100, 33);
            this.kdYawAngleBox.TabIndex = 14;
            // 
            // kpRollPitchRateBox
            // 
            this.kpRollPitchRateBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kpRollPitchRateBox.Location = new System.Drawing.Point(550, 350);
            this.kpRollPitchRateBox.Name = "kpRollPitchRateBox";
            this.kpRollPitchRateBox.Size = new System.Drawing.Size(100, 33);
            this.kpRollPitchRateBox.TabIndex = 15;
            // 
            // kiRollPitchRateBox
            // 
            this.kiRollPitchRateBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kiRollPitchRateBox.Location = new System.Drawing.Point(700, 350);
            this.kiRollPitchRateBox.Name = "kiRollPitchRateBox";
            this.kiRollPitchRateBox.Size = new System.Drawing.Size(100, 33);
            this.kiRollPitchRateBox.TabIndex = 16;
            // 
            // kdRollPitchRateBox
            // 
            this.kdRollPitchRateBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kdRollPitchRateBox.Location = new System.Drawing.Point(850, 350);
            this.kdRollPitchRateBox.Name = "kdRollPitchRateBox";
            this.kdRollPitchRateBox.Size = new System.Drawing.Size(100, 33);
            this.kdRollPitchRateBox.TabIndex = 17;
            // 
            // kpYawRateBox
            // 
            this.kpYawRateBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kpYawRateBox.Location = new System.Drawing.Point(550, 400);
            this.kpYawRateBox.Name = "kpYawRateBox";
            this.kpYawRateBox.Size = new System.Drawing.Size(100, 33);
            this.kpYawRateBox.TabIndex = 18;
            // 
            // kiYawRateBox
            // 
            this.kiYawRateBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kiYawRateBox.Location = new System.Drawing.Point(700, 400);
            this.kiYawRateBox.Name = "kiYawRateBox";
            this.kiYawRateBox.Size = new System.Drawing.Size(100, 33);
            this.kiYawRateBox.TabIndex = 19;
            // 
            // kdYawRateBox
            // 
            this.kdYawRateBox.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kdYawRateBox.Location = new System.Drawing.Point(850, 400);
            this.kdYawRateBox.Name = "kdYawRateBox";
            this.kdYawRateBox.Size = new System.Drawing.Size(100, 33);
            this.kdYawRateBox.TabIndex = 20;
            // 
            // titleLable
            // 
            this.titleLable.AutoSize = true;
            this.titleLable.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLable.ForeColor = System.Drawing.Color.Red;
            this.titleLable.Location = new System.Drawing.Point(80, 0);
            this.titleLable.Name = "titleLable";
            this.titleLable.Size = new System.Drawing.Size(713, 37);
            this.titleLable.TabIndex = 21;
            this.titleLable.Text = "Đồ án 3: Hệ thống theo dõi và cập nhật dữ liệu Drone";
            // 
            // rollLable
            // 
            this.rollLable.AutoSize = true;
            this.rollLable.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollLable.Location = new System.Drawing.Point(400, 65);
            this.rollLable.Name = "rollLable";
            this.rollLable.Size = new System.Drawing.Size(66, 25);
            this.rollLable.TabIndex = 22;
            this.rollLable.Text = "ROLL";
            // 
            // pitchLable
            // 
            this.pitchLable.AutoSize = true;
            this.pitchLable.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pitchLable.Location = new System.Drawing.Point(400, 125);
            this.pitchLable.Name = "pitchLable";
            this.pitchLable.Size = new System.Drawing.Size(74, 25);
            this.pitchLable.TabIndex = 22;
            this.pitchLable.Text = "PITCH";
            // 
            // yawLable
            // 
            this.yawLable.AutoSize = true;
            this.yawLable.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yawLable.Location = new System.Drawing.Point(700, 65);
            this.yawLable.Name = "yawLable";
            this.yawLable.Size = new System.Drawing.Size(60, 25);
            this.yawLable.TabIndex = 22;
            this.yawLable.Text = "YAW";
            // 
            // throttleLable
            // 
            this.throttleLable.AutoSize = true;
            this.throttleLable.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.throttleLable.Location = new System.Drawing.Point(700, 125);
            this.throttleLable.Name = "throttleLable";
            this.throttleLable.Size = new System.Drawing.Size(55, 25);
            this.throttleLable.TabIndex = 22;
            this.throttleLable.Text = "THR";
            // 
            // kpLable
            // 
            this.kpLable.AutoSize = true;
            this.kpLable.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kpLable.Location = new System.Drawing.Point(575, 200);
            this.kpLable.Name = "kpLable";
            this.kpLable.Size = new System.Drawing.Size(39, 25);
            this.kpLable.TabIndex = 22;
            this.kpLable.Text = "KP";
            // 
            // kiLable
            // 
            this.kiLable.AutoSize = true;
            this.kiLable.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kiLable.Location = new System.Drawing.Point(725, 200);
            this.kiLable.Name = "kiLable";
            this.kiLable.Size = new System.Drawing.Size(33, 25);
            this.kiLable.TabIndex = 22;
            this.kiLable.Text = "KI";
            // 
            // kdLable
            // 
            this.kdLable.AutoSize = true;
            this.kdLable.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kdLable.Location = new System.Drawing.Point(875, 200);
            this.kdLable.Name = "kdLable";
            this.kdLable.Size = new System.Drawing.Size(43, 25);
            this.kdLable.TabIndex = 22;
            this.kdLable.Text = "KD";
            // 
            // angleRollPitchLable
            // 
            this.angleRollPitchLable.AutoSize = true;
            this.angleRollPitchLable.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.angleRollPitchLable.Location = new System.Drawing.Point(400, 250);
            this.angleRollPitchLable.Name = "angleRollPitchLable";
            this.angleRollPitchLable.Size = new System.Drawing.Size(123, 25);
            this.angleRollPitchLable.TabIndex = 22;
            this.angleRollPitchLable.Text = "ANGLE R/P";
            // 
            // angleYawLable
            // 
            this.angleYawLable.AutoSize = true;
            this.angleYawLable.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.angleYawLable.Location = new System.Drawing.Point(400, 300);
            this.angleYawLable.Name = "angleYawLable";
            this.angleYawLable.Size = new System.Drawing.Size(106, 25);
            this.angleYawLable.TabIndex = 22;
            this.angleYawLable.Text = "ANGLE Y";
            // 
            // rateRollPitchLable
            // 
            this.rateRollPitchLable.AutoSize = true;
            this.rateRollPitchLable.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rateRollPitchLable.Location = new System.Drawing.Point(400, 350);
            this.rateRollPitchLable.Name = "rateRollPitchLable";
            this.rateRollPitchLable.Size = new System.Drawing.Size(105, 25);
            this.rateRollPitchLable.TabIndex = 22;
            this.rateRollPitchLable.Text = "RATE R/P";
            // 
            // rateYawLable
            // 
            this.rateYawLable.AutoSize = true;
            this.rateYawLable.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rateYawLable.Location = new System.Drawing.Point(400, 400);
            this.rateYawLable.Name = "rateYawLable";
            this.rateYawLable.Size = new System.Drawing.Size(88, 25);
            this.rateYawLable.TabIndex = 22;
            this.rateYawLable.Text = "RATE Y";
            // 
            // EspIP
            // 
            this.EspIP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EspIP.Location = new System.Drawing.Point(10, 250);
            this.EspIP.Name = "EspIP";
            this.EspIP.Size = new System.Drawing.Size(150, 30);
            this.EspIP.TabIndex = 20;
            // 
            // EspPort
            // 
            this.EspPort.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EspPort.Location = new System.Drawing.Point(200, 250);
            this.EspPort.Name = "EspPort";
            this.EspPort.Size = new System.Drawing.Size(150, 30);
            this.EspPort.TabIndex = 20;
            // 
            // Esp32IP
            // 
            this.Esp32IP.AutoSize = true;
            this.Esp32IP.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Esp32IP.Location = new System.Drawing.Point(10, 200);
            this.Esp32IP.Name = "Esp32IP";
            this.Esp32IP.Size = new System.Drawing.Size(133, 25);
            this.Esp32IP.TabIndex = 22;
            this.Esp32IP.Text = "IP ADDRESS";
            // 
            // Esp32Port
            // 
            this.Esp32Port.AutoSize = true;
            this.Esp32Port.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Esp32Port.Location = new System.Drawing.Point(200, 200);
            this.Esp32Port.Name = "Esp32Port";
            this.Esp32Port.Size = new System.Drawing.Size(67, 25);
            this.Esp32Port.TabIndex = 22;
            this.Esp32Port.Text = "PORT";
            // 
            // sendSPButt
            // 
            this.sendSPButt.AutoSize = true;
            this.sendSPButt.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendSPButt.Location = new System.Drawing.Point(10, 300);
            this.sendSPButt.Name = "sendSPButt";
            this.sendSPButt.Size = new System.Drawing.Size(150, 50);
            this.sendSPButt.TabIndex = 4;
            this.sendSPButt.Text = "Apply SP";
            this.sendSPButt.Click += new System.EventHandler(this.sendSPButt_Click);
            // 
            // panelTopRight
            // 
            this.panelTopRight.BackColor = System.Drawing.Color.LightGreen;
            this.panelTopRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopRight.Controls.Add(this.ChartRoll);
            this.panelTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopRight.Location = new System.Drawing.Point(403, 3);
            this.panelTopRight.Name = "panelTopRight";
            this.panelTopRight.Size = new System.Drawing.Size(394, 294);
            this.panelTopRight.TabIndex = 1;
            // 
            // ChartRoll
            // 
            this.ChartRoll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartRoll.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChartRoll.Location = new System.Drawing.Point(0, 0);
            this.ChartRoll.Margin = new System.Windows.Forms.Padding(4);
            this.ChartRoll.Name = "ChartRoll";
            this.ChartRoll.ScrollGrace = 0D;
            this.ChartRoll.ScrollMaxX = 0D;
            this.ChartRoll.ScrollMaxY = 0D;
            this.ChartRoll.ScrollMaxY2 = 0D;
            this.ChartRoll.ScrollMinX = 0D;
            this.ChartRoll.ScrollMinY = 0D;
            this.ChartRoll.ScrollMinY2 = 0D;
            this.ChartRoll.Size = new System.Drawing.Size(392, 292);
            this.ChartRoll.TabIndex = 15;
            this.ChartRoll.UseExtendedPrintDialog = true;
            // 
            // panelBottomLeft
            // 
            this.panelBottomLeft.BackColor = System.Drawing.Color.LightYellow;
            this.panelBottomLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottomLeft.Controls.Add(this.ChartPitch);
            this.panelBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomLeft.Location = new System.Drawing.Point(3, 303);
            this.panelBottomLeft.Name = "panelBottomLeft";
            this.panelBottomLeft.Size = new System.Drawing.Size(394, 294);
            this.panelBottomLeft.TabIndex = 2;
            // 
            // ChartPitch
            // 
            this.ChartPitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartPitch.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChartPitch.Location = new System.Drawing.Point(0, 0);
            this.ChartPitch.Margin = new System.Windows.Forms.Padding(4);
            this.ChartPitch.Name = "ChartPitch";
            this.ChartPitch.ScrollGrace = 0D;
            this.ChartPitch.ScrollMaxX = 0D;
            this.ChartPitch.ScrollMaxY = 0D;
            this.ChartPitch.ScrollMaxY2 = 0D;
            this.ChartPitch.ScrollMinX = 0D;
            this.ChartPitch.ScrollMinY = 0D;
            this.ChartPitch.ScrollMinY2 = 0D;
            this.ChartPitch.Size = new System.Drawing.Size(392, 292);
            this.ChartPitch.TabIndex = 16;
            this.ChartPitch.UseExtendedPrintDialog = true;
            // 
            // panelBottomRight
            // 
            this.panelBottomRight.BackColor = System.Drawing.Color.LightCoral;
            this.panelBottomRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottomRight.Controls.Add(this.ChartYaw);
            this.panelBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomRight.Location = new System.Drawing.Point(403, 303);
            this.panelBottomRight.Name = "panelBottomRight";
            this.panelBottomRight.Size = new System.Drawing.Size(394, 294);
            this.panelBottomRight.TabIndex = 3;
            // 
            // ChartYaw
            // 
            this.ChartYaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartYaw.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChartYaw.Location = new System.Drawing.Point(0, 0);
            this.ChartYaw.Margin = new System.Windows.Forms.Padding(4);
            this.ChartYaw.Name = "ChartYaw";
            this.ChartYaw.ScrollGrace = 0D;
            this.ChartYaw.ScrollMaxX = 0D;
            this.ChartYaw.ScrollMaxY = 0D;
            this.ChartYaw.ScrollMaxY2 = 0D;
            this.ChartYaw.ScrollMinX = 0D;
            this.ChartYaw.ScrollMinY = 0D;
            this.ChartYaw.ScrollMinY2 = 0D;
            this.ChartYaw.Size = new System.Drawing.Size(392, 292);
            this.ChartYaw.TabIndex = 17;
            this.ChartYaw.UseExtendedPrintDialog = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Drone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Drone";
            this.Text = "Drone Control";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Drone_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTopLeft.ResumeLayout(false);
            this.panelTopLeft.PerformLayout();
            this.panelTopRight.ResumeLayout(false);
            this.panelBottomLeft.ResumeLayout(false);
            this.panelBottomRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTopLeft;
        private System.Windows.Forms.Panel panelTopRight;
        private System.Windows.Forms.Panel panelBottomLeft;
        private System.Windows.Forms.Panel panelBottomRight;

        private ZedGraph.ZedGraphControl ChartRoll;
        private ZedGraph.ZedGraphControl ChartPitch;
        private ZedGraph.ZedGraphControl ChartYaw;

        private System.Windows.Forms.Button connectButt;
        private System.Windows.Forms.Button exitButt;
        private System.Windows.Forms.Button angleButt;
        private System.Windows.Forms.Button rateButt;
        private System.Windows.Forms.Button sendButt;
        private System.Windows.Forms.Button sendSPButt;
        private System.Windows.Forms.Button emerButt;
        private System.Windows.Forms.Button calibButt;

        private System.Windows.Forms.TextBox rollBox;
        private System.Windows.Forms.TextBox pitchBox;
        private System.Windows.Forms.TextBox yawBox;
        private System.Windows.Forms.TextBox throttleBox;
        private System.Windows.Forms.TextBox kpRollPitchAngleBox;
        private System.Windows.Forms.TextBox kiRollPitchAngleBox;
        private System.Windows.Forms.TextBox kdRollPitchAngleBox;
        private System.Windows.Forms.TextBox kpYawAngleBox;
        private System.Windows.Forms.TextBox kiYawAngleBox;
        private System.Windows.Forms.TextBox kdYawAngleBox;
        private System.Windows.Forms.TextBox kpRollPitchRateBox;
        private System.Windows.Forms.TextBox kiRollPitchRateBox;
        private System.Windows.Forms.TextBox kdRollPitchRateBox;
        private System.Windows.Forms.TextBox kpYawRateBox;
        private System.Windows.Forms.TextBox kiYawRateBox;
        private System.Windows.Forms.TextBox kdYawRateBox;
        private System.Windows.Forms.TextBox EspIP;
        private System.Windows.Forms.TextBox EspPort;

        private System.Windows.Forms.Label Esp32IP;
        private System.Windows.Forms.Label Esp32Port;
        private System.Windows.Forms.Label titleLable;
        private System.Windows.Forms.Label rollLable;
        private System.Windows.Forms.Label pitchLable;
        private System.Windows.Forms.Label yawLable;
        private System.Windows.Forms.Label throttleLable;
        private System.Windows.Forms.Label angleRollPitchLable;
        private System.Windows.Forms.Label angleYawLable;
        private System.Windows.Forms.Label rateRollPitchLable;
        private System.Windows.Forms.Label rateYawLable;
        private System.Windows.Forms.Label kpLable;
        private System.Windows.Forms.Label kiLable;
        private System.Windows.Forms.Label kdLable;
        public System.Windows.Forms.Timer timer1;
    }
}
