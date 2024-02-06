public class MainCarrera
{
    static void Main(string[] args)
    {
        int i;
        int x = 0;
        int y = 10;
        const int POWER = 7;

        Console.WriteLine("Carrera de Puntos.");
        Carrera_de_Puntos[] cp = new Carrera_de_Puntos[4];
        for (i = 0; i < cp.Length; i++)
        {
            cp[i] = new Carrera_de_Puntos(x, y, (char)('A' + i));
            y += 2;
            cp[i].mostrar();
        }
        Carrera_de_Puntos.fijar_meta(60);
        Console.SetCursorPosition(20, 18);
        Console.Write("Presiona Cualquier Tecla Para Comenzar la Carrera.");
        Console.ReadKey();
        i = 0;
        while (!cp[i].avanzar(POWER))
        {
            cp[i].mostrar();
            i++;
            if (i == cp.Length)
            {
                i = 0;
                Console.ReadKey();
            }
        }
        cp[i].mostrar();
        Console.SetCursorPosition(20, 20);
        Console.WriteLine("Ha Ganado la Letra: {0}", (char)('A' + i));
    }
}