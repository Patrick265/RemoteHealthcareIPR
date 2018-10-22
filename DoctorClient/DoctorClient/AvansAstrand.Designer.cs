namespace DoctorClient
{
    partial class AvansAstrand
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.UpdateLabel = new System.Windows.Forms.Label();
            this.InfoBox = new System.Windows.Forms.Label();
            this.WeerstandLabel = new System.Windows.Forms.Label();
            this.RPMlabel = new System.Windows.Forms.Label();
            this.HartslagLabel = new System.Windows.Forms.Label();
            this.DataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataChart)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DataChart, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.UpdateLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.InfoBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.WeerstandLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.RPMlabel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.HartslagLabel, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.12389F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.9823F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.964602F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.964602F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.964602F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(274, 444);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // UpdateLabel
            // 
            this.UpdateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpdateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.UpdateLabel.Location = new System.Drawing.Point(10, 10);
            this.UpdateLabel.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.UpdateLabel.Name = "UpdateLabel";
            this.UpdateLabel.Size = new System.Drawing.Size(259, 78);
            this.UpdateLabel.TabIndex = 0;
            this.UpdateLabel.Text = "label1";
            // 
            // InfoBox
            // 
            this.InfoBox.AutoSize = true;
            this.InfoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.InfoBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.InfoBox.Location = new System.Drawing.Point(10, 108);
            this.InfoBox.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(64, 25);
            this.InfoBox.TabIndex = 1;
            this.InfoBox.Text = "label1";
            // 
            // WeerstandLabel
            // 
            this.WeerstandLabel.AutoSize = true;
            this.WeerstandLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WeerstandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.WeerstandLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.WeerstandLabel.Location = new System.Drawing.Point(3, 337);
            this.WeerstandLabel.Name = "WeerstandLabel";
            this.WeerstandLabel.Size = new System.Drawing.Size(268, 35);
            this.WeerstandLabel.TabIndex = 2;
            this.WeerstandLabel.Text = "label1";
            this.WeerstandLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RPMlabel
            // 
            this.RPMlabel.AutoSize = true;
            this.RPMlabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RPMlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.RPMlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.RPMlabel.Location = new System.Drawing.Point(3, 372);
            this.RPMlabel.Name = "RPMlabel";
            this.RPMlabel.Size = new System.Drawing.Size(268, 35);
            this.RPMlabel.TabIndex = 3;
            this.RPMlabel.Text = "label2";
            this.RPMlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HartslagLabel
            // 
            this.HartslagLabel.AutoSize = true;
            this.HartslagLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HartslagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.HartslagLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.HartslagLabel.Location = new System.Drawing.Point(3, 407);
            this.HartslagLabel.Name = "HartslagLabel";
            this.HartslagLabel.Size = new System.Drawing.Size(268, 37);
            this.HartslagLabel.TabIndex = 4;
            this.HartslagLabel.Text = "label3";
            this.HartslagLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DataChart
            // 
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 85F;
            chartArea1.Position.Width = 100F;
            chartArea1.Position.Y = 3F;
            this.DataChart.ChartAreas.Add(chartArea1);
            this.DataChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            legend1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            legend1.HeaderSeparatorColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.White;
            legend1.LegendItemOrder = System.Windows.Forms.DataVisualization.Charting.LegendItemOrder.SameAsSeriesOrder;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Data";
            legend1.Position.Auto = false;
            legend1.Position.Height = 9.79021F;
            legend1.Position.Width = 95F;
            legend1.Position.X = 5F;
            legend1.Position.Y = 90F;
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataChart.Legends.Add(legend1);
            this.DataChart.Location = new System.Drawing.Point(285, 10);
            this.DataChart.Margin = new System.Windows.Forms.Padding(5, 10, 10, 10);
            this.DataChart.Name = "DataChart";
            this.DataChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            series1.Legend = "Data";
            series1.Name = "Hartslag";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Data";
            series2.Name = "RPM";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Data";
            series3.Name = "Weerstand";
            this.DataChart.Series.Add(series1);
            this.DataChart.Series.Add(series2);
            this.DataChart.Series.Add(series3);
            this.DataChart.Size = new System.Drawing.Size(505, 430);
            this.DataChart.TabIndex = 1;
            this.DataChart.Text = "chart1";
            // 
            // AvansAstrand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AvansAstrand";
            this.Text = "AvansAstrand";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label UpdateLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart DataChart;
        private System.Windows.Forms.Label InfoBox;
        private System.Windows.Forms.Label WeerstandLabel;
        private System.Windows.Forms.Label RPMLabel;
        private System.Windows.Forms.Label HartslagLabel;
        private System.Windows.Forms.Label RPMlabel;
    }
}