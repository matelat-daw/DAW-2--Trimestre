namespace Batalla_Naval_2
{
    internal class Funciones
    {
        const int SIZE = 10;
        const char AGUA = '~';
        const char BARCO1 = 'H';
        const char BARCO2 = 'A';
        const char DISPARADO = '*';
        const char TOCADO = '#';
        public static int[] counter = new int[2];
        static char[,] water = new char[SIZE, SIZE];
        static char[,] tablero = new char[SIZE, SIZE];
        static bool hundido1;
        static bool hundido2;

        internal static void disparo(string coord)
        {
            extraerCoordenada(coord, out int row, out int col);
            char result; // Se Usa Para Asignarle el Caracter Actual en el Tablero.
            if (tablero[row, col] == AGUA)
            {
                water[row, col] = DISPARADO;
                tablero[row, col] = DISPARADO;
                result = AGUA;
            }
            else if (tablero[row, col] == DISPARADO || tablero[row, col] == TOCADO)
            {
                result = DISPARADO;
            }
            else
            {
                water[row, col] = TOCADO;
                result = TOCADO;
            }
            switch (result) // Salta al Caracter que Estaba en el Tablero.
            {
                case AGUA: // Si Era Agua
                    Console.WriteLine("Agua.\n Presiona ENTER para Continuar.");
                    Console.ReadKey();
                    break;
                case TOCADO: // Si tocaste un Barco.
                    Console.WriteLine("Tocado.\n");
                    Funciones.checkGame(coord);
                    if (Funciones.counter[0] > 0)
                    {
                        if (Funciones.counter[0] > 1)
                        {
                            Console.WriteLine("Has tocado el Barco Grande: {0} Veces.", Funciones.counter[0]);
                        }
                        else
                        {
                            Console.WriteLine("Has tocado el Barco Grande: {0} Vez.", Funciones.counter[0]);
                        }
                    }
                    if (Funciones.counter[1] > 0)
                    {
                        if (Funciones.counter[1] > 1)
                        {
                            Console.WriteLine("Has tocado el Barco Mediano: {0} Veces.", Funciones.counter[1]);
                        }
                        else
                        {
                            Console.WriteLine("Has tocado el Barco Mediano: {0} Vez.", Funciones.counter[1]);
                        }
                    }
                    Console.WriteLine("Presiona ENTER para Continuar.");
                    Console.ReadKey();
                    break;
                default: // Disaro Repetido.
                    Console.WriteLine("Revisa tus Dioptrías, ya Habías Disparado Ahí, Tiro Repetido.\n Presiona ENTER para Continuar.");
                    Console.ReadKey();
                    break;
            }
        }
		
		private static void extraerCoordenada(string coord, out int row, out int col)
        {
            int index = 0;
            string letra;
            string letras = "ABCDEFGHIJ";
            letra = coord.Substring(0, 1); // Obtiene la Letra de la string coord, que llega por copia (parametro por copia).
            while (index < letras.Length && letra != letras[index].ToString()) // Mientas la Letra no esté en la string letras.
            {
                index++; // Incrementa index.
            }
            col = index; // Asigna el valor de index a la variable de salida(out) col.
            row = Convert.ToByte(coord.Substring(1)) - 1; // Obtiene el valor númerico de la string coord, le resta 1, lo convierte a Byte y lo asigna a la variable de salida(out) row.
        }

        internal static void showTablero(bool which)
        {
            int row;
            int col;

            Console.Clear();
            Console.Write("    ");
            for (row = 0; row < water.GetLength(0); row++)
            {
                Console.Write("{0, 4}", Convert.ToChar('A' + row));
            }
            Console.WriteLine();
            for (row = 0; row < water.GetLength(0); row++)
            {
                Console.Write("{0, 4}", (row + 1));
                for (col = 0; col < water.GetLength(1); col++)
                {
                    if (which)
                    {
                        Console.Write("{0, 4}", tablero[row, col]);
                    }
                    else
                    {
                        if (water[row, col] == TOCADO)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0, 4}", water[row, col]);
                        }
                        else if (water[row, col] == AGUA)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("{0, 4}", water[row, col]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("{0, 4}", water[row, col]);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine();
            }
        }

        internal static void fillTablero()
        { 
            int row;
            int col;
            int hor;
            int ver;
            int aircc;
            int trana;
            Random random = new Random();

            for (row = 0; row < SIZE; row++)
            {
                for (col = 0; col < SIZE; col++)
                {
                    tablero[row, col] = AGUA;
                    water[row, col] = AGUA;
                }
            }

            hor = random.Next(0, 3);
            ver = random.Next(0, 5);

            for (aircc = 0; aircc < 4; aircc++)
            {
                tablero[hor, ver + aircc] = BARCO1;
            }

            hor = random.Next(5, 8);
            ver = random.Next(5, 10);

            for (trana = 0; trana < 3; trana++)
            {
                tablero[hor + trana, ver] = BARCO2;
            }
        }

        internal static void checkGame(string coord)
        {
            extraerCoordenada(coord, out int row, out int col);

            if (water[row, col] == TOCADO && tablero[row, col] == BARCO1)
            {
                tablero[row, col] = TOCADO;
                counter[0]++;
                if (counter[0] == 4)
                    hundido1 = true;
            }

            if (water[row, col] == TOCADO && tablero[row, col] == BARCO2)
            {
                tablero[row, col] = TOCADO;
                counter[1]++;
                if (counter[1] == 3)
                    hundido2 = true;
            }

            if (hundido1 && hundido2)
            {
                Console.WriteLine("Has Ganado, Has Hundido la Flota.\n");
                Console.WriteLine("Presiona Enter Para Volver al Menú Pricipal.\n");
                Console.ReadKey();
                showTablero(false);
                reset();
            }
        }

        private static void reset()
        {
            fillTablero();
            hundido1 = false;
            hundido2 = false;
            counter[0] = 0;
            counter[1] = 0;
        }
    }
}