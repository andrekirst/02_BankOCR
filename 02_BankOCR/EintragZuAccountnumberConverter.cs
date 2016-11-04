using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BankOCR
{
    public class EintragZuAccountnumberConverter
    {
        internal static List<string> SegmenteExtrahieren(Eintrag eintrag)
        {
            List<string> result = new List<string>();

            const int anzahlSegemente = 9;
            for (int i = 0; i < anzahlSegemente; i++)
            {
                result.Add("");
                // Nur drei Zeilen, weil die letzte Zeile der Abschnitt für den nächsten Eintrag ist
                foreach (string zeile in eintrag.Zeilen.Take(3))
                {
                    int zeichenIndex = i * 3;
                    result[i] += zeile[zeichenIndex].ToString();
                    result[i] += zeile[zeichenIndex + 1].ToString();
                    result[i] += zeile[zeichenIndex + 2].ToString();
                }
            }

            return result;
        }

        public static AccountnumberStatus AccountnumberStatusPruefen(List<int> ziffern)
        {
            if (ziffern.Contains(-1)) return AccountnumberStatus.Illegible;

            return CheckGueltigeAccountnumber(ziffern) ? AccountnumberStatus.Ok : AccountnumberStatus.Error;
        }

        internal static bool CheckGueltigeAccountnumber(List<int> ziffern)
        {
            int checksumme = ChecksummeBerechnen(ziffern);

            if (checksumme%11 == 0)
            {
                return true;
            }
            return false;
        }

        internal static int ChecksummeBerechnen(List<int> ziffern)
        {
            // Dreht Elemente in Liste um, zur einfacheren Berechnung der Checksumme
            ziffern.Reverse();

            int checksumme = 0;
            for (int i = 0; i < ziffern.Count; i++)
            {
                checksumme += ziffern[i]*(i + 1);
            }
            return checksumme;
        }

        public static List<int> ZiffernDurchVergleichBestimmen(Eintrag eintrag)
        {
            List<string> segmente = SegmenteExtrahieren(eintrag);
            return segmente.Select(ZifferDurchVergleichBestimmen).ToList();
        }

        internal static int ZifferDurchVergleichBestimmen(string ziffernZeichenfolge)
        {
            Dictionary<string, int> vergleichsDict = new Dictionary<string, int>()
            {
                {" _ | ||_|", 0 },
                {"     |  |", 1 },
                {" _  _||_ ", 2 },
                {" _  _| _|", 3 },
                {"   |_|  |", 4 },
                {" _ |_  _|", 5 },
                {" _ |_ |_|", 6 },
                {" _   |  |", 7 },
                {" _ |_||_|", 8 },
                {" _ |_| _|", 9 }
            };

            if (vergleichsDict.ContainsKey(ziffernZeichenfolge))
            {
                return vergleichsDict[ziffernZeichenfolge];
            }

            return -1;
        }

        public static string ZuAccountnumberKonvertieren(List<int> ziffern)
        {
            return string.Join("", ziffern).Replace("-1", "?");
        }
    }
}
