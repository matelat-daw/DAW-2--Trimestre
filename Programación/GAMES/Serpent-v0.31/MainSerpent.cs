public class MainSerpent
{
    static void Main(string[] args)
    {
        int i; // Variable i se Usa para Crear en un Bucle las Coordenadas del Cuerpo de la Serpiente.
        Coords[] ring = new Coords[6]; // Tamaño del Cuerpo 6.
        LinkedList<Coords> body = new LinkedList<Coords>(); // Lista Enlazada de Coords (Coordenadas de la Clase Coords).

        Console.WriteLine("Juego de la Serpiente Version 0.31 - Con LinkingList<>. Presiona ESC para Salir en Cualquier Momento."); // Título.

        for (i = 0; i < ring.Length; i++) // Bucle al tamaño del Cuerpo de la Serpiente.
        {
            ring[i] = new (60 - i, 13); // Asigna a cada Parte del Cuerpo de la Serpiente una Nueva Coords (Coordenada), Desde 60 en X, 13 en Y hasta 55 en X y 13 en Y.
            body.AddLast(ring[i]); // Agrega cada Parte del Cuerpo de la Serpiente a la Lista Enlazada body.
        }
        Menu menu = new Menu();
        menu.show();
        Serpent serpent = new Serpent(body); // Crea un Objeto serpent Instanciando la Clase Serpent.
        serpent.show(); // Muestra serpent.
    }
}