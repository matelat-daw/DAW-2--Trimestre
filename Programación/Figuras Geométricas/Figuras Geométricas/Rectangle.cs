
public class Rectangle
{
    private int ancho;
    private int alto;
    private Point posicion;

    public Rectangle (int x, int y, int ancho, int alto)
    {
        posicion = new Point();
        posicion.setX(x);
        posicion.setY(y);
        this.ancho = ancho;
        this.alto = alto;
    }

    public int getAncho()
    {
        return ancho;
    }

    public int getAlto()
    {
        return alto;
    }

    public static void pruebaRectangulo()
    {
        int area_total;
        Rectangle[] array = [
            new Rectangle(0, 0, 10, 10),
            new Rectangle(5, 5, 15, 15),
            new Rectangle(10, 10, 20, 20)
            ];
        area_total = areas(array);
        Console.WriteLine("\nEl Area de Todos Los Rectángulos es: {0}\n", area_total);
    }

    private static int areas(Rectangle[] array)
    {
        int result = 0;

        for (int i = 0; i < array.Length; i++)
        {
            result += array[i].area();
        }
        return result;
    }

    public void mostrar()
    {
        for (int i = posicion.getX(); i <= ancho + posicion.getX(); i++)
        {
            Console.SetCursorPosition(i, 0 + posicion.getY());
            Console.Write("*");
            Console.SetCursorPosition(i, alto + posicion.getY());
            Console.Write("*");
        }

        for (int j = posicion.getY(); j < alto + posicion.getY(); j++)
        {
            Console.SetCursorPosition(posicion.getX(), j);
            Console.Write("*");
            Console.SetCursorPosition(ancho + posicion.getX(), j);
            Console.Write("*");
        }
        Console.WriteLine("\n");
    }

    public int perimetro()
    {
        return ancho * 2 + alto * 2;
    }

    public int area()
    {
        return ancho * alto;
    }
}