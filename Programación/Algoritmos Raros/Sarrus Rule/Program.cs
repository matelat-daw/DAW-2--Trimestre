public class Program
{
    static void Main(string[] args)
    {
        int[,] array = new int[3, 3]
        {
            { 2, 3, 4 },
            { 0, 5, 6 },
            { 4, 3, 2 }
        };
        int[,] result;

        Console.WriteLine("Este Programa Obtiene el Determinanter de un Array de 3x3 con la Regla de Sarrus.\n");
        result = Funciones.arrangeHorizontal(array);

        Console.WriteLine("El Determinante del Array es: {0}", Funciones.getDeterminantH(result));

        result = Funciones.arrangeVertical(array);

        Console.WriteLine("El Determinante del Array es: {0}", Funciones.getDeterminantV(result));
    }
}