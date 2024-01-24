public class Program
{
    static void Main(string[] args)
    {
        double[,] array = new double[3, 3]
        {
            { 2, 3, 4 },
            { 0, 5, 6 },
            { 4, 3, 2 }
        };

        Console.WriteLine("Regla de Sarrus por Patrick.\n");
        Console.WriteLine("El Determinante es: {0}", Funciones.getDeterminate(array));
    }
}