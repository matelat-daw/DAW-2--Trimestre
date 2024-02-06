public class Carrera_de_Puntos
{
    private int x;
    private int pre_x;
    private int y;
    private char player;
    private static int llegada;
    private Random velocity = new Random();
    private bool result = false;

    public Carrera_de_Puntos(int x, int y, char player)
    {
        this.x = x;
        this.y = y;
        this.player = player;
    }

    public bool avanzar(int power)
    {
        pre_x = x;
        x += velocity.Next(power);
        if (x >= llegada)
        {
            x = llegada;
            result = true;
        }
        return result;
    }

    public static void fijar_meta(int meta)
    {
        llegada = meta;
        Console.SetCursorPosition(meta, 10);
        Console.Write("| L");
        Console.SetCursorPosition(meta, 11);
        Console.Write("| L");
        Console.SetCursorPosition(meta, 12);
        Console.Write("| E");
        Console.SetCursorPosition(meta, 13);
        Console.Write("| G");
        Console.SetCursorPosition(meta, 14);
        Console.Write("| A");
        Console.SetCursorPosition(meta, 15);
        Console.Write("| D");
        Console.SetCursorPosition(meta, 16);
        Console.Write("| A");
    }

    public void mostrar()
    {
        Console.SetCursorPosition(pre_x, y);
        Console.Write(" ");
        Console.SetCursorPosition(x, y);
        Console.Write(player);
    }
}