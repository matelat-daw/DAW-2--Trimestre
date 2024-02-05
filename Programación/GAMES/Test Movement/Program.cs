class Program
{
    static int width = 80;
    static int height = 20;

    static int headX;
    static int headY;
    static int foodX;
    static int foodY;

    static List<int> snakeX;
    static List<int> snakeY;
    static int snakeLength;
    static bool isGameOver;

    static void Main()
    {
        InitializeGame();

        Console.Clear();
        DrawGame();
        InitializeGame();

        while (!isGameOver)
        {
            ProcessInput();
            Thread.Sleep(100);
        }

        Console.WriteLine("Game Over! Press any key to exit.");
        Console.ReadKey();
    }

    static void InitializeGame()
    {
        Console.WindowWidth = width + 2;
        Console.WindowHeight = height + 2;
        Console.BufferWidth = Console.WindowWidth;
        Console.BufferHeight = Console.WindowHeight;

        for (int i = 0; i < 82; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write("O");
            Console.SetCursorPosition(i, 21);
            Console.Write("O");
        }

        for (int i = 0; i < 22; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("O");
            Console.SetCursorPosition(81, i);
            Console.Write("O");
        }

        headX = width / 2;
        headY = height / 2;

        snakeX = new List<int> { headX, headX - 1, headX - 2, headX - 3 };
        snakeY = new List<int> { headY, headY, headY, headY };
        snakeLength = 4;

        isGameOver = false;

        SpawnFood();
    }

    static void DrawGame()
    {
        Console.SetCursorPosition(foodX, foodY);
        Console.Write("Ò");

        for (int i = 0; i < snakeLength; i++)
        {
            Console.SetCursorPosition(snakeX[i], snakeY[i]);
            if (i == 0)
            {
                Console.Write("@");
            }
            else
            {
                Console.Write("*");
            }
        }
        CheckFood();
    }

    static void ProcessInput()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    MoveSnakeUp();
                    break;

                case ConsoleKey.DownArrow:
                    MoveSnakeDown();
                    break;

                case ConsoleKey.LeftArrow:
                    MoveSnakeLeft();
                    break;

                case ConsoleKey.RightArrow:
                    MoveSnakeRight();
                    break;
            }
        }
        CheckCollision();
    }

    static void MoveSnakeUp()
    {
        snakeX.Insert(0, headX);
        snakeY.Insert(0, headY - 1);
        UpdateHeadPosition();
        show();
    }

    static void MoveSnakeDown()
    {
        snakeX.Insert(0, headX);
        snakeY.Insert(0, headY + 1);
        UpdateHeadPosition();
        show();
    }

    static void MoveSnakeLeft()
    {
        snakeX.Insert(0, headX - 1);
        snakeY.Insert(0, headY);
        UpdateHeadPosition();
        show();
    }

    static void MoveSnakeRight()
    {
        snakeX.Insert(0, headX + 1);
        snakeY.Insert(0, headY);
        UpdateHeadPosition();
        show();
    }

    private static void show()
    {
        Console.Clear();
        for (int i = snakeX[0]; i > snakeX[0] - snakeLength; i--)
        {
            Console.SetCursorPosition(i, headY);
            if (i == snakeX[0])
            {
                Console.Write("@");
            }
            else
            {
                Console.Write("*");
            }
        }
        Thread.Sleep(500);
    }

    static void UpdateHeadPosition()
    {
        if (snakeX.Count > snakeLength)
        {
            snakeX.RemoveAt(snakeX.Count - 1);
            snakeY.RemoveAt(snakeY.Count - 1);
        }
    }

    static void CheckCollision()
    {
        if (headX <= 0 || headX >= width || headY <= 0 || headY >= height)
            isGameOver = true;

        //for (int i = 1; i < snakeLength; i++)
        //{
        //    if (headX == snakeX[i] && headY == snakeY[i])
        //        isGameOver = true;
        //}
    }

    static void SpawnFood()
    {
        Random rand = new Random();
        foodX = rand.Next(1, width);
        foodY = rand.Next(1, height);
    }

    static void CheckFood()
    {
        if (headX == foodX && headY == foodY)
        {
            snakeLength++;
            SpawnFood();
        }
    }
}