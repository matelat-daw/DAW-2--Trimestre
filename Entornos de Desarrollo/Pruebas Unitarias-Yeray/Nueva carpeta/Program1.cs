public class Program
{
    private static void Main(string[] args)
    {
        int[] array = { 0, 1, 2, 4, 9, 20, 76, 34, 65, 89 };

        int valores = numMenosMedia(array);
        Console.WriteLine(valores);
    }
    public static int numMenosMedia(int[] array) 
    {
        int suma = 0;
        int contador = 0;

        for (int i = 0; i < array.Length; i++)
        {
            suma += array[i];
        }
        int media = suma / array.Length;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < media)
            {
                contador++;
            }
        }
        return contador;
    }
}