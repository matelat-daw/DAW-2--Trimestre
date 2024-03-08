public class Program
{
    private static void Main(string[] args)
    {
        int[] array = [1, 5, 7, 3, 9, 20, 76, 34, 65, 89]; // Declaración y Asignación del Array array.

        Console.WriteLine(NumMenosMedia(array)); // Imprime el Resulatado de la Llamada a la Función.
    }

    public static int NumMenosMedia(int[] array) // Método Para Comprobar la Cantidad de Número Inferiores a la Media de la Suma de todos los Valores en el Array.
    {
        int suma = 0; // Para Acumular la Suma.
        int contador = 0; // Para Contar los Valores Inferiores a la Media.

        for (int i = 0; i < array.Length; i++) // Bucle al Tamaño del Array.
        {
            suma += array[i]; // Acumula la Suma de Todos los Valores en la Variable suma.
        }
        int media = suma / array.Length; // Asigna a la Variable media la Media de la Suma.

        for (int i = 0; i < array.Length; i++) // Bucle al Tamaño del Array.
        {
            if (array[i] < media) // Compruebo si el Valor en el Array en el Índice i es Menor que la media.
            {
                contador++; // Si se Cumple, Incremento el Contador.
            }
        }
        return contador; // Retorno el Contador.
    }
}