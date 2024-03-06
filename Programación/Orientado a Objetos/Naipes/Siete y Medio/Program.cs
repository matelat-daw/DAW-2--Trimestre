public class Program
{
    public static double player = 0.0;
    public static double banca = 0.0;

    static void Main(string[] args)
    {
        Console.WriteLine("Juego del 7 y Medio.\n");
        Mazo mazo = new();
        Console.WriteLine("\nEsta es tu Mano.\n");
        player = mazo.GetPlayer();
        Console.WriteLine("\nAhora la Banca Sacará Carta.\n");
        banca = mazo.GetBank();
        if (player > 7.5 && banca > 7.5)
        {
            Console.WriteLine("No Pierdes, Tú te has Pasado, Pero la Banca También se ha Pasado.");
        }
        else
        {
            if (player > banca && player <= 7.5 || banca > 7.5)
            {
                Console.WriteLine("Haz Ganado Tú Tienes: {0} y la Banca Tiene: {1}", player, banca);
            }
            else if (player < banca || player > 7.5 && banca <= 7.5)
            {
                Console.WriteLine("Haz Perdido la Banca Tiene: {0} y Tú Tienes: {1}", banca, player);
            }
            else
            {
                Console.WriteLine("Hay Empate la Banca Tiene: {0} y Tú Tienes: {1}", banca, player);
            }
        }
    }
}