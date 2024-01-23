public class Program
{
    static double[] array = [1.2, 2.3, 3.4, 4.5, 5.6, 6.7, 7.8, 8.9, 9.1, 10.1, 11.2, 12.3, 13.4, 14.5];

    static void Main(string[] args)
    {
        Console.WriteLine("Este Programa Usa una Función a la que le Pasa un Array con datos de tipo double y calcula la Media del Array.\n");

        Funciones.calcularPromedio(array);
    }
}