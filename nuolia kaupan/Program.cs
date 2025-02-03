namespace nuolia_kaupan;


using System;

enum KarkiTyyppi { Puu = 3, Teräs = 5, Timantti = 50 }
enum PeraTyyppi { Lehti = 0, Kanansulka = 1, Kotkansulka = 5 }

class Nuoli
{
    public KarkiTyyppi Karki { get; set; }
    public PeraTyyppi Pera { get; set; }
    public int VarrenPituus { get; set; }

    public Nuoli(KarkiTyyppi karki, PeraTyyppi pera, int varrenPituus)
    {
        Karki = karki;
        Pera = pera;
        VarrenPituus = varrenPituus;
    }

    public double PalautaHinta()
    {
        double varrenHinta = VarrenPituus * 0.05;
        return (int)Karki + (int)Pera + varrenHinta;
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
