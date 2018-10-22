namespace BikeClient
{
    partial class SimulatorGUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lblRequestedPower = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblPulse = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRPM = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPower = new System.Windows.Forms.Label();
            this.lblEnergy = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.btnDistance = new System.Windows.Forms.Button();
            this.btnTime = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.btnRequestedPower = new System.Windows.Forms.Button();
            this.txtRequestedPower = new System.Windows.Forms.TextBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSendAndReceive = new System.Windows.Forms.Button();
            this.txbJSON = new System.Windows.Forms.RichTextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.labelWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.MinimumSize = new System.Drawing.Size(320, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Afstand";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 179);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.MinimumSize = new System.Drawing.Size(320, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "Verzocht vermogen";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 240);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.MinimumSize = new System.Drawing.Size(320, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(320, 50);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tijd";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblDistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDistance.Location = new System.Drawing.Point(573, 121);
            this.lblDistance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDistance.MinimumSize = new System.Drawing.Size(170, 50);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(170, 50);
            this.lblDistance.TabIndex = 9;
            this.lblDistance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRequestedPower
            // 
            this.lblRequestedPower.AutoSize = true;
            this.lblRequestedPower.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRequestedPower.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRequestedPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestedPower.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRequestedPower.Location = new System.Drawing.Point(573, 181);
            this.lblRequestedPower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRequestedPower.MinimumSize = new System.Drawing.Size(170, 50);
            this.lblRequestedPower.Name = "lblRequestedPower";
            this.lblRequestedPower.Size = new System.Drawing.Size(170, 50);
            this.lblRequestedPower.TabIndex = 10;
            this.lblRequestedPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.White;
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTime.Location = new System.Drawing.Point(572, 242);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.MinimumSize = new System.Drawing.Size(170, 50);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(170, 50);
            this.lblTime.TabIndex = 11;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPulse
            // 
            this.lblPulse.AutoSize = true;
            this.lblPulse.BackColor = System.Drawing.Color.White;
            this.lblPulse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPulse.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPulse.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPulse.Location = new System.Drawing.Point(571, 387);
            this.lblPulse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPulse.MinimumSize = new System.Drawing.Size(170, 50);
            this.lblPulse.Name = "lblPulse";
            this.lblPulse.Size = new System.Drawing.Size(170, 50);
            this.lblPulse.TabIndex = 13;
            this.lblPulse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 385);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.MinimumSize = new System.Drawing.Size(320, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(320, 50);
            this.label8.TabIndex = 12;
            this.label8.Text = "Hartslag";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 446);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.MinimumSize = new System.Drawing.Size(320, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(320, 50);
            this.label9.TabIndex = 14;
            this.label9.Text = "RPM";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRPM
            // 
            this.lblRPM.AutoSize = true;
            this.lblRPM.BackColor = System.Drawing.Color.White;
            this.lblRPM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRPM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRPM.Location = new System.Drawing.Point(571, 448);
            this.lblRPM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRPM.MinimumSize = new System.Drawing.Size(170, 50);
            this.lblRPM.Name = "lblRPM";
            this.lblRPM.Size = new System.Drawing.Size(170, 50);
            this.lblRPM.TabIndex = 15;
            this.lblRPM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(22, 506);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.MinimumSize = new System.Drawing.Size(320, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(320, 50);
            this.label11.TabIndex = 16;
            this.label11.Text = "Snelheid";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.BackColor = System.Drawing.Color.White;
            this.lblSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSpeed.Location = new System.Drawing.Point(571, 508);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeed.MinimumSize = new System.Drawing.Size(170, 50);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(170, 50);
            this.lblSpeed.TabIndex = 17;
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Silver;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(23, 13);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.MinimumSize = new System.Drawing.Size(320, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(339, 60);
            this.label13.TabIndex = 18;
            this.label13.Text = "Selecteer verbinding:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPorts
            // 
            this.cmbPorts.BackColor = System.Drawing.Color.White;
            this.cmbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(370, 13);
            this.cmbPorts.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPorts.MinimumSize = new System.Drawing.Size(370, 0);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(370, 56);
            this.cmbPorts.TabIndex = 19;
            this.cmbPorts.SelectedIndexChanged += new System.EventHandler(this.CmbPorts_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(22, 324);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.MinimumSize = new System.Drawing.Size(320, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(320, 50);
            this.label14.TabIndex = 20;
            this.label14.Text = "Vermogen";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.BackColor = System.Drawing.Color.White;
            this.lblPower.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPower.Location = new System.Drawing.Point(572, 326);
            this.lblPower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPower.MinimumSize = new System.Drawing.Size(170, 50);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(170, 50);
            this.lblPower.TabIndex = 21;
            this.lblPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnergy
            // 
            this.lblEnergy.AutoSize = true;
            this.lblEnergy.BackColor = System.Drawing.Color.White;
            this.lblEnergy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnergy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEnergy.Location = new System.Drawing.Point(571, 569);
            this.lblEnergy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnergy.MinimumSize = new System.Drawing.Size(170, 50);
            this.lblEnergy.Name = "lblEnergy";
            this.lblEnergy.Size = new System.Drawing.Size(170, 50);
            this.lblEnergy.TabIndex = 23;
            this.lblEnergy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 567);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.MinimumSize = new System.Drawing.Size(320, 50);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(320, 50);
            this.label5.TabIndex = 22;
            this.label5.Text = "Energie";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDistance
            // 
            this.txtDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtDistance.Location = new System.Drawing.Point(370, 121);
            this.txtDistance.MinimumSize = new System.Drawing.Size(4, 50);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(129, 45);
            this.txtDistance.TabIndex = 24;
            // 
            // btnDistance
            // 
            this.btnDistance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.btnDistance.Location = new System.Drawing.Point(505, 121);
            this.btnDistance.MinimumSize = new System.Drawing.Size(50, 50);
            this.btnDistance.Name = "btnDistance";
            this.btnDistance.Size = new System.Drawing.Size(50, 50);
            this.btnDistance.TabIndex = 25;
            this.btnDistance.UseVisualStyleBackColor = false;
            this.btnDistance.Click += new System.EventHandler(this.BtnDistance_Click);
            // 
            // btnTime
            // 
            this.btnTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.btnTime.Location = new System.Drawing.Point(504, 242);
            this.btnTime.MinimumSize = new System.Drawing.Size(50, 50);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(50, 50);
            this.btnTime.TabIndex = 27;
            this.btnTime.UseVisualStyleBackColor = false;
            this.btnTime.Click += new System.EventHandler(this.BtnTime_Click);
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtTime.Location = new System.Drawing.Point(369, 242);
            this.txtTime.MinimumSize = new System.Drawing.Size(4, 50);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(129, 45);
            this.txtTime.TabIndex = 26;
            // 
            // btnRequestedPower
            // 
            this.btnRequestedPower.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRequestedPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.btnRequestedPower.Location = new System.Drawing.Point(505, 181);
            this.btnRequestedPower.MinimumSize = new System.Drawing.Size(50, 50);
            this.btnRequestedPower.Name = "btnRequestedPower";
            this.btnRequestedPower.Size = new System.Drawing.Size(50, 50);
            this.btnRequestedPower.TabIndex = 29;
            this.btnRequestedPower.UseVisualStyleBackColor = false;
            this.btnRequestedPower.Click += new System.EventHandler(this.BtnRequestedPower_Click);
            // 
            // txtRequestedPower
            // 
            this.txtRequestedPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtRequestedPower.Location = new System.Drawing.Point(369, 181);
            this.txtRequestedPower.MinimumSize = new System.Drawing.Size(4, 50);
            this.txtRequestedPower.Name = "txtRequestedPower";
            this.txtRequestedPower.Size = new System.Drawing.Size(129, 45);
            this.txtRequestedPower.TabIndex = 28;
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtCommand.Location = new System.Drawing.Point(761, 18);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(244, 45);
            this.txtCommand.TabIndex = 30;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnSend.Location = new System.Drawing.Point(761, 118);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(250, 50);
            this.btnSend.TabIndex = 31;
            this.btnSend.Text = "send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // btnSendAndReceive
            // 
            this.btnSendAndReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnSendAndReceive.Location = new System.Drawing.Point(1017, 118);
            this.btnSendAndReceive.Name = "btnSendAndReceive";
            this.btnSendAndReceive.Size = new System.Drawing.Size(250, 50);
            this.btnSendAndReceive.TabIndex = 32;
            this.btnSendAndReceive.Text = "send and receive";
            this.btnSendAndReceive.UseVisualStyleBackColor = true;
            this.btnSendAndReceive.Click += new System.EventHandler(this.BtnSendAndReceive_Click);
            // 
            // txbJSON
            // 
            this.txbJSON.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txbJSON.Location = new System.Drawing.Point(761, 181);
            this.txbJSON.Name = "txbJSON";
            this.txbJSON.Size = new System.Drawing.Size(497, 303);
            this.txbJSON.TabIndex = 33;
            this.txbJSON.Text = "";
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.Gray;
            this.trackBar1.Location = new System.Drawing.Point(761, 553);
            this.trackBar1.Maximum = 24;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(489, 56);
            this.trackBar1.TabIndex = 36;
            this.trackBar1.Value = 12;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(802, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 15);
            this.label4.TabIndex = 37;
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.BackColor = System.Drawing.Color.White;
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarning.Location = new System.Drawing.Point(763, 385);
            this.labelWarning.MinimumSize = new System.Drawing.Size(450, 80);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(450, 80);
            this.labelWarning.TabIndex = 38;
            this.labelWarning.UseWaitCursor = true;
            // 
            // SimulatorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1270, 625);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.txbJSON);
            this.Controls.Add(this.btnSendAndReceive);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.btnRequestedPower);
            this.Controls.Add(this.txtRequestedPower);
            this.Controls.Add(this.btnTime);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.btnDistance);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.lblEnergy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPower);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbPorts);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblRPM);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblPulse);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblRequestedPower);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SimulatorGUI";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lblRequestedPower;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblPulse;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRPM;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.Label lblEnergy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Button btnDistance;
        private System.Windows.Forms.Button btnTime;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Button btnRequestedPower;
        private System.Windows.Forms.TextBox txtRequestedPower;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSendAndReceive;
        private System.Windows.Forms.RichTextBox txbJSON;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelWarning;
    }
}

