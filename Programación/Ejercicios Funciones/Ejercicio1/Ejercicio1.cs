public class Ejercicio1
{
    static void Main(string[] args)
    {
        int[] array = [1, 2, 3, 4, 5, 6 ,7 ,8 ,9 ,10, -10, -9, -8, -7, -6, -5, -4, -3, -2, -1];

        Console.WriteLine("Este Programa Llama a una Función que le Pasa un Array con Números Enteros Positivos y Negativos y Retorna el valor Mínimo del Array.\n");

        Console.WriteLine("Este es el Array Pasado Como Parámetro.\n");
        Funciones1.show(array); // Llama a la Función show(array) le pasa el array a Mostrar.

        Console.WriteLine("\n\nEl Número Mímino del array es: {0}", Funciones1.minimo(array)); // Muestra el Resultado de la Función minimo(array) que Recibe el Array, Devuelve el Número Más Pequeño en el Array.
    }
}