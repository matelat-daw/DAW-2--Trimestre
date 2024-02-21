public class Triangulo // Triángulo Isósceles.
{
    private int _base;
    private int altura;
    private Point vertice;

    public Triangulo (int x, int y, int ancho, int altura)
    {
        vertice = new Point();
        vertice.setX(x);
        vertice.setY(y);
        this._base = ancho;
        this.altura = altura;
    }

    public int getAncho()
    {
        return _base;
    }

    public int getAlto()
    {
        return altura;
    }

    public int perimetro()
    {
        double hipo = Math.Sqrt(_base / 2.0 * _base / 2.0 + altura * altura);
        return (int)(hipo * 2 + _base);
    }

    public int area()
    {
        return (_base * altura) / 2;
    }

    public void mostrar()
    {
        Drawing.showTriangle('*', altura);
    }
}