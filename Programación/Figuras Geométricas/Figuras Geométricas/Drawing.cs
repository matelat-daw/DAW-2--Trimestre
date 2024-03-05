public class Drawing
{
    public static void ShowRectangle(double ancho, double alto) // Respeta las coordenadas del Punto para Mostrar el Rectángulo/Cuadrado en Pantalla.
    {
        int y = Console.CursorTop;
        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 0; i <= ancho; i++)
        {
            Console.SetCursorPosition(0 + i, y + 2);
            Console.Write("*");
            Console.SetCursorPosition(0 + i, y + (int)alto / 2 + 2);
            Console.Write("*");
        }

        for (int j = 0; j < alto / 2; j++)
        {
            Console.SetCursorPosition(0, y + j + 2);
            Console.Write("*");
            Console.SetCursorPosition((int)ancho, y + j + 2);
            Console.Write("*");
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\n");
    }

    public static void ShowTriangle(double altura)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Render(Draw(altura)); // Llama al Método Render que llama al Método Draw y le Pasa la Altura del Triángulo.
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void Render(char[,] map) // Chorizeado de Internet, recibe el Array Bidimensional map.
    {
        int width = map.GetLength(1); // El Ancho es el Tamaño del Array de las X.
        int height = map.GetLength(0); // El Alto es el Tamaño del Array de las Y.

        for (int i = 0; i < height; i++) // Hace un Bucle Desde 0 a la Altura.
        {
            if (i != 0) // Si i es Distinto de 0.
            {
                Console.WriteLine(); // Hace un Salto de Línea.
            }

            for (int j = 0; j < width; j++) // Hace un Bucle Desde 0 al Ancho.
            {
                char c = map[i, j]; // Asgina al char c el Caracter en el Array Bidimensional map en los índices i y j.
                Console.Write(c == '\0' ? ' ' : c); // Dibuja en Pantalla el Caracter c, si es NULL Dibuja un Espacio, si no Dibuja el Caracter Pasado Para Dibujar.
            }
        }
        Console.WriteLine(); // Hace un Salto de Línea
    }

    public static char[,] Draw(double height) // Chorizeado de Internet, Recibe el Caracter y la Altura.
    {
        char sym = '*';
        double width = height * 2.0 - 1; // El Ancho es igual al alto * 2 - 1.
        char[,] map = new char[(int)height, (int)width]; // Crea un Array Bidimensional de Caracteres Llamado map con la Altura y el Ancho.
        int x = (int)width - 1; // Asigna a x el Ancho - 1.
        int y = (int)height - 1; // Asigna a y el Alto - 1.

        for (int i = 0; i < height; i++) // Hace un Bucle Desde 0 a la Altura.
        {
            map[y, i * 2] = sym; // En el Array de char map Pone en y, i * 2 el Caracter a Dibujar.

            if (i != 0) // Si i es Distinto de 0.
            {
                map[y - i, i] = sym; // map de y - i, i = al Caracter a Dibujar.
                map[y - i, x - i] = sym; // en map de y - i, x - i = al Carater a Dibujar.
            }
        }
        return map; // Retorna el Array Bidimensional map.
    }

    public static void ShowCircle(int radio)
    {
        double thickness = 0.4; // Espesor del borde
        double rIn = radio - thickness, rOut = radio + thickness; // Al Borde del Radio Interno se le resta el Espesor y al Externo de le Suma.

        Console.ForegroundColor = ConsoleColor.Green; // Cambio el color del Pincel a Verde.
        for (double y = radio; y >= -radio; --y) // Bucle Desde el radio Hasta el radio Negativo Predecrementando Y, la Vertical.
        {
            for (double x = -radio; x < rOut; x += 0.5) // Bucle Desde el Radio Negativo Hasta el radio + el Espesor Post Incrementando X, la Horizontal en .5.
            {
                double value = x * x + y * y; // Asigno a la Variable value la Suma de X al Cuadrado + Y al Cuadrado.
                if (value >= rIn * rIn && value <= rOut * rOut) // Si value es Mayor o Igual que el Radio Interno al Cuadrado y value es Menor o Igual que el Radio Externo al Caudrado.
                {
                    Console.Write('*'); // Pinto el Asterisco, Cuerpo de la Circunferencia.
                }
                else // Si No.
                {
                    Console.Write(' '); // Pinto un Espacio.
                }
            }
            Console.WriteLine(); // Salto de Línea.
        }
        Console.ResetColor(); // Cambio el Color del Pincel a Gris, el Estandar de la Consola.
    }

    public static void ShowOctogon(int size, double apotema)
    {
        int y = Console.CursorTop;
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(20, y);
        Horizontal(size);
        Console.SetCursorPosition(20, y + size / 2 + (int)apotema);
        Horizontal(size);
        Vertical(size, apotema, y);
        Diagonal(size, apotema, y);
        Console.ResetColor();
    }

    private static void Diagonal(int size, double apotema, int y)
    {
        int j = 0;
        for (int i = 1; i <= size / 2 - 1; i++)
        {
            Console.SetCursorPosition(20 - (int)apotema - 1 + i + j, y + (int)apotema / 2 - i + 1);
            Console.Write('*');
            Console.SetCursorPosition(20 + size + i - 1 + j, y + size / 2 + (int)apotema - j);
            Console.Write('*');
            Console.SetCursorPosition(20 + size + i + j - 1, y + j);
            Console.Write('*');
            Console.SetCursorPosition(20 - (int)apotema - 1 + i + j, y + size + j - 1);
            Console.Write('*');
            j++;
        }
    }

    private static void Horizontal(int size)
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write('*');
        }
    }

    private static void Vertical(int size, double apotema, int y)
    {
        for (int i = 0; i < size / 2 + 1; i++)
        {
            Console.SetCursorPosition(20 - (int)apotema, y + i + (int)apotema / 2);
            Console.Write("*");
            Console.SetCursorPosition(20 + size + (int)apotema - 1, y + i + (int)apotema / 2);
            Console.Write("*");
        }
    }
}