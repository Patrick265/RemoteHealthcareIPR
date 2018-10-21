namespace DoctorClient
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DatesBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PulseChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PowerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RPMChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PulseChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PowerChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RPMChart)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.DatesBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(956, 571);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // DatesBox
            // 
            this.DatesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatesBox.ItemHeight = 16;
            this.DatesBox.Location = new System.Drawing.Point(10, 10);
            this.DatesBox.Margin = new System.Windows.Forms.Padding(10);
            this.DatesBox.Name = "DatesBox";
            this.DatesBox.Size = new System.Drawing.Size(266, 551);
            this.DatesBox.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.PulseChart, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.PowerChart, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.RPMChart, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(296, 10);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(650, 551);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // PulseChart
            // 
            chartArea4.Name = "ChartArea1";
            this.PulseChart.ChartAreas.Add(chartArea4);
            this.PulseChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PulseChart.Location = new System.Drawing.Point(0, 0);
            this.PulseChart.Margin = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.PulseChart.Name = "PulseChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Series1";
            this.PulseChart.Series.Add(series4);
            this.PulseChart.Size = new System.Drawing.Size(320, 270);
            this.PulseChart.TabIndex = 0;
            this.PulseChart.Text = "PulseChart";
            title4.Name = "Hart Frequentie";
            title4.Text = "Hart Frequentie";
            this.PulseChart.Titles.Add(title4);
            // 
            // PowerChart
            // 
            chartArea5.Name = "ChartArea1";
            this.PowerChart.ChartAreas.Add(chartArea5);
            this.PowerChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PowerChart.Location = new System.Drawing.Point(330, 0);
            this.PowerChart.Margin = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.PowerChart.Name = "PowerChart";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "Series1";
            this.PowerChart.Series.Add(series5);
            this.PowerChart.Size = new System.Drawing.Size(320, 270);
            this.PowerChart.TabIndex = 1;
            this.PowerChart.Text = "PowerChart";
            title5.Name = "Power";
            title5.Text = "Power";
            this.PowerChart.Titles.Add(title5);
            // 
            // RPMChart
            // 
            chartArea6.Name = "ChartArea1";
            this.RPMChart.ChartAreas.Add(chartArea6);
            this.RPMChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RPMChart.Location = new System.Drawing.Point(0, 280);
            this.RPMChart.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.RPMChart.Name = "RPMChart";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Name = "Series1";
            this.RPMChart.Series.Add(series6);
            this.RPMChart.Size = new System.Drawing.Size(320, 271);
            this.RPMChart.TabIndex = 2;
            this.RPMChart.Text = "RPM Chart";
            title6.Name = "RPM";
            title6.Text = "RPM";
            this.RPMChart.Titles.Add(title6);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(956, 571);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(974, 618);
            this.MinimumSize = new System.Drawing.Size(974, 618);
            this.Name = "Form2";
            this.Text = "`";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PulseChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PowerChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RPMChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox DatesBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart PulseChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart PowerChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart RPMChart;
    }
}