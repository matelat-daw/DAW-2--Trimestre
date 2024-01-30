
public class Funciones
{
    public static void insertar(int[] array, ref int qtty, int position, int num)
    {
        if (position >= 0 && position < array.Length) // Filtra que la posición Esté entre 0 y 9.
        {
            for (int i = array.Length - 1; i > position; i--) // Bucle desde la Última Posición del Array, Hasta la posición + 1, Decrementando el Índice.
            {
                array[i] = array[i - 1]; // Muevo los Elementos del Array de Detrás Para Adelante.
            }
            array[position] = num; // Pongo el Número Pasado Como Parámetro en la Posición Pasada Como Parámetro.
            qtty++; // Incremento la Cantidad de Datos en el Array.
        }
        else // Si la Posición no es Valida.
        {
            throw new Exception("ERROR"); // Lanzo una Excepción.
        }
    }

    public static void mostrar(int[] array) // Método que Muestra el Contenido del Array.
    {
        for (int i = 0; i < array.Length; i++) // Bucle desde 0 Hasta el tamaño del Array - 1.
        {
            Console.WriteLine("En la Posición {0} del Array hay: {1}", i, array[i]); // Muestro los Datos.
        }
    }
}