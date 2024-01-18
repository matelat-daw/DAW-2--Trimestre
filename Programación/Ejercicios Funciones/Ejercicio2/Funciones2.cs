public class Funciones2
{
    public static int position(int[] array) // Función position(int[] array) Recibe el Array.
    {
        int result = -1; // Contendrá la posición del Valor Más Pequeño en el Array, se Inicializa a -1, en caso que se Proporcione un Array Vacio, Dará Error.
        int small = array[0]; // Es el Pivote, se le Asigna el Valor en la Primera Posición del Array, se Usa para Saber Cual es el Dato Más Pequeño en el Array.

        for (int i = 1; i < array.Length; i++) // Bucle al Tamaño del Array, Comienza Desde 1.
        {
            if (array[i] < small) // Si el Dato en el Array en la Posición actual es Menor que el Pivote.
            {
                small = array[i]; // Se asigna al Pivote el Valor en el Array.
                result = i; // Y se Asigna a result el Índice, el valor de la variable i en el Bucle.
            }
        }
        return result; // Cuando Sale del Bucle Retorna result.
    }
}