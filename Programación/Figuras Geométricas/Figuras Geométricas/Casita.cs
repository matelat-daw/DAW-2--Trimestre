public class Casita: Figura
{
    private readonly Cuadrado fachada;
    private readonly TrianguloEq techo;

    public Casita(int x, int y, double lado) : base(x, y)
    {
        techo = new TrianguloEq(x, y, lado);
        fachada = new Cuadrado(x, GetY() + (int)techo.GetAltura(), lado);
    }

    public override double Perimetro()
    {
        return fachada.Perimetro() + techo.Perimetro();
    }

    public override double Area()
    {
        return techo.Area() + fachada.Area();
    }

    public double GetAlto()
    {
        return fachada.GetAlto() + techo.GetAltura();
    }

    public double GetAncho()
    {
        return fachada.GetAncho();
    }

    public override void Mostrar()
    {
        techo.Mostrar();
        fachada.Mostrar();
    }
}