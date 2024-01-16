namespace Pruebas
{
    internal class Funciones
    {
        internal static int[] ordenaMuestra(int[] array, int start, int end)
        {
            int i;
            int j;
            long accu = 0;
            double pivote;

            for (i = start; i < end; i++)
            {
                accu += array[i];
            }
            pivote = (int)(accu / (end - start));
            pivote = Math.Ceiling(pivote);

            i = start;
            j = end;

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
            show(array);
            if (j > start)
            {
                ordenaMuestra(array, start, j);
            }
            if (i < end)
            {
                ordenaMuestra(array, i, end);
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