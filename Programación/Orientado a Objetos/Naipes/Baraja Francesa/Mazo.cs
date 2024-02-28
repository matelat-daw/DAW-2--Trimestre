public class Mazo
{
    private int baraja = 0;
    private int j = 0;
    private Carta[] carta = new Carta[52];
    public static int numCartas = 52;
    private Random alea = new Random();

    public Mazo()
    {
        while (baraja < 4)
        {
            for (int i = 0; i < 13; i++)
            {
                carta[i + j] = new Carta(i, Palo.Pica + baraja);
            }
            j += 13;
            baraja++;
        }
    }

    public Carta daCarta() // Función que Retorna la Carta que se Selecciona Aleatoriamente. El switch lo Puse Yo Porque me Gusta, Pero no lo Pide.
    {
        Carta aux = null; // carta Auxiliar que Contendrá los Datos del Objeto Carta que se Obtiene con el Número Aleatorio.

        if (numCartas > 0) // Si la Cantidad de Cartas es Mayor que 0.
        {
            int card = alea.Next(numCartas); // Obtengo un Número Aleatorio entre 0 y en Número de Cartas Disponible.
            switch (carta[card].getPalo()) // Hago un Switch al Palo de la Carta para Cambiar el Color de la Fuente.
            {
                case Palo.Pica: // Si es Pica.
                case Palo.Trebol: // Si es Trébol.
                    Console.ForegroundColor = ConsoleColor.Black; // Color Negro.
                    break;
                case Palo.Diamante: // Si es Diamante.
                case Palo.Corazon: // Si es Coraazón
                    Console.ForegroundColor = ConsoleColor.Red; // Color Rojo.
                    break;
            }
            aux = new Carta(carta[card].getNumero(), carta[card].getPalo()); // Asigno a aux la Carta Actual.
            carta[card] = carta[numCartas - 1]; // Cargo en la posición de la Carta Actual la Última Carta del Array de Cratas.
            numCartas--; // Decremento la Cantidad de Carta Disponibles.
        }
        return aux; // Retorno la Carta Aux, la Carta Actual.
    }

    public void show() // Muestra las Cartas que Hay en el Array de Catas. OJO esta Función no la Pide.
    {
        Console.ForegroundColor = ConsoleColor.Black; // Color de la Fuente Negro.
        for (int i = 0; i < numCartas; i++) // Bucle hasta el Número de Cartas.
        {
            Console.WriteLine("Carta: {0}", carta[i].ToString()); // Las Muestra en Pantalla.
        }
    }
}