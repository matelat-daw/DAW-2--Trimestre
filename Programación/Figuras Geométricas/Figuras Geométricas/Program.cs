public class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangulo = new Rectangle(5, 5, 45, 12);
        Circulo circulo = new Circulo(20, 20, 10);
        Triangulo triangulo = new Triangulo(60, 20, 20, 20);
        Poligono poligono = new Poligono(0, 0, 20, 8, 20);

        Console.WriteLine("Este Programa Muestra un Varias Figuras Geométricas Dibujadas a Partir de las Coordenadas Pasadas.\n");
        rectangulo.mostrar();

        Console.WriteLine("\n\nEl Perimetro del Rectángulo de base={0} x altura={1} es: {2}\n", rectangulo.getAncho(), rectangulo.getAlto(), rectangulo.perimetro());
        Console.WriteLine("\nEl Área del Rectángulo de base={0} x altura={1} es: {2}\n", rectangulo.getAncho(), rectangulo.getAlto(), rectangulo.area());
        
        Rectangle.pruebaRectangulo();

        circulo.mostrar();

        Console.WriteLine("\n\nEl Perimetro del Circulo de Radio={0} es: {1}\n", circulo.getRadio(), circulo.perimetro());
        Console.WriteLine("\nEl Área del Circulo de Radio={0} es: {1}\n", circulo.getRadio(), circulo.area());

        triangulo.mostrar();

        Console.WriteLine("\n\nEl Perimetro del Triángulo Isósceles de base={0} x altura={1} es: {2}\n", triangulo.getAncho(), triangulo.getAlto(), triangulo.perimetro());
        Console.WriteLine("\nEl Área del Triángulo Isósceles de base={0} x altura={1} es: {2}\n", triangulo.getAncho(), triangulo.getAlto(), triangulo.area());

        poligono.mostrar();

        Console.WriteLine("\n\n");
        Console.WriteLine("\nEl Perimetro del Polígono Regular (Octógono) de lado={0} x número de lados={1} y radio={2} es: {3}\n", poligono.getSize(), poligono.getQtty(), poligono.getRadio(), poligono.perimetro());
        Console.WriteLine("\nEl Área del Polígono Regular (Octógono) de lado={0} x número de lados={1} y radio={2} es: {3}\n", poligono.getSize(), poligono.getQtty(), poligono.getRadio(), poligono.area());
    }
}