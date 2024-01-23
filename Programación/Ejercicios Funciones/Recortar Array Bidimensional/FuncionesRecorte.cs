public class FuncionesRecorte
{
    public static double[,] recortaMatriz(double[,] array, int startrow, int startcol, int rows, int cols) // Fucnión recortaMatriz(), Recibe el Array, las coordenadas de Inicio y Fin y la cantidad de Filas y Columnas a insertar en el Nuevo Array.
    {
        double[,] nuevoArray = new double[rows, cols]; // Doy al Nuevo Array el tamaño de las Filas y Las Columnas que Quiero Ingresar.

        for (int i = startrow; i < startrow + rows; i++) // Hago un Bucle Comenzando Desde la Posición startrow hasta startrow + la cantidad de Filas rows.
        {
            for (int j = startcol; j < startcol + cols; j++) // Hago un Bucle Comenzando Desde la Posición startcol hasta startcol + la cantidad de Columnas cols.
            {
                nuevoArray[i - startrow, j - startcol] = array[i, j]; // Inserto en el Nuevo Array los Datos en el Array Pasado Como Parámetro.
            }
        }
        return nuevoArray; // Devuelvo el Nuevo Array.
    }

    public static void show(double[,] nuevoArray) // Función para Mostrar un Array Bidimensional con sus Coordenadas.
    {
        Console.ForegroundColor = ConsoleColor.White; // Cambio el Color de la Fuente a Blanco.
        for (int i = 0; i < nuevoArray.GetLength(1); i++) // Hago un Bucle Hasta la Cantidad de Columnas del Array.
        {
            Console.Write("\t{0}", i); // Muestro el Número de Columna del Array Tabulado.
        }
        Console.WriteLine(); // Hago un Salto de Línea.
        for (int i = 0; i < nuevoArray.GetLength(0); i++) // Hago un Bucle hasta la Cantidad de las Filas del Array.
        {
            Console.Write("{0}", i); // Muestro el Número de Fila del Array.
            Console.ForegroundColor = ConsoleColor.Blue; // Cambio el Color de la Fuente a Azul.
            for (int j = 0; j < nuevoArray.GetLength(1); j++) // Hago un Bucle Hasta la Cantidad de Columnas del Array.
            {
                Console.Write("\t{0}", nuevoArray[i, j]); // Muestro el Contenido del Array Nuevo.
            }
            Console.WriteLine(); // Hago un Salto de Línea.
            Console.ForegroundColor = ConsoleColor.White; // Cambio el Color de la Fuente a Blanco.
        }
    }
}