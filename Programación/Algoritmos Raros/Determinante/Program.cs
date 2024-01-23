namespace Determinante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa que Calcula el Determinante de un Array de 3 X 3.\n");

            // Declaration of variables for matrix manipulation
            int i, j;
            int[,] arr1 = new int[3, 3]; // Declare a 3x3 integer matrix
            int det = 0; // Initialize determinant value to zero

            // User input for matrix elements

            Console.Write("Ingresa los Elementos del Array: \n");
            for (i = 0; i < 3; i++) // Loop through rows
            {
                for (j = 0; j < 3; j++) // Loop through columns
                {
                    // Prompt user to enter matrix element
                    Console.Write("element - [{0}],[{1}] : ", i, j);
                    arr1[i, j] = Convert.ToInt32(Console.ReadLine()); // Read user input and store in the matrix
                }
            }

            // Display the entered matrix
            Funciones.show(arr1);

            // Calculate the determinant of the 3x3 matrix using the method for a 3x3 matrix
            Funciones.getDeterminant(arr1);
        }
    }
}