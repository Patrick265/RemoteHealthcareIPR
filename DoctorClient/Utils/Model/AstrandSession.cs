using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Model
{
    public class AstrandSession
    {
        public DateTime date { get; set; }
        public List<AstrandData> data { get; set; }
        public string name { get; set; }
        public double VO2 { get; set; }

        public AstrandSession(string name, DateTime date, List<AstrandData> data, double VO2)
        {
            this.name = name;
            this.date = date;
            this.data = data;
            this.VO2 = VO2;
        }

        public AstrandSession(string name, DateTime date)
        {
            this.name = name;
            this.date = date;
            this.data = new List<AstrandData>();
        }

        public AstrandSession()
        {

        }

        public override string ToString()
        {
            return $"[AstrandSession:\nDate:\t{this.date}\nData:\t{this.data}\nName:\t{this.name}]";
        }
    }
}
