using System;

public class Program
{
    public static void Main()
    {

        //Ukol - Obratte poradi stringu
        string palindrom = "Kuna nese nanuk";
        //Prevadime na lowercase (male pismena), at nemame na konci velke pismeno pak
        palindrom = palindrom.ToLower();

        //Prochazime od konce, ale dame si pozor, ze indexujeme od nuly
        //palindrom[i] -> i je od slova index/iter, pouziva se tak nejak vsude v IT svete
        //Tim ze pocitame od 0, tak posledni index se nerovna delce, ale musime odecist 1
        for (int i = (palindrom.Length - 1); i >= 0; i--)
        {
            //Jen kontrolujeme, jestli to je mezera (tu nechceme, at to vzpada lepe)
            if (!Char.IsWhiteSpace(palindrom[i]))
            {
                Console.Write(palindrom[i]);
            }
        }
        Console.WriteLine();

        //Ukol - Napiste funkci, ktera umi detekovat, ze se jedna o palindrom (zatim jen u slov) a pak z pole vypiste jen palindromy
        string[] slova = new string[] { "kajak", "program", "rotor", "Czechitas", "madam", "Jarda", "radar", "nepotopen" };

        //Prochazime kazdou polozku v listu/poli slova (alternativa for cyklu)
        foreach (string item in slova)
        {
            //volame nasi funkci
            if (JePalindrom(item))
            {
                //Palindromy vypisujeme
                Console.WriteLine("Palindrom je: " + item);
            }
        }

        //Ukol - opravte v tomto textu omylem zapnuty Caps Lock
        string capsLock = "jAK mICROSOFT wORD POZNA ZAPNUTY cAPSLOCK";

        //Vytvarime novy string, jelikoz ten nad kterym iteruje (ktery prochazime) se neda moc menit
        string newCapsLock = string.Empty;
        
        //Pro zmenu prochazime cely string bez nejakych zvlastnosti
        for (int i = 0; i < capsLock.Length; i++)
        {
            //Kontrolujeme, jestli je znak velke pismeno
            if (Char.IsUpper(capsLock[i]))
            {
                //Pokud je, tak prevadime na maly
                newCapsLock += char.ToLower(capsLock[i]);
            }
            //Ted jestli je maly znak
            else if (Char.IsLower(capsLock[i]))
            {
                //Pokud je, tak prevadime na velky
                newCapsLock += char.ToUpper(capsLock[i]);
            }
            else
            {
                //Ostatni znaky jen prepiseme
                newCapsLock += capsLock[i];
            }
        }

        Console.WriteLine(newCapsLock);


        //Ukol - rozsifrujte tuto zpravu - text byl zasifrovan tak, ze jsme kazde pismeno posunuli o jedno doprava: 'a' -> 'b'. 
        string sifra = "Wzcpsob!qsbdf!.!hsbuvmvkj!b!ktfn!ob!Ufcf!qztoz";

        //Obdobne jak v predchozim ukolu
        string newSifra = string.Empty;

        for (int i = 0; i < sifra.Length; i++)
        {
            //Nejvetsi cary mary asi :D
            //Char neboli znak je ulozeny jako cislo (a je 97, b je 98,..) viz https://eunhanlee.hashnode.dev/decimal-ascii-table
            //Tim ze byla pouzita Ceasarova sifra (posun toho pismena o x pozic v abecede https://www.geeksforgeeks.org/caesar-cipher-in-cryptography/ )
            //Pro nas text je znak posunut o jedno doprava (pricitani 1)
            //Takze musime posouvat o jedno doleva (odecitani 1), abychom meli desifrovanou zpravu
            //Na co jsem zapomnel, kdyz mi to nefungovalo, tak je (char) tzv cast/prevod z cisla zpatky na znak 
            newSifra += (char)(sifra[i] - 1);
        }

        Console.WriteLine(newSifra);

    }

    //Argumentem si posilame slovo
    public static bool JePalindrom(string slovo)
    {
        //prochazime jednotlive pismena ve slovu
        //Maximalni pocet podelime dvemi, protoze bychom jinak testovali skoro vsechny znaky dvakrat
        //Je dulezite se pak divat na tyto optimalizace v praci
        //Pri slovech co maji +-10 znaku, tak to skoro nepoznate, ale kdyz v praci prochazim list co ma milion zaznamu, tak pulka jde fakt poznat :D
        for (int i = 0; i < slovo.Length/2; i++)
        {
            //Srovname aktualni pozici se znakem s opacnym poradim
            //Opacneho poradi docilime poctem znaků - aktualni pozice - 1 (opet ta jednicka kvuli indexovani od 0)
            if (slovo[i] != slovo[slovo.Length - (i + 1)])
            {
                //pokud najdeme neco co nam nesedi, tak vracime false
                return false;
            }
        }
        //pokud jsme probehli vse v pohode, tak vracime true
        return true;
    }

    //Tohle je takovy hezci a slozitejsi pristup, jak to obratit
    //Neni potreba tohle znat a i ja jsem si to hledal
    //ALE je vzdycky fajn, kdyz se kouknete na dilci problemy 
    //zkusite se kouknout na internet, jestli na to uz neexistuje funkce, at nevymyslite kolo
    static string ReverseString(string input)
    {
        //Prevedeme si to do pole char(znaku)
        var inputArray = input.ToCharArray();
        //Pole maji zabudovanou funkci na obraceni poradi
        Array.Reverse(inputArray);
        //Prevadime na string a vracime
        return new string(inputArray);
    }
}