public class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Juego de Cartas");
        Mazo mazo = new Mazo();
        mazo.show();
        for (int i = 0; i < 25; i++)
        {
            mazo.daCarta();
        }
        Console.WriteLine("Quedan: {0} Cartas.\n", Mazo.numCartas);
        mazo.show();
        for (int i = 0; i < 25; i++)
        {
            mazo.daCarta();
        }
        Console.WriteLine("Quedan: {0} Cartas.\n", Mazo.numCartas);
        mazo.show();
        mazo.daCarta();
        mazo.daCarta();
        mazo.daCarta();
    }
}