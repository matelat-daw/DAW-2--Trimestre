public class Equilatero // Triángulo Equilatero.
{
    private int _base;
    private Point vertice;

    public Equilatero (int x, int y, int _base)
    {
        vertice = new Point (x, y);
        vertice.setX(x);
        vertice.setY(y);
        this._base = _base;
    }

    public int getBase()
    {
        return _base;
    }

    public int perimetro()
    {
        return _base * 3;
    }

    public double area()
    {
        int base2 = _base * _base;
        double altura = Math.Sqrt(base2 - (_base / 2) * (_base / 2));
        return (_base * altura) / 2;
    }

    public void mostrar()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Drawing.showTriangle('*', (int)Math.Sqrt(_base * _base - (_base / 2) * (_base / 2)));
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}