using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Model;

namespace Server
{
	public class ServerUtil
	{
		public List<Patient> PatientsInfo { get; set; }

        public ServerUtil(List<Patient> patientsInfo)
        {
            PatientsInfo = patientsInfo;
        }

        public ServerUtil()
        {
            this.PatientsInfo = new List<Patient>();
        }

        public void GenerateJson()
		{
			Patient Patrick = new Patient();
			Patrick.date = new DateTime(1995, 7, 26).ToString("d",
				  CultureInfo.CreateSpecificCulture("de-DE"));
			Patrick.name = "Patrick de Jong";
			Patrick.height = 175;
			Patrick.weight = 63;
            Patrick.male = true;
            Patrick.CalculateAge();
            Patrick.GenerateTargetedWatt();
            Patrick.CalcMaxHeartRate();

            Patient Tom = new Patient();
			Tom.date = new DateTime(1997, 9, 24).ToString("d",
				  CultureInfo.CreateSpecificCulture("de-DE"));
			Tom.name = "Tom Martens";
			Tom.height = 183;
			Tom.weight = 90;
            Tom.male = true;
            Tom.CalculateAge();
            Tom.GenerateTargetedWatt();
            Tom.CalcMaxHeartRate();

            Patient Gerdtinus = new Patient();
			Gerdtinus.date = new DateTime(1995, 12, 21).ToString("d",
				  CultureInfo.CreateSpecificCulture("de-DE"));
			Gerdtinus.name = "Gerdtinus Netten";
			Gerdtinus.height = 180;
			Gerdtinus.weight = 70;
            Gerdtinus.male = true;
            Gerdtinus.CalculateAge();
            Gerdtinus.GenerateTargetedWatt();
            Gerdtinus.CalcMaxHeartRate();


            Patient TimB = new Patient();
			TimB.date = new DateTime(1996, 10, 11).ToString("d",
				  CultureInfo.CreateSpecificCulture("de-DE"));
			TimB.name = "Tim de Booij";
			TimB.height = 181;
			TimB.weight = 73;
            TimB.male = true;
            TimB.CalculateAge();
            TimB.GenerateTargetedWatt();
            TimB.CalcMaxHeartRate();

            Patient TimV = new Patient();
			TimV.date = new DateTime(1997, 6, 7).ToString("d",
				  CultureInfo.CreateSpecificCulture("de-DE"));
			TimV.name = "Tim de Vries";
			TimV.height = 177;
			TimV.weight = 60;
            TimV.male = true;
            TimV.CalculateAge();
            TimV.GenerateTargetedWatt();
            TimV.CalcMaxHeartRate();

            Patient Renske = new Patient();
			Renske.date = new DateTime(1999, 3, 11).ToString("d",
				  CultureInfo.CreateSpecificCulture("de-DE"));
			Renske.name = "Renske van der Veen";
			Renske.height = 180;
			Renske.weight = 75;
            Renske.male = false;
            Renske.CalculateAge();
            Renske.GenerateTargetedWatt();
            Renske.CalcMaxHeartRate();


            this.PatientsInfo.Add(Patrick);
			this.PatientsInfo.Add(Tom);
			this.PatientsInfo.Add(Gerdtinus);
			this.PatientsInfo.Add(TimB);
			this.PatientsInfo.Add(TimV);
			this.PatientsInfo.Add(Renske);

			string jsonI = JsonConvert.SerializeObject(this.PatientsInfo);
			if (new FileInfo("../../res/PatientData.json").Length == 0)
			{
				File.WriteAllText("../../res/PatientData.json", jsonI);
			}
		}

		public void GenTrainingSesJson(List<Patient> info)
		{
			string path = "../../res/trainingsessions/";

			foreach (Patient patient in info)
			{
				string filePath = path + patient.date + "-" + patient.name + ".json";
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }
			}
		}

		public void WriteToJson(string username, string date, string machineName)
		{

		}
	}
}
