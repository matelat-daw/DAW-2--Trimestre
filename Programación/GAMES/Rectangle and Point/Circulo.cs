public class Circulo
{
    private int radio;
    private Point posicion;

    public Circulo (int x, int y, int radio)
    {
        posicion = new Point();
        posicion.setX(x);
        posicion.setY(y);
        this.radio = radio;
    }

    public double perimetro()
    {
        return 2 * Math.PI * radio;
    }

    public double area()
    {
        return Math.PI * radio * radio;
    }
}