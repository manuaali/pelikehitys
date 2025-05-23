using System;
using System.Collections.Generic;
using System.Linq;

class Tavara
{
    public string Nimi { get; }
    public double Paino { get; }
    public double Tilavuus { get; }

    public Tavara(string nimi, double paino, double tilavuus)
    {
        Nimi = nimi;
        Paino = paino;
        Tilavuus = tilavuus;
    }

    public override string ToString()
    {
        return Nimi;
    }
}

class Nuoli : Tavara
{
<<<<<<< Updated upstream
    public Nuoli() : base("Nuoli", 0, 0.05) { }
=======
    public Nuoli() : base("Nuoli", 0.1, 0.05) { }
>>>>>>> Stashed changes
}

class Jousi : Tavara
{
<<<<<<< Updated upstream
    public Jousi() : base("Jousi", 1, 1) { }
=======
    public Jousi() : base("Jousi", 1, 4) { }
>>>>>>> Stashed changes
}

class Köysi : Tavara
{
    public Köysi() : base("Köysi", 1, 1.5) { }
}

class Vettä : Tavara
{
    public Vettä() : base("Vettä", 2, 2) { }
}

class RuokaAnnos : Tavara
{
    public RuokaAnnos() : base("Ruoka-annos", 1, 0.5) { }
}

class Miekka : Tavara
{
    public Miekka() : base("Miekka", 5, 3) { }
}

<<<<<<< Updated upstream
=======
class VaritettyTavara<T>
{
    public T Tavara { get; }
    public ConsoleColor Vari { get; }

    public VaritettyTavara(T tavara, ConsoleColor vari)
    {
        Tavara = tavara;
        Vari = vari;
    }

    public void NaytaTavara()
    {
        var vanhaVari = Console.ForegroundColor;
        Console.ForegroundColor = Vari;
        Console.WriteLine(Tavara.ToString());
        Console.ForegroundColor = vanhaVari;
    }
}

>>>>>>> Stashed changes
class Reppu
{
    private List<VaritettyTavara<Tavara>> tavarat = new List<VaritettyTavara<Tavara>>();
    private int maxTavaroidenMaara;
    private double maxPaino;
    private double maxTilavuus;

    public Reppu(int maxTavaroidenMaara, double maxPaino, double maxTilavuus)
    {
        this.maxTavaroidenMaara = maxTavaroidenMaara;
        this.maxPaino = maxPaino;
        this.maxTilavuus = maxTilavuus;
    }

    public bool Lisaa(VaritettyTavara<Tavara> tavara)
    {
        if (tavarat.Count >= maxTavaroidenMaara ||
            LaskePaino() + tavara.Tavara.Paino > maxPaino ||
            LaskeTilavuus() + tavara.Tavara.Tilavuus > maxTilavuus)
        {
            return false;
        }

        tavarat.Add(tavara);
        return true;
    }

    public double LaskePaino() => tavarat.Sum(t => t.Tavara.Paino);
    public double LaskeTilavuus() => tavarat.Sum(t => t.Tavara.Tilavuus);

    public override string ToString()
    {
        if (tavarat.Count == 0)
            return "Reppu on tyhjä.";

        string sisalto = "Repussa on:\n";
        foreach (var t in tavarat)
        {
            t.NaytaTavara();
        }
        return sisalto;
    }
}

class Program
{
    static void Main()
    {
        var kaikkiTavarat = new List<Tavara>
        {
            new Nuoli(),
            new Jousi(),
            new Köysi(),
            new Vettä(),
            new RuokaAnnos(),
            new Miekka()
        };

        var reppu = new Reppu(10, 30, 20);

        while (true)
        {
            Console.WriteLine(reppu);
            Console.WriteLine($"\nRepun tilanne: {reppu.LaskePaino():0.##} kg / 30 kg, {reppu.LaskeTilavuus():0.##} tilavuusyksikköä / 20\n");

            Console.WriteLine("Mitä haluat lisätä? (kirjoita tavaran numero tai nimi, tyhjä lopettaa)");
            for (int i = 0; i < kaikkiTavarat.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {kaikkiTavarat[i].Nimi}");
            }

            string syote = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(syote))
                break;

            if (int.TryParse(syote, out int indeksinumero) && indeksinumero >= 1 && indeksinumero <= kaikkiTavarat.Count)
            {
                syote = kaikkiTavarat[indeksinumero - 1].Nimi;
            }

            Tavara valittuTavara = syote.ToLower() switch
            {
                "nuoli" => new Nuoli(),
                "jousi" => new Jousi(),
                "köysi" => new Köysi(),
                "vettä" => new Vettä(),
                "ruoka-annos" => new RuokaAnnos(),
                "miekka" => new Miekka(),
                _ => null
            };

            if (valittuTavara != null)
            {
                ConsoleColor vari = valittuTavara.Nimi switch
                {
<<<<<<< Updated upstream
=======
                    "Nuoli" => ConsoleColor.Cyan,
                    "Jousi" => ConsoleColor.Green,
                    "Köysi" => ConsoleColor.Yellow,
                    "Vettä" => ConsoleColor.Blue,
                    "Ruoka-annos" => ConsoleColor.Magenta,
                    "Miekka" => ConsoleColor.Red,
                    _ => ConsoleColor.White
                };

                var varitetty = new VaritettyTavara<Tavara>(valittuTavara, vari);

                if (reppu.Lisaa(varitetty))
                {
>>>>>>> Stashed changes
                    Console.WriteLine($"{valittuTavara.Nimi} lisättiin reppuun.");
                }
                else
                {
                    Console.WriteLine("Ei mahdu reppuun.");
                }
            }
            else
            {
                Console.WriteLine("Mikäs se tämä tavara on?");
            }
        }
    }
}
