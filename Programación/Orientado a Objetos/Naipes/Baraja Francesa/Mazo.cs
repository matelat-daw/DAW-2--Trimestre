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

    public Carta daCarta()
    {
        int card = alea.Next(numCartas);
        int number = carta[card].getNumero();
        switch (carta[card].getPalo())
        {
            case Palo.Pica:
                Console.ForegroundColor = ConsoleColor.Black;
                //showFormatedUp(number);
                //Figuras.pic();
                //showFormatedDown(number);
                // Console.WriteLine("{0}", carta[number].ToString());
                break;
            case Palo.Trebol:
                Console.ForegroundColor = ConsoleColor.Black;
                //showFormatedUp(number);
                //Figuras.clover();
                //showFormatedDown(number);
                // Console.WriteLine("{0}", carta[number].ToString());
                break;
            case Palo.Diamante:
                Console.ForegroundColor = ConsoleColor.Red;
                //showFormatedUp(number);
                //Figuras.diamond();
                //showFormatedDown(number);
                // Console.WriteLine("{0}", carta[number].ToString());
                break;
            case Palo.Corazon:
                Console.ForegroundColor = ConsoleColor.Red;
                //showFormatedUp(number);
                //Figuras.heart();
                //showFormatedDown(number);
                // Console.WriteLine("{0}", carta[number].ToString());
                break;
        }
        carta[card] = carta[numCartas - 1];
        numCartas--;
        return carta[number];
    }

    private void numeroCartas()
    {
        numCartas--;
    }

    public void show()
    {
        string cardNumber = "";
        Console.ForegroundColor = ConsoleColor.Black;
        for (int i = 0; i < numCartas; i++)
        {
            //switch (carta[i].getNumero())
            //{
            //    case 0:
            //        cardNumber = Carta.nombreCarta[0];
            //        break;
            //    case 1:
            //        cardNumber = Carta.nombreCarta[1];
            //        break;
            //    case 2:
            //        cardNumber = Carta.nombreCarta[2];
            //        break;
            //    case 3:
            //        cardNumber = Carta.nombreCarta[3];
            //        break;
            //    case 4:
            //        cardNumber = Carta.nombreCarta[4];
            //        break;
            //    case 5:
            //        cardNumber = Carta.nombreCarta[5];
            //        break;
            //    case 6:
            //        cardNumber = Carta.nombreCarta[6];
            //        break;
            //    case 7:
            //        cardNumber = Carta.nombreCarta[7];
            //        break;
            //    case 8:
            //        cardNumber = Carta.nombreCarta[8];
            //        break;
            //    case 9:
            //        cardNumber = Carta.nombreCarta[9];
            //        break;
            //    case 10:
            //        cardNumber = Carta.nombreCarta[10];
            //        break;
            //    case 11:
            //        cardNumber = Carta.nombreCarta[11];
            //        break;
            //    case 12:
            //        cardNumber = Carta.nombreCarta[12];
            //        break;
            //}
            Console.WriteLine("Carta: {0}", carta[i].ToString());
        }
    }

    private void showFormatedUp(int card)
    {
        Console.WriteLine(" __________________");
        if (card == 9)
        {
            Console.WriteLine("|                  |\n|{0}                |", Carta.nombreCarta[card]);
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
            Console.WriteLine("|                {0}|", Carta.nombreCarta[card]);
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
                Console.WriteLine("|                {0} |", Carta.nombreCarta[0]);
                break;
            case 1:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[1]);
                break;
            case 2:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[2]);
                break;
            case 3:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[3]);
                break;
            case 4:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[4]);
                break;
            case 5:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[5]);
                break;
            case 6:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[6]);
                break;
            case 7:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[7]);
                break;
            case 8:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[8]);
                break;
            case 9:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[9]);
                break;
            case 10:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[10]);
                break;
            case 11:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[11]);
                break;
            case 12:
                Console.WriteLine("|                {0} |", Carta.nombreCarta[12]);
                break;
        }
    }

    private void bottomDown(int card)
    {
        switch (card)
        {
            case 0:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[0]);
                break;
            case 1:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[1]);
                break;
            case 2:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[2]);
                break;
            case 3:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[3]);
                break;
            case 4:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[4]);
                break;
            case 5:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[5]);
                break;
            case 6:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[6]);
                break;
            case 7:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[7]);
                break;
            case 8:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[8]);
                break;
            case 9:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[9]);
                break;
            case 10:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[10]);
                break;
            case 11:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[11]);
                break;
            case 12:
                Console.WriteLine("|                  |\n|{0}                 |", Carta.nombreCarta[12]);
                break;
        }
    }
}