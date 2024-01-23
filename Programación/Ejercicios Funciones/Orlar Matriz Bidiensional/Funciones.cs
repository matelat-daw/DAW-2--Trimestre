public class Funciones
{
    public static double[,] orlaMatriz(double[,] array, int startrow, int startcol, int rows, int cols)
    {
        double[,] nuevoArray = new double[rows + 2, cols + 2];
        int f;
        int c;

        for (f = 1; f < nuevoArray.GetLength(0) - 1; f++)
        {
            for (c = 1; c < nuevoArray.GetLength(1) - 1; c++)
            {
                nuevoArray[f, c] = array[startrow + f - 1, startcol + c - 1];
            }
        }
        return nuevoArray;
    }
}