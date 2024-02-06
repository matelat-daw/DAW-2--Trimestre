using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Data;

struct Position
{
    public int row;
    public int col;
    public Position(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
}


class Program
{
    public void DrawFood()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("@");
    }

    public void DrawObstacle()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("=");
    }

    public void DrawSnakeBody()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("*");
    }

    
    public void Direction(Position[] directions)
    {

        directions[0] = new Position(0, 1);
        directions[1] = new Position(0, -1);
        directions[2] = new Position(1, 0);
        directions[3] = new Position(-1, 0);

    }

    public void CheckUserInput(ref int direction, byte right, byte left, byte down, byte up)
    {

        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != right) direction = left;
            }
            if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != left) direction = right;
            }
            if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != down) direction = up;
            }
            if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != up) direction = down;
            }
        }
    }

    public int GameOverCheck(int currentTime, Queue<Position> snakeElements, Position snakeNewHead, int negativePoints)
    {
        if (snakeElements.Contains(snakeNewHead) || (Environment.TickCount - currentTime) > 30000)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;//Text color for game over

            int userPoints = (snakeElements.Count - 4) * 100 - negativePoints;//points calculated for player
            userPoints = Math.Max(userPoints, 0); //if (userPoints < 0) userPoints = 0;

            PrintLinesInCenter("Game Over!", "Your points are:" + userPoints, "Press enter to exit the game!");

            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            return 1;
        }
        return 0;
    }

    public int WinningCheck(Queue<Position> snakeElements, int negativePoints)
    {
        if (snakeElements.Count == 7)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;//Text color for game won

            int userPoints = (snakeElements.Count - 4) * 100 - negativePoints;//points calculated for player
            userPoints = Math.Max(userPoints, 0); //if (userPoints < 0) userPoints = 0;

            PrintLinesInCenter("You Win!", "Your points are:" + userPoints, "Press enter to exit the game!");

            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            return 1;
        }
        return 0;
    }

    public void GenerateFood(ref Position food, Queue<Position> snakeElements)
    {
        Random randomNumbersGenerator = new Random();
        do
        {
            food = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight), //Food generated within console height
                randomNumbersGenerator.Next(0, Console.WindowWidth)); //Food generate within console width
        }
        while (snakeElements.Contains(food));
        Console.SetCursorPosition(food.col, food.row);
        DrawFood();
    }

    private static void PrintLinesInCenter(params string[] lines)
    {
        int verticalStart = (Console.WindowHeight - lines.Length) / 2; //  printing the lines
        int verticalPosition = verticalStart;
        foreach (var line in lines)
        {
            int horizontalStart = (Console.WindowWidth - line.Length) / 2;

            Console.SetCursorPosition(horizontalStart, verticalPosition);

            Console.Write(line);
            ++verticalPosition;
        }
    }

    public void DisplayStartScreen()
    {
        Console.ForegroundColor = ConsoleColor.Cyan; //text color for text display

        PrintLinesInCenter("WELCOME TO SNAKE GAME", "\n", "Highest Score");

        Thread.Sleep(3000);

        Console.Clear();
    }

    static void Main(string[] args)
    {

        byte right = 0;
        byte left = 1;
        byte down = 2;
        byte up = 3;
        int currentTime = Environment.TickCount;
        int lastFoodTime = 0;
        int foodDissapearTime = 10000; //food dissappears after 10 second 
        int negativePoints = 0;
        bool alive = true;

        Console.SetWindowSize(56, 38);//reducing screen size 
        Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        Position[] directions = new Position[4];

        Program p = new Program();

        p.DisplayStartScreen();

        p.Direction(directions);

        double sleepTime = 100;
        int direction = right;
        Random randomNumbersGenerator = new Random();
        Console.BufferHeight = Console.WindowHeight;
        lastFoodTime = Environment.TickCount;

        Queue<Position> snakeElements = new Queue<Position>();
        // List<Position> snakeElements = new List<Position>(); 
        for (int i = 0; i <= 3; i++) // Length of the snake was reduced to 3 units of *
        {
            snakeElements.Enqueue(new Position(0, i));
        }

        //To position food randomly when the program runs first time
        Position food = new Position();
        p.GenerateFood(ref food, snakeElements);

        //while the game is running position snake on terminal with shape "*"
        foreach (Position position in snakeElements)
        {
            Console.SetCursorPosition(position.col, position.row);
            p.DrawSnakeBody();
        }

        while (true)
        {
            negativePoints++;

            p.CheckUserInput(ref direction, right, left, down, up);

            Position snakeHead = snakeElements.Last();
            Position nextDirection = directions[direction];

            Position snakeNewHead = new Position(snakeHead.row + nextDirection.row, snakeHead.col + nextDirection.col);

            if (snakeNewHead.col < 0) snakeNewHead.col = Console.WindowWidth - 1;
            if (snakeNewHead.row < 0) snakeNewHead.row = Console.WindowHeight - 1;
            if (snakeNewHead.row >= Console.WindowHeight) snakeNewHead.row = 0;
            if (snakeNewHead.col >= Console.WindowWidth) snakeNewHead.col = 0;

            int gameOver = p.GameOverCheck(currentTime, snakeElements, snakeNewHead, negativePoints);
            if (gameOver == 1)
                return;

            int winning = p.WinningCheck(snakeElements, negativePoints);
            if (winning == 1) return;

            Console.SetCursorPosition(snakeHead.col, snakeHead.row);
            p.DrawSnakeBody();

            snakeElements.Enqueue(snakeNewHead);
            Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
            Console.ForegroundColor = ConsoleColor.Gray;
            if (direction == right) Console.Write(">"); //Snake head when going right
            if (direction == left) Console.Write("<");//Snake head when going left
            if (direction == up) Console.Write("^");//Snake head when going up
            if (direction == down) Console.Write("v");//Snake head when going down


            if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
            {
                Console.Beep();// Make a sound effect when food was eaten.
                p.GenerateFood(ref food, snakeElements);

                lastFoodTime = Environment.TickCount;
                sleepTime--;
            }
            else
            {
                Position last = snakeElements.Dequeue();
                Console.SetCursorPosition(last.col, last.row);
                Console.Write(" ");
            }

            if (Environment.TickCount - lastFoodTime >= foodDissapearTime)
            {
                negativePoints = negativePoints + 50;
                Console.SetCursorPosition(food.col, food.row);
                Console.Write(" ");

                p.GenerateFood(ref food, snakeElements);
                lastFoodTime = Environment.TickCount;
            }

            sleepTime -= 0.01;
            Thread.Sleep((int)sleepTime);
        }
    }
}