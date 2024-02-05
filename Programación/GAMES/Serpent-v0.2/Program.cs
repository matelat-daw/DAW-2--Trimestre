using System.Media;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Juego de la Serpiente.\n");
        Serpent serpent = new Serpent();
        serpent.initialize();
        serpent.start();
    }
}

public class Food
{
    private static int foodX;
    private static int foodY;

    public static int FoodX
    {
        get { return foodX; }
        set { foodX = value; }
    }

    public static int FoodY
    {
        get { return foodY; }
        set { foodY = value; }
    }

    public static void addFood()
    {
        Random rnd = new Random();
        foodX = rnd.Next(20, Board.getBoardXEnd);
        foodY = rnd.Next(5, Board.getBoardVEnd);
        show();
    }

    public static void show()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(foodX, foodY);
        Console.Write("Ò");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

}

public class Board
{
    private static int board_hstart = 19;
    private static int board_vstart = 4;
    private static int board_hend = 101;
    private static int board_vend = 26;

    public static int getBoardXEnd
    {
        get { return board_hend; }
    }

    public static int getBoardVEnd
    {
        get { return board_vend; }
    }

    public static int getBoardXstart
    {
        get { return board_hstart; }
    }

    public static int getBoardVstart
    {
        get { return board_vstart; }
    }

    public void show()
    {
        for (int i = board_hstart; i <= board_hend; i++)
        {
            Console.SetCursorPosition(i, board_vstart);
            Console.Write('O');
            Console.SetCursorPosition(i, board_vend);
            Console.Write('O');
        }

        for (int i = board_vstart; i <= board_vend; i++)
        {
            Console.SetCursorPosition(board_hstart, i);
            Console.Write('O');
            Console.SetCursorPosition(board_hend, i);
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
        list.Add("5)-. Pauso la Música");
        list.Add("6)-. Salgo del Juego");

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
    private int body_length = 4;
    private int cont = 0;
    private int velocity = 300;
    private int speed = 0;
    private int direction = 3;
    private int score = 0;
    private int x_start = 20;
    private int x_end = 100;
    private int y_start = 5;
    private int y_end = 25;
    private List<int> coords = new List<int>();
    private bool starting;
    private bool start_sound;
    private bool start_music;
    private bool pause;
    private SoundPlayer sound;
    private int last_direction = 3;

    public void initialize()
    {
        this.coords = [63, 15, 62, 15, 61, 15, 60, 15];
    }

    public void move()
    {
        if (starting)
        {
            if (coords[0] >= x_start && coords[0] <= x_end && coords[1] >= y_start && coords[1] <= y_end)
            {
                int fix = 0;
                if (!start_sound)
                {
                    sound = new SoundPlayer(Environment.CurrentDirectory + "/audio/start.wav");
                    sound.Play();
                    start_sound = true;
                    Thread.Sleep(4000);
                }

                if (!start_music)
                {
                    if (!pause)
                    {
                        sound = new SoundPlayer(Environment.CurrentDirectory + "/audio/music.wav");
                        sound.Play();
                    }
                    else
                    {
                        sound.Stop();
                    }
                    start_music = true;
                }

                clean();
                switch (direction)
                {
                    case 0:
                        if (direction != last_direction)
                        {
                            for (i = 1; i < coords.Count; i += 2)
                            {
                                coords[i] = coords[i] - coords.Count / 4 + fix;
                                fix++;
                            }
                        }
                        else
                        {
                            for (i = 1; i < coords.Count; i += 2)
                            {
                                coords[i]--;
                            }
                        }
                        fix = 0;
                        for (i = 0; i < coords.Count - 1; i += 2)
                        {
                            coords[i] = coords[0];
                        }
                        last_direction = direction;
                        break;
                    case 1:
                        if (direction != last_direction)
                        {
                            for (i = 1; i < coords.Count; i += 2)
                            {
                                coords[i] = coords[i] + coords.Count / 4 - fix;
                                fix++;
                            }
                        }
                        else
                        {
                            for (i = 1; i < coords.Count; i += 2)
                            {
                                coords[i]++;
                            }
                        }
                        fix = 0;
                        for (i = 0; i < coords.Count - 1; i += 2)
                        {
                            coords[i] = coords[0];
                        }
                        last_direction = direction;
                        break;
                    case 2:
                        if (direction != last_direction)
                        {
                            for (i = 0; i < coords.Count - 1; i += 2)
                            {
                                coords[i] = coords[i] - coords.Count / 4 + fix;
                                fix++;
                            }
                        }
                        else
                        {
                            for (i = 0; i < coords.Count - 1; i += 2)
                            {
                                coords[i]--;
                            }
                        }
                        fix = 0;
                        for (i = 1; i < coords.Count; i += 2)
                        {
                            coords[i] = coords[1];
                        }
                        last_direction = direction;
                        break;
                    case 3:
                        if (direction != last_direction)
                        {
                            for (i = 0; i < coords.Count - 1; i += 2)
                            {
                                coords[i] = coords[i] + coords.Count / 4 - fix;
                                fix++;
                            }
                        }
                        else
                        {
                            for (i = 0; i < coords.Count - 1; i += 2)
                            {
                                coords[i]++;
                            }
                        }
                        fix = 0;
                        for (i = 1; i < coords.Count; i += 2)
                        {
                            coords[i] = coords[1];
                        }
                        last_direction = direction;
                        break;
                }
                show();

                Thread.Sleep(velocity - speed);


                if (coords[0] == Food.FoodX && coords[1] == Food.FoodY)
                {
                    score += 10;
                    speed += 10;
                    if (speed > 300)
                    {
                        speed = 300;
                    }
                    if (score % 100 == 0)
                    {
                        lifes++;
                    }
                    switch (direction)
                    {
                        case 0:
                            coords.Add(coords[0]);
                            coords.Add(coords[coords.Count - 2] + 1);
                            break;
                        case 1:
                            coords.Add(coords[0]);
                            coords.Add(coords[coords.Count - 2] - 1);
                            break;
                        case 2:
                            coords.Add(coords[coords.Count - 2] + 1);
                            coords.Add(coords[1]);
                            break;
                        case 3:
                            coords.Add(coords[coords.Count - 2] - 1);
                            coords.Add(coords[1]);
                            break;
                    }
                    Console.SetCursorPosition(60, 30);
                    Console.WriteLine("Comí Manzana: {0}", score);
                    Food.addFood();
                }
            }
            else
            {
                lifes--;
                // sound = false;
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
                    continua();
                }
            }
            change();
        }
    }

    private void change()
    {
        do
        {
            while (!Console.KeyAvailable)
            {
                move();
            }
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    if (!starting)
                    {
                        starting = true;
                        move();
                    }
                    break;
                case ConsoleKey.D2:
                    starting = false;
                    break;
                case ConsoleKey.D3:
                    if (!starting)
                    {
                        starting = true;
                        move();
                    }
                    break;
                case ConsoleKey.D4:
                    start();
                    break;
                case ConsoleKey.D5:
                    start_music = false;
                    pause = true;
                    break;
                case ConsoleKey.D6:
                    Console.SetCursorPosition(60, 40);
                    Console.WriteLine("Estás Seguro que Quierres Salir?. Presiona ESC para Abandonar el Juego, Cualquier Otra Tecla Para Seguir.");
                    break;
                case ConsoleKey.UpArrow:
                    if (direction != 1)
                    {
                        last_direction = direction;
                        direction = 0;
                    }
                    move();
                    break;
                case ConsoleKey.DownArrow:
                    if (direction != 0)
                    {
                        last_direction = direction;
                        direction = 1;
                    }
                    move();
                    break;
                case ConsoleKey.LeftArrow:
                    if (direction != 3)
                    {
                        last_direction = direction;
                        direction = 2;
                    }
                    move();
                    break;
                case ConsoleKey.RightArrow:
                    if (direction != 2)
                    {
                        last_direction = direction;
                        direction = 3;
                    }
                    move();
                    break;
            }
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        Environment.Exit(0);
    }

    private void loose()
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.WriteLine("Lo Siento Haz Perdido.\n");
        Console.WriteLine("Presiona Y Para Volver a Jugar o ESC para Cerrar el Programa.");
        ConsoleKeyInfo key;
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Escape)
        {
            if (key.Key == ConsoleKey.Y)
            {
                start();
            }
        }
        Environment.Exit(0);
    }

    private void clean()
    {
        for (i = y_start; i <= y_end; i++)
        {
            for (int j = x_start; j <= x_end; j++)
            {
                Console.SetCursorPosition(j, i);
                Console.Write(" ");
            }
        }
        Food.show();
    }

    public void start()
    {
        Console.Clear();
        Console.CursorVisible = false;
        Board board = new Board();
        board.show();
        show();
        Food.addFood();
        Menu menu = new Menu();
        Console.SetCursorPosition(20, 1);
        Console.WriteLine("Juego de la Serpiente.\n");
        menu.show();
        Console.Write("\nSelecciona una Opción del Menú(ESC to Exit): ");
        change();
    }

    private void show()
    {
        Console.SetCursorPosition(coords[0], coords[1]);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("@");
        Console.ForegroundColor = ConsoleColor.White;
        for (i = 2; i < coords.Count; i += 2)
        {
            Console.SetCursorPosition(coords[i], coords[i + 1]);
            Console.Write("*");
        }
    }

    private void continua()
    {
        for (i = 0; i < coords.Count; i+=2)
        {
            coords[i] = 63 - i / 2;
            coords[i + 1] = 15;
        }
        show();
    }
}