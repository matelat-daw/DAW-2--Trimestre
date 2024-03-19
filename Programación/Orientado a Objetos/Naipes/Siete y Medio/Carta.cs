namespace Naipes;

public class Carta(int numero, Palo palo)
{
    public static string[] nombreCarta = ["1", "2", "3", "4", "5", "6", "7", "10", "C", "R"]; // Pide que las Cartas se Muestren con Letras.
    private readonly int numero = numero; // Número de la Carta. Él lo Llama Valor creo.
    private readonly Palo palo = palo;

    public int GetNumero() { return numero; } // Getter del Número de la Carta.

    public Palo GetPalo() { return palo; } // Getter del Palo de la Carta.

    public override string ToString() // Sobreescribe la función ToString().
    {
        return $"{nombreCarta[GetNumero()]} de: {GetPalo()}"; // Formatea la Salida, Muestra la Carta en Letras y el Palo.
    }
}