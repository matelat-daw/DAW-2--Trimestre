namespace Parámetros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = 3.3;
            double num2 = 8.8;
            double[] array = [num1, num2];

            Console.WriteLine("Paso de Parámetros");

            Console.WriteLine("\nPor Copia, No Modifica el Valor Original de las Variables.\n");
            Funciones.show(num1, num2);
            Funciones.intercambia(num1, num2);
            Funciones.show(num1, num2);

            Console.WriteLine("\nPor Referencia, Modifica el Valor Original de las Variables.\n");
            Funciones.show(num1, num2);
            Funciones.intercambia(ref num1, ref num2);
            Funciones.show(num1, num2);

            Console.WriteLine("\nPor Referencia, al Pasarle un Array se pasa la Referencia a la Dirección de Memoria Donde Están los Datos.\n");
            Funciones.show(array[0], array[1]);
            Funciones.intercambia(array);
            Funciones.show(array[0], array[1]);

            Console.WriteLine("\nPor Referencia, al Pasarle un Array se pasa la Referencia a la Dirección de Memoria Donde Están los Datos.\n");
            Funciones.show(array[0], array[1]);
            Funciones.intercambia(array, false);
            Funciones.show(array[0], array[1]);

            Console.WriteLine("\nPor Referencia, al Pasarle un Array se pasa la Referencia a la Dirección de Memoria Donde Están los Datos.\n");
            Funciones.show(array[0], array[1]);
            Funciones.intercambia(ref array);
            Funciones.show(array[0], array[1]);
        }
    }
}
