public class Funciones2
{
    public static int position(int[] array) // Función position(int[] array) Recibe el Array.
    {
        int position = 0; // La Posición 0, se le Asigna el Índice de la Primera Posición del Array.

        for (int i = 1; i < array.Length; i++) // Bucle al Tamaño del Array, Comienza Desde 1.
        {
            if (array[i] < array[position]) // Si el Dato en el Array en la Posición actual es Menor que el Pivote.
            {
                position = i; // Y se Asigna a result el Índice, el valor de la variable i en el Bucle.
            }
        }
        return position; // Cuando Sale del Bucle Retorna result.
    }
}