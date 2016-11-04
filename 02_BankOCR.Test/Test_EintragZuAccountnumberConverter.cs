using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Runtime.InteropServices;

namespace _02_BankOCR.Test
{
    /// <summary>
    /// Summary description for Test_EintragZuAccountnumberConverter
    /// </summary>
    [TestClass]
    public class Test_EintragZuAccountnumberConverter
    {
        [TestMethod]
        public void Eintrag_Aus_Zahlen_1_9_Ergibt_Pruefsumme()
        {
            Eintrag eintrag = new Eintrag()
            {
                Zeilen = new List<string>()
                {
                    "    _  _     _  _  _  _  _ ",
                    "  | _| _||_||_ |_   ||_||_|",
                    "  ||_  _|  | _||_|  ||_| _|",
                    ""
                }
            };

            List<int> result = EintragZuAccountnumberConverter.PruefsummenBestimmen(eintrag);

            List<int> expected = new List<int>
            {
                Convert.ToInt32("000001001", 2),
                Convert.ToInt32("010011110", 2),
                Convert.ToInt32("010011011", 2),
                Convert.ToInt32("000111001", 2),
                Convert.ToInt32("010110011", 2),
                Convert.ToInt32("010110111", 2),
                Convert.ToInt32("010001001", 2),
                Convert.ToInt32("010111111", 2),
                Convert.ToInt32("010111011", 2),
            };

            CollectionAssert.AreEqual(expected, result);


        }

        [TestMethod]
        public void Neun_Ziffern_aus_Eintrag_extrahiert()
        {
            Eintrag eintrag = new Eintrag()
            {
                Zeilen = new List<string>()
                {
                    "    _  _     _  _  _  _  _ ",
                    "  | _| _||_||_ |_   ||_||_|",
                    "  ||_  _|  | _||_|  ||_| _|",
                    ""
                }
            };

            List<List<string>> result = EintragZuAccountnumberConverter.SegmenteExtrahieren(eintrag);
            Assert.AreEqual(9, result.Count);
            List<string> ziffer1 = new List<string>() { " ", " ", " ", " ", " ", "|", " ",  " ", "|" };
            CollectionAssert.AreEqual(ziffer1, result[0]);
        }

        [TestMethod]
        public void Pruefsumme_von_Ziffer_Eins_ist_Neun()
        {
            List<string> ziffer1 = new List<string>() { " ", " ", " ", " ", " ", "|", " ", " ", "|" };
            int result = EintragZuAccountnumberConverter.PruefsummeFuerSegmentBestimmen(ziffer1);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Pruefsumme_von_Ziffer_Zwei_ist_158()
        {
            List<string> ziffer1 = new List<string>() { " ", "_", " ", " ", "_", "|", "|", "_", " " };
            int result = EintragZuAccountnumberConverter.PruefsummeFuerSegmentBestimmen(ziffer1);
            var expected = Convert.ToInt32("010011110", 2);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Pruefsumme_158_ist_Ziffer_2()
        {
            int ziffer = EintragZuAccountnumberConverter.ZifferDurchVergleichBestimmen(158);
            Assert.AreEqual(2, ziffer);
        }

        [TestMethod]
        public void Ziffern_123456789_zu_Accountnumber_123456789()
        {
            List<int> ziffern = new List<int>()
            {
                1,2,3,4,5,6,7,8,9
            };

            Accountnumber expected = new Accountnumber()
            {
                Wert = "123456789"
            };

            Accountnumber result = EintragZuAccountnumberConverter.ZuAccountnumberKonvertieren(ziffern);

            Assert.AreEqual(expected.Wert, result.Wert);
        }

        [TestMethod]
        public void Check_345882865_sollte_gültige_Accountnumber_sein()
        {
            List<int> ziffern = new List<int>()
            {
                3,4,5,8,8,2,8,6,5
            };

            bool result = EintragZuAccountnumberConverter.AufGueltigeAccountnumberPruefen(ziffern);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Check_345882866_sollte_ungültige_Accountnumber_sein()
        {
            List<int> ziffern = new List<int>()
            {
                3,4,5,8,8,2,8,6,6
            };

            bool result = EintragZuAccountnumberConverter.AufGueltigeAccountnumberPruefen(ziffern);

            Assert.IsFalse(result);
        }
    }
}
