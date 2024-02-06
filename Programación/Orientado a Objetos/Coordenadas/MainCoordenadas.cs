public class MainCoordenadas
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
}