using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BankOCR
{
    public static class FileProvider
    {
        public static IEnumerable<string> LeseDatei(string dateiname)
        {
            return File.ReadAllLines(dateiname);
        }

        public static void SchreibeAccountnummernDatei(List<Accountnumber> accnrs)
        {
            var aktuellesDatum = DateTime.Now;
            File.WriteAllLines($"{aktuellesDatum.ToShortDateString()}_{aktuellesDatum.Hour}_{aktuellesDatum.Minute}.txt", accnrs.Select(accnr =>
            {
                string status = accnr.Status == AccountnumberStatus.Ok
                    ? ""
                    : accnr.Status.ToString().Substring(0, 3).ToUpper();
                return accnr.Wert + " " + status;
            }));
        }
    }
}
