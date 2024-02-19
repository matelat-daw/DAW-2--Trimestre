
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

    public static void pruebaRectangulo()
    {
        int area_total;
        Rectangle[] array = [
            new Rectangle(0, 0, 10, 10),
            new Rectangle(5, 5, 15, 15),
            new Rectangle(10, 10, 20, 20)
            ];
        area_total = areas(array);
        Console.WriteLine("El Area de Todos Los Rectángulos es: {0}", area_total);
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
        for (int i = posicion.getX(); i < ancho + posicion.getX(); i++)
        {
            for (int j = posicion.getY(); j < alto + posicion.getY(); j++)
            {
                Console.SetCursorPosition(i, j);
                Console.Write("*");
            }
        }
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