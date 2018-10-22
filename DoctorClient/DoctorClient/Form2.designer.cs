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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DatesBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PulseC = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PowerC = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RPMC = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PulseC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PowerC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RPMC)).BeginInit();
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
            this.DatesBox.SelectedIndexChanged += new System.EventHandler(this.DatesBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.PulseC, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.PowerC, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.RPMC, 0, 1);
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
            // PulseC
            // 
            chartArea1.Name = "ChartArea1";
            this.PulseC.ChartAreas.Add(chartArea1);
            this.PulseC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PulseC.Location = new System.Drawing.Point(0, 0);
            this.PulseC.Margin = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.PulseC.Name = "PulseC";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "Hartslag";
            this.PulseC.Series.Add(series1);
            this.PulseC.Size = new System.Drawing.Size(320, 270);
            this.PulseC.TabIndex = 0;
            this.PulseC.Text = "PulseChart";
            title1.Name = "Hart Frequentie";
            title1.Text = "Hart Frequentie";
            this.PulseC.Titles.Add(title1);
            // 
            // PowerC
            // 
            chartArea2.Name = "ChartArea1";
            this.PowerC.ChartAreas.Add(chartArea2);
            this.PowerC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PowerC.Location = new System.Drawing.Point(330, 0);
            this.PowerC.Margin = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.PowerC.Name = "PowerC";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.DodgerBlue;
            series2.Name = "PowerChart";
            this.PowerC.Series.Add(series2);
            this.PowerC.Size = new System.Drawing.Size(320, 270);
            this.PowerC.TabIndex = 1;
            this.PowerC.Text = "PowerChart";
            title2.Name = "Power";
            title2.Text = "Power";
            this.PowerC.Titles.Add(title2);
            // 
            // RPMC
            // 
            chartArea3.Name = "ChartArea1";
            this.RPMC.ChartAreas.Add(chartArea3);
            this.RPMC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RPMC.Location = new System.Drawing.Point(0, 280);
            this.RPMC.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.RPMC.Name = "RPMC";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Crimson;
            series3.Name = "RPMChart";
            this.RPMC.Series.Add(series3);
            this.RPMC.Size = new System.Drawing.Size(320, 271);
            this.RPMC.TabIndex = 2;
            this.RPMC.Text = "RPM Chart";
            title3.Name = "RPM";
            title3.Text = "RPM";
            this.RPMC.Titles.Add(title3);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "`";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PulseC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PowerC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RPMC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox DatesBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart PulseC;
        private System.Windows.Forms.DataVisualization.Charting.Chart PowerC;
        private System.Windows.Forms.DataVisualization.Charting.Chart RPMC;
    }
}