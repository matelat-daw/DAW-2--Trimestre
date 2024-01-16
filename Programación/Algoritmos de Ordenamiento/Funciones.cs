
using System;

namespace Algoritmos_de_Ordenamiento
{
    internal class Funciones
    {
        internal static int[] bubleSort(int[] array)
        {
            int j;
            int i = array.Length - 1;
            int index;

            while (i > 0)
            {
                index = 0;
                for (j = 0; j < i; j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        int aux = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = aux;
                        index = j;
                    }
                }
                i = index;
            }
            return array;
        }

        internal static void show(int[] array)
        {
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