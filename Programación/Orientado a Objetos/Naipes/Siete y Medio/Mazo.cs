public class Mazo
{
    private int baraja = 0;
    private int j = 0;
    public static int numCartas = 40;
    private Carta[] carta = new Carta[numCartas];
    private Random alea = new Random();
    private double player_score = 0.0;
    private double bank_score = 0.0;

    public Mazo()
    {
        while (baraja < 4)
        {
            for (int i = 0; i < 10; i++)
            {
                carta[i + j] = new Carta(i, Palo.Oro + baraja);
            }
            j += 10;
            baraja++;
        }
    }

    public double GetPlayer()
    {
        return AskPlayer();
    }

    public double GetBank()
    {
        return AskBank();
    }

    public Carta DaCarta() // Función que Retorna la Carta que se Selecciona Aleatoriamente. El switch lo Puse Yo Porque me Gusta, Pero no lo Pide.
    {
        Carta aux = null; // carta Auxiliar que Contendrá los Datos del Objeto Carta que se Obtiene con el Número Aleatorio.

        if (numCartas > 0) // Si la Cantidad de Cartas es Mayor que 0.
        {
            int card = alea.Next(numCartas); // Obtengo un Número Aleatorio entre 0 y en Número de Cartas Disponible.
            aux = new Carta(carta[card].getNumero(), carta[card].getPalo()); // Asigno a aux la Carta Actual.
            carta[card] = carta[numCartas - 1]; // Cargo en la posición de la Carta Actual la Última Carta del Array de Cratas.
            numCartas--; // Decremento la Cantidad de Carta Disponibles.
        }
        return aux; // Retorno la Carta Aux, la Carta Actual.
    }

    public double AskPlayer()
    {
        int player_card = DaCarta().getNumero() + 1;
        double real_value = 0.0;

        if (player_card > 7)
        {
            real_value = .5;
        }
        else
        {
            real_value = (double)player_card;
        }
        player_score += real_value;
        Console.WriteLine($"Tienes: {player_score} Puntos.");
        Console.Write("Quieres Otra Carta: s Para Otra Carta, Enter Para Plantarte.");
        string response = Console.ReadLine().ToLower();
        if (response == "s")
        {
            AskPlayer();
        }
        return player_score;
    }

    public double AskBank()
    {
        int bank_card = DaCarta().getNumero() + 1;
        double real_value = 0.0;

        if (bank_card > 7)
        {
            real_value = .5;
        }
        else
        {
            real_value = (double)bank_card;
        }
        bank_score += real_value;
        Console.WriteLine("La Banca Tiene: {0}", bank_score);

        if (bank_score < 5)
        {
            AskBank();
        }
        return bank_score;
    }
}