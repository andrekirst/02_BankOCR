using System.Collections.Generic;

namespace _02_BankOCR
{
    public class Interactors
    {
        public string GebeMirStarttext()
        {
            return "Dateipfad, du Honk: ";
        }

        public List<Accountnumber> ParseOCR(string dateiname)
        {
            FileProvider fileProvider = new FileProvider();
            IEnumerable<string> zeilen = fileProvider.LeseDatei(dateiname);
            IEnumerable<Eintrag> eintraege = ZeilenZuEintragConverter.Convert(zeilen);
            return Parser.InAccountnumberParsen(eintraege);
        }
    }
}