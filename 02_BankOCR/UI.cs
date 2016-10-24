using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_BankOCR
{
    public class UI
    {
        public event Action<int, int> EnterGedrueckt;

        public void OnEnter(int anfang, int ende)
        {
            EnterGedrueckt?.Invoke(anfang, ende);
        }

        public void ZeigeStarttext(string startText)
        {
            Console.Write(startText);
        }

        public void ZeigeDialog()
        {
            // "asdasd"
            // "1,2"
            string zeile = Console.ReadLine();
            //Tuple<int, int> zahlen = GibMirdieZahlenAusDerZeichenkette(zeile);
            //OnEnter(zahlen.Item1, zahlen.Item2);
        }
    }
}