public class Funciones1
{
    public static int minimo(int[] array) // Función que Obtiene el Número Más Pequeño del Array, Recibe el Array como Parámetro.
    {
        int small = array[0]; // Declaro y Asigno a una Variable de Tipo int llamada small el Primer Valor en el Array, se Usará como Pivote.

        for (int i = 1; i < array.Length; i++) // Bucle al Tamaño del Array, Pero Comenzando desde 1, ya que el Pivote es el Primer Valor del Array.
        {
            if (array[i] < small) // Si el Valor en la posición i del Array es Menor que el Pivote (small).
            {
                small = array[i]; // Asigno a small el Contenido en la Posición Actual en el Array.
            }
        }
        return small; // Cuando Finaliza el Bucle Retorno small que Contendrá el Valor Mínimo en el Array.
    }

    public static void show(int[] array) // Función para Mostrar el Array, Recibe el Array como Parámetro.
    {
        for (int i = 0; i < array.Length; i++) // Bucle al Tamaño del Array.
        {
            if (i < array.Length - 1) // Si aun no Llego a la Anteúltima Posición.
                Console.Write("{0}, ", array[i]); // Muestro el Contenido del Array Separado por ,.
            else // Si llegó a la Última Posición.
                Console.Write("{0}.", array[i]); // Muestro el Último valor del Array y el Punto Final.
        }
    }
}