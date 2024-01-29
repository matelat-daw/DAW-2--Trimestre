public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Este Programa Crea una Estructura de Datos int, que Contendrá Coordenadas.\n");

        Punto p = new Punto(20, 20);
        ConsoleKeyInfo key;
        Console.WriteLine("Estás en las Coordenadas: X = {0}, Y =  {1}.\n", p.getX(), p.getY());
        Console.WriteLine("Puedes Desplazarte por el Tablero, los Límites son: el Mínimo para X e Y = 0, el Máximo = 120 y 25 Respectivamente.\n");
        Console.WriteLine("Usa las Flechas del Teclado para Moverte por el Tablero.");
        Console.WriteLine("Presiona la Flecha en la Dirección que Quieras Desplazarte, Presion ESC Para Salir.");
        Console.WriteLine("Presiona Cualquier Tecla Para Empezar.");
        Console.ReadKey();
        Console.Clear();
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
        }
    }

    public class Punto
    {
        private int x;
        private int y;
        private const int y_limit = 39;
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

        public Punto(){}

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
                draw();
            }
            else
            {
                y--;
                draw();
                
            }
        }

        public void abajo()
        {
            if (getY() == y_limit)
            {
                y = 0;
                draw();
            }
            else
            {
                y++;
                draw();
            }
        }

        public void izquierda()
        {
            if (getX() == 0)
            {
                x = x_limit;
                draw();
            }
            else
            {
                x--;
                draw();
            }
        }

        public void derecha()
        {
            if (getX() == x_limit)
            {
                x = 0;
                draw();
            }
            else
            {
                x++;
                draw();
            }
        }

        public void draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }
    }
}