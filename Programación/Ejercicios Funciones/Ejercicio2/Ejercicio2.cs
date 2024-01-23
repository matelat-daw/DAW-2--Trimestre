public class Ejercicio2
{
    static void Main(string[] args)
    {
        int[] array = [1, 2, 3, 4, -20, 6, 7, 8, 9, 10, -10, -9, -8, -7, -6, -5, -4, -3, -2, -1];

        Console.WriteLine("Este Programa Llama a una Función que le Pasa un Array con Números Enteros Positivos y Negativos y Retorna la Posición del valor Mínimo del Array.\n");

        Console.WriteLine("Este es el Array Pasado Como Parámetro.\n");
        Funciones1.show(array); // Llama a la Función show(array) en la clase Funciones1 que Pertenece a la Clase Ejercicio1, para poder hacer eso, hay que Agregar una Referencia a la Clase Ejercicio1: Botón Derecho sobre el Proyecto Ejercicio2 Add o Agregar, Project Reference o Referencia a Proyecto y en la Ventana que se Abre hay que Seleccionar el Proyecto que se Necesite Referenciar, en Este Caso el Proyecto Ejercicio1.

        Console.WriteLine("\n\nLa Posición en el Array del Número Más Pequeño es: {0}", Funciones2.position(array)); // Muestra el resultado del Método position(array) de la Funcion2, Devuelve la Posición en el Array del Número Más Pequeño.
    }
}