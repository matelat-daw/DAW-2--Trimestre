using System.Security.AccessControl;

public class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangulo = new Rectangle(5, 5, 45, 12);
        Circulo circulo = new Circulo(20, 20, 5);

        Console.WriteLine("Este Programa Muestra un Rectangulo Dibujado a Partir de las Coordenadas Pasadas.\n");
        rectangulo.mostrar();
        int perimetro = rectangulo.perimetro();
        int area = rectangulo.area();

        Console.WriteLine("\nEl Perimetro es: {0}\n", perimetro);
        Console.WriteLine("\nEl Área es: {0}\n", area);

        Rectangle.pruebaRectangulo();

        Console.WriteLine("\nEl Perimetro del Circulo es: {0}\n", circulo.perimetro());
        Console.WriteLine("\nEl Área del Circulo es: {0}\n", circulo.area());
    }
}