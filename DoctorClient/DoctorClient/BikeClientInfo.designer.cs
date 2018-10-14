namespace DoctorClient
{
    partial class BikeClientInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtReqPower = new System.Windows.Forms.TextBox();
            this.txtReqDistance = new System.Windows.Forms.TextBox();
            this.distance = new System.Windows.Forms.Label();
            this.tijdtxt = new System.Windows.Forms.Label();
            this.power = new System.Windows.Forms.Label();
            this.heartrate = new System.Windows.Forms.Label();
            this.rpm = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.Label();
            this.energie = new System.Windows.Forms.Label();
            this.lblBikeInfo = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.txtRequestedPower = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtPulse = new System.Windows.Forms.TextBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.txtRPM = new System.Windows.Forms.TextBox();
            this.txtEnergy = new System.Windows.Forms.TextBox();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.oldData = new System.Windows.Forms.Button();
            this.btnPowerPlus = new System.Windows.Forms.Button();
            this.btnDistancePlus = new System.Windows.Forms.Button();
            this.deletetab = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BorderSkin.BackColor = System.Drawing.Color.DimGray;
            this.chart1.BorderSkin.BackImageTransparentColor = System.Drawing.Color.White;
            this.chart1.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(378, 160);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "Energy";
            series8.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Legend = "Legend1";
            series9.Name = "Power";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Legend = "Legend1";
            series10.Name = "Distance";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend1";
            series11.Name = "Pulse";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Legend = "Legend1";
            series12.Name = "RPM";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Legend = "Legend1";
            series13.Name = "Speed";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.Legend = "Legend1";
            series14.Name = "Requested Power";
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Series.Add(series10);
            this.chart1.Series.Add(series11);
            this.chart1.Series.Add(series12);
            this.chart1.Series.Add(series13);
            this.chart1.Series.Add(series14);
            this.chart1.Size = new System.Drawing.Size(312, 211);
            this.chart1.TabIndex = 86;
            this.chart1.Text = "chart1";
            // 
            // txtReqPower
            // 
            this.txtReqPower.BackColor = System.Drawing.Color.White;
            this.txtReqPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReqPower.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.txtReqPower.Location = new System.Drawing.Point(213, 161);
            this.txtReqPower.MaxLength = 3;
            this.txtReqPower.Multiline = true;
            this.txtReqPower.Name = "txtReqPower";
            this.txtReqPower.Size = new System.Drawing.Size(50, 25);
            this.txtReqPower.TabIndex = 78;
            this.txtReqPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReqPower.TextChanged += new System.EventHandler(this.txtReqPower_TextChanged);
            // 
            // txtReqDistance
            // 
            this.txtReqDistance.BackColor = System.Drawing.Color.White;
            this.txtReqDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReqDistance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.txtReqDistance.Location = new System.Drawing.Point(213, 131);
            this.txtReqDistance.MaxLength = 5;
            this.txtReqDistance.Multiline = true;
            this.txtReqDistance.Name = "txtReqDistance";
            this.txtReqDistance.Size = new System.Drawing.Size(50, 25);
            this.txtReqDistance.TabIndex = 77;
            this.txtReqDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReqDistance.TextChanged += new System.EventHandler(this.txtReqDistance_TextChanged);
            // 
            // distance
            // 
            this.distance.BackColor = System.Drawing.Color.White;
            this.distance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.distance.Location = new System.Drawing.Point(13, 131);
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(123, 25);
            this.distance.TabIndex = 87;
            this.distance.Text = "Distance";
            // 
            // tijdtxt
            // 
            this.tijdtxt.BackColor = System.Drawing.Color.White;
            this.tijdtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tijdtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tijdtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.tijdtxt.Location = new System.Drawing.Point(13, 161);
            this.tijdtxt.Name = "tijdtxt";
            this.tijdtxt.Size = new System.Drawing.Size(123, 25);
            this.tijdtxt.TabIndex = 89;
            this.tijdtxt.Text = "Requested power";
            // 
            // power
            // 
            this.power.BackColor = System.Drawing.Color.White;
            this.power.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.power.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.power.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.power.Location = new System.Drawing.Point(13, 192);
            this.power.Name = "power";
            this.power.Size = new System.Drawing.Size(123, 25);
            this.power.TabIndex = 90;
            this.power.Text = "Time";
            // 
            // heartrate
            // 
            this.heartrate.BackColor = System.Drawing.Color.White;
            this.heartrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.heartrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heartrate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.heartrate.Location = new System.Drawing.Point(13, 254);
            this.heartrate.Name = "heartrate";
            this.heartrate.Size = new System.Drawing.Size(123, 25);
            this.heartrate.TabIndex = 91;
            this.heartrate.Text = "Heartrate";
            // 
            // rpm
            // 
            this.rpm.BackColor = System.Drawing.Color.White;
            this.rpm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rpm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.rpm.Location = new System.Drawing.Point(13, 285);
            this.rpm.Name = "rpm";
            this.rpm.Size = new System.Drawing.Size(123, 25);
            this.rpm.TabIndex = 92;
            this.rpm.Text = "RPM";
            // 
            // speed
            // 
            this.speed.BackColor = System.Drawing.Color.White;
            this.speed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.speed.Location = new System.Drawing.Point(13, 315);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(123, 25);
            this.speed.TabIndex = 93;
            this.speed.Text = "Speed";
            // 
            // energie
            // 
            this.energie.BackColor = System.Drawing.Color.White;
            this.energie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.energie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.energie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.energie.Location = new System.Drawing.Point(13, 346);
            this.energie.Name = "energie";
            this.energie.Size = new System.Drawing.Size(123, 25);
            this.energie.TabIndex = 94;
            this.energie.Text = "Energy";
            // 
            // lblBikeInfo
            // 
            this.lblBikeInfo.BackColor = System.Drawing.Color.White;
            this.lblBikeInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBikeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBikeInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.lblBikeInfo.Location = new System.Drawing.Point(13, 90);
            this.lblBikeInfo.Name = "lblBikeInfo";
            this.lblBikeInfo.Size = new System.Drawing.Size(170, 28);
            this.lblBikeInfo.TabIndex = 95;
            this.lblBikeInfo.Text = "bikeinfo";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.BackColor = System.Drawing.Color.White;
            this.lblDateOfBirth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfBirth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.lblDateOfBirth.Location = new System.Drawing.Point(13, 45);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(123, 28);
            this.lblDateOfBirth.TabIndex = 96;
            this.lblDateOfBirth.Text = "Geboortedatum";
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.lblName.Location = new System.Drawing.Point(13, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(241, 28);
            this.lblName.TabIndex = 97;
            this.lblName.Text = "Patient naam";
            // 
            // txtDistance
            // 
            this.txtDistance.BackColor = System.Drawing.Color.White;
            this.txtDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtDistance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.txtDistance.Location = new System.Drawing.Point(142, 131);
            this.txtDistance.Multiline = true;
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(65, 25);
            this.txtDistance.TabIndex = 113;
            this.txtDistance.Text = "N/A";
            this.txtDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRequestedPower
            // 
            this.txtRequestedPower.BackColor = System.Drawing.Color.White;
            this.txtRequestedPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtRequestedPower.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.txtRequestedPower.Location = new System.Drawing.Point(142, 161);
            this.txtRequestedPower.Multiline = true;
            this.txtRequestedPower.Name = "txtRequestedPower";
            this.txtRequestedPower.Size = new System.Drawing.Size(65, 25);
            this.txtRequestedPower.TabIndex = 114;
            this.txtRequestedPower.Text = "N/A";
            this.txtRequestedPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.Color.White;
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.txtTime.Location = new System.Drawing.Point(142, 192);
            this.txtTime.Multiline = true;
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(65, 25);
            this.txtTime.TabIndex = 115;
            this.txtTime.Text = "N/A";
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPulse
            // 
            this.txtPulse.BackColor = System.Drawing.Color.White;
            this.txtPulse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPulse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.txtPulse.Location = new System.Drawing.Point(142, 254);
            this.txtPulse.Multiline = true;
            this.txtPulse.Name = "txtPulse";
            this.txtPulse.Size = new System.Drawing.Size(65, 25);
            this.txtPulse.TabIndex = 116;
            this.txtPulse.Text = "N/A";
            this.txtPulse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSpeed
            // 
            this.txtSpeed.BackColor = System.Drawing.Color.White;
            this.txtSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.txtSpeed.Location = new System.Drawing.Point(142, 316);
            this.txtSpeed.Multiline = true;
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(65, 25);
            this.txtSpeed.TabIndex = 117;
            this.txtSpeed.Text = "N/A";
            this.txtSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRPM
            // 
            this.txtRPM.BackColor = System.Drawing.Color.White;
            this.txtRPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtRPM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.txtRPM.Location = new System.Drawing.Point(142, 285);
            this.txtRPM.Multiline = true;
            this.txtRPM.Name = "txtRPM";
            this.txtRPM.Size = new System.Drawing.Size(65, 25);
            this.txtRPM.TabIndex = 118;
            this.txtRPM.Text = "N/A";
            this.txtRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEnergy
            // 
            this.txtEnergy.BackColor = System.Drawing.Color.White;
            this.txtEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtEnergy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.txtEnergy.Location = new System.Drawing.Point(142, 347);
            this.txtEnergy.Multiline = true;
            this.txtEnergy.Name = "txtEnergy";
            this.txtEnergy.Size = new System.Drawing.Size(65, 25);
            this.txtEnergy.TabIndex = 119;
            this.txtEnergy.Text = "N/A";
            this.txtEnergy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPower
            // 
            this.txtPower.BackColor = System.Drawing.Color.White;
            this.txtPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPower.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.txtPower.Location = new System.Drawing.Point(142, 223);
            this.txtPower.Multiline = true;
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(65, 25);
            this.txtPower.TabIndex = 121;
            this.txtPower.Text = "N/A";
            this.txtPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.label1.Location = new System.Drawing.Point(13, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 120;
            this.label1.Text = "Power";
            // 
            // oldData
            // 
            this.oldData.BackColor = System.Drawing.Color.White;
            this.oldData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.oldData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.oldData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.oldData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oldData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.oldData.Location = new System.Drawing.Point(547, 8);
            this.oldData.Name = "oldData";
            this.oldData.Size = new System.Drawing.Size(143, 30);
            this.oldData.TabIndex = 98;
            this.oldData.Text = "History";
            this.oldData.UseVisualStyleBackColor = false;
            this.oldData.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPowerPlus
            // 
            this.btnPowerPlus.BackColor = System.Drawing.Color.White;
            this.btnPowerPlus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.btnPowerPlus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPowerPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPowerPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btnPowerPlus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.btnPowerPlus.Location = new System.Drawing.Point(269, 160);
            this.btnPowerPlus.Name = "btnPowerPlus";
            this.btnPowerPlus.Size = new System.Drawing.Size(100, 25);
            this.btnPowerPlus.TabIndex = 123;
            this.btnPowerPlus.Text = "Change";
            this.btnPowerPlus.UseVisualStyleBackColor = false;
            this.btnPowerPlus.Click += new System.EventHandler(this.btnPowerPlus_Click);
            // 
            // btnDistancePlus
            // 
            this.btnDistancePlus.BackColor = System.Drawing.Color.White;
            this.btnDistancePlus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.btnDistancePlus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDistancePlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDistancePlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btnDistancePlus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.btnDistancePlus.Location = new System.Drawing.Point(269, 131);
            this.btnDistancePlus.Name = "btnDistancePlus";
            this.btnDistancePlus.Size = new System.Drawing.Size(100, 25);
            this.btnDistancePlus.TabIndex = 122;
            this.btnDistancePlus.Text = "Change";
            this.btnDistancePlus.UseVisualStyleBackColor = false;
            this.btnDistancePlus.Click += new System.EventHandler(this.btnDistancePlus_Click);
            // 
            // deletetab
            // 
            this.deletetab.BackColor = System.Drawing.Color.White;
            this.deletetab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.deletetab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.deletetab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.deletetab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletetab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletetab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.deletetab.Location = new System.Drawing.Point(547, 45);
            this.deletetab.Name = "deletetab";
            this.deletetab.Size = new System.Drawing.Size(143, 28);
            this.deletetab.TabIndex = 125;
            this.deletetab.Text = "Delete";
            this.deletetab.UseVisualStyleBackColor = false;
            this.deletetab.Click += new System.EventHandler(this.deletetab_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(13, 415);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(356, 23);
            this.txtMessage.TabIndex = 126;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.Color.White;
            this.btnSendMessage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.btnSendMessage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnSendMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.btnSendMessage.Location = new System.Drawing.Point(13, 378);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(194, 30);
            this.btnSendMessage.TabIndex = 127;
            this.btnSendMessage.Text = "Send message to user";
            this.btnSendMessage.UseVisualStyleBackColor = false;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.button1.Location = new System.Drawing.Point(378, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 65);
            this.button1.TabIndex = 129;
            this.button1.Text = "Send emergency stop";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // comboBox
            // 
            this.comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(378, 131);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 26);
            this.comboBox.TabIndex = 130;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // BikeClientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.deletetab);
            this.Controls.Add(this.btnPowerPlus);
            this.Controls.Add(this.btnDistancePlus);
            this.Controls.Add(this.txtPower);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEnergy);
            this.Controls.Add(this.txtRPM);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.txtPulse);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtRequestedPower);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.lblBikeInfo);
            this.Controls.Add(this.oldData);
            this.Controls.Add(this.energie);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.rpm);
            this.Controls.Add(this.heartrate);
            this.Controls.Add(this.power);
            this.Controls.Add(this.tijdtxt);
            this.Controls.Add(this.distance);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.txtReqPower);
            this.Controls.Add(this.txtReqDistance);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BikeClientInfo";
            this.Size = new System.Drawing.Size(993, 620);
            this.Load += new System.EventHandler(this.BikeClientInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox txtReqPower;
        private System.Windows.Forms.TextBox txtReqDistance;
        private System.Windows.Forms.Label distance;
        private System.Windows.Forms.Label tijdtxt;
        private System.Windows.Forms.Label power;
        private System.Windows.Forms.Label heartrate;
        private System.Windows.Forms.Label rpm;
        private System.Windows.Forms.Label speed;
        private System.Windows.Forms.Label energie;
        private System.Windows.Forms.Label lblBikeInfo;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.TextBox txtRequestedPower;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtPulse;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.TextBox txtRPM;
        private System.Windows.Forms.TextBox txtEnergy;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button oldData;
        private System.Windows.Forms.Button btnPowerPlus;
        private System.Windows.Forms.Button btnDistancePlus;
        private System.Windows.Forms.Button deletetab;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox;
    }
}
