
public class Serpent
{
    private int i;
    private int x = 60;
    private int y = 13;
    private int life = 3;
    private int score = 0;
    private bool change = false;
    private const int XSTART = 19;
    private const int XEND = 101;
    private const int YSTART = 4;
    private const int YEND = 31;
    private LinkedList<Coords> body = new LinkedList<Coords>();
    private Direction direction;
    private Coords aux;
    private Food food;

    public int getDirection
    {
        get { return (int)direction; }
    }

    public Serpent(LinkedList<Coords> body)
    {
        this.body = body;
        this.direction = Direction.East;
        food = new Food();
        showFood();
        showFrame();
    }

    private void showFrame()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        for (int i = XSTART - 1; i <= XEND + 1; i++)
        {
            Console.SetCursorPosition(i, YSTART - 1);
            Console.Write('-');
            Console.SetCursorPosition(i, YEND + 1);
            Console.Write('_');
        }

        for (int i = YSTART - 1; i <= YEND + 1; i++)
        {
            Console.SetCursorPosition(XSTART - 1, i);
            Console.Write('|');
            Console.SetCursorPosition(XEND + 1, i);
            Console.Write('|');
        }
    }

    private void showFood()
    {
        Console.SetCursorPosition(food.getx_food, food.gety_food);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write('Ò');
    }

    public void show()
    {
        Console.CursorVisible = false;
        for (i = 0; i < body.Count; i++)
        {
            Console.SetCursorPosition(body.ElementAt(i).xValue, body.ElementAt(i).yValue);
            if (i == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("*");
            }
            if (!change)
            {
                switch (direction)
                {
                    case Direction.North:
                        Console.SetCursorPosition(body.Last.Value.xValue, body.Last.Value.yValue);
                        Console.Write(' ');
                        break;
                    case Direction.South:
                        Console.SetCursorPosition(body.Last.Value.xValue, body.Last.Value.yValue);
                        Console.Write(' ');
                        break;
                    case Direction.East:
                        Console.SetCursorPosition(body.Last.Value.xValue, body.Last.Value.yValue);
                        Console.Write(' ');
                        break;
                    case Direction.West:
                        Console.SetCursorPosition(body.Last.Value.xValue, body.Last.Value.yValue);
                        Console.Write(' ');
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case Direction.North:
                        Console.SetCursorPosition(body.Last.Value.xValue, body.Last.Value.yValue + 1);
                        Console.Write(' ');
                        Console.SetCursorPosition(body.Last.Value.xValue, body.Last.Value.yValue + 2);
                        Console.Write(' ');
                        change = false;
                        break;
                    case Direction.South:
                        Console.SetCursorPosition(body.Last.Value.xValue, body.Last.Value.yValue - 1);
                        Console.Write(' ');
                        Console.SetCursorPosition(body.Last.Value.xValue, body.Last.Value.yValue - 2);
                        Console.Write(' ');
                        change = false;
                        break;
                    case Direction.East:
                        Console.SetCursorPosition(body.Last.Value.xValue - 1, body.Last.Value.yValue);
                        Console.Write(' ');
                        Console.SetCursorPosition(body.Last.Value.xValue - 2, body.Last.Value.yValue);
                        Console.Write(' ');
                        change = false;
                        break;
                    case Direction.West:
                        Console.SetCursorPosition(body.Last.Value.xValue + 1, body.Last.Value.yValue);
                        Console.Write(' ');
                        Console.SetCursorPosition(body.Last.Value.xValue + 2, body.Last.Value.yValue);
                        Console.Write(' ');
                        change = false;
                        break;
                }
            }
        }

        for (i = 0; i < body.Count; i++)
        {
            if (body.First.Value.xValue == food.getx_food && body.First.Value.yValue == food.gety_food)
            {
                life--;
                for (i = 0; i < body.Count; i++)
                {

                }
            }
        }

        if (body.First.Value.xValue == food.getx_food && body.First.Value.yValue == food.gety_food)
        {
            score += 10;
            if (score % 100 == 0)
            {
                life++;
            }
            food = new Food();
            showFood();
            aux = new(body.ElementAt(1).xValue, body.ElementAt(1).yValue);
            body.AddLast(aux);
        }
    }

    public void move()
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow:
                if (direction != Direction.South)
                {
                    direction = Direction.North;
                    aux = new(body.ElementAt(0).xValue, body.ElementAt(0).yValue - 1);
                    body.AddFirst(aux);
                    body.RemoveLast();
                }
                break;
            case ConsoleKey.DownArrow:
                if (direction != Direction.North)
                {
                    direction = Direction.South;
                    aux = new(body.ElementAt(0).xValue, body.ElementAt(0).yValue + 1);
                    body.AddFirst(aux);
                    body.RemoveLast();
                }
                break;
            case ConsoleKey.LeftArrow:
                if (direction != Direction.East)
                {
                    direction = Direction.West;
                    aux = new(body.ElementAt(0).xValue - 1, body.ElementAt(0).yValue);
                    body.AddFirst(aux);
                    body.RemoveLast();
                }
                break;
            case ConsoleKey.RightArrow:
                if (direction != Direction.West)
                {
                    direction = Direction.East;
                    aux = new(body.ElementAt(0).xValue + 1, body.ElementAt(0).yValue);
                    body.AddFirst(aux);
                    body.RemoveLast();
                }
                break;
            case ConsoleKey.Escape:
                Environment.Exit(0);
                break;
        }

        if (body.ElementAt(0).xValue == XEND)
        {
            x = XSTART + 1;
            aux = new(x, body.ElementAt(0).yValue);
            same();
        }
        if (body.ElementAt(0).xValue == XSTART)
        {
            x = XEND - 1;
            aux = new(x, body.ElementAt(0).yValue);
            same();
        }
        if (body.ElementAt(0).yValue == YEND)
        {
            y = YSTART + 1;
            aux = new(body.ElementAt(0).xValue, y);
            same();
        }
        if (body.ElementAt(0).yValue == YSTART)
        {
            y = YEND - 1;
            aux = new(body.ElementAt(0).xValue, y);
            same();
        }
        show();
        move();
    }

    private void same()
    {
        body.AddFirst(aux);
        body.RemoveLast();
        change = true;
    }
}