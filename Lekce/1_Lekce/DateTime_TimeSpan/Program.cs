using System;

namespace DateTime_TimeSpan
{
    public class Program
    {
        public static void Main()
        {
            // Zbyvajici dny do dovolene
            // Postupne se uzivatele zeptej na den, mesic a rok odjezdu na dovolenou. Pomoci DateTime a TimeSpan vypocitej pocet
            // zbyvajicich dni do odjezdu na dovolenou a vypis je na konzoli.
            // Pozn.: pro zjednoduseni staci pouzit int.Parse

            // Cteme co nam uzivatel zadal a prevadime na cislo
            // Tento pristup lze pouzit podle zadani u vsech trech udaju (den, mesic, rok)
            Console.WriteLine("Zadejte den odjezdu");
            int denOdjezdu = int.Parse(Console.ReadLine());

            Console.WriteLine("Zadejte mesic odjezdu");
            int mesicOdjezdu = int.Parse(Console.ReadLine());

            // Pro ukazku jeden z moznych zpusobu poziti Int.TryParse
            Console.WriteLine("Zadejte rok odjezdu");

            // Metoda nam vraci, jestli prevod probehl uspesne a "dovnitr", jak argument posilame promenou kde bude v pripade uspechu cislo
            bool byloZadanoCislo = int.TryParse(Console.ReadLine(), out int rokOdjezdu);

            // Kontrolujeme jestli bylo zadano cislo
            // Pokud nebylo, tak to dame uzivateli vedet a ukoncime program
            // Dalo by se to vyresit i tak, ze by to uzivatel nemusel poustet znovu, ale je to slozitejsi a nechame na priste/na vyzadani :D
            if (!byloZadanoCislo)
            {
                Console.WriteLine("Tohle neni cislo. Zkus to znovu a lepe.");
                return;
            }

            // Dalsi kontrola co me napadla, tak treba na to jestli je validni mesic. Kdyz by nam bez tohodle prislo 25 treba, tak nam to spadne
            if (mesicOdjezdu >= 1 && mesicOdjezdu <= 12)
            {
                // Vytvarime DateTime
                DateTime datumOdjezdu = new DateTime(rokOdjezdu, mesicOdjezdu, denOdjezdu);

                // Odecitame dnesek od datumu odjezdu 
                // Davame si pozor, ze pouzijeme DateTime.Today a ne DateTime.Now, protoze resime jen dny.
                // Pokud to neudelame, tak nam to odecte i hodiny, minuty,... a nebude nam to zaokrouhlovat
                TimeSpan zbyvajiciPocetDniDoOdjezdu = datumOdjezdu - DateTime.Today;

                // Kontrolujeme, jestli dovolena uz nebyla
                if (zbyvajiciPocetDniDoOdjezdu.Days < 0)
                {
                    Console.WriteLine("Uz si na dovolenou odjel/a a mozna si i zpatky :(");
                    Console.WriteLine($"Odjezd byl pred {Math.Abs(zbyvajiciPocetDniDoOdjezdu.Days)}.");
                }
                else
                {
                    // Vytiskneme pocet dni uzivateli. 
                    // Pro zajimavost, pokud bychom pocitali i s hodinami, minutami,..., tak muzeme pouzit i .TotalDays 
                    Console.WriteLine($"Do odjezdu zbyva {zbyvajiciPocetDniDoOdjezdu.Days}");
                }
            }
            else
            {
                //Uzivateli se snazime vzdycky davat vedet (hlavne kdyz je to jeho chyba)
                Console.WriteLine("Mesic ti nesedi. Zkus to znovu a lepe.");
                return;
            }
        }
    }
}