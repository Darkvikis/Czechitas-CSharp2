using System;

public class Program
{
    public static void Main()
    {
        //navrhnete vhodnou strukturu trid, ktera umozni v programu (v Mainu) vytvorit seznam zviratek v zoo koutku (List), 
        //ktery pak muzeme jednoduse projit cyklem (foreach) a zadat kazdemu z nich prikaz VydavejZvuk
        //pritom kazde zviratko bude vydavat jiny zvuk (vypise na konzoli Haf, haf nebo Mnau, mnau)
        //v ramci cyklu nechci resit, jake konkretni zviratko to je
        //vytvorte alespon 3 ruzna zviratka
        //hint: budete potrebovat vhodnou bazovou tridu a virtual/abstract a override
        Pes fik = new();
        Vlk petr = new();
        Kocka haslerka = new();

        List<Zvire> zviratka = new() { fik, petr, haslerka };

        zviratka.ForEach(x => x.UdelaZvuk());
    }

}

public abstract class Zvire
{
    public abstract void UdelaZvuk();
}

public class Pes : Zvire
{
    public override void UdelaZvuk()
    {
        Console.WriteLine("Haf, haf");
    }
}

public class Kocka : Zvire
{
    public override void UdelaZvuk()
    {
        Console.WriteLine("Mnau, mnau");
    }
}

public class Vlk : Pes
{
    public override void UdelaZvuk()
    {
        base.UdelaZvuk();
        Console.WriteLine("Vrrrrrr");
    }
}