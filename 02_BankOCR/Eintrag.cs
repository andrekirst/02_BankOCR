﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BankOCR
{
    public class Eintrag
    {
        public Eintrag()
        {
            Zeilen = new List<string>();
        }

        public List<string> Zeilen { get; set; }
    }
}
