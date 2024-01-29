public class Root
{
    static void Main(string[] args)
    {
        Console.WriteLine("Este Programa Crea una Estructura de Datos int, que Contendrá Coordenadas.\n");
        /* Coordenada[] puntos = new Coordenada[3];
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
            Console.ForegroundColor = ConsoleColor.Gray;
        } */
        Punto p = new Punto(20, 20);
        ConsoleKeyInfo key;
        Console.WriteLine("Estás en las Coordenadas: X = {0}, Y =  {1}.\n", p.getX(), p.getY());
        Console.WriteLine("Puedes Desplazarte por el Tablero, los Límites son: el Mínimo para X e Y = 0, el Máximo = 120 y 25 Respectivamente.\n");
        Console.WriteLine("Usa las Flechas del Teclado para Moverte por el Tablero.");
        Console.Write("Presiona la Flecha en la Dirección que Quieras Desplazarte: ");
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Escape)
        {
            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    p.derecha();
                    break;
                case ConsoleKey.LeftArrow:
                    p.izquierda();
                    break;
                case ConsoleKey.UpArrow:
                    p.arriba();
                    break;
                case ConsoleKey.DownArrow:
                    p.abajo();
                    break;

            }
            Console.WriteLine("Estás en las Coordenadas: X = {0}, Y =  {1}.\n", p.getX(), p.getY());
        }
    }

    /* public class Coordenada()
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
    } */

    public class Punto
    {
        private int x;
        private int y;
        private const int y_limit = 25;
        private const int x_limit = 119;

        public Punto(int x, int y)
        {
            if (x < 0 || x > x_limit || y < 0 || y > y_limit)
            {
                throw new Exception();
            }
            this.x = x;
            this.y = y;
        }

        public Punto()
        {

        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void setX(int x)
        {
            if (x >= 0 && x <= x_limit)
                this.x = x;
        }

        public void setY(int y)
        {
            if (y >= 0 && y <= y_limit)
                this.y = y;
        }

        public void arriba()
        {
            if (getY() == 0)
            {
                y = y_limit;
            }
            else
            {
                y--;
            }
        }

        public void abajo()
        {
            if (getY() == y_limit)
            {
                y = 0;
            }
            else
            {
                y++;
            }
        }

        public void izquierda()
        {
            if (getX() == 0)
            {
                x = x_limit;
            }
            else
            {
                x--;
            }
        }

        public void derecha()
        {
            if (getX() == x_limit)
            {
                x = 0;
            }
            else
            {
                x++;
            }
        }
    }
}