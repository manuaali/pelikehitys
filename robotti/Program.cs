using System;
namespace robotti;
public interface IRobottiKasky
{
    void Suorita(Robotti robotti);
}

public class Käynnistä : IRobottiKasky
{
    public void Suorita(Robotti robotti)
    {
        robotti.OnKaynnissa = true;
    }
}

public class Sammuta : IRobottiKasky
{
    public void Suorita(Robotti robotti)
    {
        robotti.OnKaynnissa = false;
    }
}

public class Ylös : IRobottiKasky
{
    public void Suorita(Robotti robotti)
    {
        if (robotti.OnKaynnissa) robotti.Y++;
    }
}

public class Alas : IRobottiKasky
{
    public void Suorita(Robotti robotti)
    {
        if (robotti.OnKaynnissa) robotti.Y--;
    }
}

public class Vasen : IRobottiKasky
{
    public void Suorita(Robotti robotti)
    {
        if (robotti.OnKaynnissa) robotti.X--;
    }
}

public class Oikea : IRobottiKasky
{
    public void Suorita(Robotti robotti)
    {
        if (robotti.OnKaynnissa) robotti.X++;
    }
}

public class Robotti
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool OnKaynnissa { get; set; }
    public IRobottiKasky[] Kaskyt { get; set; } = new IRobottiKasky[3];

    public void Suorita()
    {
        foreach (IRobottiKasky kasky in Kaskyt)
        {
            kasky?.Suorita(this);
            Console.WriteLine($"Robotti: [{X} {Y} {OnKaynnissa}]");
        }
    }
}

class Program
{
    static void Main()
    {
        Robotti robotti = new Robotti();

        Console.WriteLine("komennot robootille: käynnistä, sammuta, ylös, Alas, Oikea, Vasen.");
        for (int i = 0; i < 3; i++)
        {
            string syote = Console.ReadLine().Trim().ToLower();
            switch (syote)
            {
                case "käynnistä":
                    robotti.Kaskyt[i] = new Käynnistä();
                    break;
                case "sammuta":
                    robotti.Kaskyt[i] = new Sammuta();
                    break;
                case "ylös":
                    robotti.Kaskyt[i] = new Ylös();
                    break;
                case "alas":
                    robotti.Kaskyt[i] = new Alas();
                    break;
                case "vasen":
                    robotti.Kaskyt[i] = new Vasen();
                    break;
                case "oikea":
                    robotti.Kaskyt[i] = new Oikea();
                    break;
                default:
                    Console.WriteLine("virheellinen komento");
                    i--;
                    break;
            }
        }

        robotti.Suorita();
    }
}
