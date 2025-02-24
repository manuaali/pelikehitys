using System;
using System.Collections.Generic;
using System.Linq;

class Tavara
{
    public string Nimi { get; }
    public int Paino { get; }
    public double Tilavuus { get; }

    public Tavara(string nimi, int paino, double tilavuus)
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

class Reppu
{
    private List<Tavara> tavarat = new List<Tavara>();
    private int maxTavaroidenMaara;
    private int maxPaino;
    private double maxTilavuus;

    public Reppu(int maxTavaroidenMaara, int maxPaino, double maxTilavuus)
    {
        this.maxTavaroidenMaara = maxTavaroidenMaara;
        this.maxPaino = maxPaino;
        this.maxTilavuus = maxTilavuus;
    }

    public bool Lisaa(Tavara tavara)
    {
        if (tavarat.Count >= maxTavaroidenMaara ||
            LaskePaino() + tavara.Paino > maxPaino ||
            LaskeTilavuus() + tavara.Tilavuus > maxTilavuus)
        {
            return false;
        }

        tavarat.Add(tavara);
        return true;
    }

    public int LaskePaino() => tavarat.Sum(t => t.Paino);
    public double LaskeTilavuus() => tavarat.Sum(t => t.Tilavuus);

    public override string ToString()
    {
        return tavarat.Count > 0
            ? $"Repussa on seuraavat tavarat: {string.Join(", ", tavarat)}"
            : "Reppu on tyhjä.";
    }
}

class Program
{
    static void Main()
    {
        var kaikkiTavarat = new List<Tavara>
        {
            new Tavara("Nuoli", 0, 0.05),
            new Tavara("Jousi", 1, 1),
            new Tavara("Köysi", 1, 1.5),
            new Tavara("Vettä", 2, 2),
            new Tavara("Ruoka-annos", 1, 0.5),
            new Tavara("Miekka", 5, 3)
        };

        var reppu = new Reppu(10, 30, 20);

        while (true)
        {
            Console.WriteLine(reppu);
            Console.WriteLine("\nMitä haluat lisätä? (kirjoita tavaran numero tai nimi, tyhjä lopettaa)");
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

            var valittuTavara = kaikkiTavarat.Find(t => t.Nimi.Equals(syote, StringComparison.OrdinalIgnoreCase));

            if (valittuTavara != null)
            {
                if (reppu.Lisaa(valittuTavara))
                {
                    Console.WriteLine($"{syote} lisättiin reppuun.");
                }
                else
                {
                    Console.WriteLine("ei mahdu reppuun.");
                }
            }
            else
            {
                Console.WriteLine("mikäs se tämä tavara on?");
            }
        }
    }
}
