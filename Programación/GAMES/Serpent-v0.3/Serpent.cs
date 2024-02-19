using System.Media;

public class Serpent // Clase Serpent, Usa Muchas variables de la Clase y de otras Clases que se Consiguen con los Getter de esas Clases y la Variable is_food de tipo bool static, Tiene que ser static Para que Cuando el Jugador Pierde el Juego y Vuelve a Empezar No Muestre la Comida dos Veces en la Pantalla.
{
    private int i;
    private const int XSNAKE = 60;
    private int x = XSNAKE;
    private const int YSNAKE = 13;
    private int y = YSNAKE;
    private int life = 3;
    private int score = 0;
    private const int XSTART = 19;
    private const int XEND = 101;
    private const int YSTART = 4;
    private const int YEND = 31;
    private LinkedList<Coords> body = new LinkedList<Coords>();
    private Direction direction;
    private Coords aux;
    private Food food;
    private SoundPlayer sound;
    private bool start_sound = true;
    private bool game_over = false;
    private bool change = false;
    private static bool is_food = false;

    public Serpent(LinkedList<Coords> body) // Constructor de la Clase Serpent, Recibe por Parametro body, el Cuerpo de la Serpiente.
    {
        this.body = body;
        this.direction = Direction.East; // Asigna a direccion la Direction East, va Hacia la Derecha.
        if (!is_food) // La Variable bool is_food está a false, Entra en la Condición.
        {
            is_food = true; // Se Pone a true y al Ser static Mantandrá Siempre ese Valor a Menos que se le Asigne Otro. Si no se Declara static, al Perder el Juego y Volver a Instanciar la Clase Serpent (Se Crea una Serpiente Nueva) la Variable se Pondría a false y Mostraría 2 Food en la Pantalla.
            food = new Food(); // Crea un Nuevo Objeto Food.
            showFood(); // Muestra el Objeto Food en la Pantalla.
        }
        showFrame(); // Muestra el Tablero de Juego, el Marco.
    }

    private void showFrame() // Método que Muestra el Marco del Tablero de Juego.
    {
        Console.ForegroundColor = ConsoleColor.Blue; // Pone el Color de la Fuente Azul.
        for (int i = XSTART - 1; i <= XEND + 1; i++) // Bucle Desde el Borde XSTART menos 1 al Borde XEND + 1.
        {
            Console.SetCursorPosition(i, YSTART - 1); // Pongo en Cursor en la Posición Donde Quiero Imprimir en la Pantalla.
            Console.Write('-'); // Imprimo el Caracter -.
            Console.SetCursorPosition(i, YEND + 1); // Pongo en Cursor en la Posición Donde Quiero Imprimir en la Pantalla.
            Console.Write('_'); // Imprimo el Caracter -.
        }

        for (int i = YSTART - 1; i <= YEND + 1; i++) // Bucle Desde el Borde YSTART menos 1 al Borde YEND + 1.
        {
            Console.SetCursorPosition(XSTART - 1, i); // Pongo en Cursor en la Posición Donde Quiero Imprimir en la Pantalla.
            Console.Write('|'); // Imprimo el Caracter |.
            Console.SetCursorPosition(XEND + 1, i); // Pongo en Cursor en la Posición Donde Quiero Imprimir en la Pantalla.
            Console.Write('|'); // Imprimo el Caracter |.
        }
    }

    private void showFood() // Método que Muestra la Comida (Food) en la Pantalla.
    {
        Console.SetCursorPosition(food.getx_food, food.gety_food); // Pongo en Cursor en las Coordenadas X e Y de Food.
        Console.ForegroundColor = ConsoleColor.Red; // Cambio la Fuente a Color Rojo.
        Console.Write('Ò'); // Muerstro la Ò Acentuada con el Acento Invertido (Simbolo de Appletiser).
    }

    public void show() // Metodo show de la Clase Serpent.
    {
        if (!game_over) // Si No Ha Terminado el Juego, game_over esta a false.
        {
            if (start_sound)
            {
                sound = new SoundPlayer(Environment.CurrentDirectory + "/audio/start.wav");
                sound.Play();
                start_sound = false;
                Thread.Sleep(4000);
            }

            Console.SetCursorPosition(20, 2); // Posiciono el Cursor.
            Console.Write("Vidas: {0}", life); // Muestro la Palabra Vidas: y la Cantidad de Vidas Disponible.
            Console.SetCursorPosition(60, 2); // Posiciono el Cursor.
            Console.Write("Puntos: {0}", score); // Muestro la Palabra Puntos: y Los Puntos que se van Acumulando.
            Console.CursorVisible = false; // Escondo el Cursor.
            for (i = 0; i < body.Count; i++) // Hago un Bucle al Tamaño del cuerpo de serpent, body.
            {
                Console.SetCursorPosition(body.ElementAt(i).xValue, body.ElementAt(i).yValue); // Posiciono el Cursor en las Coordenadas de Cada Parte de la Serpiente.
                if (i == 0) // Si estoy en la primera Posición (la 0), Muestro la Cabeza.
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Fuente Color Verde.
                    Console.Write("@"); // Muestro la Cabeza (@).
                }
                else // Si ya no Estoy Mostrando la Primera Posición Muestro el Cuerpo (*).
                {
                    Console.ForegroundColor = ConsoleColor.White; // Fuente Color Blanco.
                    Console.Write("*"); // Muestro el cuerpo (*).
                }
                if (!change) // Si no Cambio de Dirección, bool change está a false.
                {
                    Console.SetCursorPosition(body.Last.Value.xValue, body.Last.Value.yValue); // Posiciono el Cursor en la Última Posición del Cuerpo de la Serpiente.
                    Console.Write(' '); // Muestro un Espacio.
                }
                else // Si se Cambió de Dirección el bool change paso a true.
                {
                    switch (direction) // Cambio Según la Dirección.
                    {
                        case Direction.North: // Si Voy a North, Subiendo.
                            Console.SetCursorPosition(body.Last.Value.xValue, body.Last.Value.yValue + 1); // Posiciono el Cursor en la Coordenada del Último Anillo de la Serpiente.
                            Console.Write(' '); // Muestro un Espacio.
                            Console.SetCursorPosition(body.Last.Value.xValue, body.Last.Value.yValue + 2); // Posiciono el Cursor en la Coordenada del Último Anillo de la Serpiente + 1, Esto es Para Cuando se Cambia de Limite Máximo a Mínimo, Horizontal o Vertical.
                            Console.Write(' '); // Muestro un Espacio.
                            change = false; // Pongo el bool change a false.
                            break;
                        case Direction.South:
                            Console.SetCursorPosition(body.Last.Value.xValue, body.Last.Value.yValue - 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(body.Last.Value.xValue, body.Last.Value.yValue - 2);
                            Console.Write(' ');
                            change = false;
                            break;
                        case Direction.East:
                            Console.SetCursorPosition(body.Last.Value.xValue - 1, body.Last.Value.yValue);
                            Console.Write(' ');
                            Console.SetCursorPosition(body.Last.Value.xValue - 2, body.Last.Value.yValue);
                            Console.Write(' ');
                            change = false;
                            break;
                        case Direction.West:
                            Console.SetCursorPosition(body.Last.Value.xValue + 1, body.Last.Value.yValue);
                            Console.Write(' ');
                            Console.SetCursorPosition(body.Last.Value.xValue + 2, body.Last.Value.yValue);
                            Console.Write(' ');
                            change = false;
                            break;
                    }
                }
            }
        }
        else // Si game_over está a true.
        {
            gameOver(); // Llama al Método gameOver().
        }

        for (i = 1; i < body.Count; i++) // Bucle al Tamaño del Cuerpo de la Serpiente, Verifica si la Serpiente se Muerde a si Misma.
        {
            if (body.First.Value.xValue == body.ElementAt(i).xValue && body.First.Value.yValue == body.ElementAt(i).yValue) // Si Choca.
            {
                life--; // Descuenta una vida.
                if (life < 0) // Si life es < 0
                {
                    game_over = true; // Pone game_over a true.
                }
                else // Si No.
                {
                    clean(); // Llama al Metodo clean();
                }
            }
        }

        if (body.First.Value.xValue == food.getx_food && body.First.Value.yValue == food.gety_food) // Si la Cabeza de la Serpiente paso por las Coordenadas de Food, la Comida.
        {
            sound = new SoundPlayer(Environment.CurrentDirectory + "/audio/eat.wav");
            sound.Play();
            score += 10; // Incremento el score.
            if (score % 100 == 0) // Verifico si el Puntaje es Múltiplo de 100, Cada 100 Puntos Ganas una Vida.
            {
                life++; // Si Es, Ganas una Vida, Incremento life.
            }
            food = new Food(); // Creo un Nuevo Objeto Food.
            showFood(); // Lo Muestro.
            aux = new(body.ElementAt(body.Count - 1).xValue, body.ElementAt(body.Count - 1).yValue); // En la Coordenada aux Creo un Nuevo Elemento Coords con la Posición del Último Anillo de la Serpiente.
            body.AddLast(aux); // Lo Agrego al Final del Cuerpo de la Serpiente.
        }
    }

    public void move() // Método que Mueve la Serpiente.
    {
        switch (Console.ReadKey(true).Key) // Cambio a la Tecla que esté Disponible en el Teclado, Si No Se Preciona Ninguna Tecla no se Mueve.
        {
            case ConsoleKey.UpArrow: // Si Se Presionó la Flecha Hacia Arriba.
                if (direction != Direction.South) // Si la Dirección no Es la Contraria.
                {
                    direction = Direction.North; // Cambio a la Dirección North (Arriba).
                    aux = new(body.ElementAt(0).xValue, body.ElementAt(0).yValue - 1); // Creo un Nuevo Anillo del Cuerpo de la Serpiente en las Coordenadas X e Y - 1.
                    body.AddFirst(aux); // Lo Agrego al Principio de la Lista Enlazada, Primera Posición del Cuerpo (body) de la Serpiente.
                    body.RemoveLast(); // Quito el Último Elemento del Cuerpo de la Serpiente.
                }
                break;
            case ConsoleKey.DownArrow:
                if (direction != Direction.North)
                {
                    direction = Direction.South;
                    aux = new(body.ElementAt(0).xValue, body.ElementAt(0).yValue + 1);
                    body.AddFirst(aux);
                    body.RemoveLast();
                }
                break;
            case ConsoleKey.LeftArrow:
                if (direction != Direction.East)
                {
                    direction = Direction.West;
                    aux = new(body.ElementAt(0).xValue - 1, body.ElementAt(0).yValue);
                    body.AddFirst(aux);
                    body.RemoveLast();
                }
                break;
            case ConsoleKey.RightArrow:
                if (direction != Direction.West)
                {
                    direction = Direction.East;
                    aux = new(body.ElementAt(0).xValue + 1, body.ElementAt(0).yValue);
                    body.AddFirst(aux);
                    body.RemoveLast();
                }
                break;
            case ConsoleKey.Escape: // Si se Presiona ESC.
                Console.SetCursorPosition(0, 33); // Posiciono el Cursor Debajo del Tablero.
                Environment.Exit(0); // Termino el Programa a la Fuerza.
                break;
        }

        if (body.ElementAt(0).xValue == XEND) // Si la Cabeza de la Serpeinte llegó al Final de la Pantalla en el Eje X
        {
            x = XSTART + 1; // Cambio la posición del la Cabeza al Comienzo de la Pnatalla + 1.
            aux = new(x, body.ElementAt(0).yValue); // Creo la Nueva Coordenada.
            same(); // Llamo al Método same().
        }
        if (body.ElementAt(0).xValue == XSTART)
        {
            x = XEND - 1;
            aux = new(x, body.ElementAt(0).yValue);
            same();
        }
        if (body.ElementAt(0).yValue == YEND)
        {
            y = YSTART + 1;
            aux = new(body.ElementAt(0).xValue, y);
            same();
        }
        if (body.ElementAt(0).yValue == YSTART)
        {
            y = YEND - 1;
            aux = new(body.ElementAt(0).xValue, y);
            same();
        }
        show();
        move();
    }

    private void same() // Ese Método Agrega al body el nuevo Anillo de la Serpiente.
    {
        body.AddFirst(aux); // Agrega la Nueva Coordenada en la Primera Posición del Cuerpo de la Serpiente
        body.RemoveLast(); // Quita el Último Elemento del Cuerpo de la Serpiente.
        change = true; // Pongo el bool change a true, ya que al Pasar del Fondo de la Pantalla al Principìo hay que Quitar un Anillo más.
    }

    private void clean() // Este Método se Usa Cuando La Serpiente se Muerde a si Misma.
    {
        cleanCorpse(); // Llama al Método cleanCorpse() que Limpia los Restos de la Serpiente Muerta.
        Console.SetCursorPosition(40, 15); // Posiciono el Cursor en las cooredenadas X = 40 e Y = 15.
        Console.ForegroundColor = ConsoleColor.White; // Color de la Fuente Blanca.
        Console.WriteLine("Has Perdido una Vida, Presiona Cualquier Tecla Para Continuar."); // Muestro el Mensaje en la Pantalla.
        Console.ReadKey(); // Espera la Pusación de una Tecla.
        Console.SetCursorPosition(40, 15); // Posiciono el Cursor en las coordenadas X = 40 e Y = 15.
        Console.WriteLine("                                                              "); // Muestro el Mensaje en Pantalla.
        for (i = 0; i < body.Count; i++) // Bucle al Tamaño del Cuerpo de la Serpiente.
        {
            aux = new(XSNAKE + 1 - body.Count + i, YSNAKE); // Creo los Nuevo Anillos de la Serpiente en las Coordenadas de Origen.
            body.RemoveLast(); // Remuevo el Último Anillo del Cuerpo.
            body.AddFirst(aux); // Agrego a la Primera Posición el Nuevo Anillo en la Coordenada Original, de Esta Manera el Tamaño de la Serpiente no cambia.
        }
        direction = Direction.East; // Defino la direction Como la del Inicio del Juego, Hacia el East.
        show(); // Lo Muestro.
    }

    private void cleanCorpse() // Método que Limpia los Restos de la Serpiente Muerta.
    {
        for (i = 0; i < body.Count; i++) // Bucle al Tamaño del Cuerpo de la Serpiente.
        {
            Console.SetCursorPosition(body.ElementAt(i).xValue, body.ElementAt(i).yValue); // Posiciono el Cursor en las Coordenadas de la Serpiente.
            Console.Write(' '); // Muestro un Espacio en Blanco.
        }
    }

    private void gameOver() // Método que se Llama Si Perdí Todas Las Vidas.
    {
        cleanCorpse(); // Limpio los restos de la Serpiente Muerta.
        life = 3; // Vuelvo a Poner las Vidas a 3.
        score = 0; // El Score a 0.
        game_over = false; // game_over a false.

        sound = new SoundPlayer(Environment.CurrentDirectory + "/audio/dead.wav");
        sound.Play();

        Console.SetCursorPosition(33, 15); // Posiciono el Cursor en las Coordenadas X = 33 e Y = 15.
        Console.ForegroundColor = ConsoleColor.White; // Color de la Fuente Blanco.
        Console.WriteLine("Has Perdido el Juego, Presiona Cualquier Tecla Para Empezar de Nuevo."); // Muestro el Mensaje en Pantalla.
        Console.ReadKey(); // Espera la Presión de una Tecla.

        Console.SetCursorPosition(68, 2); // Posiciono el Cursor en X = 68 e Y = 2, Para Borrar el Score.
        Console.Write("     "); // Limpio el Score con 5 Espacios, Habría que Comer 1000 Manzanas Para Llegar a 5 Cifras y 10000 para 6 cifras.

        Console.SetCursorPosition(33, 15); // Posiciono el Cursor en X = 33 e Y = 15 Para Borrar el Mensaje Has Perdido.
        Console.WriteLine("                                                                     "); // Muestro Espacios.
        Coords[] ring = new Coords[6]; // Creo una Nueva Instancia de la Clase Coords de Nombre ring, un Array con 6 Coordenadas.
        body = new LinkedList<Coords>(); // Creo un Nuevo body, una Nueva Lista Enlazada de Coords.
        Serpent serpent = null; // Declaro e Inicializo una Nueva serpent a null.

        for (i = 0; i < ring.Length; i++) // Bucle al Tamaño del array de Coords ring.
        {
            ring[i] = new(XSNAKE - i, YSNAKE); // Asigno al Array de Coords ring[i] en cada indice de la variable i del bucle Las Coordenadas Originales de la Serpiente XSNAKE e YSNAKE.
            body.AddLast(ring[i]); // Agrego a body las Cooredenadas en ring[i].
        }
        serpent = new Serpent(body); // Creo un nuevo Objeto serpent con el Cuerpo Recién Creado.
        direction = Direction.East; // Asigno a direction la Dirección East, ir Hacia la Derecha.
        show(); // Lo Muestro en Pantalla y Comienza un Nuevo Juego.
    }
}