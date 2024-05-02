namespace Kolekce
{
    public class Program
    {
        static public void Main()
        {
            List<double> cisla = new()
            {
            0.046939913,
            0.295866297,
            0.852489925,
            0.84994766,
            0.96925183,
            0.946275497,
            0.688903175,
            0.553463564,
            0.59628254,
            0.645816929
        };

            // Vypis vsechna cisla na konzoli (nachystej si pro to funkci)
            Vypis(cisla);

            // Vypis na konzoli pocet cisel v seznamu
            VypisPocet(cisla);

            // Pridej cislo 0.5 do seznamu
            cisla.Add(0.5);
            Vypis(cisla);

            // vypis prvni cislo ze seznamu, ktere je vetsi nez 0.8
            double hledaneCislo;

            // Jednodussi a prehlednejsi postup
            // Prochazime vsechny cisla, doku nenajdeme vetsi ne 0.8
            foreach (double cislo in cisla)
            {
                if (cislo > 0.8)
                {
                    hledaneCislo = cislo;
                    // break je tu duleyite, abychom se dostali z cyklu a nasli opravdu prvni cislo
                    break;
                }
            }

            // Tohle je urcite pouzivanejsi pristup 
            // Vyuzivame fci Find, kde specifikujeme podminku a ona nam vrati prvni co tomu odpovida
            // Jde pozit i FindAll, aby jste nasly vsechny ktere odpovidaji podmince 
            hledaneCislo = cisla.Find(cislo => cislo > 0.8);

            Console.WriteLine(hledaneCislo);

            // najdi nejvetsi cislo v seznamu, vypis, ktere to je, a odstran ho ze seznamu
            // Do hodnoty max davame minimalni hodnotu double, jelikoz to s ni budeme srovnavat
            // Pokud bychom pouzili treba cislo 0, tak to sice v tomto pripade bude fungovat,
            // ale pokud by byly vsechny cisla zaporna, tak se nam vrati ta 0
            double max = double.MinValue;
            foreach (double cislo in cisla)
            {
                if (cislo > max)
                {
                    max = cislo;
                }
            }

            Console.WriteLine("Nejvetsi cislo" + max);

            // Mazeme prvek z Listu, smaze prvni hodnotu, ktera se rovna
            // Jde pouzit i RemoveAll(cislo => cislo == max), ktere smaze vsechny cisla, ktera se tomu rovnaji
            cisla.Remove(max);

            // vypis opet vsechna cisla a jejich pocet
            Vypis(cisla);
            VypisPocet(cisla);
        }

        public static void Vypis(List<double> cisla)
        {
            foreach (double v in cisla)
            {
                Console.WriteLine(v);
            }
        }

        public static void VypisPocet(List<double> cisla)
        {
            Console.WriteLine(cisla.Count);
        }
    }
}