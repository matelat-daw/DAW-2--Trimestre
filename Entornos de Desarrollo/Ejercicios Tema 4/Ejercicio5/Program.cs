/*
 *  Programa que llama a la funcion palabrasEnFrase(String s),la cual devuelve
 *  el número de palabras que hay en la frase que se le pasa como parámetro
 *  "Alejandro es un crack" debería devolver 4.
 */
Console.WriteLine("Introduce una frase:");
String str = Console.ReadLine();
int res = palabrasEnFrase(str);
Console.WriteLine("En la frase hay este número de palabras: " + res);


static int palabrasEnFrase(String s)
{
    int i = 0;
    int r = 0;
    while (i < s.Length)
    {
        if (s.ElementAt(i) == ' ')
        {
            r++;
        }
        i++;
    }
    r++;
    return r;
}