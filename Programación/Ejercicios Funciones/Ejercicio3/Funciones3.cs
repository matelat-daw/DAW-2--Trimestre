public class Funciones3
{
    public static int[] array; // Se Declara el Array como Static Para Poder Usarlo Desde Otras Clases, El Ejercicio 6 lo Necesita.

    public static void fill(int size) // La función fill recibe el Tamaño de Array que se Rellenará con Números Aleatorios de 1 a 99.
    {
        array = new int[size]; // Creo el Array array del Tamaño Pasado por Parámetro.
        Random rnd = new Random(); // Creo la Variable rnd Para Obtener Números al Azar.

        for (int i = 0; i < array.Length; i++) // Bucle al Tamaño del Array.
        {
            array[i] = rnd.Next(1, 100); // Relleno el Array con Números al Azar Entre 1 y 99.
        }

        Console.Write("El Array Es: ");
        Funciones1.show(array); // Llamo a la Función show(array) de la Clase Funciones1, Para Poder Usar la Función de Otra Clase hay que Agregar una Referencia al Proyecto que Contiene la Clase: Botón Derecho sobre el Proyecto Ejercicio3 Add o Agregar, Project Reference o Referencia a Proyecto y en la Ventana que se Abre hay que Seleccionar el Proyecto que se Necesite Referenciar, en Este Caso el Proyecto Ejercicio1.
    }
}