public class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Juego de Cartas");
        Mazo mazo = new Mazo();
        mazo.Show();
        for (int i = 0; i < 25; i++)
        {
            mazo.DaCarta();
        }
        Console.WriteLine("Quedan: {0} Cartas.\n", Mazo.numCartas);
        mazo.Show();
        for (int i = 0; i < 25; i++)
        {
            mazo.DaCarta();
        }
        Console.WriteLine("Quedan: {0} Cartas.\n", Mazo.numCartas);
        mazo.Show();
        mazo.DaCarta();
        mazo.DaCarta();
        mazo.DaCarta();
        mazo.DaCarta();
    }
}