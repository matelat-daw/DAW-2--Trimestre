public class Funciones
{
    public static double getDeterminate(double[,] matrix)
    {
        /* public static double[] filtrado(double[] array, double limite)
        {
            // Cuento cuantos hay
            int cont = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > limite)
                    cont++;
            }
            // Creo el array e inserto los datos
            double[] result = new double[cont];
            cont = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > limite)
                {
                    result[cont++] = array[i];
                }
            }
            return result;
        }

        // Acotar Matriz.
        public static double[,] acotarMatriz(double[,] matrix, int inf, int inc, int finf, int finc)
        {
            try
            {
                double[,] result = new double[finf - inf + 1, finc - inc + 1];
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = matrix[i + inf, j + inc];
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                return matrix;
            }
        }

        // Orlar Matriz.
        public static double[,] orlarMatriz(double[,] matrix, int inf, int inc, int finf, int finc)
        {
            try
            {
                double[,] aux = acotarMatriz(matrix, inf, inc, inf + finf - 1, inc + finc - 1);
                double[,] result = new double[aux.GetLength(0) + 2, aux.GetLength(1) + 2];
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = 0;
                    }
                }

                for (int i = 0; i < aux.GetLength(0); i++)
                {
                    for (int j = 0; j < aux.GetLength(1); j++)
                    {
                        result[i + 1, j + 1] = aux[i, j];
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                return matrix;
            }
        } */
        // Calcular determinante

        double determinante = 0; // Inicializa determinante a 0.
        double[] calculos = new double[matrix.GetLength(0) * 2]; // Crea un Array de Doubles Para Almacenar los 6 Valores a Manipular.
        int j = 0, k = 0; // j y k son 0.

        // Almacenar los calculos
        for (int i = 0; i < matrix.GetLength(0) * 2; i++) // Bucle al Tamaño de la Array de 3x3 Multiplicado por 2 = 6.
        {
            if (i == matrix.GetLength(0)) // Si i Llega al Tamaño de las Filas del Array = 3.
                j = matrix.GetLength(0) - 1; // A j se le Asigna el Valor Tamaño de las Filas del Array - 1 = 2;
            for (int y = 0; y < matrix.GetLength(0); y++) // Bucle Hasta el Tamaño de las Filas del Array.
            {
                if (y == 0) // Cuando y es 0.
                    calculos[i] += matrix[j, k]; // En el Array calculos en la Posición i Almacena el Valor en el Array Original en la Posición j, k.
                else // Cuando y se incrementa.
                    calculos[i] *= matrix[j, k]; // Almacena en el Array calculos en la Posición i la Multiplicación del Valor que ya Estaba con los Otros Valores en el Array Original en las Posiciones j, k.
                if (i < matrix.GetLength(0)) // Si i es Mayor que el Tamaño de las Filas del Array Original.
                {
                    j++; // Incrementa j.
                         // j = (j % (matrix.GetLength(0)) == 0) ? 0 : j % (matrix.GetLength(0)); // Asigna a j 0 si j llega a 3 ó 1 ó 2 si j es 1 ó 2. Esta Línea se Puede Reemplazar por:
                    if (j == matrix.GetLength(0))
                    {
                        j = 0;
                    }
                }
                else
                {
                    j--;
                    //j = (j < 0) ? matrix.GetLength(0) - 1 : j; // Y esta por:
                    if (j < 0)
                    {
                        j = matrix.GetLength(0) - 1;
                    }
                }
                k++;
            }
            if (i < matrix.GetLength(0)) // Si i es Menor que el Tamaño de las Filas del Array Original.
                j++; // Incrementa j.
            else j--; // Si No, Decrementa j.
            k = 0; // Asigna 0 a k.
        }

        /*Calcular El determinante*/
        for (int i = 0; i < calculos.Length; i++) // Bucle al Tamaño del Array calculos.
        {
            Console.WriteLine(calculos[i]); // Muestra en Pantalla el Contenido del Array, en la Primera Posición Está la Multiplicación de las Posiociones 0,0 - 1,1 y 2,2 del Array Original, etc.
            if (i < calculos.Length / 2) // Si i es Menor que el Tamaño de la Mitad del Array calculos.
                determinante += calculos[i]; // Suma en la Variable determinante los Valores en la Primera Mitad del Array calculos.
            else // Si No.
                determinante -= calculos[i]; // Resta en la Variable determinante los Valores en la Segunda Mitad del Array calculos.
        }
        return determinante; // Devuelve determinante.
    }
}