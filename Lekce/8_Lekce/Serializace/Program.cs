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

        //1. Upravte tridu Clovek, aby byla serializovatelna
        //2. Ulozte cely telefonni seznam do XML pomoci serializeru a StreamWriteru
        //3. Nactete cely telefonni seznam ze souboru XML pomoci deserializeru a StreamReaderu

    }
}