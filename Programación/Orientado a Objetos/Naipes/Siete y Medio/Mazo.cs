namespace Naipes;

public class Mazo
{
    private int baraja = 0;
    private int j = 0;
    public static int numCartas = 40;
    private static Carta[] carta = new Carta[numCartas];
    private static Random alea = new Random();

    public Mazo()
    {
        while (baraja < 4)
        {
            for (int i = 0; i < 10; i++)
            {
                carta[i + j] = new Carta(i + 1, Palo.Oro + baraja);
            }
            j += 10;
            baraja++;
        }
    }

    public void Baraja()
    {
        Mazo mazo = new();
    }

    public static Carta DaCarta() // Función que Retorna la Carta que se Selecciona Aleatoriamente. El switch lo Puse Yo Porque me Gusta, Pero no lo Pide.
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
}