public class LinkedList
{
    private LinkedList<Punto> serpent = new LinkedList<Punto>();
    private readonly Direction direction;

    private LinkedList (LinkedList<Punto> serpent, Direction direction)
    {
        this.serpent = serpent;
        this.direction = direction;
    }

    public void move()
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow:

                break;
            case ConsoleKey.DownArrow:
                break;
            case ConsoleKey.LeftArrow:
                break;
            case ConsoleKey.RightArrow:
                break;
        }
        move();
    }

    public void show()
    {

    }
}