using System;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main()
    {
        //napiste dva ruzne interfacy: IUmiPocitatObsah, IUmiPocitatObvod
        //implementujte tridy obdelnik a kruh, ktere oba interfacy pouzivaji
        //vlozte jejich instance do seznamu a zavolejte na nich prislusne metody na vypocet obsahu a obvodu

        Obdelnik obdelnik = new Obdelnik();
        obdelnik.PriradStrany(2, 3);

        Ctverec ctverec = new Ctverec();
        ctverec.PriradStrany(2);

        Kruh kruh = new Kruh() { Polomer = 3 };

        List<IUmiPocitatObsah> umiPocitatObsahy = new List<IUmiPocitatObsah> { obdelnik, kruh, ctverec };

        foreach (var item in umiPocitatObsahy)
        {
            var obsah = (item as IUmiPocitatObsah)?.PocitejObsah();
            Console.WriteLine(obsah);
        }
    }

    interface IUmiPocitatObsah
    {
        double PocitejObsah();
    }

    interface IUmiPocitatObvod
    {
        double PocitejObvod();
    }

    public abstract class CtverecAObdelnik
    {
        public int A { get; set; }
        public int B { get; set; }

        public virtual void PriradStrany(int a, int? b = null)
        {
            A = a;
        }
    }

    public class Ctverec : CtverecAObdelnik, IUmiPocitatObsah, IUmiPocitatObvod
    {

        public double PocitejObsah()
        {
            return A * A;
        }

        public double PocitejObvod()
        {
            return 4 * A;
        }

        public override void PriradStrany(int a, int? b = null)
        {
            base.PriradStrany(a, b);
        }
    }

    public class Obdelnik : CtverecAObdelnik, IUmiPocitatObsah, IUmiPocitatObvod
    {
        public double PocitejObsah()
        {
            return A * B;
        }

        public double PocitejObvod()
        {
            return 2 * A + 2 * B;
        }

        public override void PriradStrany(int a, int? b = null)
        {
            base.PriradStrany(a, b);
            if (b != null)
            {
                B = (int)b;
            }
        }
    }

    public class Kruh : IUmiPocitatObsah, IUmiPocitatObvod
    {
        public int Polomer { get; set; }

        public double PocitejObsah()
        {
            return double.Pi * Polomer * Polomer;
        }

        public double PocitejObvod()
        {
            return 2 * Polomer * double.Pi;
        }
    }
}