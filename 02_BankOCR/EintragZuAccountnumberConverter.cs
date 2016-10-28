using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BankOCR
{
    public class EintragZuAccountnumberConverter
    {
        public static List<int> PruefsummenBestimmen(Eintrag eintrag)
        {
            List<List<string>> segmente = SegmenteExtrahieren(eintrag);
            return segmente.Select(segment => PruefsummeFuerSegmentBestimmen(segment)).ToList();
        }

        internal static List<List<string>> SegmenteExtrahieren(Eintrag eintrag)
        {
            List<List<string>> result = new List<List<string>>();

            const int anzahlSegemente = 9;
            for (int i = 0; i < anzahlSegemente; i++)
            {
                result.Add(new List<string>());
                // Nur drei Zeilen, weil die letzte Zeile der Abschnitt für den nächsten Eintrag ist
                foreach (string zeile in eintrag.Zeilen.Take(3))
                {
                    int zeichenIndex = i * 3;
                    result[i].Add(zeile[zeichenIndex].ToString());
                    result[i].Add(zeile[zeichenIndex + 1].ToString());
                    result[i].Add(zeile[zeichenIndex + 2].ToString());
                }
            }

            return result;
        }

        internal static int PruefsummeFuerSegmentBestimmen(List<string> ziffer)
        {
            var binString = string.Join("", ziffer.Select(c => c == " " ? "0" : "1"));
            return Convert.ToInt32(binString, 2);
        }

        public static List<int> ZiffernDurchVergleichBestimmen(List<int> pruefsummen)
        {
            return pruefsummen.Select(p => ZifferDurchVergleichBestimmen(p)).ToList();
        }

        internal static int ZifferDurchVergleichBestimmen(int pruefsumme)
        {
            Dictionary<int, int> vergleichsDict = new Dictionary<int, int>()
            {
                { Convert.ToInt32("010101111", 2), 0 },
                { Convert.ToInt32("000001001", 2), 1 },
                { Convert.ToInt32("010011110", 2), 2 },
                { Convert.ToInt32("010011011", 2), 3 },
                { Convert.ToInt32("000111001", 2), 4 },
                { Convert.ToInt32("010110011", 2), 5 },
                { Convert.ToInt32("010110111", 2), 6 },
                { Convert.ToInt32("010001001", 2), 7 },
                { Convert.ToInt32("010111111", 2), 8 },
                { Convert.ToInt32("010111011", 2), 9 }
            };

            return vergleichsDict[pruefsumme];
        }

        public static Accountnumber ZuAccountnumberKonvertieren(List<int> ziffern)
        {
            return new Accountnumber()
            {
                Wert = string.Join("", ziffern)
            };
        }
    }
}
