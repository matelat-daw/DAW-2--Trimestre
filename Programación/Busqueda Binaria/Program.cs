
namespace Busqueda_Binaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int[] array = [10, 20, 30, 40, 50, 60, 70, 80, 90];
            int position;
            int[] array = new int[75000];
            int i;
            Random rnd = new();
            for (i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 10001);
            }

            array = Funciones.quickSort(array, 0, array.Length - 1);

            Console.WriteLine("Este Programa Hace una Busqueda Binaria en un Array de Enteros.\n");
            position = Funciones.search(array, 5000);
            Funciones.show(position);
        }
    }
}