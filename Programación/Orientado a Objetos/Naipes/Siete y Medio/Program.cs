public class Program
{
    public static double numero = 0.0;
    public static double banca = 0.0;
    public static bool player = false;
    public static bool bank = false;

    static void Main(string[] args)
    {
        Console.WriteLine("Juego del 7 y Medio.\n");
        Mazo mazo = new Mazo();

        PideJugador(mazo);
        Console.WriteLine("Te Haz Plantado, Tienes: {0}.\n", numero);
        Console.WriteLine("Ahora la Banca Sacará Carta.\n");
        PideBanca(mazo);
        if (numero > 7.5 && banca > 7.5)
        {
            Console.WriteLine("No Pierdes, Tú te has Pasado, Pero la Banca También se ha Pasado.");
        }
        else
        {
            if (numero > banca && numero <= 7.5 || banca > 7.5)
            {
                Console.WriteLine("Haz Ganado Tú Tienes: {0} y la Banca Tiene: {1}", numero, banca);
            }
            else if (numero < banca || numero > 7.5 && banca <= 7.5)
            {
                Console.WriteLine("Haz Perdido la Banca Tiene: {0} y Tú Tienes: {1}", banca, numero);
            }
            else
            {
                Console.WriteLine("Hay Empate la Banca Tiene: {0} y Tú Tienes: {1}", banca, numero);
            }
        }
    }

    private static void PideJugador(Mazo mazo)
    {
        int num = mazo.DaCarta().getNumero() + 1;

        if (num > 7)
        {
            if (!player)
            {
                numero = .5;
                player = true;
            }
            else
            {
                numero += .5;
            }
        }
        else
        {
            numero += num;
            player = true;
        }
        Console.WriteLine($"Tienes: {numero} Puntos.");
        Console.Write("Quieres Otra Carta: s Para Otra Carta, Enter Para Plantarte.");
        string response = Console.ReadLine().ToLower();
        if (response == "s")
        {
            PideJugador(mazo);
        }
    }

    private static void PideBanca(Mazo mazo)
    {
        int num = mazo.DaCarta().getNumero() + 1;

        if (num > 7)
        {
            if (!bank)
            {
                banca = .5;
                bank = true;
            }
            else
            {
                banca += .5;
            }
        }
        else
        {
            banca += num;
            bank = true;
        }
        Console.WriteLine("La Banca Tiene: {0}", banca);

        if (banca < 5)
        {
            PideBanca(mazo);
        }
    }
}