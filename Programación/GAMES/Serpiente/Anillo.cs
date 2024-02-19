public class Anillo
{
    private const int X_LIM = 110;
    private const int Y_LIM = 25;
    private int x;
    private int y;
    public char id;

    public Anillo(int x, int y, char id)
    {
        this.x = x % (X_LIM + 1);
        this.y = y % (Y_LIM + 1);
        this.id = id;
    }

    public Anillo(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.id = '*';
    }

    // Constructor Copia
    public Anillo(Anillo orig):this(orig.x,orig.y,orig.id) {}

    public int GetX()
    {
        return x;
    }
    public int GetY()
    {
        return y;
    }

    public Anillo Norte()
    {
        if (y == 0)
            y = Y_LIM;
        else
            y--;
        return this;
    }
    public Anillo Sur()
    {
        if (y == Y_LIM)
            y = 0;
        else
            y++;
        return this;
    }

    public Anillo Oeste()
    {
        if (x == 0)
            x = X_LIM;
        else
            x--;
        return this;
    }

    public Anillo Este()
    {
        if (x == X_LIM)
            x = 0;
        else
            x++;
        return this;
    }
    public void Mostrar()
    {
        Imprimir(id);
    }
    public void Ocultar()
    {
        Imprimir(' ');
    }
    private void Imprimir(char ch)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(ch);
        Console.SetCursorPosition(0, 0);
    }
}