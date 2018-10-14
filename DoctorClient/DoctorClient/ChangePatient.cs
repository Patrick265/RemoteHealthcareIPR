using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils.Model;

namespace DoctorClient
{
	public partial class ChangePatient : Form
	{
		public List<Patient> patients;
		public int index;
		public Form1 form;

		public ChangePatient(List<Patient> patients, int index, Form1 form)
		{
			InitializeComponent();
			this.patients = patients;
			this.index = index;
			this.form = form;
			NameTextBox.Text = patients[index].name;
			WeightTextBox.Text = patients[index].weight.ToString();
			HeightTextBox.Text = patients[index].height.ToString();
		}

		private void ChangePatientButton_Click(object sender, EventArgs e)
		{
			Console.WriteLine("OLD: " + patients[index].ToString());
			if (IsDigitsOnly(WeightTextBox.Text) && IsDigitsOnly(HeightTextBox.Text) && !int.TryParse(NameTextBox.Text, out int result))
			{
				patients[index].name = NameTextBox.Text;
				patients[index].weight = Convert.ToInt32(WeightTextBox.Text);
				patients[index].height = Convert.ToInt32(HeightTextBox.Text);
				form.doctor.SendUsers(patients);
				Form1.getNames();
				form.UpdateForm(form.machineNames, this.patients);

				this.Close();

			}
			else
			{
				MessageBox.Show("Geen goede data ingevoerd");
			}

			Console.WriteLine("NEW: " + patients[index].ToString());
		}

		private bool IsDigitsOnly(string str)
		{
			foreach (char c in str)
			{
				if (c < '0' || c > '9')
					return false;
			}

			return true;
		}

		private bool IsTextOnly(string str)
		{
			foreach (char c in str)
			{
				if (c > '0' || c < '9')
					return false;
			}
			return true;
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			string result = MessageBox.Show(this, "Weet u zeker of je de patiënt wilt verwijderen?", "caption", MessageBoxButtons.OKCancel).ToString();
			if(result == "OK")
			{
				Console.WriteLine("HALLO DIKKE AIDS");
				this.patients.RemoveAt(index);
				form.doctor.SendUsers(patients);
				Form1.getNames();
				form.UpdateForm(form.machineNames, this.patients);

				this.Close();
			}

		}
	}
}
