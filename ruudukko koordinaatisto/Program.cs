namespace ruudukko_koordinaatisto;
struct Koordinaatti
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Koordinaatti(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool OnVieressa(Koordinaatti toinen)
    {
        int deltaX = Math.Abs(X - toinen.X);
        int deltaY = Math.Abs(Y - toinen.Y);
        return (deltaX == 1 && deltaY == 0) || (deltaX == 0 && deltaY == 1);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Syötä X-koordinaatti: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Syötä Y-koordinaatti: ");
        int y = int.Parse(Console.ReadLine());

        Koordinaatti keskipiste = new Koordinaatti(x, y);
        Koordinaatti[] viereisetKoordinaatit =
        {
            new Koordinaatti(x - 1, y - 1),
            new Koordinaatti(x - 1, y),
            new Koordinaatti(x - 1, y + 1),
            new Koordinaatti(x, y - 1),
            new Koordinaatti(x, y + 1),
            new Koordinaatti(x + 1, y - 1),
            new Koordinaatti(x + 1, y),
            new Koordinaatti(x + 1, y + 1)
        };

        Console.WriteLine($"Koordinaatit sen ympärillä:");
        foreach (var koord in viereisetKoordinaatit)
        {
            Console.WriteLine($"({koord.X}, {koord.Y})");
        }
    }
}


