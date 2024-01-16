using System.Drawing;

namespace Arte_Ascii
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char caracter;

            Console.WriteLine("Este Programa Dibuja un Caracter Multiplicando su Tamaño por 20 con el Caracter que se le Pase por Teclado.\n");
            do
            {
                Console.Write("Ingresa el Caracter a Agrandar (El Espacio para Salir.): ");
                caracter = Convert.ToChar(Console.ReadLine());

                var image = Funciones.GetLetterImage(caracter);
                Bitmap bitmap = Funciones.ResizImage(image, 40);
                Funciones.ConvertToAscii(bitmap, caracter);
            }
            while (caracter != ' ') ;
        }
    }
}