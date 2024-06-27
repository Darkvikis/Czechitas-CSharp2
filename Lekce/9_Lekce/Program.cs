// Vytvor unit test pomoci xUnit projektu a napis testy pro staticke
// metody Secti a Vydel.
namespace Kalkulacka;
public static class Kalkulacka
{
    public static double Secti(double x, double y)
    {
        return (x + y);
    }

    public static double Vydel(double x, double y)
    {
        return (x / y);
    }
}

public class Program
{
    public static void Main()
    {
        //Console.WriteLine("Hello World");
    }
}