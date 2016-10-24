using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _02_BankOCR.Test
{
    [TestClass]
    public class Test_ZeilenZuEintragConverter
    {
        [TestMethod]
        public void Wenn_vier_Zeilen_dann_ein_Eintrag()
        {
            List<string> zeilen = new List<string>()
            {
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                ""
            };

            List<Eintrag> eintraege = ZeilenZuEintragConverter.Convert(zeilen);
            Assert.IsNotNull(eintraege);
            Assert.AreEqual(eintraege.Count, 1);
        }

        [TestMethod]
        public void Wenn_acht_Zeilen_dann_zwei_Eintraege()
        {
            List<string> zeilen = new List<string>()
            {
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                "",

                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   || ||_|",
                "  ||_  _|  | _||_|  ||_||_|",
                ""
            };

            List<Eintrag> eintraege = ZeilenZuEintragConverter.Convert(zeilen);
            Assert.IsNotNull(eintraege);
            Assert.AreEqual(eintraege.Count, 2);

            Eintrag eintrag1 = new Eintrag()
            {
                Zeilen = new List<string>()
                {
                    "    _  _     _  _  _  _  _ ",
                    "  | _| _||_||_ |_   ||_||_|",
                    "  ||_  _|  | _||_|  ||_| _|",
                    ""
                }
            };

            Eintrag eintrag2 = new Eintrag()
            {
                Zeilen = new List<string>()
                {
                    "    _  _     _  _  _  _  _ ",
                    "  | _| _||_||_ |_   || ||_|",
                    "  ||_  _|  | _||_|  ||_||_|",
                    ""
                }
            };

            List<Eintrag> eintrageErwartet = new List<Eintrag>()
            {
                eintrag1, eintrag2
            };
            CollectionAssert.AreEqual(eintrageErwartet[0].Zeilen, eintraege[0].Zeilen);
        }
    }
}
