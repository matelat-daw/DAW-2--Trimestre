public class Punto
{
    private int x;
    private int y;
    private const int Y_LIM = 25;
    private const int X_LIM = 110;

    public Punto(int x, int y)
    {
        if (x < 0 || x > X_LIM || y < 0 || y > Y_LIM)
        {
            throw new Exception();
        }
        this.x = x % X_LIM;
        this.y = y % Y_LIM;
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
        if (x >= 0 && x <= X_LIM)
            this.x = x;
    }

    public void setY(int y)
    {
        if (y >= 0 && y <= Y_LIM)
            this.y = y;
    }

    public void arriba()
    {
        if (getY() == 0)
        {
            y = Y_LIM;
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
        if (getY() == Y_LIM)
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
            x = X_LIM;
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
        if (getX() == X_LIM)
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