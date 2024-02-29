using System.Security.Cryptography;

public class Program
{
    static void Main(string[] args)
    {
        ConsoleKeyInfo key;
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Juego de Cartas");
        Mazo mazo = new();
        Menu menu = new();
        menu.Show();
        Console.WriteLine("Selecciona una Opción del Menú: ");
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Escape)
        {
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    break;
            }
        }
        Jugador player = new Jugador("César", 100);
        Console.WriteLine("Bienvenido Jugador: {0}, Tienes: {1} € para Apostar.", player.Nombre, player.Dinero);
        //mazo.Show();
        //for (int i = 0; i < 25; i++)
        //{
        //    mazo.DaCarta();
        //}
        //Console.WriteLine("Quedan: {0} Cartas.\n", Mazo.numCartas);
        //mazo.Show();

        //for (int i = 0; i < 25; i++)
        //{
        //    mazo.DaCarta();
        //}
        //Console.WriteLine("Quedan: {0} Cartas.\n", Mazo.numCartas);
        //mazo.Show();
        //mazo.DaCarta();
        //mazo.DaCarta();
        //mazo.DaCarta();
        //mazo.DaCarta();
    }
}