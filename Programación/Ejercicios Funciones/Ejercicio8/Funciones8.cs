public class Funciones8
{
    public static int[] positions(string frase, char letter) // La Función positions(string frase, char letter), Recibe una String y una Letra y Busca las Posiciones donde están las Coincidencias con la Letra Buscada, en la String.
    {
        int size = Funciones7.count(frase, letter); // Obtengo las coincidencias de la letra en la frase de la Función count deel ejercicio 7(Funciones7).
        int[] positions = new int[size]; // Creo el array positions del tamao de la cantidad de coincidencias(size).

        int index = 0; // Declaro index y le Asigno el Valor 0.

        for (int i = 0; i < frase.Length; i++) // Bucle al Tamaño de la String.
        {
            if (letter == frase[i]) // Si la Letra Está en la Posición i en la String.
            {
                positions[index++] = i; // Asigno a la Posición index del Array positions el Valor de i y  post incremento index.
                // index++; // Incremento index.
            }
        }
        return positions; // Devuelvo el Array positions.
    }

    public static int size(string frase, char letter, out int[] positions)
    {
        List<int> lista = new List<int>();

        int i = 0;
        for (i = 0; i < frase.Length; i++)
        {
            if (frase[i] == letter)
            {
                lista.Add(i);
            }
        }

        positions = lista.ToArray();
        return positions.Length;
    }

    public static void showPositions(int[] positions) // Función showPositions(int[] positions), Recibe un Array y Muestra por Pantalla las Posiciones de las Letras Encontradas en la String.
    {
        int index = 0; // Declaro index y le Asigno el Valor 0, será el Índice del Array positions.

        while (index < positions.Length && positions[index] != -1) // Mientras index no llegue al Final del Array y no Haya un -1 en la Posición index del Array positions.
        {
            Console.WriteLine("\nLa Posición de la {0}ª Coincidencia Es: {1}", index + 1, positions[index]); // Muestra por Pantalla la Posición de la Letra en la Cadena.
            index++; // Incrementa index
        }
        if (index == 0) // Si a la Salida index es Igual a 0.
        {
            Console.WriteLine("\nNo se Ha Encontrado Ninguna Coincidencia."); // No Hubo Ninguna Coincidencia.
        }
    }
}