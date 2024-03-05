public class TrianguloEq(int x, int y, double lado) : Figura(x, y) // Triángulo Equilatero.
{
    private readonly double lado = lado;

    public double GetBase() { return lado; }

    public double GetAltura()
    {
        int base2 = (int)(lado * lado);
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

    //public override string ToString()
    //{
    //    // return String.Format("El Tríangulo Equilátero de Lado: {0:F2} Tiene un Perímetro de: {1} y un Área de: {2:F2}", GetAltura(), Perimetro(), Area());
    //    return $"El Tríangulo Equilátero de Lado: {GetAltura():F2} Tiene un Perímetro de: {Perimetro()} y un Área de: {Area():F2}";
    //}
}