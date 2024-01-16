

namespace Agoritmo_Quick_Sort
{
    internal class Funciones
    {
        internal static int[] quickSort(int[] array, int start, int end)
        {
            int i, j, central;
            double pivote;
            central = (start + end) / 2;
            pivote = array[central];
            i = start;
            j = end;
            do
            {
                while (array[i] < pivote) i++;
                while (array[j] > pivote) j--;
                if (i <= j)
                {
                    int temp;
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (start < j)
            {
                quickSort(array, start, j);
            }
            if (i < end)
            {
                quickSort(array, i, end);
            }
            return array;
        }
    }
}