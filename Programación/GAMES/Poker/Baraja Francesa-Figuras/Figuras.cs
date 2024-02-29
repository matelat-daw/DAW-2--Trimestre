
public static class Figuras
{
    public static void Heart(int c)
    {
        Console.WriteLine(" _________________");
        Console.WriteLine("|                 |");
        NumberLeft(c);
        Console.WriteLine("|   **      **    |");
        Console.WriteLine("|  ****    ****   |");
        Console.WriteLine("|  *****  *****   |");
        Console.WriteLine("|    ********     |");
        Console.WriteLine("|      ****       |");
        Console.WriteLine("|       **        |");
        Console.WriteLine("|        *        |");
        NumberRight(c);
        Console.WriteLine(" -----------------");

    }

    public static void Pic(int c)
    {
        Console.WriteLine(" _________________");
        Console.WriteLine("|                 |");
        NumberLeft(c);
        Console.WriteLine("|      **         |");
        Console.WriteLine("|     ****        |");
        Console.WriteLine("|   ********      |");
        Console.WriteLine("|  **********     |");
        Console.WriteLine("|   ********      |");
        Console.WriteLine("|      **         |");
        Console.WriteLine("|    ******       |");
        NumberRight(c);
        Console.WriteLine(" -----------------");
    }

    public static void Diamond(int c)
    {
        Console.WriteLine(" _________________");
        Console.WriteLine("|                 |");
        NumberLeft(c);
        Console.WriteLine("|      **         |");
        Console.WriteLine("|     ****        |");
        Console.WriteLine("|   ********      |");
        Console.WriteLine("| ************    |");
        Console.WriteLine("|   ********      |");
        Console.WriteLine("|     ****        |");
        Console.WriteLine("|      **         |");
        NumberRight(c);
        Console.WriteLine(" -----------------");
    }

    public static void Clover(int c)
    {
        Console.WriteLine(" _________________");
        Console.WriteLine("|                 |");
        NumberLeft(c);
        Console.WriteLine("|   **       **   |");
        Console.WriteLine("|  ****     ****  |");
        Console.WriteLine("|  ***** * *****  |");
        Console.WriteLine("|     *******     |");
        Console.WriteLine("|  ***** * *****  |");
        Console.WriteLine("|  ****  *  ****  |");
        Console.WriteLine("|   **    *  **   |");
        NumberRight(c);
        Console.WriteLine(" -----------------");
    }

    private static void NumberLeft(int c)
    {
        switch (c)
        {
            case 0:
                Console.WriteLine("| A               |");
                break;
            case 9:
                Console.WriteLine("| 10              |");
                break;
            case 10:
                Console.WriteLine("| J               |");
                break;
            case 11:
                Console.WriteLine("| Q               |");
                break;
            case 12:
                Console.WriteLine("| K               |");
                break;
            default:
                Console.WriteLine("| {0}               |", c + 1);
                break;
        }
    }

    private static void NumberRight(int c)
    {
        switch (c)
        {
            case 0:
                Console.WriteLine("|               A |");
                break;
            case 9:
                Console.WriteLine("|              10 |");
                break;
            case 10:
                Console.WriteLine("|               J |");
                break;
            case 11:
                Console.WriteLine("|               Q |");
                break;
            case 12:
                Console.WriteLine("|               K |");
                break;
            default:
                Console.WriteLine("|               {0} |", c + 1);
                break;
        }
    }
}