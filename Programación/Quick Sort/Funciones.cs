namespace Quick_Sort
{
    internal class Funciones
    {
        internal static int[] quickSort(int[] array, int first, int last)
        {
            int i;
            int j;
            int central;
            int pivote;

            central = (first + last) / 2;
            pivote = array[central];
            i = first;
            j = last;

            do
            {
                while (array[i] < pivote) i++;
                while (array[j] > pivote) j--;
                if (i <= j)
                {
                    int tmp;
                    tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (j > first)
            {
                quickSort(array, first, j);
            }
            if (i < last)
            {
                quickSort(array, i, last);
            }
            return array;
        }

        internal static void show(int[] array)
        {
            Console.WriteLine("\n");
            for (int i = 0; i < array.Length; i++)
            {
                if (i < array.Length - 1)
                {
                    Console.Write("{0}, ", array[i]);
                }
                else
                {
                    Console.Write("{0}.", array[i]);
                }
            }
        }
    }
}