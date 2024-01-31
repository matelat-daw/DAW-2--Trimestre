public class Funciones
{
    public static void insertar(int[] array, ref int qtty, int position, int num)
    {
        //if (position >= 0 && position <= qtty) // Filtra que la posición Esté entre 0 y la Cantidad de Datos en el Array.
        //{
        //    for (int i = qtty; i > position; i--) // Bucle desde la Última Posición del Array, Hasta la posición + 1, Decrementando el Índice.
        //    {
        //        array[i] = array[i - 1]; // Muevo los Elementos del Array de Detrás Para Adelante.
        //    }
        //    array[position] = num; // Pongo el Número Pasado Como Parámetro en la Posición Pasada Como Parámetro.
        //    qtty++; // Incremento la Cantidad de Datos en el Array.
        //}
        //else // Si la Posición no es Valida.
        //{
        //    throw new Exception("ERROR"); // Lanzo una Excepción.
        //}

        if (position < 0 || position > qtty || array.Length == qtty)
            throw new Exception("ERROR");
        for (int i = qtty; i > position; i--) // Bucle desde la Última Posición del Array, Hasta la posición + 1, Decrementando el Índice.
        {
            array[i] = array[i - 1]; // Muevo los Elementos del Array de Detrás Para Adelante.
        }
        array[position] = num; // Pongo el Número Pasado Como Parámetro en la Posición Pasada Como Parámetro.
        qtty++; // Incremento la Cantidad de Datos en el Array.

    }

    public static int extraer(int[] array, ref int qtty, int position)
    {
        int aux;
        //if (position >= 0 && position <= qtty) // Filtra que la posición Esté entre 0 y la Cantidad de Datos en el Array.
        //{
        //    aux = array[position];
        //    for (int i = position + 1; i < qtty; i++) // Bucle desde la Posición Siguiente a la Posición Pasada del Array, Hasta la Última Posición del Array Incrementando el Índice.
        //    {
        //        array[i - 1] = array[i]; // Muevo los Elementos del Array de Delante Para atrás.
        //    }
        //    qtty--; // Incremento la Cantidad de Datos en el Array.
        //}
        //else // Si la Posición no es Valida.
        //{
        //    throw new Exception("ERROR"); // Lanzo una Excepción.
        //}
        if (position < 0 || position >= qtty)
            throw new Exception();
        aux = array[position];
        for (int i = position + 1; i < qtty; i++) // Bucle desde la Posición Siguiente a la Posición Pasada del Array, Hasta la Última Posición del Array Incrementando el Índice.
        {
            array[i - 1] = array[i]; // Muevo los Elementos del Array de Delante Para atrás.
        }
        qtty--; // Incremento la Cantidad de Datos en el Array.
        return aux;
    }

    public static void mostrar(int[] array, int qtty) // Método que Muestra el Contenido del Array.
    {
        for (int i = 0; i < qtty; i++) // Bucle desde 0 Hasta el tamaño del Array - 1.
        {
            Console.WriteLine("En la Posición {0} del Array hay: {1}", i, array[i]); // Muestro los Datos.
        }
    }
}