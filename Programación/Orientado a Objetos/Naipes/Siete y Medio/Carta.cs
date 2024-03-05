public class Carta
{
    public static string[] nombreCarta = ["1", "2", "3", "4", "5", "6", "7", "10", "C", "R"]; // Pide que las Cartas se Muestren con Letras.
    private int numero; // Número de la Carta. Él lo Llama Valor creo.
    private Palo palo;

    public Carta(int numero, Palo palo)
    {
        this.numero = numero;
        this.palo = palo;
    }

    public int getNumero() { return numero; } // Getter del Número de la Carta.

    public Palo getPalo() { return palo; } // Getter del Palo de la Carta.
}