using System;
namespace robotti;
public abstract class RobottiKasky
{
    public abstract void Suorita(Robotti robotti);
}

public class Kaynnista : RobottiKasky
{
    public override void Suorita(Robotti robotti)
    {
        robotti.OnKaynnissa = true;
    }
}

public class Sammuta : RobottiKasky
{
    public override void Suorita(Robotti robotti)
    {
        robotti.OnKaynnissa = false;
    }
}

public class YlosKasky : RobottiKasky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKaynnissa) robotti.Y++;
    }
}

public class AlasKasky : RobottiKasky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKaynnissa) robotti.Y--;
    }
}

public class VasenKasky : RobottiKasky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKaynnissa) robotti.X--;
    }
}

public class OikeaKasky : RobottiKasky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKaynnissa) robotti.X++;
    }
}

public class Robotti
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool OnKaynnissa { get; set; }
    public RobottiKasky[] Kaskyt { get; set; } = new RobottiKasky[3];

    public void Suorita()
    {
        foreach (RobottiKasky kasky in Kaskyt)
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
                    robotti.Kaskyt[i] = new Kaynnista();
                    break;
                case "sammuta":
                    robotti.Kaskyt[i] = new Sammuta();
                    break;
                case "ylös":
                    robotti.Kaskyt[i] = new YlosKasky();
                    break;
                case "alas":
                    robotti.Kaskyt[i] = new AlasKasky();
                    break;
                case "vasen":
                    robotti.Kaskyt[i] = new VasenKasky();
                    break;
                case "oikea":
                    robotti.Kaskyt[i] = new OikeaKasky();
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