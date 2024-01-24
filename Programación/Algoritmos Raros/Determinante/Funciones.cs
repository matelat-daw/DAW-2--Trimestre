public class Funciones
{
    public static void getDeterminant(int[,] arr1)
    {
        int i, j, det = 0;
        for (i = 0; i < 3; i++)
            det = det + (arr1[0, i] * (arr1[1, (i + 1) % 3] * arr1[2, (i + 2) % 3] - arr1[1, (i + 2) % 3] * arr1[2, (i + 1) % 3]));

        // Display the determinant of the matrix
        Console.Write("\nThe Determinant of the matrix is: {0}\n\n", det);
    }

    public static void show(int[,] arr1)
    {
        int i, j;

        Console.Write("The matrix is :\n");
        for (i = 0; i < 3; i++) // Loop through rows
        {
            for (j = 0; j < 3; j++) // Loop through columns
                Console.Write("{0}  ", arr1[i, j]); // Print each element of the matrix
            Console.Write("\n"); // Move to the next row
        }
    }
}