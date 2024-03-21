using Baraja;

public class Program
{
    static void Main(string[] args)
    {
        Mazo mazo = new();
        Mano mano = new ManoSieteyMedia();
        char opcion;
        try
        {
            do
            {
                mano.AñadeCarta(mazo.DaCarta());
                Console.WriteLine(mano);
                Console.Write("¿Desea otra carta? (n Para Terminar, Cualquier Otra Para Tomar Carta): ");
                opcion = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
            } while (opcion != 'n');
            Console.WriteLine("Prudencia y suerte.");
        }
        catch (Exception)
        {
            Console.WriteLine(mano);
            Console.WriteLine("\nPerdiste por pasar el límite de 7.5 puntos.");
        }
        Console.WriteLine($"Tienes {mano.CuentaPuntos():f1} puntos");
    }

    private static void PruebaNaipes()
    {
        Mazo m = new();
        Carta[] cartas = new Carta[5];
        for (int i = 0; i < cartas.Length; i++)
            cartas[i] = m.DaCarta();
        mostrar(cartas);
    }

    private static void mostrar(Carta[] cartas)
    {
        for (int i = 0; i < cartas.Length; i++)
        {
            Console.WriteLine(cartas[i]);
        }
    }
}