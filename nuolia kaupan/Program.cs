namespace nuolia_kaupan;

using System;

enum KarkiTyyppi { Puu = 3, Teräs = 5, Timantti = 50 }
enum PeraTyyppi { Lehti = 0, Kanansulka = 1, Kotkansulka = 5 }

class Nuoli
{
    private KarkiTyyppi karki;
    private PeraTyyppi pera;
    private int varrenPituus;

    public Nuoli(KarkiTyyppi karki, PeraTyyppi pera, int varrenPituus)
    {
        this.karki = karki;
        this.pera = pera;
        this.varrenPituus = varrenPituus;
    }

    public KarkiTyyppi GetKarki()
    {
        return karki;
    }

    public PeraTyyppi GetPera()
    {
        return pera;
    }

    public int GetVarrenPituus()
    {
        return varrenPituus;
    }

    public double PalautaHinta()
    {
        double varrenHinta = varrenPituus * 0.05;
        return (int)karki + (int)pera + varrenHinta;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Minkälainen kärki (Puu, Teräs tai Timantti)?: ");
        KarkiTyyppi karki = (KarkiTyyppi)Enum.Parse(typeof(KarkiTyyppi), Console.ReadLine(), true);

        Console.WriteLine("Minkälaiset sulat (Lehti, Kanansulka vai Kotkansulka)?: ");
        PeraTyyppi pera = (PeraTyyppi)Enum.Parse(typeof(PeraTyyppi), Console.ReadLine(), true);

        Console.WriteLine("Nuolen pituus (60-100cm): ");
        int varrenPituus = int.Parse(Console.ReadLine());

        if (varrenPituus < 60 || varrenPituus > 100)
        {
            Console.WriteLine("Virheellinen pituus! Käytetään oletuksena 60 cm.");
            varrenPituus = 60;
        }

        Nuoli nuoli = new Nuoli(karki, pera, varrenPituus);
        double hinta = nuoli.PalautaHinta();

        Console.WriteLine($"Tämä nuolen hinta on {hinta} kultaa.");
    }
}
