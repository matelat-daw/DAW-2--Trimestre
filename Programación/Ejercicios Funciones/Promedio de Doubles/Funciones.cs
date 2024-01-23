public class Funciones
{
    public static void calcularPromedio(double[] array)
    {
        double total = 0;
        int qtty = array.Length;

        for (int i = 0; i < qtty; i++)
        {
            total += array[i];
        }

        Console.WriteLine("El Promedio de los Valores del Array es: {0}", total / qtty);
    }
}