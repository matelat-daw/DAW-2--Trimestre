﻿public class TrianguloEq // Triángulo Equilatero.
{
    private int lado;
    private Punto vertice;

    public TrianguloEq (int x, int y, int lado)
    {
        vertice = new Punto ();
        vertice.setX(x);
        vertice.setY(y);
        this.lado = lado;
    }

    public int getBase() { return lado; }

    public double getAltura()
    {
        int base2 = lado * lado;
        return Math.Sqrt(base2 - lado / 2.0 * lado / 2.0);
    }

    public int perimetro()
    {
        return lado * 3;
    }

    public double area()
    {
        return lado * getAltura() / 2.0;
    }

    public void mostrar()
    {
        Drawing.showTriangle((int)getAltura());
    }

    public override string ToString()
    {
        return String.Format("El Tríangulo Equilátero de Lado: {0:F2} Tiene un Perímetro de: {1} y un Área de: {2:F2}", getAltura(), perimetro(), area());
    }
}