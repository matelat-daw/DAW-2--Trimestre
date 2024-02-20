public class Triangulo
{
    private int ancho;
    private int altura;
    private Point vertice;

    public Triangulo (int x, int y, int ancho, int altura)
    {
        vertice = new Point();
        vertice.setX(x);
        vertice.setY(y);
        this.ancho = ancho;
        this.altura = altura;
    }

    public int getAncho()
    {
        return ancho;
    }

    public int getAlto()
    {
        return altura;
    }

    public int perimetro()
    {
        double hipo = Math.Sqrt(ancho * ancho + altura * altura);
        return (int)(hipo * 2 + ancho);
    }

    public int area()
    {
        return (ancho * altura) / 2;
    }

    public void mostrar()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Render(Draw('*', altura)); // Llama al Método Render que llama al Método Draw y le Pasa el Caracter a Dibujar y la Altura.
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public char[,] Draw(char sym, int height) // Chorizeado de Internet, Recibe el Caracter y la Altura.
    {
        int width = height * 2 - 1; // El Ancho es igual al alto * 2 - 1.
        char[,] map = new char[height, width]; // Crea un Array Bidimensional de Caracteres Llamado map con la Altura y el Ancho.
        int x = width - 1; // Asigna a x el Ancho - 1.
        int y = height - 1; // Asigna a y el Alto - 1.

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

    public void Render(char[,] map) // Chorizeado de Internet, recibe el Array Bidimensional map.
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
}