public class Carrera_de_Puntos
{
    int x;
    int y;
    char player;
    static int llegada;

    public Carrera_de_Puntos(int x, int y, char player)
    {
        this.x = x;
        this.y = y;
        this.player = player;
    }

    public bool avanzar(int speed)
    {
        Random velocity = new Random();
        bool result = false;
        x += velocity.Next(speed);
        if (x > llegada)
        {
            x = llegada;
            result = true;
        }
        return result;
    }

    public static void fijar_meta(int meta)
    {
        llegada = meta;
    }

    public void mostrar()
    {
        Console.SetCursorPosition(x, y);
        Console.Write(player);
    }
}