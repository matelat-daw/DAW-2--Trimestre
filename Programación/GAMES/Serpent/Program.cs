using System.Collections.Generic;
using System.ComponentModel.Design;

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
    int x = 29;
    int y = 3;
    const int x_limit = 89;
    const int y_limit = 23;

    public void show()
    {
        for (int i = x; i < x + 89; i++)
        {
            Console.SetCursorPosition(i, y);
            Console.Write('-');
            Console.SetCursorPosition(i, y + y_limit);
            Console.Write('-');
        }

        for (int i = y; i < y + 23; i++)
        {
            Console.SetCursorPosition(x, i);
            Console.Write('-');
            Console.SetCursorPosition(x + x_limit, i);
            Console.Write('-');
        }
    }

    public void load()
    {
        Random rnd = new Random();
        int x = rnd.Next(30, x_limit);
        int y = rnd.Next(4, y_limit);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(x, y);
        Console.Write("Ó");
        Console.ForegroundColor = ConsoleColor.Gray;
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

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine("\n{0}", list[i]);
        }
        Console.WriteLine();
    }
}

public class Serpent
{
    int lifes = 3;
    int x;
    int y;
    int x_start = 30;
    int y_start = 4;
    const int x_limit = 118;
    const int y_limit = 22;
    int body = 4;
    int cont = 0;
    bool starting;
    bool up;
    bool down;
    bool left;
    bool rigth;
    int speed = 300;

    public async void move(int x, int y, int direction)
    {
        if (starting)
        {
            this.x = x;
            this.y = y;
            try
            {
                if (x > x_start && x < x_limit && y > y_start && y < y_limit)
                {
                    show(x, y);
                    await Task.Delay(300);
                    Console.SetCursorPosition(x - body, y);
                    Console.Write(' ');
                    cont++;
                    switch (direction)
                    {
                        case 1:
                            move(x, y - 1, 1);
                            break;
                        case 2:
                            move(x, y + 1, 2);
                            break;
                        case 3:
                            move(x - 1, y, 3);
                            break;
                        case 4:
                            move(x + 1, y, 4);
                            break;
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
                    Console.SetCursorPosition(60, 15);
                    Console.WriteLine("Has Perdido un Vida, te quedan: {0} Oportunidades.", lifes);
                    Console.WriteLine("Presiona una Tecla Para Continuar.");
                    Console.ReadKey();
                    move(62, 13, 4);
                }
            }
            if (cont == 5)
            {
                body++;
                cont = 0;
            }
        }
    }

    public void start()
    {
        int selection;
        Board board = new Board();
        board.show();
        board.load();
        Menu menu = new Menu();
        ConsoleKeyInfo key;

        Console.WriteLine("\n\n\nJuego de la Serpiente.\n");
        menu.show();
        Console.Write("\nSelecciona una Opción del Menú(ESC to Exit): ");
        show(62, 13);
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Escape)
        {
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    if (!starting)
                    {
                        starting = true;
                        show(62, 13);
                        play(key);
                    }
                    break;
                case ConsoleKey.D2:
                    starting = false;
                    break;
                case ConsoleKey.D3:
                    if (!starting)
                    {
                        starting = true;
                        show(x, y);
                    }
                    break;
                case ConsoleKey.D4:
                    start();
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("Estás Seguro que Quierres Salir?. Presiona ESC para Continua, Cualquier Otra Tecla Para Seguir.");
                    break;
            }
        }
    }

    private void play(ConsoleKeyInfo key)
    {
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Escape)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    move(x, y, 1);
                    break;
                case ConsoleKey.DownArrow:
                    move(x, y, 2);
                    break;
                case ConsoleKey.LeftArrow:
                    move(x, y, 3);
                    break;
                case ConsoleKey.RightArrow:
                    move(x, y, 4);
                    break;
            }
        }
    }

    public void show(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("@");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(x - body, y);
        for (int i = x - body; i < x; i++)
        {
            Console.Write("*");
        }
    }
}