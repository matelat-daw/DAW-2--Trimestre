public class Program
{
    static void Main(string[] args)
    {
        int[] array = [22, 33, 44, 55, 66, 77, 0, 0, 0, 0];
        int num;
        int position;
        int qtty = 6;

        Console.WriteLine("Este Programa Mueve los Datos de un Array a un Posición Determinada.\n");
        do
        {
            Console.Write("Ingresa el Número a Introducir en el Array: ");
            num = int.Parse(Console.ReadLine());
            if (num != 0)
            {
                Console.Write("Ingresa la Posición del Número en el Array: ");
                position = int.Parse(Console.ReadLine());
                Funciones.insertar(array, ref qtty, position, num);
                Funciones.mostrar(array);
            }
        } while (num != 0);
    }
}