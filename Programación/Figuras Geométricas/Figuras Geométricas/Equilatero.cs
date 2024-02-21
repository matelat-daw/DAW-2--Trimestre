public class Equilatero // Triángulo Equilatero.
{
    private int lado;
    private Point vertice;

    public Equilatero (int x, int y, int lado)
    {
        vertice = new Point ();
        vertice.setX(x);
        vertice.setY(y);
        this.lado = lado;
    }

    public int getBase()
    {
        return lado;
    }

    public double getAltura()
    {
        int base2 = lado * lado;
        return Math.Sqrt(base2 - (lado / 2) * (lado / 2));
    }

    public int perimetro()
    {
        return lado * 3;
    }

    public double area()
    {
        return (lado * getAltura()) / 2;
    }

    public void mostrar()
    {
        Drawing.showTriangle('*', (int)Math.Sqrt(lado * lado - (lado / 2) * (lado / 2)));
    }
}