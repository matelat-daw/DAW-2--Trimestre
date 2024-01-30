
public class Funciones
{
    public static void insertar(int[] array, int size, int position, int num)
    {
        if (position < array.Length)
        {
            if (array[position] == 0)
            {
                array[position] = num;
            }
            else
            {
                array[position + 1] = array[position];
                array[position] = num;
            }
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