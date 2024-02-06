using System.Collections.Immutable;

public class Carrera_de_Puntos
{
    private int x;
    private int[] all_x = new int[4];
    private int[] pre_x = new int[4];
    private int y;
    private int cont = 0;
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
        pre_x[cont] = x;
        x += velocity.Next(power);
        all_x[cont] = x;
        cont++;
        if (cont == 4)
        {
            cont = 0;
        }
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
        int[] rest = new int[2];
        int midIndex;
        int lowMid;

        int maxValue = all_x.Max();
        int maxIndex = all_x.ToList().IndexOf(maxValue);
        int minValue = all_x.Min();
        int minIndex = all_x.ToList().IndexOf(minValue);
        int index = 0;

        for (int i = 0; i < all_x.Length; i++)
        {
            if (i != maxIndex && i != minIndex && all_x.Max() != 0 && all_x.Min() != 0)
            {
                rest[index] = i;
                index++;
            }
        }

        if (rest[0] > rest[1])
        {
            midIndex = rest[0];
            lowMid = rest[1];
        }
        else
        {
            midIndex = rest[1];
            lowMid = rest[0];
        }

        Console.SetCursorPosition(pre_x[0], y);
        Console.Write(" ");
        Console.SetCursorPosition(all_x[0], y);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(player);
        Console.SetCursorPosition(pre_x[1], y);
        Console.Write(" ");
        Console.SetCursorPosition(all_x[1], y);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(player);
        Console.SetCursorPosition(pre_x[2], y);
        Console.Write(" ");
        Console.SetCursorPosition(all_x[2], y);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(player);
        Console.SetCursorPosition(pre_x[3], y);
        Console.Write(" ");
        Console.SetCursorPosition(all_x[3], y);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(player);
        Console.ForegroundColor= ConsoleColor.White;
    }
}