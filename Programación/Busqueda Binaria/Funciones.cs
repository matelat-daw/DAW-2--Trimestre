

namespace Busqueda_Binaria
{
    internal class Funciones
    {
        internal static int search(int[] array, int clave)
        {
            int position;

            int central, bajo, alto;
            int valorCentral;
            bajo = 0;
            alto = array.Length - 1;
            while (bajo <= alto)
            {
                central = (bajo + alto) / 2; /* índice de elemento central */
                valorCentral = array[central]; /* valor del índice central */
                if (clave == valorCentral)
                {
                    return central; /* encontrado, devuelve posición */
                }
                else if (clave < valorCentral)
                {
                    alto = central - 1; /* ir a sublista inferior */
                }
                else
                {
                    bajo = central + 1; /* ir a sublista superior */
                }
            }
            return -1;
        }

        internal static void show(int position)
        {
            if (position >= 0)
            {
                Console.WriteLine("El Número Buscado está en el Array en la Posición: {0}", position);
            }
            else
            {
                Console.WriteLine("El Número no está en el Array.");
            }
        }

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
    }
}