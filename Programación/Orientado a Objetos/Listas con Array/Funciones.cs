
public class Funciones
{
    public static void insertar(int[] array, ref int qtty, int position, int num)
    {
        if (position < array.Length)
        {
            for (int i = array.Length - 1; i > position; i--)
            {
                array[i] = array[i - 1];
            }
            array[position] = num;
            qtty++;
        }
        else
        {
            throw new Exception();
        }
    }

    public static void mostrar(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("En la Posición {0} del Array hay: {1}", i, array[i]);
        }
    }
}