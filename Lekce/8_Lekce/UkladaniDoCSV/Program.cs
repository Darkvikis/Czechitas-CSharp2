using System;
using System.Collections.Generic;

public class Clovek
{
    public string Jmeno { get; set; }
    public string Prijmeni { get; set; }
    public int TelCislo { get; set; }

    public Clovek(string jmeno, string prijmeni, int telCislo)
    {
        Jmeno = jmeno;
        Prijmeni = prijmeni;
        TelCislo = telCislo;
    }
}

public class Program
{
    public static void Main()
    {
        List<Clovek> telefonniSeznam = new List<Clovek>
        {
            new Clovek("Jarda", "Kadlec", 777123456),
            new Clovek("Honza", "Kratochvila", 777987654),
            new Clovek("Petr", "Novak", 778111222)
        };

        //1. Vytvorte slozku TelefonniSeznam v adresari Appdata pro konkretniho uzivatele

        //Muzeme si to rozdelit do 3 kroku od vnitrku
        //Environment.SpecialFolder.ApplicationData - je predem stanovena a hlavne systemem stanovena slozka
        //Environment.GetFolderPath - vrati nam cestu k te slozce
        //Path.Combine - zkombinuje cestu k te defaultni slozce a prida tu nasi
        var adresar = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TelefonniSeznam");

        //zjistujeme, jeslti ta nase slozka existuje
        if (!Directory.Exists(adresar))
        {
            //pokud ne, tak ji vytvorime
            Directory.CreateDirectory(adresar);
        }

        //2. Do souboru telefonniSeznam.csv ulozte obsah seznamu telefonniSeznam tak,
        //   ze kazdy zaznam bude na jednom radku a oddelene budou carkami

        //zkombinujeme cestu k nasi slozce a k novemu souboru
        string soubor = Path.Combine(adresar, "telefonniSeznam.csv");

        //Zapiseme prvni radek do naseho souboru (pokud neexistuje, tak ho vytvori
        File.WriteAllText(soubor, "Jmeno, Prijmeni, TelCislo" + Environment.NewLine);

        //vyrobime si radky podle  dat v telefonniSeznam
        List<string> radky = telefonniSeznam.Select(c => $"{c.Jmeno}, {c.Prijmeni}, {c.TelCislo}").ToList();

        //vsechny radky zapiseme
        File.AppendAllLines(soubor, radky);

        //3. Napiste cyklus, ktery soubor precte a zpatky ho ulozi do noveho seznamu

        //zjistime jestli soubor existuje
        if (File.Exists(soubor))
        {
            //nacteme vsechny radky ze souboru
            var nactenoZeSouboru = File.ReadAllLines(soubor);

            //vytvorime novy list lidi
            List<Clovek> noviLidi = new();

            //pocitadlo pro ignorovani prvniho radku
            int radekCislo = 0;

            //prochazime co jsme nacetli
            foreach (var radek in nactenoZeSouboru)
            {
                //ignorujeme prvni radek
                if (radekCislo++ == 0) continue;

                //rozdelime nacteny radek pomoci , a dame ho do listu stringu
                List<string> hodnoty = radek.Split(',').ToList();

                //vytvorime osobu pomoci dat z radku
                //.Trim() odstrani prazdne znaky na konci a zacatku (mezery apod.) existuje i TrimStart a TrimEnd
                Clovek osoba = new(hodnoty[0].Trim(), hodnoty[1].Trim(), int.Parse(hodnoty[2].Trim()));

                //pridame osobu
                noviLidi.Add(osoba);
            }

            //rychla kontrola ze jsme vse nacetli spravne
            foreach (var item in noviLidi)
            {
                Console.WriteLine($"{item.Jmeno} {item.Prijmeni} {item.TelCislo}");
            }
        }
        else
        {
            //oznamime, pokud soubor neexistuje
            Console.WriteLine("Soubor nenalezen");
        }
    }
}