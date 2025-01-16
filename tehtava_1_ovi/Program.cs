namespace tehtava_1_ovi
{
    enum OvenTila
    {
        Auki,
        Kiinni,
        Lukossa
    }

    class Program
    {
        static void Main(string[] args)
        {

            OvenTila tila = OvenTila.Lukossa;

            while (true)
            {
                Console.WriteLine($"Ovi on {tila}. Mitä haluat tehdä? (avaa, sulje, lukitse, avaa_lukko)");

                string syote = Console.ReadLine().ToLower();

                switch (syote)
                {
                    case "avaa":
                        if (tila == OvenTila.Kiinni)
                        {
                            tila = OvenTila.Auki;
                            Console.WriteLine("Ovi avattiin.");
                        }
                        else
                        {
                            Console.WriteLine("Ovea ei voi avata tästä tilasta.");
                        }
                        break;

                    case "sulje":
                        if (tila == OvenTila.Auki)
                        {
                            tila = OvenTila.Kiinni;
                            Console.WriteLine("Ovi suljettiin.");
                        }
                        else
                        {
                            Console.WriteLine("Ovea ei voi sulkea tästä tilasta.");
                        }
                        break;

                    case "lukitse":
                        if (tila == OvenTila.Kiinni)
                        {
                            tila = OvenTila.Lukossa;
                            Console.WriteLine("Ovi lukittiin.");
                        }
                        else
                        {
                            Console.WriteLine("Ovea ei voi lukita tästä tilasta.");
                        }
                        break;

                    case "avaa_lukko":
                        if (tila == OvenTila.Lukossa)
                        {
                            tila = OvenTila.Kiinni;
                            Console.WriteLine("Oven lukko avattiin.");
                        }
                        else
                        {
                            Console.WriteLine("Ovea ei voi avata lukosta tästä tilasta.");
                        }
                        break;

                    default:
                        Console.WriteLine("Tuntematon komento. Yritä uudelleen.");
                        break;
                }

                Console.WriteLine(); 
            }
        }
    }
}