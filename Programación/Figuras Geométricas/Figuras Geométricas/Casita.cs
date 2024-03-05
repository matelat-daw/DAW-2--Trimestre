public class Casita: Figura
{
    private readonly int lado;
    private readonly Cuadrado fachada;
    private readonly TrianguloEq techo;

    public Casita(int x, int y, int lado) : base(x, y)
    {
        this.lado = lado;
        techo = new TrianguloEq(x, y, lado);
        fachada = new Cuadrado(x, GetY() + (int)techo.GetAltura(), lado);
    }

    public override double Perimetro()
    {
        double result = 0.0;

        return result;
    }

    public override double Area()
    {
        double result = 0.0;

        return result;
    }
    public override string ToString()
    {
        // return String.Format("El Tríangulo Equilátero de Lado: {0:F2} Tiene un Perímetro de: {1} y un Área de: {2:F2}", GetAltura(), Perimetro(), Area());
        return String.Format("La Casita de Fachada de Área: {0:F2} y Techo de Área: {1:F2} Tiene un Perímetro de Fachada: {2:F2} y un Perímetro de Techo: {3:F2}, En Definitiva la Casita tiene un Perimetro de: {4:F2} y un Área de: {5:F2}", fachada.Area(), techo.Area(), fachada.Perimetro(), techo.Perimetro(), fachada.Perimetro() + techo.Perimetro(), techo.Area() + fachada.Area());
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
        //Drawing.ShowTriangle(techo.GetAltura());
        //Drawing.ShowRectangle(fachada.GetAncho(), fachada.GetAlto());
    }
}