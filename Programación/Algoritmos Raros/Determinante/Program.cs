public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Programa que Calcula el Determinante de un Array de 3 X 3.\n");

        // Declaration of variables for matrix manipulation
        int i, j;
        int[,] array = new int[3, 3]
        {
            { 2, 3, 4 },
            { 0, 5, 6 },
            { 4, 3, 2 }
        };
        int det = 0; // Initialize determinant value to zero

        // Display the entered matrix
        Funciones.show(array);

        // Calculate the determinant of the 3x3 matrix using the method for a 3x3 matrix
        Funciones.getDeterminant(array);
    }
}