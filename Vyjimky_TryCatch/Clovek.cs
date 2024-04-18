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
            Jmeno = jmeno;
            TelCislo = telCislo;
        }

        public string VypisJmenoACislo()
        {
            return $"{Jmeno}: {TelCislo}";
        }
    }
}
