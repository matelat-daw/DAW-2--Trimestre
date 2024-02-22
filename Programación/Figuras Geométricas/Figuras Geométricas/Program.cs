﻿public class Program
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


        string[,] datos;
        datos = HojaCalculo.datos("Figuras.csv");
        Console.WriteLine("Los Datos a Mostrar Son: ");
        Tablas.mostrar(datos, 15);


        for (int i = 0; i < datos.GetLength(0); i++)
        {
            switch (datos[i, 0])
            {
                case "Rectangulo":
                    Rectangulo rect_csv = new Rectangulo(int.Parse(datos[i, 1]), int.Parse(datos[i, 2]), int.Parse(datos[i, 3]), int.Parse(datos[i, 4]));
                    Console.WriteLine("\n\nEl Perimetro del Rectángulo de base={0} x altura={1} es: {2}\n", rect_csv.getAncho(), rect_csv.getAlto(), rect_csv.perimetro());
                    Console.WriteLine("\nEl Área del Rectángulo de base={0} x altura={1} es: {2}\n", rect_csv.getAncho(), rect_csv.getAlto(), rect_csv.area());
                    rect_csv.mostrar();
                    break;
                case "Circulo":
                    Circulo circl_csv = new Circulo(int.Parse(datos[i, 1]), int.Parse(datos[i, 2]), int.Parse(datos[i, 3]));
                    Console.WriteLine("\n\nEl Perimetro del Circulo de Radio={0} es: {1}\n", circl_csv.getRadio(), circl_csv.perimetro());
                    Console.WriteLine("\nEl Área del Circulo de Radio={0} es: {1}\n", circl_csv.getRadio(), circl_csv.area());
                    circl_csv.mostrar();
                    break;
                case "Triangulo":
                    TrianguloIso iso_csv = new TrianguloIso(int.Parse(datos[i, 1]), int.Parse(datos[i, 2]), int.Parse(datos[i, 3]), int.Parse(datos[i, 4]));
                    Console.WriteLine("\n\nEl Perimetro del Triángulo Isósceles de base={0} x altura={1} es: {2}\n", iso_csv.getAncho(), iso_csv.getAlto(), iso_csv.perimetro());
                    Console.WriteLine("\nEl Área del Triángulo Isósceles de base={0} x altura={1} es: {2}\n", iso_csv.getAncho(), iso_csv.getAlto(), iso_csv.area());
                    iso_csv.mostrar();
                    break;
                case "Poligono":
                    Poligono poli_csv = new Poligono(int.Parse(datos[i, 1]), int.Parse(datos[i, 2]), int.Parse(datos[i, 3]), int.Parse(datos[i, 4]), int.Parse(datos[i, 5]));
                    Console.WriteLine("\n\n");
                    Console.WriteLine("\nEl Perimetro del Polígono Regular (Octógono) de lado={0} x número de lados={1} y radio={2} es: {3}\n", poli_csv.getSize(), poli_csv.getQtty(), poli_csv.getRadio(), poli_csv.perimetro());
                    Console.WriteLine("\nEl Área del Polígono Regular (Octógono) de lado={0} x número de lados={1} y radio={2} es: {3}\n", poli_csv.getSize(), poli_csv.getQtty(), poli_csv.getRadio(), poli_csv.area());
                    poli_csv.mostrar();
                    break;
                case "Equilatero":
                    TrianguloEq equi_csv = new TrianguloEq(int.Parse(datos[i, 1]), int.Parse(datos[i, 2]), int.Parse(datos[i, 3]));
                    Console.WriteLine("\n\nEl Perímetro del Triángulo Equilátero de Base={0} es: {1}\n", equi_csv.getBase(), equi_csv.perimetro());
                    Console.WriteLine("\nEl Área del Triángulo Equilátero de Base={0} es: {1}\n", equi_csv.getBase(), equi_csv.area());
                    equi_csv.mostrar();
                    break;
            }
        }
    }
}