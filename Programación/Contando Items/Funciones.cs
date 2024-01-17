using System;

public class Funciones
{
    public static int cuentaItems(string frase)
    {
        int qtty = 0;
        bool space = false;

        for (int i = 0; i < frase.Length; i++)
        {
            if (!Char.IsWhiteSpace(frase[i]))
            {
                if (!space)
                {
                    qtty++;
                }
                space = true;
            }
            else
            {
                space = false;
            }
        }
        return qtty;
    }

    public static string trim(string frase)
    {
        return rtrim(ltrim(frase));
    }

    private static string ltrim(string frase)
    {
        int index = 0;
        string result = "";

        while (Char.IsWhiteSpace(frase[index]))
        {
            index++;
        }
        for (int i = index; i < frase.Length; i++)
        {
            result += frase[i];
        }

        return result;
    }

    private static string rtrim(string frase)
    {
        int index = frase.Length - 1;
        string result = "";

        while (Char.IsWhiteSpace(frase[index]))
        {
            index--;
        }
        for (int i = 0; i <= index; i++)
        {
            result += frase[i];
        }

        return result;
    }

    public static string[] split(string frase)
    {
        int start = 0;
        int index = 0;
        int counter = 0;
        int qtty;
        string[] result;
        bool space = false;

        qtty = cuentaItems(frase);
        result = new string[qtty];
        for (int i = 0; i < frase.Length; i++)
        {
            while (!Char.IsWhiteSpace(frase[counter]) && counter < frase.Length - 1)
            {
                if (!space)
                {
                    start = i;
                    space = true;
                }
                counter++;
            }
            if (space)
            {
                if (counter == frase.Length - 1)
                {
                    counter++;
                }
                for (int j = start; j < counter; j++)
                {
                    result[index] += frase[j];
                }
                index++;
            }
            i = counter;
            counter++;
            space = false;
        }
        return result;
    }
}