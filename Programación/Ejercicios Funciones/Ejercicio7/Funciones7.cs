public class Funciones7
{
    public static int count(string frase, char letter) // Función count(string frase, char letter), Recibe una String y una Letra a Buscar dentro de la String.
    {
        int counter = 0; // Declaro la Variable counter y la Inicializo a 0.

        for (int i = 0; i < frase.Length; i++) // Bucle al Tamaño de la String.
        {
            if (letter == frase[i]) // Si Encuentro la Letra en la String
            {
                counter++; // Incremento counter.
            }
        }
        return counter; // Devuelvo counter.
    }
}