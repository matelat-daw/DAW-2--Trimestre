public class Ejercicio8
{
    static void Main(string[] args)
    {
        int[] positions; // Declaro el Array de Enteros position.

        Console.WriteLine("Este Programa Llama a la Función positions(\"Hola\", 'a'), Pasándole una String y una Letra y Muestra las Posiciones en las que Aparece la Letra en la String\n");

        Console.WriteLine("La Palabra Es: Caballariza y la Letra a Buscar Es: a");

        positions = Funciones8.positions("bbbabbb", 'a'); // Asigno a position el Resultado de la Llamada a la Función positions("Hola", 'a') a la que le paso como Parámetros una String y una Letra.

        Funciones8.showPositions(positions); // Llamo a la Función showPositions(positions) Pasándole como Parámetro el Array positions.
    }
}