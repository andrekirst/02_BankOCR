using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BankOCR
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();
            Interactors interactors = new Interactors();

            ui.EnterGedrueckt += (dateiname) =>
            {
                List<Accountnumber> accountnumbers = interactors.ParseOCR(dateiname);
                FileProvider.SchreibeAccountnummernDatei(accountnumbers);
                ui.ZeigeAccountnumbers(accountnumbers);
            };

            string startText = interactors.GebeMirStarttext();
            ui.ZeigeStarttext(startText);
            ui.ZeigeDialog();

            Console.WriteLine("Press the any key");
            Console.ReadLine();
        }
    }
}
