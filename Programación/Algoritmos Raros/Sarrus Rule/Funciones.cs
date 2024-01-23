public class Funciones
{
    static int i, j;

    public static int[,] arrangeVertical(int[,] array)
    {
        int[,] vertical = new int[5, 3];

        for (j = 0; j < vertical.GetLength(1); j++) // Regla de Sarrus Propagación Vertical.
        {
            for (i = 0; i < vertical.GetLength(0); i++)
            {
                if (i < vertical.GetLength(1))
                    vertical[i, j] = array[i, j];
                else
                    vertical[i, j] = array[i - 3, j];
            }
        }

        return vertical;
    }

    public static int getDeterminantV(int[,] result)
    {
        int determinant = 0;

        determinant += result[0, 0] * result[1, 1] * result[2, 2] + result[1, 0] * result[2, 1] * result[3, 2] + result[2, 0] * result[3, 1] * result[4, 2];
        determinant -= result[0, 2] * result[1, 1] * result[2, 0] + result[1, 2] * result[2, 1] * result[3, 0] + result[2, 2] * result[3, 1] * result[4, 0];
        return determinant;
    }

    public static int[,] arrangeHorizontal(int[,] array)
    {
        int[,] horizontal = new int[3, 5];

        for (i = 0; i < horizontal.GetLength(0); i++) // Regla de Sarrus Propagación Horizontal.
        {
            for (j = 0; j < horizontal.GetLength(1); j++)
            {
                if (j < horizontal.GetLength(0))
                    horizontal[i, j] = array[i, j];
                else
                    horizontal[i, j] = array[i, j - 3];
            }
        }

        return horizontal;
    }

    public static int getDeterminantH(int[,] result)
    {
        int determinant = 0;

        determinant += result[0, 0] * result[1, 1] * result[2, 2] + result[0, 1] * result[1, 2] * result[2, 3] + result[0, 2] * result[1, 3] * result[2, 4];
        determinant -= result[0, 2] * result[1, 1] * result[2, 0] + result[1, 2] * result[2, 1] * result[0, 3] + result[2, 2] * result[1, 3] * result[0, 4];
        return determinant;
    }
}