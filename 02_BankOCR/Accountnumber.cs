using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BankOCR
{
    public class Accountnumber
    {
        public string Wert { get; set; }

        public AccountnumberStatus Status { get; set; }

        public override bool Equals(object other)
        {
            var toCompareWith = other as Accountnumber;
            if (toCompareWith == null)
                return false;
            return this.Wert == toCompareWith.Wert;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public enum AccountnumberStatus
    {
        Ok,
        Error,
        Illegible
    }
}
