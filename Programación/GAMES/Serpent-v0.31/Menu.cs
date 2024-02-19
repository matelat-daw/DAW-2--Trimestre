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

        Console.SetCursorPosition(0, 35);
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine("\n{0}", list[i]);
        }
        Console.WriteLine();
    }
}