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

            ui.EnterGedrueckt += (anfang, ende) =>
            {
                IEnumerable<string> fizzBuzzListe = interactors.ErstelleFizzBuzzListe(anfang, ende);
                ui.ZeigeListe(fizzBuzzListe);
            };

            string startText = interactors.GebeMirStarttext();
            ui.ZeigeStarttext(startText);
            ui.ZeigeDialog();

            Console.WriteLine("Press the any key");
            Console.ReadLine();
        }
    }
}
