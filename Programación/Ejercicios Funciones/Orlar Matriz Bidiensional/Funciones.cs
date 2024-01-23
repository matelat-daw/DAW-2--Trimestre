public class Funciones
{
    public static double[,] orlaMatriz(double[,] array, int startrow, int startcol, int rows, int cols)
    {
        double[,] nuevoArray = new double[rows + 2, cols + 2];
        int i = 0;
        int j = 0;

        for (i = 0; i < rows + 2; i++)
        {
            for (j = 0; j < cols + 2; j++)
            {
                if (i < 1 || i > rows)
                {
                    nuevoArray[i, j] = 0.0;
                }
                else
                {
                    if (j < 1 || j > cols)
                    {
                        nuevoArray[i, j] = 0.0;
                    }
                    else
                    {
                        nuevoArray[i, j] = array[startrow + i - 1, startcol + j - 1];
                    }
                }
            }
        }
        return nuevoArray;
    }
}