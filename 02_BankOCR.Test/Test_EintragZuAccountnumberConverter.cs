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

            List<string> result = EintragZuAccountnumberConverter.SegmenteExtrahieren(eintrag);
            Assert.AreEqual(9, result.Count);
            string ziffer1 = "     |  |";
            Assert.AreEqual(ziffer1, result[0]);
        }

        [TestMethod]
        public void Liste_ist_Ziffer_1()
        {
            int ziffer = EintragZuAccountnumberConverter.ZifferDurchVergleichBestimmen("     |  |");
            Assert.AreEqual(1, ziffer);
        }
        [TestMethod]
        public void Kaputte_Zahl_ergibt_minus_1()
        {
            int ziffer = EintragZuAccountnumberConverter.ZifferDurchVergleichBestimmen("_________");
            Assert.AreEqual(-1, ziffer);
        }

        [TestMethod]
        public void Ziffern_123456789_zu_Accountnumber_123456789()
        {
            List<int> ziffern = new List<int>()
            {
                1,2,3,4,5,6,7,8,9
            };

            string result = EintragZuAccountnumberConverter.ZuAccountnumberKonvertieren(ziffern);

            Assert.AreEqual("123456789", result);
        }

        [TestMethod]
        public void Check_345882865_sollte_gültige_Accountnumber_sein()
        {
            List<int> ziffern = new List<int>()
            {
                3,4,5,8,8,2,8,6,5
            };

            AccountnumberStatus result = EintragZuAccountnumberConverter.AccountnumberStatusPruefen(ziffern);

            Assert.AreEqual(AccountnumberStatus.Ok, result);
        }
        
        [TestMethod]
        public void Check_345882866_sollte_ungültige_Accountnumber_sein()
        {
            List<int> ziffern = new List<int>()
            {
                3,4,5,8,8,2,8,6,6
            };

            AccountnumberStatus result = EintragZuAccountnumberConverter.AccountnumberStatusPruefen(ziffern);

            Assert.AreEqual(AccountnumberStatus.Error, result);
        }

        [TestMethod]
        public void Check_345_minus_182866_sollte_unlesbare_Accountnumber_sein()
        {
            List<int> ziffern = new List<int>()
            {
                3,4,5,-1,8,2,8,6,6
            };

            AccountnumberStatus result = EintragZuAccountnumberConverter.AccountnumberStatusPruefen(ziffern);

            Assert.AreEqual(AccountnumberStatus.Illegible, result);
        }

        [TestMethod]
        public void Checksumme_von_123123123_ist_84()
        {
            int result = EintragZuAccountnumberConverter.ChecksummeBerechnen(new List<int>()
            {
                1,
                2,
                3,
                1,
                2,
                3,
                1,
                2,
                3
            });

            Assert.AreEqual(84, result);
        }

        [TestMethod]
        public void Accnr_345882865_sollte_gültig_sein()
        {
            var result = EintragZuAccountnumberConverter.CheckGueltigeAccountnumber(new List<int>()
            {
                3,
                4,
                5,
                8,
                8,
                2,
                8,
                6,
                5
            });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Accnr_123123123_sollte_ungültig_sein()
        {
            var result = EintragZuAccountnumberConverter.CheckGueltigeAccountnumber(new List<int>()
            {
                1,2,3,1,2,3,1,2,3
            });

            Assert.IsFalse(result);
        }
    }
}
