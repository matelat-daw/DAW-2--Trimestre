public class MainCarrera
{
    static void Main(string[] args)
    {
        bool result = false;
        int i;
        int x = 0;
        int y = 10;

        Console.WriteLine("Carrera de Puntos.");
        Carrera_de_Puntos[] cp = new Carrera_de_Puntos[4];
        for (i = 0; i < cp.Length; i++)
        {
            cp[i] = new Carrera_de_Puntos(x, y, (char)('A' + i));
            y += 2;
        }
        i = 0;
        Carrera_de_Puntos.fijar_meta(60);
        while (!cp[i].avanzar(7))
        {
            cp[i].avanzar(7);
            cp[i].mostrar();
            i++;
            if (i == cp.Length)
            {
                i = 0;
                Console.ReadKey();
                Console.Clear();
            }
        }
        cp[i].mostrar();
        Console.SetCursorPosition(20, 30);
        Console.WriteLine("Ha Ganado la Letra: {0}", (char)('A' + i));
    }
}