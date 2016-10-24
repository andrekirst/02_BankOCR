using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BankOCR
{
    public class FileProvider
    {
        public IEnumerable<string> LeseDatei(string dateiname)
        {
            return File.ReadAllLines(dateiname);
        }
    }
}
