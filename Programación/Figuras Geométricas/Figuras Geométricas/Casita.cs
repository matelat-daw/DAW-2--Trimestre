public class Casita: Figura
{
    private int lado;
    private int _base;
    Cuadrado fachada;
    TrianguloEq techo;

    public Casita(int x, int y) : base(x, y)
    {
        fachada = new Cuadrado(x, y, lado);
        techo = new TrianguloEq(x, y, _base);
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
        return $"La Casita de Fachada de Área: {fachada.Area():F2} y Techo de Área: {techo.Area():F2} Tiene un Perímetro de Fachada: {fachada.Perimetro():F2} y un Perímetro de Techo: {techo.Perimetro():F2}";
    }


    public override void Mostrar()
    {
        
    }
}