
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
            new Rectangle(80, 5, 10, 10),
            new Rectangle(95, 5, 15, 15),
            new Rectangle(115, 5, 20, 20)
            ];
        area_total = areas(array);
        Console.SetCursorPosition(76, 25);
        Console.WriteLine("El Area de Todos Los Cuadrados es: {0}", area_total);
        Console.SetCursorPosition(76, 27);
        Console.WriteLine("El Perimetro Individual es: {0}, {1} y {2}", array[0].perimetro(), array[1].perimetro(), array[2].perimetro());
        Console.SetCursorPosition(76, 29);
        Console.WriteLine("Y el Área Individual es: {0}, {1} y {2}", array[0].area(), array[1].area(), array[2].area());
    }

    private static int areas(Rectangle[] array)
    {
        int result = 0;

        for (int i = 0; i < array.Length; i++)
        {
            result += array[i].area();
            array[i].mostrar();
        }
        return result;
    }

    public void mostrar()
    {
        Console.ForegroundColor = ConsoleColor.Red;
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
        Console.ForegroundColor = ConsoleColor.Gray;
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