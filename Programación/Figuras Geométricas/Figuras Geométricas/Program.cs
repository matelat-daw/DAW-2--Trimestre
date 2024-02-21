public class Program
{
    static void Main(string[] args)
    {
        //Rectangle rectangulo = new Rectangle(5, 5, 45, 12);
        //Circulo circulo = new Circulo(20, 20, 10);
        //Elipse elipse = new Elipse(20, 20, 10, 5);
        //Triangulo triangulo = new Triangulo(60, 20, 20, 20);
        //Poligono poligono = new Poligono(0, 0, 20, 8, 20);
        //Equilatero equilatero = new Equilatero(0, 0, 30);

        //Console.ForegroundColor = ConsoleColor.White;
        //Console.WriteLine("Este Programa Muestra Varias Figuras Geométricas Dibujadas a Partir de las Coordenadas Pasadas.\n");
        //rectangulo.mostrar();

        //Console.WriteLine("\n\nEl Perimetro del Rectángulo de base={0} x altura={1} es: {2}\n", rectangulo.getAncho(), rectangulo.getAlto(), rectangulo.perimetro());
        //Console.WriteLine("\nEl Área del Rectángulo de base={0} x altura={1} es: {2}\n", rectangulo.getAncho(), rectangulo.getAlto(), rectangulo.area());

        //Rectangle.pruebaRectangulo();

        //circulo.mostrar();

        //Console.WriteLine("\n\nEl Perimetro del Circulo de Radio={0} es: {1}\n", circulo.getRadio(), circulo.perimetro());
        //Console.WriteLine("\nEl Área del Circulo de Radio={0} es: {1}\n", circulo.getRadio(), circulo.area());

        //Console.SetCursorPosition(80, 53);
        //Console.WriteLine("El Perimetro de la Elipse de Radio1={0} y Radio2={1} es: {2}", elipse.getRadio1(), elipse.getRadio2(), elipse.perimetro());
        //Console.SetCursorPosition(80, 56);
        //Console.WriteLine("El Área de la Elipse de Radio1={0} y Radio2={1} es: {2}\n", elipse.getRadio1(), elipse.getRadio2(), elipse.area());

        //triangulo.mostrar();

        //Console.WriteLine("\n\nEl Perimetro del Triángulo Isósceles de base={0} x altura={1} es: {2}\n", triangulo.getAncho(), triangulo.getAlto(), triangulo.perimetro());
        //Console.WriteLine("\nEl Área del Triángulo Isósceles de base={0} x altura={1} es: {2}\n", triangulo.getAncho(), triangulo.getAlto(), triangulo.area());

        //poligono.mostrar();

        //Console.WriteLine("\n\n");
        //Console.WriteLine("\nEl Perimetro del Polígono Regular (Octógono) de lado={0} x número de lados={1} y radio={2} es: {3}\n", poligono.getSize(), poligono.getQtty(), poligono.getRadio(), poligono.perimetro());
        //Console.WriteLine("\nEl Área del Polígono Regular (Octógono) de lado={0} x número de lados={1} y radio={2} es: {3}\n", poligono.getSize(), poligono.getQtty(), poligono.getRadio(), poligono.area());

        //equilatero.mostrar();

        //Console.WriteLine("\n\nEl Perímetro del Triángulo Equilátero de Base={0} es: {1}\n", equilatero.getBase(), equilatero.perimetro());
        //Console.WriteLine("\nEl Área del Triángulo Equilátero de Base={0} es: {1}\n", equilatero.getBase(), equilatero.area());

        string[,] datos;
        // datos = HojaCalculo.datos("Figuras.csv");
        datos = HojaCalculo.datos("Figuras.csv");


        Console.WriteLine("Los Datos a Mostrar Son: ");
        Tablas.mostrar(datos, 15);


        for (int i = 0; i < datos.GetLength(0); i++)
        {
            switch (datos[i, 0])
            {
                case "Rectangulo":
                    Rectangle rectangulo = new Rectangle(int.Parse(datos[0, 1]), int.Parse(datos[0, 2]), int.Parse(datos[0, 3]), int.Parse(datos[0, 4]));
                    Console.WriteLine("\n\nEl Perimetro del Rectángulo de base={0} x altura={1} es: {2}\n", rectangulo.getAncho(), rectangulo.getAlto(), rectangulo.perimetro());
                    Console.WriteLine("\nEl Área del Rectángulo de base={0} x altura={1} es: {2}\n", rectangulo.getAncho(), rectangulo.getAlto(), rectangulo.area());
                    Drawing.showRectangle(0, 0, int.Parse(datos[0, 3]), int.Parse(datos[0, 4]));
                    break;
                case "Circulo":
                    Circulo circulo = new Circulo(int.Parse(datos[1, 1]), int.Parse(datos[1, 2]), int.Parse(datos[1, 3]));
                    Console.WriteLine("\n\nEl Perimetro del Circulo de Radio={0} es: {1}\n", circulo.getRadio(), circulo.perimetro());
                    Console.WriteLine("\nEl Área del Circulo de Radio={0} es: {1}\n", circulo.getRadio(), circulo.area());
                    Drawing.showCircle(int.Parse(datos[1, 3]));
                    break;
                case "Triangulo":
                    Triangulo triangulo = new Triangulo(int.Parse(datos[2, 1]), int.Parse(datos[2, 2]), int.Parse(datos[2, 3]), int.Parse(datos[2, 4]));
                    Console.WriteLine("\n\nEl Perimetro del Triángulo Isósceles de base={0} x altura={1} es: {2}\n", triangulo.getAncho(), triangulo.getAlto(), triangulo.perimetro());
                    Console.WriteLine("\nEl Área del Triángulo Isósceles de base={0} x altura={1} es: {2}\n", triangulo.getAncho(), triangulo.getAlto(), triangulo.area());
                    Drawing.showTriangle('*', int.Parse(datos[2, 4]));
                    break;
                case "Equilatero":
                    Equilatero equilatero = new Equilatero(int.Parse(datos[3, 1]), int.Parse(datos[3, 2]), int.Parse(datos[3, 3]));
                    Console.WriteLine("\n\nEl Perímetro del Triángulo Equilátero de Base={0} es: {1}\n", equilatero.getBase(), equilatero.perimetro());
                    Console.WriteLine("\nEl Área del Triángulo Equilátero de Base={0} es: {1}\n", equilatero.getBase(), equilatero.area());
                    Drawing.showTriangle('*', int.Parse(datos[2, 4]));
                    break;
            }
        }
    }
}