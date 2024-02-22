﻿public class Circulo // Círculos.
{
    private Punto centro;
    private int radio;

    public Circulo (int x, int y, int radio)
    {
        centro = new Punto();
        centro.setX(x);
        centro.setY(y);
        this.radio = radio;
    }

    public int getRadio() { return radio; }

    public double perimetro()
    {
        return 2 * Math.PI * radio;
    }

    public double area()
    {
        return Math.PI * radio * radio;
    }

    public void mostrar()
    {
        Drawing.showCircle(radio);
    }
}