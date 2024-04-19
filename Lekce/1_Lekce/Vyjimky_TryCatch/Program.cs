using System;
using Vyjimky_TryCatch;

//Upravte tridu Clovek tak, aby konstruktor vyhodil vyjimku, pokud jmeno neni platne (null nebo prazdny string)
//nebo pokud tel cislo neni validni (zkontrolujte pocet cislic). Tip: Delku cisla zjistite zavolanim telCislo.ToString().Length.
//Do metody Main doplnte blok try-catch, ktery uzivatele upozorni, pokud udela chybu
//Muzete pouzit obecnou tridu Exception, nebo lepe specifickou ArgumentException
namespace TryCatch
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Program na vytvareni telefonniho seznamu");
            Console.WriteLine("========================================");
            Console.Write("Zadejte jmeno: ");
            string jmeno = Console.ReadLine();
            Console.Write("Zadejte telefonni cislo (bez predvolby): ");
            string cislo = Console.ReadLine();

            try
            {   // Muzeme kontrolovat i tady
                // Kontrola tady je o neco korektnejsi, ale moc nas toho nenauci, proto je tu zakomentovana
                //if (cislo == null || cislo.Length != 9)
                //{
                //  Console.WriteLine("Mas spatne cislo. Zkus to znovu.");
                //  return;
                //}

                Clovek prvniClovek = new Clovek(jmeno, int.Parse(cislo));
                prvniClovek.VypisJmenoACislo();
            }
            // Tady chytame vyjimky
            // Jelikoz tu mame jen obecnou, tak nam to vezme vsechny, ale muzeme tu vytvorit i catch pro ArgumentException
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}