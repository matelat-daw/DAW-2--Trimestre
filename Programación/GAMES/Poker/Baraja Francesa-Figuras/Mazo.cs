public class Mazo
{
    private readonly int baraja = 0;
    private readonly int j = 0;
    private readonly Carta[] carta = new Carta[52];
    public static int numCartas = 52;
    private readonly Random alea = new();

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

    public void DaCarta()
    {
        if (numCartas > 0)
        {
            int card = alea.Next(0, numCartas);
            int number = carta[card].GetNumero();
            switch (carta[card].GetPalo())
            {
                case Palo.Pica:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Figuras.Pic(number);
                    break;
                case Palo.Trebol:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Figuras.Clover(number);
                    break;
                case Palo.Diamante:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Figuras.Diamond(number);
                    break;
                case Palo.Corazon:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Figuras.Heart(number);
                    break;
            }
            numCartas--;
            if (numCartas == 0)
            {
                Console.WriteLine("Esa Fue la Última Carta del Mazo.");
            }
            carta[card] = carta[numCartas];
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Ya Salió la Última Carta del Mazo, No Insistas.");
        }
    }

    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        for (int i = 0; i < numCartas; i++)
        {
            string cardNumber;
            switch (carta[i].GetNumero())
            {
                case 0:
                    cardNumber = Carta.nombreCarta[0];
                    break;
                case 10:
                    cardNumber = Carta.nombreCarta[1];
                    break;
                case 11:
                    cardNumber = Carta.nombreCarta[2];
                    break;
                case 12:
                    cardNumber = Carta.nombreCarta[3];
                    break;
                default:
                    cardNumber = (carta[i].GetNumero() + 1).ToString();
                    break;
            }
            Console.WriteLine("Carta: {0} de: {1}", cardNumber, carta[i].GetPalo());
        }
    }
}