using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
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

    private Clovek() { }
}

public class Program
{
    public static void Main()
    {
        List<Clovek> telefonniSeznam = new()
        {
            new Clovek("Jarda", "Kadlec", 777123456),
            new Clovek("Honza", "Kratochvila", 777987654),
            new Clovek("Petr", "Novak", 778111222)
        };

        //1. Upravte tridu Clovek, aby byla serializovatelna
        //2. Ulozte cely telefonni seznam do XML pomoci serializeru a StreamWriteru

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

        //vytvorime si cestu k souboru
        var soubor = Path.Combine(adresar, "telefonniSeznam.xml");

        //vytvarime serializer na List Cloveku
        XmlSerializer serializer = new(typeof(List<Clovek>));

        //vytvarime writer pro ten dany soubor
        using StreamWriter writer = new(soubor);

        //spojime oboji dohromady
        serializer.Serialize(writer, telefonniSeznam);

        //disposujeme writer, at muzeme soubor znovu otevrit (zkuste smazat, at vite kde to spadne)
        writer.Dispose();
        //3. Nactete cely telefonni seznam ze souboru XML pomoci deserializeru a StreamReaderu

        //vytvarime reader pro ten dany soubor
        using StreamReader reader = new(soubor);

        //deserializujeme tj. prevadime na ten dany typ z textu (opet List Cloveku)
        var nactenoZeSouboru = serializer.Deserialize(reader) as List<Clovek>;

        //rychla kontrola ze jsme vse nacetli spravne
        foreach (var item in nactenoZeSouboru)
        {
            Console.WriteLine($"{item.Jmeno} {item.Prijmeni} {item.TelCislo}");
        }

        //dispose readeru, ktery ale neni tak nutny jak predtim
        reader.Dispose();
    }
}