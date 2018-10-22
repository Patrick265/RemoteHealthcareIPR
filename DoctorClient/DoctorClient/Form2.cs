﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Utils.Model;

namespace DoctorClient
{
    public partial class Form2 : Form
    {
        private ClientDoctor Doctor;
        private List<string> DateList;
        private List<AstrandSession> AstrandSessions;
        private Patient Patient;

        #region Forms Component
        private ListBox DateListBox;
        private Chart RpmChart;
        private Chart PulseChart;
        private Chart PowerChart;
        #endregion

        public Form2(ClientDoctor clientDoctor, Patient patient)
        {
            InitializeComponent();
            this.Doctor = clientDoctor;
            this.Patient = patient;

            this.DateList = new List<string>();
            if (this.Doctor.AstrandSessions != null)
            {
                this.AstrandSessions = this.Doctor.AstrandSessions;
            }

            this.DateListBox = DatesBox;
            this.RpmChart = RPMC;
            this.PulseChart = PulseC;
            this.PowerChart = PowerC;

            FillListBox();
            if(this.DateList.Count > 0)
            {
                this.DatesBox.SelectedItem = this.DateList[0];
            }
            
        }

        private void DatesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<AstrandData> data = new List<AstrandData>();
            this.PulseChart.Series["Hartslag"].Points.Clear();
            this.RpmChart.Series["RPMChart"].Points.Clear();
            this.PowerChart.Series["PowerChart"].Points.Clear();
            foreach (AstrandSession session in this.AstrandSessions)
            {
                if(session.date.ToString() == DatesBox.SelectedItem.ToString())
                {
                    data = session.data;
                }
            }

            foreach(AstrandData Adata in data)
            {
                this.PulseChart.Series["Hartslag"].Points.Add(Adata.Pulse);
                this.RpmChart.Series["RPMChart"].Points.Add(Adata.Rpm);
                this.PowerChart.Series["PowerChart"].Points.Add(Adata.Power);
            }
        }

        public void FillListBox()
        {
            foreach (AstrandSession session in this.AstrandSessions)
            {
                this.DateList.Add(session.date.ToString());
            }

            this.DateListBox.DataSource = this.DateList;
        }

        private void FillChartList(List<AstrandData> data)
        {

        }
    }
}
