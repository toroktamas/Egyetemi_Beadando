using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Beadando2
{
    class Program
    {
        static public int Sorokszama(string fajlnev)
        {
            StreamReader SR = new StreamReader(fajlnev, Encoding.Default);   //Fájl sorainak megszámolása
            int szam = 0;
            while (!SR.EndOfStream)
            {
                string s = SR.ReadLine();
                szam++;
            }
            SR.Close();
            return szam;
        }
        static private string[] Feldolgoz(string fajlnev)
        {
            string[] kiiras = new string[Sorokszama(fajlnev)];    //Létrehozok egy string tömböt amibe a beiratás tomb van.
            Novenyek[] novenyek1 = new Novenyek[Sorokszama(fajlnev)];  // Létrehozom az objektumot
            int darab = 0;  // sorok szama
            string[] fajl = System.IO.File.ReadAllLines(fajlnev, Encoding.UTF8); //Kiolvasom egy fájlból a sorait.
            for (int i = 0; i < fajl.Length; i++) //végigmegyek a szövegekkel feltöltöt tömbön
            {
                if (fajl[i] != "\n")  //Üres sorok kiszűrése.
                {
                    string[] darab1 = fajl[i].Split(';'); // szétválogatom a sor adatait
                    novenyek1[darab] = new Novenyek(darab1[0], darab1[1], int.Parse(darab1[2]), DateTime.Parse(darab1[3]), bool.Parse(darab1[4]));// zárójeln belül az adatokat adom meg.
                    DateTime locsolas_datuma = novenyek1[darab].maOntozes(int.Parse(darab1[2]), DateTime.Parse(darab1[3]), bool.Parse(darab1[4]), darab1[0]); // megváltoztatom a locsolás dátumát
                    kiiras[darab] = darab1[0] + ";" + darab1[1] + ";" + (darab1[2]).ToString() + ";" + (locsolas_datuma).ToString() + ";" + (darab1[4]).ToString(); //összegyűjtöm egy tömbe az adatokat.
                    darab++; //továbblépek a következő sorra.
                }
            }
            return kiiras;
        }

        static private void Valtoztat(ref string[] kiiras)
        {
            for (int i = 0; i < kiiras.Length; i++) //kiiratom a fajl sorait hogy el tudja dönteni hogy melyik sort akarja megváltoztatni.
            {
                Console.WriteLine("{0}.{1}",i+1,kiiras[i]);
            }

            Console.WriteLine("Hanyadik sort szeretné megváltoztatni?");
            //Megváltoztatom a megadott sor adatait hogy mmit kell megváltoztatni és hogy melyik sorba.
            int szam = int.Parse(Console.ReadLine());
            for (int i = 0; i < kiiras.Length; i++)
            {
                if (i == (szam-1))
                { 
                    string[] darab1 = kiiras[i].Split(';');
                    Console.WriteLine("A beirt szöveg nem tartalmazhat {0} karaktert.", ";");
                    Console.WriteLine("Mit szeretne megváltoztatni vagy törölni. (Novenyneve/Fényigeny/Vizigeny/UtolsoLocsolas/Szure)");
                    string valtoztat = Console.ReadLine();
                    if (valtoztat == "Novenyneve")
                    {
                        Console.WriteLine("Törölni vagy változtatni akarja az adatot.(Torol/Valtoztat)");
                        string modosit = Console.ReadLine();
                        if (modosit == "Torol")
                        {
                            darab1[0] = "";
                        }
                        if (modosit == "Valtoztat")
                        {
                            Console.WriteLine("Változtassa meg a növény nevét.");
                            string novenynev = Console.ReadLine();
                            darab1[0] = novenynev;
                        }
                        else
                        {
                            Console.WriteLine("Valamit elirtal.");
                        }
                    }
                    if (valtoztat == "Fényigeny")
                    {
                        Console.WriteLine("Törölni vagy változtatni akarja az adatot.(Torol/Valtoztat)");
                        string modosit = Console.ReadLine();
                        if (modosit == "Torol")
                        {
                            darab1[1] = "";
                        }
                        if (modosit == "Valtoztat")
                        {
                            Console.WriteLine("Változtassa meg a fényigenyt.");
                            string fenyigeny = Console.ReadLine();
                            darab1[1] = fenyigeny;
                        }
                        else
                        {
                            Console.WriteLine("Valamit elirtal.");
                        }
                    }
                    if (valtoztat == "Vizigeny")
                    {
                        Console.WriteLine("Törölni vagy változtatni akarja az adatot.(Torol/Valtoztat)");
                        string modosit = Console.ReadLine();
                        if (modosit == "Torol")
                        {
                            darab1[2] = "";
                        }
                        if (modosit == "Valtoztat")
                        {
                            Console.WriteLine("Változtassa meg a vizigenyt.");
                            string vizigeny = Console.ReadLine();
                            darab1[2] = vizigeny;
                        }
                        else
                        {
                            Console.WriteLine("Valamit elirtal.");
                        }
                    }

                    if (valtoztat == "UtolsoLocsolas")
                    {
                        Console.WriteLine("Törölni vagy változtatni akarja az adatot.(Torol/Valtoztat)");
                        string modosit = Console.ReadLine();
                        if (modosit == "Torol")
                        {
                            darab1[3] = "";
                        }
                        if (modosit == "Valtoztat")
                        {
                            Console.WriteLine("Változtassa meg a utolso locsolas dátumát.");
                            string locsolasdatuma = Console.ReadLine();
                            darab1[3] = locsolasdatuma;
                        }
                        else
                        {
                            Console.WriteLine("Valamit elirtal.");
                        }
                    }

                    if (valtoztat == "Szure")
                    {
                        Console.WriteLine("Törölni vagy változtatni akarja az adatot.(Torol/Valtoztat)");
                        string modosit = Console.ReadLine();
                        if (modosit == "Torol")
                        {
                            darab1[4] = "";
                        }
                        if (modosit == "Valtoztat")
                        {
                            Console.WriteLine("Változtassa meg a szure tulajdonságot.");
                            string szure = Console.ReadLine();
                            darab1[4] = szure;
                        }
                        else
                        {
                            Console.WriteLine("Valamit elirtal.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valamit elirtal.");
                    }
                    kiiras[i] = darab1[0] + ";" + darab1[1] + ";" + darab1[2]+";"+darab1[3]+";"+darab1[4];
                }
            }
        }

        static private string Hozzaad()
        {    
            //Bekérem a hozzáadott növény adatait.
            Console.WriteLine("Irja be a noveny nevet:");
            string novenyneve = Console.ReadLine();
            Console.WriteLine("Irja be a fényigényt:");
            string fenyigeny = Console.ReadLine();
            Console.WriteLine("Irja be a vizigenyt:");
            string vizigeny = Console.ReadLine();
            Console.WriteLine("Irja be az utolso locsolas dátumát:");
            string utolsolocsolas = Console.ReadLine();
            Console.WriteLine("Irja be hogy szur-e:(true/false)");
            string szure = Console.ReadLine();
            string ujsor = novenyneve+";"+fenyigeny+";"+vizigeny+";"+utolsolocsolas+";"+szure;
            return ujsor;
        }

        static private void SorHozzadFajl(string fajlnev ,string ujsor, string[] kiiras)
        {
            System.IO.StreamWriter SR = new System.IO.StreamWriter(fajlnev);
            for (int i = 0; i < kiiras.Length; i++)
            {
                SR.WriteLine(kiiras[i]);//sorokat kiiratom
            }
            SR.WriteLine(ujsor); // hozzáadandó sort hozzáadom
            SR.Close(); //bezárom a fájlt.
            
        }

        static private void Fajlbakiirat(string fajlnev, ref string[] tomb_amit_kiiratok)
        {
            System.IO.File.WriteAllLines(fajlnev, tomb_amit_kiiratok, Encoding.UTF8);  //tömböt kiiratom a fájlba.
        }

        static private void FelhasznaloEldont(string fajlnev)
        {
            string[] feldolgozott_adat = Feldolgoz(fajlnev); // meghívom a fájlkezelő fuggvényt
            Console.WriteLine("Szeretne valamit változtani a fájlban? (igen/nem)"); 
            string valtoztate = Console.ReadLine();
            if (valtoztate == "igen")  //eldöntetem a felhasználóval hogy meg akarja e változtatni a fájlt.
            {
                Console.WriteLine("Szeretne hozzáadni a fájlhoz új növényt?(igen/nem)");
                string hozzaad = Console.ReadLine(); 
                if (hozzaad == "igen")
                {
                    SorHozzadFajl(fajlnev, Hozzaad(), Feldolgoz(fajlnev)); //függvényel hozzáadok a fájlhoz egy új sort.
                    //hozzáadunk egy plusz sort a kiirando fajlhoz. Az előzőek kitörlése nélkül.
                }
                else if (hozzaad == "nem")
                {
                    Valtoztat(ref feldolgozott_adat);
                    Fajlbakiirat(fajlnev, ref feldolgozott_adat);
                }
                else
                {
                    Console.WriteLine("Valamit elirtal.");
                }

            }
            else if (valtoztate == "nem")
            {
                Fajlbakiirat(fajlnev, ref feldolgozott_adat); //kiiratom a fájlt.
            }
        }

        static void Main(string[] args)
        {
            string fajlnev = "";
            if (args.Length != 0)//megnézem hogy a meghíváskor vagy a futtatskor akarom megadni a fájl nevét.
            {
                fajlnev = (args[0]).ToString(); //meghíváskor küldöm be a fajlnevet
            }
            else
            {
                Console.WriteLine("Kérem adja meg a fájl nevét:"); // consolról kérem be a fájl nevét.
                fajlnev = Console.ReadLine();
            }
            FelhasznaloEldont(fajlnev);  //Kiiratások meghívása 
            Console.WriteLine("Kérem a kikapcsoláshoz nyomjon egy entert.");           
            Console.ReadLine();
            
        }
    }
}
