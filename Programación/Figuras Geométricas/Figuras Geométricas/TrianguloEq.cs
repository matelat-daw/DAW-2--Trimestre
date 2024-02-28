public class TrianguloEq: Figura // Triángulo Equilatero.
{
    private int lado;

    public TrianguloEq (int x, int y, int lado)
    {
        posicion = new Punto ();
        posicion.setX(x);
        posicion.setY(y);
        this.lado = lado;
    }

    public int getBase() { return lado; }

    public double getAltura()
    {
        int base2 = lado * lado;
        return Math.Sqrt(base2 - lado / 2.0 * lado / 2.0);
    }

    public override double perimetro()
    {
        return lado * 3;
    }

    public override double area()
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