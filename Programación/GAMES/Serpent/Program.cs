using System.ComponentModel;

public class Program
{
    static void Main(string[] args)
    {
        Serpent serpent = new Serpent();
        serpent.start();
    }
}

public class Board
{
    int x = 19;
    int y = 4;
    const int x_limit = 101;
    const int y_limit = 26;

    public void show()
    {
        for (int i = x; i < x_limit; i++)
        {
            Console.SetCursorPosition(i, y);
            Console.Write('O');
            Console.SetCursorPosition(i, y_limit);
            Console.Write('O');
        }

        for (int i = y; i < y_limit; i++)
        {
            Console.SetCursorPosition(x, i);
            Console.Write('O');
            Console.SetCursorPosition(x_limit, i);
            Console.Write('O');
        }
    }
}

public class Menu
{
    public void show()
    {
        List<string> list = new List<string>();
        list.Add("1)-. Nuevo Juego");
        list.Add("2)-. Pausa el Juego");
        list.Add("3)-. Continua Jugando");
        list.Add("4)-. Me Rindo");
        list.Add("5)-. Salgo del Juego");

        Console.SetCursorPosition(0, 30);
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine("\n{0}", list[i]);
        }
        Console.WriteLine();
    }
}

public class Serpent()
{
    private int lifes = 3;
    private int x = 62;
    private int y = 15;
    private int appleX;
    private int appleY;
    private int x_start = 20;
    private int y_start = 5;
    private const int x_limit = 100;
    private const int y_limit = 25;
    private int body = 4;
    private bool starting;
    private int speed;
    private int fast = 0;
    private int direction = 4;

    public async void move()
    {
        if (starting)
        {
            try
            {
                if (x >= x_start && x < x_limit && y >= y_start && y < y_limit)
                {
                    show();
                    await Task.Delay(speed);
                    switch (direction)
                    {
                        case 0:
                            y--;
                            speed = 600 - fast;
                            break;
                        case 1:
                            y++;
                            speed = 600 - fast;
                            break;
                        case 2:
                            speed = 300 - fast;
                            x--;
                            break;
                        case 3:
                            speed = 300 - fast;
                            x++;
                            break;
                    }
                    move();
                    if (x == appleX && y == appleY)
                    {
                        body++;
                        fast -= 50;
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                lifes--;
                if (lifes == 0)
                {
                    start();
                }
                else
                {
                    Console.SetCursorPosition(60, 35);
                    Console.WriteLine("Has Perdido un Vida, te quedan: {0} Oportunidades.", lifes);
                    Console.WriteLine("Presiona una Tecla Para Continuar.");
                    Console.ReadKey();
                    x = 62;
                    y = 15;
                    move();
                }
            }
        }
    }

    public void start()
    {
        int selection;
        Board board = new Board();
        board.show();
        load();
        Menu menu = new Menu();
        ConsoleKeyInfo key;
        Console.SetCursorPosition(20, 1);
        Console.WriteLine("Juego de la Serpiente.\n");
        menu.show();
        Console.Write("\nSelecciona una Opción del Menú(ESC to Exit): ");
        show();
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Escape)
        {
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    if (!starting)
                    {
                        starting = true;
                        show();
                        play();
                    }
                    break;
                case ConsoleKey.D2:
                    starting = false;
                    break;
                case ConsoleKey.D3:
                    if (!starting)
                    {
                        starting = true;
                        play();
                    }
                    break;
                case ConsoleKey.D4:
                    start();
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("Estás Seguro que Quierres Salir?. Presiona ESC para Abandonar el Juego, Cualquier Otra Tecla Para Seguir.");
                    break;
            }
        }
    }

    private void play()
    {
        ConsoleKeyInfo key;
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Escape)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    direction = 0;
                    break;
                case ConsoleKey.DownArrow:
                    direction = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    direction = 2;
                    break;
                case ConsoleKey.RightArrow:
                    direction = 3;
                    break;
            }
            move();
        }
    }

    public void show()
    {
        int i;

        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("@");
        Console.ForegroundColor = ConsoleColor.White;
        switch (direction)
        {
            case 0:
                Console.SetCursorPosition(x, y + body);
                for (i = y; i < y + body; i++)
                {
                    Console.Write("*");
                }
                break;
            case 1:
                Console.SetCursorPosition(x, y - body);
                for (i = y; i < y - body; i++)
                {
                    Console.Write("*");
                }
                break;
            case 2:
                Console.SetCursorPosition(x + body, y);
                for (i = x + body; i < x; i++)
                {
                    Console.Write("*");
                }
                break;
            case 3:
                Console.SetCursorPosition(x - body, y);
                for (i = x - body; i < x; i++)
                {
                    Console.Write("*");
                }
                break;
        }
    }

    public void load()
    {
        Random rnd = new Random();
        appleX = rnd.Next(20, x_limit);
        appleY = rnd.Next(5, y_limit);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(appleX, appleY);
        Console.Write("Ó");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}