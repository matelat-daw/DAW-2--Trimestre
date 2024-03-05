public class Program
{
    static void Main(string[] args)
    {
        //Rectangulo rectangulo = new Rectangulo(5, 5, 45, 12);
        //Circulo circulo = new Circulo(20, 20, 10);
        //Elipse elipse = new Elipse(20, 20, 10, 5);
        //TrianguloIso triangulo = new TrianguloIso(60, 20, 20, 20);
        //Poligono poligono = new Poligono(0, 0, 20, 8, 20);
        //TrianguloEq equilatero = new TrianguloEq(0, 0, 30);

        //Console.ForegroundColor = ConsoleColor.White;
        //Console.WriteLine("Este Programa Muestra Varias Figuras Geométricas Dibujadas a Partir de las Coordenadas Pasadas.\n");
        //rectangulo.mostrar();

        //Console.WriteLine("\n\nEl Perimetro del Rectángulo de base={0} x altura={1} es: {2}\n", rectangulo.getAncho(), rectangulo.getAlto(), rectangulo.perimetro());
        //Console.WriteLine("\nEl Área del Rectángulo de base={0} x altura={1} es: {2}\n", rectangulo.getAncho(), rectangulo.getAlto(), rectangulo.area());

        //Rectangulo.pruebaRectangulo();

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

        List<string> datos;
        datos = HojaCalculo.datos("Figuras.csv"); // Asigno a datos el Resultado de Leer el Fichero Figuras.csv del que se Encarga el Método datos("x.x") la clase HojaCalculo.
        Console.WriteLine("Los Datos a Mostrar del Fichero CSV Son: \n"); // Mensaje en Pantalla.
        Tablas.ShowCSV(datos, 15); // Llamo al Método mostrar de la Clase Tablas, le paso el Array Bidimensional datos y la Separación Entre Palabras, Lo Muestra en Pantalla.

        int j = 0;
        Figura? figura = new Cuadrado(5, 5, 40);
        figura.Mostrar();
        Console.WriteLine("\n\n{0}\n", figura);

        Figura? trapecio = new Trapecio(5, 5, 5, 10, 8);
        Console.WriteLine("\n\n{0}\n", trapecio);

        for (int i = 0; i < datos.Count; i+=6) // Bucle al tamaño de la Lista.
        {
            switch (datos[i])
            {
                case "Rectangulo": // Si está la Palabra Rectangulo, Instancia un Objeto de la Clase Rectangulo, Pasa los Datos de la Lista y Muestra el Rectángulo.
                    figura = new Rectangulo(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]), getInt(datos[i + 4]));
                    figura.Mostrar();
                    Console.WriteLine();
                    break;
                case "Cuadrado": // Si está la Palabra Cuadrado, Instancia un Objeto de la Clase Cuadrado, Pasa los Datos de la Lista y Muestra el Cuadrado
                    figura = new Cuadrado(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]));
                    figura.Mostrar();
                    Console.WriteLine();
                    break;
                case "Circulo":
                    figura = new Circulo(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]));
                    figura.Mostrar();
                    Console.WriteLine();
                    break;
                case "Casita":
                    figura = new Casita(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]));
                    figura.Mostrar();
                    break;
                case "Triangulo":
                    figura = new TrianguloIso(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]), getInt(datos[i + 4]));
                    figura.Mostrar();
                    Console.WriteLine();
                    break;
                case "Poligono":
                    figura = new Poligono(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]), getInt(datos[i + 4]), getInt(datos[i + 5]));
                    Console.SetCursorPosition(80, Console.CursorTop + 2);
                    figura.Mostrar();
                    Console.WriteLine();
                    break;
                case "Equilatero":
                    figura = new TrianguloEq(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]));
                    figura.Mostrar();
                    Console.WriteLine("\n");
                    break;
                case "Elipse":
                    figura = new Elipse(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]), getInt(datos[i + 4]));
                    break;
                //default:
                //    Console.WriteLine(datos[i][j] + "\n");
                //    j++;
                //    break;
            }
            Console.WriteLine("\n\n{0}\n", figura);
        }
    }

    public static int getInt(string x)
    {
        return int.Parse(x);
    }

    //private static double areaDeFigura(Figura f)
    //{
    //    return f.area();
    //}
}