public class Funciones
{
    public static void sumaDatos(double[] array)
    {
        double total = 0;

        for (int i = 0; i < array.Length; i++)
        {
            total += array[i];
        }

        Console.WriteLine("La Suma de los Valores del Array es: {0:f2}", total); // :f2 redondea  a dos decimales.
        Console.WriteLine("La Suma de los Valores del Array es: {0}", total); // Si da Redondo lo muestra sin decimales.
    }
}