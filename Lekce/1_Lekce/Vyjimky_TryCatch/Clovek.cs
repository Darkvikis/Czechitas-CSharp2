using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vyjimky_TryCatch
{
    public class Clovek
    {
        public string Jmeno;
        public int TelCislo;

        public Clovek(string jmeno, int telCislo)
        {
            // Kontrolujeme, jestli jmeno neni prazdne nebo ani inicializovane (prazdne je Epmty a inicializovane je null)
            if (String.IsNullOrEmpty(jmeno))
            {
                // Pokud je, tak vyhodime vyjimku a pridame do ni zpravu 
                throw new Exception("Jmeno neni validni.");
            }

            // Kontrolujeme pocet cislic, tim ze prevedeme na string a vratime si jeho delku
            if (telCislo.ToString().Length != 9)
            {
                // Pokud ma jiny pocet, tak vyhodime vyjimku a pridame do ni zpravu 
                // Tady pozivam jinou vyjimku, ktera je takova presnejsi a muzu do ni dat i nazev udaje
                throw new ArgumentException("Cislo neni validni.", nameof(TelCislo));
            }

            Jmeno = jmeno;
            TelCislo = telCislo;
        }

        public string VypisJmenoACislo()
        {
            return $"{Jmeno}: {TelCislo}";
        }
    }
}
