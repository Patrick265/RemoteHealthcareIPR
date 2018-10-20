﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Model
{
    public class AstrandSession
    {
        public DateTime date { get; }
        public List<AstrandData> data { get; set; }
        public string name;

        public AstrandSession(string name, DateTime date, List<AstrandData> data)
        {
            this.name = name;
            this.date = date;
            this.data = data;
        }

        public AstrandSession(string name, DateTime date)
        {
            this.name = name;
            this.date = date;
            this.data = new List<AstrandData>();
        }
    }
}
