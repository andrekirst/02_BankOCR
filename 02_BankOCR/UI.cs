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

        public void ZeigeListe(IEnumerable<string> fizzBuzzListe)
        {
            foreach (string eintrag in fizzBuzzListe)
            {
                Console.WriteLine(eintrag);
            }
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
            Tuple<int, int> zahlen = GibMirdieZahlenAusDerZeichenkette(zeile);
            OnEnter(zahlen.Item1, zahlen.Item2);
        }

        private Tuple<int, int> GibMirdieZahlenAusDerZeichenkette(string zeile)
        {
            int[] split = zeile.Split(',').Select(x => Int32.Parse(x)).ToArray();
            return new Tuple<int, int>(split[0], split[1]);
        }
    }
}