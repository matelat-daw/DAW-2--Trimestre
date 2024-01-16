
namespace Parámetros
{
    internal class Funciones
    {
        internal static void intercambia(double num1, double num2)
        {
            double aux;
            aux = num1;
            num1 = num2;
            num2 = aux;
        }

        internal static void intercambia(ref double num1, ref double num2)
        {
            double aux;
            aux = num1;
            num1 = num2;
            num2 = aux;
        }

        internal static void intercambia(double[] array)
        {
            double aux;
            aux = array[0];
            array[0] = array[1];
            array[1] = aux;
        }

        internal static void intercambia(double[] array, bool second)
        {
            array = new double[array.Length]; // Si se Crea una Nueva Tabla los Valores no se Pierden.
            double aux;
            aux = array[0];
            array[0] = array[1];
            array[1] = aux;
        }

        internal static void intercambia(ref double[] array)
        {
            array = new double[array.Length]; // Si se Crea una Nueva Tabla los Valores se Pierden, se Rellena con 0.
            array[0] = 0;
            array[1] = 1;
            double aux;
            aux = array[0];
            array[0] = array[1];
            array[1] = aux;
        }

        internal static void show(double num1, double num2)
        {
            Console.WriteLine("\nEl Número 1 es: {0}\nEl Número 2 es: {1}", num1, num2);
            Console.WriteLine("\nEl Punto es: [ {0}, {1} ]", num1, num2);
        }
    }
}