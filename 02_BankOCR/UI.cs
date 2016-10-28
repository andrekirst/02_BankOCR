using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_BankOCR
{
    public class UI
    {
        public event Action<string> EnterGedrueckt;

        public void OnEnter(string dateiname)
        {
            EnterGedrueckt?.Invoke(dateiname);
        }

        public void ZeigeStarttext(string startText)
        {
            Console.Write(startText);
        }

        public void ZeigeDialog()
        {
            string dateiname = Console.ReadLine();
            OnEnter(dateiname);
        }

        internal void ZeigeAccountnumbers(List<Accountnumber> accountnumbers)
        {
            foreach (Accountnumber accountnumber in accountnumbers)
            {
                Console.WriteLine(accountnumber.Wert);
            }
        }
    }
}