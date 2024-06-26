﻿public class Rectangulo(int x, int y, double ancho, double alto) : Figura(x, y) // Rectángulos.
{
    private readonly double ancho = Math.Abs(ancho);
    private readonly double alto = Math.Abs(alto);

    public double GetAncho() { return ancho; }

    public double GetAlto() { return alto; }

    public override double Perimetro()
    {
        return ancho * 2 + alto * 2;
    }

    public override double Area()
    {
        return ancho * alto;
    }

    public override void Mostrar()
    {
        Drawing.ShowRectangle(GetAncho(), GetAlto());
    }

    //public override string ToString()
    //{
    //    string figure;
    //    if (GetAlto() != GetAncho())
    //    {
    //        figure = "Rectángulo";
    //    }
    //    else
    //    {
    //        figure = "Cuadrado";
    //    }
    //    // return String.Format("El {0} de Ancho: {1} y Alto: {2} Tiene un Perímetro de: {3} y un Área de: {4}", figure, GetAncho(), GetAlto(), Perimetro(), Area());
    //    return $"El {figure} de Ancho: {GetAncho()} y Alto: {GetAlto()} Tiene un Perímetro de: {Perimetro()} y un Área de: {Area()}";
    //}

    //public static void pruebaRectangulo()
    //{
    //    double area_total;
    //    Rectangulo[] array = [
    //        new Rectangulo(80, 5, 10, 10),
    //        new Rectangulo(95, 5, 15, 15),
    //        new Rectangulo(115, 5, 20, 20)
    //        ];
    //    area_total = Areas(array);
    //    Console.SetCursorPosition(76, 25);
    //    Console.WriteLine("El Area de Todos Los Cuadrados es: {0}", area_total);
    //    Console.SetCursorPosition(76, 27);
    //    Console.WriteLine("El Perimetro Individual es: {0}, {1} y {2}", array[0].Perimetro(), array[1].Perimetro(), array[2].Perimetro());
    //    Console.SetCursorPosition(76, 29);
    //    Console.WriteLine("Y el Área Individual es: {0}, {1} y {2}", array[0].Area(), array[1].Area(), array[2].Area());
    //}

    //private static double Areas(Rectangulo[] array)
    //{
    //    double result = 0;

    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        result += array[i].Area();
    //        array[i].Mostrar();
    //    }
    //    return result;
    //}
}