
public class Funciones
{
    public static void incrementa(ref int number, ref int tope)
    {
        if (number == tope - 1)
        {
            number = 0;
        }
        else
        {
            number++;
        }
    }

    public static void decrementa(ref int number, ref int tope)
    {
        if (number == 0)
        {
            number = tope - 1;
        }
        else
        {
            number--;
        }
    }

    public static void show(int number)
    {
        Console.WriteLine("El Número Incrementado es: {0}", number);
    }
}