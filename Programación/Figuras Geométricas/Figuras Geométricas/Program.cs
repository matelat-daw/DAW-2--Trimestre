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


        // string[,] datos; // Declaro el Array Bidimensional de Strings datos.
        List<string> datos;
        datos = HojaCalculo.datos("Figuras.csv"); // Asigno a datos el Resultado de Leer el Fichero Figuras.csv del que se Encarga el Método datos("x.x") la clase HojaCalculo.
        Console.WriteLine("Los Datos a Mostrar Son: "); // Mensaje en Pantalla.
        Tablas.showCSV(datos, 15); // Llamo al Método mostrar de la Clase Tablas, le paso el Array Bidimensional datos y la Separación Entre Palabras, Lo Muestra en Pantalla.

        // for (int i = 0; i < datos.GetLength(0); i++) // Bucle al tamaño del Array.
        for (int i = 0; i < datos.Count; i+=6) // Bucle al tamaño del Array.
        {
            Object figura = null;
            // switch (datos[i, 0]) // Cambia a la String Contenida en la Posición 0 del Índice i.
            switch (datos[i])
            {
                case "Rectangulo": // Si está la Palabra Rectangulo, Instancia un Objeto de la Clase Rectangulo, Pasa los Datos del Array Bidimensional y Muestra el Rectángulo.
                    // Rectangulo rect_csv = new Rectangulo(int.Parse(datos[i, 1]), int.Parse(datos[i, 2]), int.Parse(datos[i, 3]), int.Parse(datos[i, 4]));
                    figura = new Rectangulo(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]), getInt(datos[i + 4]));
                    // rect_csv.mostrar();
                    break;
                case "Circulo":
                    // Circulo circl_csv = new Circulo(int.Parse(datos[i, 1]), int.Parse(datos[i, 2]), int.Parse(datos[i, 3]));
                    figura = new Circulo(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]));
                    //circl_csv.mostrar();
                    break;
                case "Triangulo":
                    // TrianguloIso iso_csv = new TrianguloIso(int.Parse(datos[i, 1]), int.Parse(datos[i, 2]), int.Parse(datos[i, 3]), int.Parse(datos[i, 4]));
                    figura = new TrianguloIso(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]), getInt(datos[i + 4]));
                    //iso_csv.mostrar();
                    break;
                case "Poligono":
                    // Poligono poli_csv = new Poligono(int.Parse(datos[i, 1]), int.Parse(datos[i, 2]), int.Parse(datos[i, 3]), int.Parse(datos[i, 4]), int.Parse(datos[i, 5]));
                    figura = new Poligono(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]), getInt(datos[i + 4]), getInt(datos[i + 5]));
                    //poli_csv.mostrar();
                    break;
                case "Equilatero":
                    // TrianguloEq equi_csv = new TrianguloEq(int.Parse(datos[i, 1]), int.Parse(datos[i, 2]), int.Parse(datos[i, 3]));
                    figura = new TrianguloEq(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]));
                    //equi_csv.mostrar();
                    break;
                case "Elipse":
                    figura = new Elipse(getInt(datos[i + 1]), getInt(datos[i + 2]), getInt(datos[i + 3]), getInt(datos[i + 4]));
                    break;
                default:
                    throw new Exception("No Esa Figura No Existe.");
            }
            Console.WriteLine("\n{0}", figura);
        }
    }

    public static int getInt(string x)
    {
        return int.Parse(x);
    }
}