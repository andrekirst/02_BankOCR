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
                List<int> pruefsummen = EintragZuAccountnumberConverter.PruefsummenBestimmen(eintrag);
                List<int> ziffern = EintragZuAccountnumberConverter.ZiffernDurchVergleichBestimmen(pruefsummen);
                Accountnumber accountnumber = EintragZuAccountnumberConverter.ZuAccountnumberKonvertieren(ziffern);
                accountnumbern.Add(accountnumber);
            }
            return accountnumbern;
        }
    }
}
