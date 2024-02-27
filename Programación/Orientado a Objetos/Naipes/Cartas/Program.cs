public class Program
{
    static void Main(string[] args)
    {
        Mazo mazo = new Mazo();
        Console.WriteLine();
        for (int i = 0; i < 20; i++) // Saca 20 Cartas del Mazo al Azar.
        {
            Console.WriteLine(mazo.daCarta().ToString()); // Las Muestra en Pantalla.
        }
    }
}