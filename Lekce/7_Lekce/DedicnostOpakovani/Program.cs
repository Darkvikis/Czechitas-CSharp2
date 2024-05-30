using System;

public class Program
{
    public static void Main()
    {
        // Vytvořte abstraktní třídu PohadkovaBytost a v ní abstraktní metodu NapisJakTravisVolnyCas
        // Vytvorte tridy Princezna, Rytir, Carodenice, ktere dedi PohadkovouBytost
        // Naimplementujte metodu NapisJakTravisVolnyCas - vypsanemu textu na konzoli se meze nekladou
        // Vytvorte instance od kazde tridy a vypiste informace o trávení volného času.


        Princezna princezna = new();
        Rytir rytir = new();
        Carodenice carodejnice = new();

        List<PohadkovaBytost> pohadkeBytosti = new() { princezna, rytir, carodejnice };

        pohadkeBytosti.ForEach(x => x.NapisJakTravisVolnyCas());
        pohadkeBytosti.ForEach(x => (x as Princezna)?.SmutnaPrincezna());

        princezna.SmutnaPrincezna();
    }

    abstract class PohadkovaBytost
    {
        public abstract void NapisJakTravisVolnyCas();
    }

    class Princezna : PohadkovaBytost
    {
        public void SmutnaPrincezna()
        {
            Console.WriteLine("Princezna je smutna");
        }

        public override void NapisJakTravisVolnyCas()
        {
            Console.WriteLine("Princezna travi volny cas na zahrade");
        }
    }

    class Rytir : PohadkovaBytost
    {
        public override void NapisJakTravisVolnyCas()
        {
            Console.WriteLine("Rytir travi volny cas na turnaji");
        }
    }

    class Carodenice : PohadkovaBytost
    {
        public override void NapisJakTravisVolnyCas()
        {
            Console.WriteLine("Carodenice travi volny cas v lese");
        }
    }
}