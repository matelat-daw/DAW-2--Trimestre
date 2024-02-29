﻿public class Circulo: Figura // Círculos.
{
    private readonly int radio;

    public Circulo (int x, int y, int radio)
    {
        posicion = new Punto();
        posicion.SetX(x);
        posicion.SetY(y);
        this.radio = radio;
    }

    public int GetRadio() { return radio; }

    public override double Perimetro()
    {
        return 2 * Math.PI * radio;
    }

    public override double Area()
    {
        return Math.PI * radio * radio;
    }

    public override void Mostrar()
    {
        Drawing.ShowCircle(radio);
    }

    public override string ToString()
    {
        return String.Format("El Circulo de Radio: {0} Tiene un Perímetro de: {1:F2} y un Área de: {2:F2}", GetRadio(), Perimetro(), Area());
    }
}