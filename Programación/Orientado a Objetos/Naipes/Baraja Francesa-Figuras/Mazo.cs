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

    public void daCarta()
    {
        if (numCartas > 0)
        {
            int card = alea.Next(0, numCartas);
            int number = carta[card].getNumero();
            switch (carta[card].getPalo())
            {
                case Palo.Pica:
                    Console.ForegroundColor = ConsoleColor.Black;
                    showFormatedUp(number);
                    Figuras.pic();
                    showFormatedDown(number);
                    break;
                case Palo.Trebol:
                    Console.ForegroundColor = ConsoleColor.Black;
                    showFormatedUp(number);
                    Figuras.clover();
                    showFormatedDown(number);
                    break;
                case Palo.Diamante:
                    Console.ForegroundColor = ConsoleColor.Red;
                    showFormatedUp(number);
                    Figuras.diamond();
                    showFormatedDown(number);
                    break;
                case Palo.Corazon:
                    Console.ForegroundColor = ConsoleColor.Red;
                    showFormatedUp(number);
                    Figuras.heart();
                    showFormatedDown(number);
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

    public void show()
    {
        string cardNumber = "";
        Console.ForegroundColor = ConsoleColor.Black;
        for (int i = 0; i < numCartas; i++)
        {
            switch (carta[i].getNumero())
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
                    cardNumber = (carta[i].getNumero() + 1).ToString();
                    break;
            }
            Console.WriteLine("Carta: {0} de: {1}", cardNumber, carta[i].getPalo());
        }
    }

    private void showFormatedUp(int card)
    {
        Console.WriteLine(" __________________");
        if (card == 9)
        {
            Console.WriteLine("|                  |\n|{0}                |", card + 1);
        }
        else
        {
            bottomUp(card);
        }
    }

    private void showFormatedDown(int card)
    {
        if (card == 9)
        {
            Console.WriteLine("|                {0}|", card + 1);
        }
        else
        {
            bottomDown(card);
        }
        Console.WriteLine("|__________________|");
    }

    private void bottomUp(int card)
    {
        switch (card)
        {
            case 0:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[0]);
                break;
            case 10:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[1]);
                break;
            case 11:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[2]);
                break;
            case 12:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[3]);
                break;
            default:
                Console.WriteLine("|                  |\n|{0}                 |", card + 1);
                break;
        }
    }

    private void bottomDown(int card)
    {
        switch (card)
        {
            case 0:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[0]);
                break;
            case 10:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[1]);
                break;
            case 11:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[2]);
                break;
            case 12:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[3]);
                break;
            default:
                Console.WriteLine("|                {0} |", card + 1);
                break;
        }
    }
}