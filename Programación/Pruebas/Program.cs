namespace Pruebas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = [ 1, 2, 3, 4, 5, 4, 3, 2, 1 ];
            // int[] array = [1, 2, 3, 4, 5, 6, 7, 8, 9];
            /* int[] array = new int[75000];
            Random rnd = new Random();
            int i;

            for (i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 10001);
            } */

            Console.WriteLine("Este Programa Ordena un Array con Quick Sort y el Pivote es la Media de la Parte del Array a Ordenar.\n");
            Console.Write("\nEl Array Es: ");
            Funciones.show(array);

            Console.Write("\n\nOrdenado Queda: ");
            array = Funciones.ordenaMuestra(array, 0, array.Length - 1);
            Funciones.show(array);
            Console.WriteLine("\n");
        }
    }
}
