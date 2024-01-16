namespace My_Art
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char caracter;

            Console.WriteLine("Este Programa Dibuja el Caracter Ingresado por Teclado de Tamaño 40 x 80.\n");
            caracter = Convert.ToChar(Console.ReadLine());
            Funciones.draw(caracter);
        }
    }
}