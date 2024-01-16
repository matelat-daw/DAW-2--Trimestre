namespace Navidad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char brush; // Caracter con el que se Pintará el Árbol.
            int heigth; // Altura del Árbol.

            Console.WriteLine("Ho Ho Ho ¡Feliz Navidad!\n\n");
            Console.WriteLine("Este Programa Dibuja un Árbol de Navidad Según las Medidas que Pida el Cliente.\n");
            Console.Write("Por Favor Ingresa el Caracter con el que se Pintará el Árbol: ");
            brush = Convert.ToChar(Console.ReadLine());
            Console.Write("Por Favor Ingresa la Altura del Árbol: "); // Solo hace falta la Altura.
            heigth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            Funciones.drawTree(brush, heigth); // Llama a la Función que Pintará el Árbol.
        }
    }
}