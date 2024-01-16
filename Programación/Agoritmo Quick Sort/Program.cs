namespace Agoritmo_Quick_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = [1, 2, 3, 4, 3, 2, 1];
            int[] array2 = new int[array.Length];
            int start = 0;
            int end = array.Length - 1;
            Console.WriteLine("Hello, World!");
            array2 = Funciones.quickSort(array, start, end);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0}, ", array[i]);
            }
            Console.WriteLine("\n");
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write("{0}, ", array2[i]);
            }
        }
    }
}
