using System.Runtime.InteropServices;

namespace Font_Size
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char caracter;

            Console.WriteLine("Este Programa cambia el Tamaño del Caracter Ingresado por Teclado, Cambiando el Tamaño de la Fuente.\n");
            caracter = Convert.ToChar(Console.ReadLine());
            Funciones.SetCurrentFont("Consolas", 1024);
            Console.Clear();
            Console.WriteLine(caracter.ToString());
            Console.ReadKey();
            Funciones.SetCurrentFont("Consolas", 16);
        }
    }
}