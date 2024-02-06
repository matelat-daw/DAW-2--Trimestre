using System.Media;

public class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
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
        for (int i = x; i <= x_limit; i++)
        {
            Console.SetCursorPosition(i, y);
            Console.Write('O');
            Console.SetCursorPosition(i, y_limit);
            Console.Write('O');
        }

        for (int i = y; i <= y_limit; i++)
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
    private int i;
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
    private int velocity = 300;
    private int speed = 0;
    private int direction = 3;
    private int score = 0;
    private bool sound = false;

    public async void move()
    {
        if (starting)
        {
            if (!sound)
            { 
                SoundPlayer voice = new SoundPlayer(Environment.CurrentDirectory + "/audio/voice1.wav");
                // voice.Play();
                sound = true;
                // await Task.Delay(4000);
            }
            if (x >= x_start && x <= x_limit && y >= y_start && y <= y_limit)
            {
                await Task.Delay(velocity);
                clean();
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.White;
                switch (direction)
                {
                    case 0:
                        for (i = y + 1; i < y + body; i++)
                        {
                            Console.SetCursorPosition(x, i);
                            Console.Write("*");
                        }
                        y--;
                        verticalSpeed();
                        break;
                    case 1:
                        for (i = y - 1; i > y - body; i--)
                        {
                            Console.SetCursorPosition(x, i);
                            Console.Write("*");
                        }
                        y++;
                        verticalSpeed();
                        break;
                    case 2:
                        for (i = x + body; i > x; i--)
                        {
                            Console.SetCursorPosition(i, y);
                            Console.Write("*");
                        }
                        x--;
                        horizontalSpeed();
                        break;
                    case 3:
                        for (i = x - body; i < x; i++)
                        {
                            Console.SetCursorPosition(i, y);
                            Console.Write("*");
                        }
                        x++;
                        horizontalSpeed();
                        break;
                }
                if (x == appleX && y == appleY)
                {
                    score += 10;
                    if (score % 100 == 0)
                    {
                        lifes++;
                    }
                    Console.SetCursorPosition(60, 30);
                    Console.WriteLine("Comí Manzana: {0}", score);
                    body++;
                    speed += 50;
                    load();
                }
                move();
            }
            else
            {
                lifes--;
                sound = false;
                if (lifes == 0)
                {
                    loose();
                }
                else
                {
                    clean();
                    Console.SetCursorPosition(60, 35);
                    Console.WriteLine("Has Perdido un Vida, te quedan: {0} Oportunidades.", lifes);
                    Console.SetCursorPosition(60, 37);
                    Console.WriteLine("Presiona una Tecla Para Continuar.");
                    Console.ReadKey();
                    x = 62;
                    y = 15;
                    direction = 3;
                    move();
                }
            }
        }
    }

    private void loose()
    {
        Console.Clear();
        Console.WriteLine("Lo Siento Haz Perdido.\n");
        Console.WriteLine("Presiona 1 Para Volver a Jugar o ESC para Cerrar el Programa.");
        ConsoleKeyInfo key;
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Escape)
        {
            if (key.Key == ConsoleKey.D1)
            {
                start();
            }
        }
        System.Environment.Exit(0);
    }

    private void verticalSpeed()
    {
        velocity = 600 - speed;
        if (velocity < 0)
            velocity = 0;
    }

    private void horizontalSpeed()
    {
        velocity = 300 - speed;
        if (velocity < 0)
            velocity = 0;
    }

    private void clean()
    {
        for (int i = y_start; i <= y_limit; i++)
        {
            for (int j = x_start; j <= x_limit; j++)
            {
                if (i != appleY && j != appleX)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(' ');
                }
            }
        }
    }

    public void start()
    {
        Console.Clear();
        Board board = new Board();
        board.show();
        show();
        load();
        Menu menu = new Menu();
        Console.SetCursorPosition(20, 1);
        Console.WriteLine("Juego de la Serpiente.\n");
        menu.show();
        Console.Write("\nSelecciona una Opción del Menú(ESC to Exit): ");
        ConsoleKeyInfo key;
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Escape)
        {
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    if (!starting)
                    {
                        starting = true;
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

    private void show()
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("@");
        Console.ForegroundColor = ConsoleColor.White;
        for (i = x - body; i < x; i++)
        {
            Console.SetCursorPosition(i, y);
            Console.Write("*");
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
                    if (direction != 1)
                        direction = 0;
                    break;
                case ConsoleKey.DownArrow:
                    if (direction != 0)
                        direction = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    if (direction != 3)
                        direction = 2;
                    break;
                case ConsoleKey.RightArrow:
                    if (direction != 2)
                        direction = 3;
                    break;
            }
            move();
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