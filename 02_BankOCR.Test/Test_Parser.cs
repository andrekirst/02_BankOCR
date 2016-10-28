using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _02_BankOCR.Test
{
    [TestClass]
    public class Test_Parser
    {
        [TestMethod]
        public void Eintraege_123456789_und_173452788_ergeben_jeweilige_Accountnumber()
        {
            List<Eintrag> eintraege = new List<Eintrag>()
            {
                new Eintrag()
                {
                    Zeilen = new List<string>()
                    {
                        "    _  _     _  _  _  _  _ ",
                        "  | _| _||_||_ |_   ||_||_|",
                        "  ||_  _|  | _||_|  ||_| _|",
                        ""
                    }
                },
                new Eintrag()
                {
                    Zeilen = new List<string>()
                    {
                        "    _  _     _  _  _  _  _ ",
                        "  |  | _||_||_  _|  ||_||_|",
                        "  |  | _|  | _||_   ||_||_|",
                        ""
                    }
                }
            };

            List<Accountnumber> expected = new List<Accountnumber>()
            {
                new Accountnumber()
                {
                    Wert = "123456789"
                },
                new Accountnumber()
                {
                    Wert = "173452788"
                }
            };

            List<Accountnumber> result = Parser.InAccountnumberParsen(eintraege);

            Assert.IsTrue(result.SequenceEqual(expected));
        }

    }
}
