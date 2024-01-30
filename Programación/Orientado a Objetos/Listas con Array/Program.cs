public class Program
{
    static void Main(string[] args)
    {
        int[] array = new int[10];
        int num;
        int position;
        int size;

        Console.WriteLine("Este Programa Mueve los Datos de un Array a un Posición Determinada.\n");
        do
        {
            Console.Write("Ingresa el Número a Introducir en el Array: ");
            num = int.Parse(Console.ReadLine());
            if (num != 0)
            {
                Console.Write("Ingresa la Posición del Número en el Array: ");
                position = int.Parse(Console.ReadLine());
                Console.Write("Ingresa el Tamaño del Array: ");
                size = int.Parse(Console.ReadLine());
                Funciones.insertar(array, size, position, num);
                Funciones.mostrar(array);
            }
        } while (num != 0);
    }
}