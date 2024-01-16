namespace Arbol_de_Navidad
{
    public class Funciones
    {
        public static void drawTree(char brush, int height, int width)
        {
            int tmp = 3;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                 *                ");
            while (height > 0)
            {
                for (int i = 0; i < (width - tmp + 10) / 2; i++)
                {
                    Console.Write(" ");
                }
                for (int i = 0; i < tmp; i++)
                {
                    if (i == tmp - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('o');
                    }
                    else if (i == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('o');
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(brush);
                    }
                }
                for (int i = 0; i < (width - tmp + 10) / 2; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("\n");
                tmp += 2;
                height -= 3;
            }
            while (width > 0)
            { 
                for (int j = 0; j < 15; j++)
                {
                    Console.Write(" ");
                }
                for (int i = 0; i < 6; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write('|');
                }
                for (int j = 0; j < 15; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
                width -= 5;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}