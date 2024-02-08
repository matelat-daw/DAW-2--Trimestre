public class MainSerpent
{
    static void Main(string[] args)
    {
        int i;
        Coords[] ring = new Coords[6];
        Serpent serpent = null;
        LinkedList<Coords> body = new LinkedList<Coords>();

        Console.WriteLine("Juego de la Serpiente Version 0.3 - Con LinkingList<>");

        for (i = 0; i < 6; i++)
        {
            ring[i] = new (60 - i, 13);
            body.AddLast(ring[i]);
        }
        serpent = new Serpent(body);
        serpent.show();
        serpent.move();
    }
}