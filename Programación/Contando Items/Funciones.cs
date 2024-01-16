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
}