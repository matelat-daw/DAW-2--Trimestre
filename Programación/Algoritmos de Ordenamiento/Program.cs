namespace Algoritmos_de_Ordenamiento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[75000];
            int i;
            int j;
            Random rnd = new Random();
            for (i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 10001);
            }

            Console.WriteLine("Este Programa Ordena un Array por el Método de la Burbuja Mejorado.\n");
            Console.Write("\nEl Array Es: ");
            Funciones.show(array);

            Console.Write("\n\nOrdenado Queda: ");
            array = Funciones.bubleSort(array);
            Funciones.show(array);
            Console.WriteLine("\n");
        }
    }
}