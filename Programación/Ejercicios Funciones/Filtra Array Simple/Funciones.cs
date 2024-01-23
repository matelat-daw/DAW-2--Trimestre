public class Funciones
{
    static double[] nuevoarray;

    public static double[] filtrarDatos(double[] array, int position)
    {
        nuevoarray = new double[array.Length - position - 1];
        for (int i = position + 1; i < array.Length; i++)
        {
            nuevoarray[i - position - 1] = array[i];
        }
        return nuevoarray;
    }

    public static void show(double[] nuevoarray)
    {
        Console.Write("Los Valores en el Nuevo Array son: ");
        for (int i = 0; i < nuevoarray.Length; i++)
        {
            if (i < nuevoarray.Length - 1)
            {
                Console.Write("{0}, ", nuevoarray[i]);
            }
            else
            {
                Console.Write("{0}.\n", nuevoarray[i]);
            }
        }
    }

    public static void showForEach(double[] nuevoarray)
    {
        Console.Write("Los Valores en el Nuevo Array son: ");
        int i = 0;
        foreach(double value in nuevoarray) // Para Cada Valor en el Array.
        {
            if (i < nuevoarray.Length - 1)
            {
                // Console.Write("{0}, ", nuevoarray[i]);
                Console.Write("{0}, ", value);
            }
            else
            {
                // Console.Write("{0}.\n", nuevoarray[i]);
                Console.Write("{0}.\n", value);
            }
            i++; // Uso el Índice i Para Saber Cuando Llegué al Final del Array.
        }
    }
}