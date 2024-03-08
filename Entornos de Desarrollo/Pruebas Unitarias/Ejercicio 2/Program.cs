public class Program
{
    private static void Main(string[] args)
    {
        int[] arrayDescendente = [9, 8, 7, 6, 5, 4, 3, 2, 1]; // Array Oredenado Descendentemente.
        Console.WriteLine(EstaOrdenada(arrayDescendente)); // Devolverá true
    }

    public static bool EstaOrdenada(int[] array) // Método que Comprueba si un Array Está Ordenado de Forma Descendente.
    {
        bool result = true; // Booleano que se Usará para Retornar el Resultado.

        for (int i = 0; i < array.Length - 1; i++) // Bucle Hasta el Tamaño del Array - 1, que se comprobará cada Índice con el Siguiente, Cuando i sea del Tamaño del Array - 1 se Comprobará con el Último Item en el Array.
        {
            if (array[i] < array[i + 1]) // Compruebo si el Dato en el Índice i es Menor que el Dato en el Siguiente Índice.
            {
                result = false; // Si Se Cumple, el Array no está Ordenado de Mayor a Menor, pongo result a false.
                i = array.Length; // Igualo i al Tamaño del Array Para Salir del Bucle.
            }
        }
        return result; // Retorno el Booleano result.
    }
}