using System.Media;

public class Program
{
    public static List<string> snake = new List<string>();
    public static int x = 60;
    public static int y = 20;
    public static int dir = 3;
    public static int counter = 0;
    public static int vertical = snake.Count / 3;

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        bool moving = false;
        int direction = 3;
        snake.Add("@");
        snake.Add("*");
        snake.Add("*");
        snake.Add("*");
        snake.Add("*");

        Console.WriteLine("Este Programa Reproduce Sonidos.");

        SoundPlayer voice = new SoundPlayer(Environment.CurrentDirectory + "/audio/voice.wav");
        // voice.Play();
        // Console.WriteLine("Presiona Cualquier Tecla para Empezar.");
        // Console.ReadLine();

        Console.SetCursorPosition(x - snake.Count + 1, y);
        for (int i = snake.Count - 1; i >= 0; i--)
        {
            Console.Write(snake[i]);
        }

        ConsoleKeyInfo key;
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Escape)
        {
            switch (key.Key)
            {
                //case ConsoleKey.OemPlus:
                case ConsoleKey.Enter:
                        snake.Add("*");
                    // snake.Add(snake[snake.Count - 1] + 1);
                    break;
                case ConsoleKey.UpArrow:
                    moving = true;
                    moveUp();
                    break;
                case ConsoleKey.DownArrow:
                    moving = true;
                    moveDown();
                    break;
                case ConsoleKey.LeftArrow:
                    moving = true;
                    dir = 2;
                    moveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    moving = true;
                    dir = 3;
                    moveRight();
                    break;
            }
            if (!moving)
            {
                show();
            }
        }
    }

    private static void moveUp()
    {
        if (dir == 0)
        {
            Console.SetCursorPosition(x + snake.Count - 1, y);
            Console.Write(' ');
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i > vertical || i == 0)
                {
                    Console.SetCursorPosition(x, y - 1 - i);
                    Console.Write(snake[i]);
                }
            }
            y--;
        }
        else
        {
            if (dir == 2 || dir == 3)
            {
                moveUpTurnig();
            }
        }
    }

    private static void moveDown()
    {
        if (dir == 1)
        {
            Console.SetCursorPosition(x - snake.Count + 2, y);
            Console.Write(' ');
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i > vertical || i == 0)
                {
                    Console.SetCursorPosition(x, y + 1 + i);
                    Console.Write(snake[i]);
                }
            }
            y++;
        }
        else
        {
            if (dir == 2 || dir == 3)
            {
                moveDownTurning();
            }
        }
    }

    private static async void moveUpTurnig()
    {
        while (counter < snake.Count)
        {
            for (int i = counter; i >= 0; i--)
            {
                if (counter < snake.Count - vertical)
                {
                    Console.SetCursorPosition(x, y - 1 - i);
                    Console.Write(snake[counter - i]);
                }
            }
            cleanHorizontal();
            counter++;
            await Task.Delay(300);
        }
        counter = 0;
        y--;
        dir = 0;
    }

    private static async void moveDownTurning()
    {
        int vertical = snake.Count / 3;

        while (counter < snake.Count)
        {
            for (int i = counter; i >= 0; i--)
            {
                if (counter < snake.Count - vertical)
                {
                    Console.SetCursorPosition(x, y + 1 + i);
                    Console.Write(snake[counter - i]);
                }
            }
            cleanHorizontal();
            counter++;
            await Task.Delay(300);
        }
        counter = 0;
        y++;
        dir = 1;
    }

    private static void moveRight()
    {
        Console.SetCursorPosition(x - snake.Count + 1, y);
        Console.Write(' ');
        for (int i = snake.Count - 1; i >= 0; i--)
        {
            Console.SetCursorPosition(x - i + 1, y);
            Console.Write(snake[i]);
        }
        x++;
    }

    private static void moveLeft()
    {
        Console.SetCursorPosition(x, y);
        Console.Write(' ');
        for (int i = 0; i < snake.Count; i++)
        {
            Console.SetCursorPosition(x - snake.Count + i, y);
            Console.Write(snake[i]);
        }
        x--;
    }

    private static async void moveUpRight()
    {
        int vertical = snake.Count / 3;

        while (counter < snake.Count)
        {
            for (int i = counter; i >= 0; i--)
            {
                if (counter < snake.Count + vertical)
                {
                    Console.SetCursorPosition(x + 1 + i, y);
                    Console.Write(snake[counter - i]);
                }
            }
            cleanVertical();
            counter++;
            await Task.Delay(300);
        }
        counter = 0;
        y++;
        dir = 1;
    }

    private static async void moveUpLeft()
    {
        int vertical = snake.Count / 3;

        while (counter < snake.Count)
        {
            for (int i = counter; i >= 0; i--)
            {
                if (counter < snake.Count + vertical)
                {
                    Console.SetCursorPosition(x + 1 + i, y);
                    Console.Write(snake[counter - i]);
                }
            }
            cleanHorizontal();
            counter++;
            await Task.Delay(300);
        }
        counter = 0;
        y++;
        dir = 1;
    }

    private static async void moveDownRight()
    {
        int vertical = snake.Count / 3;

        while (counter < snake.Count)
        {
            for (int i = counter; i >= 0; i--)
            {
                if (counter < snake.Count + vertical)
                {
                    Console.SetCursorPosition(x + 1 + i, y);
                    Console.Write(snake[counter - i]);
                }
            }
            cleanHorizontal();
            counter++;
            await Task.Delay(300);
        }
        counter = 0;
        y++;
        dir = 1;
    }

    private static async void moveDownLeft()
    {
        int vertical = snake.Count / 3;

        while (counter < snake.Count)
        {
            for (int i = counter; i >= 0; i--)
            {
                if (counter < snake.Count + vertical)
                {
                    Console.SetCursorPosition(x + 1 + i, y);
                    Console.Write(snake[counter - i]);
                }
            }
            cleanHorizontal();
            counter++;
            await Task.Delay(300);
        }
        counter = 0;
        y++;
        dir = 1;
    }

    private static void cleanHorizontal()
    {
        for (int i = counter + 1; i <= snake.Count; i++)
        {
            Console.SetCursorPosition(x - snake.Count + 1 + counter, y);
            Console.Write(' ');
        }
    }

    private static void cleanVertical()
    {
        for (int i = counter + 1; i <= snake.Count; i++)
        {
            Console.SetCursorPosition(x, y - snake.Count + 1 + counter);
            Console.Write(' ');
        }
    }

    public static void show()
    {
        for (int i = 0; i < snake.Count; i++)
        {
            Console.Write(snake[i]);
        }
        Console.WriteLine();
        for (int i = snake.Count - 1; i >= 0; i--)
        {
            Console.Write(snake[i]);
        }
        Console.WriteLine();
    }
}