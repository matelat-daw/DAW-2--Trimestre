public class Poligono
{
    private int x;
    private int y;
    private Point centro;
    private int size;
    private int number;
    private int radio;

    public Poligono (int x, int y, int size, int number, int radio)
    {
        centro = new Point();
        centro.setX(x);
        centro.setY(y);
        this.size = size;
        this.number = number;
        this.radio = radio;
    }

    public int getSize()
    {
        return size;
    }

    public int getQtty()
    {
        return number;
    }

    public int getRadio()
    {
        return radio;
    }

    public void mostrar()
    {
        Console.SetCursorPosition(30, 85);
        horizontal();
        Console.SetCursorPosition(30, size / 2 + (int)getApotema() + 85);
        horizontal();
        vertical();
        diagonal();

    }

    private void diagonal()
    {
        int j = 0;
        for (int i = 1; i <= size / 2 - 1; i++)
        {
            Console.SetCursorPosition(30 - (int)getApotema() - 1 + i + j, 85 + (int)getApotema() / 2 - i + 1);
            Console.Write('*');
            Console.SetCursorPosition(30 + size + i - 1 + j, size / 2 + (int)getApotema() + 85 - j);
            Console.Write('*');
            Console.SetCursorPosition(30 + size + i + j - 1, 85 + j);
            Console.Write('*');
            Console.SetCursorPosition(30 - (int)getApotema() - 1 + i + j, 85 + size + j - 1);
            Console.Write('*');
            j++;
        }
    }

    private void horizontal()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write('*');
        }
    }

    private void vertical()
    {
        for (int i = 0; i < size / 2 + 1; i++)
        {
            Console.SetCursorPosition(30 - (int)getApotema(), i + 85 + (int)getApotema() / 2);
            Console.Write("*");
            Console.SetCursorPosition(30 + size + (int)getApotema() - 1, i + 85 + (int)getApotema() / 2);
            Console.Write("*");
        }
    }

    public int perimetro()
    {
        return number * size;
    }

    public int area()
    {
        return ((int)(getApotema() * number * size) / 2);
    }

    public double getApotema()
    {
        double apotema;
        apotema = Math.Sqrt(radio * radio - (size / 2) * (size / 2));
        return apotema;
    }
}