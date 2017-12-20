using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando2
{
    class Novenyek
    {

        string noveny_neve; //stringként kérem be
        string fenyigeny;  //string tipusuként kérem be
        int vizigeny;   //int tipusu
        DateTime utolsolocsolas;  //DateTime tipusu
        bool szure; //bool típus

        public Novenyek(string noveny_neve, string fenyigeny, int vizigeny, DateTime utolsolocsolas, bool szure)
        {
            this.noveny_neve = noveny_neve;
            this.fenyigeny = fenyigeny;
            this.vizigeny = vizigeny;
            this.utolsolocsolas = utolsolocsolas;
            this.szure = szure;
        }

        private void locsolas(string noveny_neve)
        {
            Console.WriteLine("A mai nap meg kell locsolni {0} novényt.", noveny_neve); //Kiiratom hogy melyik virágot kell meglocsolni.
        }

        private void szuros(bool szure, string noveny_neve)
        {
            if (szure)
            {
                locsolas(noveny_neve); //Kiiratom a noveny nevet
                Console.ForegroundColor = ConsoleColor.Red; //Console kiirásának szinét megváltoztatom
                Console.WriteLine("Csak védőkesztyűben közelitse meg."); ///pirossal kell kiratnom
                Console.ResetColor();
            }
            else
            {
                locsolas(noveny_neve); //Kiiratom a noveny nevet
            }
        }

        public DateTime maOntozes(int vizigeny, DateTime utolsolocsolas,bool szure, string noveny_neve)
        {
            DateTime ma = DateTime.Today;  //ma változónak megadjuk a mai napot.
            TimeSpan szam = ma.Subtract(utolsolocsolas);  //Megnézzük hogy mennyi idó telt el a ma és az utolsó locsolas óta.
            if (szam.Days >= vizigeny)//megvizsgálom hogy ma vagy előző napokban kellett volna öntözni.
            {
                utolsolocsolas = ma;  //megváltoztatja a dátumot a listában.
                szuros(szure,noveny_neve);    //kiiratom ha kell ma locsolni akkor kesztyűt hasznaljon vagy sem.   
            }
            return utolsolocsolas;
        }

    }
}
