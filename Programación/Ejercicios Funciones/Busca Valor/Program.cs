public class Program
{
    static double[] array = [1.2, 2.3, 3.4, 4.5, 5.6, 6.7, 7.8, 8.9, 9.1, 10.1, 11.2, 12.3, 13.4, 14.5];

    static void Main(string[] args)
    {
        Console.WriteLine("Este Programa usa una Función a la que se le Pasa un Array y un Valor y Devuelve la Posición de ese Valor en el Array.\n");

        int result = Funciones.buscarElemento(array, 11.2);

        if (result == -1)
        {
            Console.WriteLine("El Número Pasado No Está en el Array.");
        }
        else
        {
            Console.WriteLine("El Número Pasado Está en la Posición: {0}", result);
        }
    }
}