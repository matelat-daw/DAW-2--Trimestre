public class Punto
{
    private int x;
    private int y;
    private const int y_limit = 39;
    private const int x_limit = 119;

    public Punto(int x, int y)
    {
        if (x < 0 || x > x_limit || y < 0 || y > y_limit)
        {
            throw new Exception();
        }
        this.x = x;
        this.y = y;
    }

    public Punto(){}

    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }

    public void setX(int x)
    {
        if (x >= 0 && x <= x_limit)
            this.x = x;
    }

    public void setY(int y)
    {
        if (y >= 0 && y <= y_limit)
            this.y = y;
    }

    public void arriba()
    {
        if (getY() == 0)
        {
            y = y_limit;
            draw();
        }
        else
        {
            y--;
            draw();
                
        }
    }

    public void abajo()
    {
        if (getY() == y_limit)
        {
            y = 0;
            draw();
        }
        else
        {
            y++;
            draw();
        }
    }

    public void izquierda()
    {
        if (getX() == 0)
        {
            x = x_limit;
            draw();
        }
        else
        {
            x--;
            draw();
        }
    }

    public void derecha()
    {
        if (getX() == x_limit)
        {
            x = 0;
            draw();
        }
        else
        {
            x++;
            draw();
        }
    }

    public void draw()
    {
        Console.SetCursorPosition(x, y);
        Console.Write("*");
    }
}