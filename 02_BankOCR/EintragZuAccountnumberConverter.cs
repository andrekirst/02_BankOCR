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
            throw new NotImplementedException();
        }

        internal static List<List<string>> ZiffernExtrahieren(Eintrag eintrag)
        {
            return null;
        }

        internal static int PruefsummeFuerZifferBestimmen(List<string> ziffer)
        {
            return -1;
        }

        public static List<int> ZiffernDurchVergleichBestimmen(List<int> pruefsummen)
        {
            throw new NotImplementedException();
        }

        public static Accountnumber ZuAccountnumberKonvertieren(List<int> ziffern)
        {
            throw new NotImplementedException();
        }
    }
}
