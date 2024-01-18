public class Funciones6
{
    public static void calcula(int[] array) // Función calcula(int[] array) Recibe como Parámetro el Array Creado en la Clase Funciones3 del Proyecto Ejericio3.
    {
        int total = 0; // Declaro la Variable total y le Asigno el Valor 0.

        for (int i = 0; i < array.Length; i++) // Bucle al Tamaño del Array.
        {
            total += array[i]; // Acumulo en la Variable total la Suma de Todos los Valores en el Array.
        }

        Console.WriteLine("La Media de los Valores en el Array es: {0}", total / array.Length); // Muestro por Pantalla La Media de los Valores en el Array, Dividiendo el total por el Tamaño del Array(La Cantidad de Datos en el Array).
    }
}