using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BankOCR
{
    public static class ZeilenZuEintragConverter
    {
        public static List<Eintrag> Convert(IEnumerable<string> zeilen)
        {
            List<Eintrag> eintraege = new List<Eintrag>();
            int zeilennummer = 1;

            Eintrag aktuellerEintrag = new Eintrag();

            foreach (string zeile in zeilen)
            {
                if (zeilennummer++ % 4 == 0)
                {
                    aktuellerEintrag.Zeilen.Add(zeile);
                    eintraege.Add(aktuellerEintrag);
                    aktuellerEintrag = new Eintrag();
                }
                else
                {
                    aktuellerEintrag.Zeilen.Add(zeile);
                }
            }

            return eintraege;
        }
    }
}
