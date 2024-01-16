namespace Navidad
{
    internal class Funciones
    {
        internal static void drawTree(char brush, int heigth)
        {
            int width = heigth; // Igualo el Ancho con la Altura del Árbol, Tiene que ser Simétrico.
            int paint = 3; // Variable paint a 3, para que el Dibujo sea Simétrico, Pinto 3 Caracteres Debajo de la Estrella.

            for (int i = 0; i < width; i++) // Cantidad de Espacios que Necesito para Poner la Estrella del Árbol.
            {
                Console.Write(' '); // Dibujo los Espacio.
            }
            Console.ForegroundColor = ConsoleColor.White; // Cambio el Color del Caracter a Blanco.
            Console.Write("*\n"); // Pinto la Estrella y Hago un Salto de Línea.
            while (heigth > 0) // Mientras la Altura heigth no Sea 0.
            {
                for (int i = 0; i < heigth - 1; i++) // Hago un Bucle hasta la Altura que se Irá Decrementando - 1.
                {
                    Console.Write(' '); // Pinto Espacios.
                }
                for (int i = 0; i < paint; i++) // Hago el Bucle que Pintará el Árbol Hasta paint que se Irá Incrementando.
                {
                    if (i == 0 || i == paint - 1) // Cuando i es 0, el Primer Caracter de la Fila ó i es el Último Caracter de la Fila del Árbol.
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // Lo pongo de Color Amarillo.
                        Console.Write('O'); // Lo Dibujo en Forma de Bola de Árbol.
                    }
                    else if (i == paint / 2) // Si i toma el Valor de la Mitad de paint.
                    {
                        if (heigth % 2 == 0) // Si es una Fila Par.
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // Lo pongo de Color Rojo.
                            Console.Write('|'); // Dibujo el Caracter Pasado para Dibujar el Árbol.
                        }
                        else // Si No, Fila Impar.
                        {
                            Console.ForegroundColor = ConsoleColor.Blue; // Lo pongo de Color Azul.
                            Console.Write('|'); // Dibujo el Caracter Pasado para Dibujar el Árbol.
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Lo pongo de Color Verde.
                        Console.Write(brush); // Dibujo el Caracter Pasado para Dibujar el Árbol.
                    }
                }
                Console.WriteLine(); // Salto de Línea.
                paint += 2; // Incremento paint en 2, Primero es 3, Después 5, 7, 9, etc.
                heigth--; // Decremento heigth.
            }
            paint = 3; // Paint Recupera su Valor Original.
            while (paint > 0) // Mientras paint sea Mayor que 0.
            {
                for (int i = 0; i < width - 2; i++) // Hago el Bucle para Poner los Espacios, para Empezar a Pintar el Tronco.
                {
                    Console.Write(' '); // Pinto los Espacios.
                }
                for (int i = 0; i < 5; i++) // Hago el Bucle al Ancho del Tronco.
                {
                    Console.Write('|'); // Pinto la Barra Vertical, Tronco.
                }
                Console.WriteLine(); // Salto de Línea.
                paint --; // Decremento paint.
            }
            Console.ForegroundColor = ConsoleColor.Gray; // Cambio el Color de los Caracteres a su Color Original, Gris.
        }
    }
}