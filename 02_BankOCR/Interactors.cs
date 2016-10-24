using System.Collections.Generic;

namespace _02_BankOCR
{
    public class Interactors
    {
        /*
        // Declare the delegate (if using non-generic pattern).
    public delegate void SampleEventHandler(object sender, SampleEventArgs e);

    // Declare the event.
    public event SampleEventHandler SampleEvent;
        */

        //    public delegate void 
        //public event  EnterPressed
        public IEnumerable<string> ErstelleFizzBuzzListe(int anfang, int ende)
        {
            //List<string> liste = new List<string>();
            //for (int i = anfang; i <= ende; i++)
            //{
            //    bool istDurch3Teilbar = FizzBuzz.IstDurch3Teilbar(i);
            //    bool istDurch5Teilbar = FizzBuzz.IstDurch5Teilbar(i);
            //    liste.Add(FizzBuzz.AusgabeTextGenerieren(istDurch3Teilbar, istDurch5Teilbar, i));
            //}
            //return liste;
            throw new System.Exception();
        }

        internal string GebeMirStarttext()
        {
            return "Hey Dude, gib mal Anfang und Ende ein.büddddde: ";
        }
    }
}