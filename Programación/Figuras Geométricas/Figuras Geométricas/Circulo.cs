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

    public int getRadio()
    {
        return radio;
    }

    public double perimetro()
    {
        return 2 * Math.PI * radio;
    }

    public double area()
    {
        return Math.PI * radio * radio;
    }

    public void mostrar()
    {
        double thickness = 0.4;
        double rIn = radio - thickness, rOut = radio + thickness;

        for (double y = radio; y >= -radio; --y)
        {
            for (double x = -radio; x < rOut; x += 0.5)
            {
                double value = x * x + y * y;
                if (value >= rIn * rIn && value <= rOut * rOut)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }
}