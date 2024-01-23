public class Program
{
    static void Main(string[] args)
    {

        double[] array = [1.2, 2.3, 3.4, 4.5, 5.6, 6.7, 7.8, 8.9, 9.1, 10.1, 11.2, 12.3, 13.4, 14.5];
        Console.WriteLine("Este Programa Usa una Función a la que le Pasa un Array con datos de tipo double y calcula el Total de la Suma de los Datos del Array.\n");

        Funciones.sumaDatos(array);
    }
}