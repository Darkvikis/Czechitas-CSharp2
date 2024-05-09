using System;

namespace Dictionary
{

    /* Vytvorte tridu TelefonniSeznam
    - uvnitr ni budete ukladat dvojice Jmeno - Telefonni cislo
    - k tomu pouzijte Dictionary, jehoz klice budou stringy a hodnoty integery
    - v ramci konstruktoru vyplnte nekolik jmen a cisel
    - vytvorte metodu, ktera do slovniku ulozi noveho cloveka a jeho telefonni cislo
    - vytvorte metodu, ktera vrati telefonni cislo cloveka
    - vytvorte metodu, ktera vypise cely telefonni seznam
    - vytvorte metodu, ktera smaze daneho cloveka
    - vytvorte metodu, ktera smaze cely telefonni seznam .Clear()
    - myslete na mozne chybove stavy (co kdyz tam dany clovek neni, co kdyz pridavam cloveka, ktery uz tam je)
    - napiste kratky program, ktery overi funkcnost teto tridy */

    public class Program
    {
        public static void Main()
        {
            TelefonniSeznam telefonniSeznam = new TelefonniSeznam();

            Console.WriteLine("Tel cislo Jana Novaka: " + telefonniSeznam.NajdiTelefon("Jan Novak"));
            telefonniSeznam.VypisSeznam();
            Console.WriteLine();

            telefonniSeznam.PridejKontakt("Eva Nováková", 555123456);
            telefonniSeznam.VypisSeznam();
            Console.WriteLine();

            telefonniSeznam.SmazOsobu("Marie Novakova");
            telefonniSeznam.VypisSeznam();
            Console.WriteLine();

            telefonniSeznam.SmazSezman();
            telefonniSeznam.VypisSeznam();
        }
    }

    public class TelefonniSeznam
    {
        private Dictionary<string, int> seznam;

        public TelefonniSeznam()
        {
            seznam = new Dictionary<string, int>();

            seznam.Add("Jan Novak", 123456789);
            seznam.Add("Marie Novakova", 123456789);
        }

        public void PridejKontakt(string jmeno, int cislo)
        {
            if (seznam.TryAdd(jmeno, cislo))
            {
                Console.WriteLine("Uspesne pridano");
            }
            else
            {
                Console.WriteLine("Uz to existuje");
            }
        }

        public int NajdiTelefon(string jmeno)
        {
            if (seznam.ContainsKey(jmeno))
            {
                return seznam[jmeno];
            }
            else
            {
                Console.WriteLine("Cislo neexistuje");
                return -1;
            }
        }

        public void VypisSeznam()
        {
            foreach (var osoba in seznam)
            {
                Console.WriteLine($"Jméno: {osoba.Key}, Telefon: {osoba.Value}");
            }
        }

        public void SmazOsobu(string jmeno)
        {            
            if (seznam.Remove(jmeno))
            {
                Console.WriteLine("Uspesne smazano");
            }
            else
            {
                Console.WriteLine("Neexistuje");
            }
        }

        public void SmazSezman()
        {
            seznam.Clear();
        }
    }
}