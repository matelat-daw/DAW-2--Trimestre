public class Program
{
    static void Main(string[] args)
    {
        double[,] array = new double[7, 5] // Defino el Array que Pasaré a Función.
        {
            {0.9, 1.2, 2.3, 3.4, 4.5},
            {5.1, 5.6, 6.7, 7.8, 8.9},
            {0.9, 9.1, 10.2, 11.3, 12.4},
            {13.1, 13.5, 14.6, 15.7, 16.8},
            {0.9, 9.1, 10.2, 11.3, 12.4},
            {5.1, 5.6, 6.7, 7.8, 8.9},
            {0.9, 1.2, 2.3, 3.4, 4.5}
        };
        double[,] nuevoArray; // Defino el Array que Recibirá el Array Resultante.

        Console.WriteLine("Este Programa Usa una Función que Recibe un Array Bidemensional, las coordenadas de Inicio y la cantidad de Filas y Columnas que se Necesitan y Devuelve un Nuevo Array Bidemensional con los datos en el Array Original.\n");

        try // Intento las llamadas a las Funciones.
        {
            nuevoArray = FuncionesRecorte.recortaMatriz(array, 2, 2, 2, 2); // Llamo a la Función recortarMatriz Pasando el Array array y las Coordenadas Necesarias.
            FuncionesRecorte.show(nuevoArray); // Si Todo ha Ido Bien, Muestro el Resultado, Pasandole a la Función show de la clase FuncionesRecorte() del Ejercicio Anterior el Nuevo Array.
        }
        catch (Exception e) // Si Huviera un Error lo Captura el catch
        {
            Console.WriteLine("Error Parece que Haz Seleccionado un Tamaño que Supera los Límites del Array: {0}", e.ToString()); // Muestro que Hubo un Error y Cual Fue.
        }
    }
}