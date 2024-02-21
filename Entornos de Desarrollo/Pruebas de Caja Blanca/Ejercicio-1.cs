public static void int contar_letras(char cadena[10], char letra)
{
    int contador = 0; n = 0; lon;
    lon = strlen(cadena);
    if (lon > 0)
    {
        do
        {
            if (cadena[contador] == letras)
            {
                n++;
            }
            contador++;
            lon--;
        } while (lon > 0);
    }
    return n;
}