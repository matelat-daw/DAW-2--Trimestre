public class TrianguloIso // Triángulo Isósceles.
{
    private int _base;
    private int altura;
    private Punto vertice;

    public TrianguloIso (int x, int y, int ancho, int altura)
    {
        vertice = new Punto();
        vertice.setX(x);
        vertice.setY(y);
        // this._base = ancho; // Valen las Dos Formas.
        _base = ancho;
        this.altura = altura;
    }

    public int getAncho() { return _base; }

    public int getAlto() { return altura; }

    public int perimetro()
    {
        double hipo = Math.Sqrt(_base / 2.0 * _base / 2.0 + altura * altura);
        return (int)(hipo * 2 + _base);
    }

    public double area()
    {
        return (_base * altura) / 2.0;
    }

    public void mostrar()
    {
        Drawing.showTriangle(altura);
    }

    public override string ToString()
    {
        return String.Format("El Tríangulo Isósceles de Base: {0} y Altura: {1} Tiene un Perímetro de: {2} y un Área de: {3:F2}", getAncho(), getAlto(), perimetro(), area());
    }
}