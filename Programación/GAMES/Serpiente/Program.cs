public class Program
{
    static void Main(string[] args)
    {
        PruebaSerpiente();
    }

    private static void PruebaSerpiente()
    {
        ConsoleKeyInfo pulsado;
        Serpiente shai_hulud = new Serpiente();
        shai_hulud.Mostrar();
        while ((pulsado = Console.ReadKey()).Key != ConsoleKey.Escape)
        {
            switch (pulsado.Key)
            {
                case ConsoleKey.RightArrow:
                    shai_hulud.direccion = Direccion.Este;
                    break;
                case ConsoleKey.LeftArrow:
                    shai_hulud.direccion = Direccion.Oeste;
                    break;
                case ConsoleKey.UpArrow:
                    shai_hulud.direccion = Direccion.Norte;
                    break;
                case ConsoleKey.DownArrow:
                    shai_hulud.direccion = Direccion.Sur;
                    break;
            }
            if (pulsado.Key == ConsoleKey.Spacebar)
                shai_hulud.Crecer();
            else
                shai_hulud.Avanzar();
        }
        Console.WriteLine("FIN");
    }
}