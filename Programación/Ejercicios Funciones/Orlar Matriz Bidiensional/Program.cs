public class Program
{
    static void Main(string[] args)
    {
        double[,] array = new double[7, 5]
        {
            {0.9, 1.2, 2.3, 3.4, 4.5},
            {5.1, 5.6, 6.7, 7.8, 8.9},
            {0.9, 9.1, 10.2, 11.3, 12.4},
            {13.1, 13.5, 14.6, 15.7, 16.8},
            {0.9, 9.1, 10.2, 11.3, 12.4},
            {5.1, 5.6, 6.7, 7.8, 8.9},
            {0.9, 1.2, 2.3, 3.4, 4.5}
        };
        double[,] nuevoArray;

        Console.WriteLine("Este Programa Usa una Función que Recibe un Array Bidemensional, las coordenadas de Inicio y la cantidad de Filas y Columnas que se Necesitan y Devuelve un Nuevo Array Bidemensional con los datos en el Nuevo Array, Adornado con 0 Alrededor.\n");

        try
        {
            nuevoArray = Funciones.orlaMatriz(array, 2, 2, 4, 3);
            FuncionesRecorte.show(nuevoArray);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Te pasaste de los Límites de la Matriz: {0}", ex);
        }
    }
}