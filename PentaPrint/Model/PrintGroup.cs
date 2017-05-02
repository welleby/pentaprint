﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PentaPrint.Model
{
    class PrintGroup
    {
        private Dictionary<String, IPrint> _printables;
        public Dictionary<String, IPrint> Printables
        {
            get
            {
                return _printables;
            }
            set
            {
                _printables = value;
                Header = this.ToString();
            }
        }
        public string Header { get; set; }
        public override string ToString()
        {
            if (Printables != null && Printables.Count > 0)
                return Printables.ToList()[0].Value.ToString();
            return "NULL";
        }
        public PrintGroup()
        {
            Printables = new Dictionary<string, IPrint>();
            Header = this.ToString();
        }
    }
}