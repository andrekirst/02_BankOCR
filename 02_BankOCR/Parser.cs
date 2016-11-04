using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BankOCR
{
    public static class Parser
    {
        public static List<Accountnumber> InAccountnumberParsen(IEnumerable<Eintrag> eintraege)
        {
            List<Accountnumber> accountnumbern = new List<Accountnumber>();
            foreach (Eintrag eintrag in eintraege)
            {
                Accountnumber aktuelleAccountnumber = new Accountnumber();
                List<int> ziffern = EintragZuAccountnumberConverter.ZiffernDurchVergleichBestimmen(eintrag);
                aktuelleAccountnumber.Wert = EintragZuAccountnumberConverter.ZuAccountnumberKonvertieren(ziffern);
                aktuelleAccountnumber.Status = EintragZuAccountnumberConverter.AccountnumberStatusPruefen(ziffern);
                accountnumbern.Add(aktuelleAccountnumber);
            }
            return accountnumbern;
        }
    }
}
