internal class Program
{
    private static void Main(string[] args)
    {
        int[] arrayDescendente = { 10, 8, 6, 4, 2 };
        Console.WriteLine(estaOrdenada(arrayDescendente)); // Devolverá true

        int[] arrayNoDescendente = { 5, 3, 7, 1, 9 };
        Console.WriteLine(estaOrdenada(arrayNoDescendente)); // Devolverá false
    }

    public static bool estaOrdenada(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] < array[i + 1])
            {
                return false;
            }
        }
        return true;
    }
}