public class Root
{
    static void Main(string[] args)
    {
        Console.WriteLine("Este Programa Crea una Estructura de Datos int, que Contendrá Coordenadas.\n");
        Coordenada[] puntos = new Coordenada[3];
        for (int i = 0; i < puntos.Length; i++)
        {
            puntos[i] = new Coordenada();
        
            puntos[i].insert();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nLa Coordenada: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}", i + 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" es: X = ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("{0}", puntos[i].x);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" e Y = ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("{0}", puntos[i].y);
            Console.ForegroundColor= ConsoleColor.Gray;
        }
    }

    public class Coordenada()
    {
        public int x;
        public int y;

        public void insert()
        {
            Console.WriteLine();
            Console.Write("Ingresa la Primera Coordenada X: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Ingresa la Segundaa Coordenada Y: ");
            y = int.Parse(Console.ReadLine());
        }
    }
}