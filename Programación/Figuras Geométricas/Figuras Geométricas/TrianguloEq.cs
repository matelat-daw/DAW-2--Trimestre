public class TrianguloEq: Figura // Triángulo Equilatero.
{
    private readonly int lado;

    public TrianguloEq (int x, int y, int lado)
    {
        posicion = new Punto ();
        posicion.SetX(x);
        posicion.SetY(y);
        this.lado = lado;
    }

    public int GetBase() { return lado; }

    public double GetAltura()
    {
        int base2 = lado * lado;
        return Math.Sqrt(base2 - lado / 2.0 * lado / 2.0);
    }

    public override double Perimetro()
    {
        return lado * 3;
    }

    public override double Area()
    {
        return lado * GetAltura() / 2.0;
    }

    public override void Mostrar()
    {
        Drawing.ShowTriangle((int)GetAltura());
    }

    public override string ToString()
    {
        return String.Format("El Tríangulo Equilátero de Lado: {0:F2} Tiene un Perímetro de: {1} y un Área de: {2:F2}", GetAltura(), Perimetro(), Area());
    }
}