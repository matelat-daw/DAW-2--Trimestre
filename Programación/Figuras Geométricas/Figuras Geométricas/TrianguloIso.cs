﻿public class TrianguloIso(int x, int y, int ancho, int altura) : Figura(x, y) // Triángulo Isósceles.
{
    private readonly int _base = ancho; // La Palabra Reservada base se usa para la Herencia Entre Clases.
    private readonly int _altura = altura;

    public int GetAncho() { return _base; }

    public int GetAlto() { return _altura; }

    public override double Perimetro()
    {
        double hipo = Math.Sqrt(_base / 2.0 * _base / 2.0 + _altura * _altura);
        return (int)(hipo * 2 + _base);
    }

    public override double Area()
    {
        return (_base * _altura) / 2.0;
    }

    public override void Mostrar()
    {
        Drawing.ShowTriangle(_altura);
    }

    //public override string ToString()
    //{
    //    // return String.Format("El Tríangulo Isósceles de Base: {0} y Altura: {1} Tiene un Perímetro de: {2} y un Área de: {3:F2}", GetAncho(), GetAlto(), Perimetro(), Area());
    //    return $"El Tríangulo Isósceles de Base: {GetAncho()} y Altura: {GetAlto()} Tiene un Perímetro de: {Perimetro()} y un Área de: {Area():F2}";
    //}
}