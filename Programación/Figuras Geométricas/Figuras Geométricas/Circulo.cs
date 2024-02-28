﻿public class Circulo: Figura // Círculos.
{
    private int radio;

    public Circulo (int x, int y, int radio)
    {
        posicion = new Punto();
        posicion.setX(x);
        posicion.setY(y);
        this.radio = radio;
    }

    public int getRadio() { return radio; }

    public override double perimetro()
    {
        return 2 * Math.PI * radio;
    }

    public override double area()
    {
        return Math.PI * radio * radio;
    }

    public void mostrar()
    {
        Drawing.showCircle(radio);
    }

    public override string ToString()
    {
        return String.Format("El Circulo de Radio: {0} Tiene un Perímetro de: {1:F2} y un Área de: {2:F2}", getRadio(), perimetro(), area());
    }
}