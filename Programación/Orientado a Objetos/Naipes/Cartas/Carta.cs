public class Carta
{
    public static string[] nombreCarta = ["A", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve", "Diez", "J", "Q", "K"]; // Pide que las Cartas se Muestren con Letras.
    private int numero; // Número de la Carta. Él lo Llama Valor creo.
    private Palo palo; // Palo de la Carta.

    public Carta(int numero, Palo palo) // Cosntructor de la Carta
    {
        this.numero = numero;
        this.palo = palo;
    }

    public int getNumero() { return numero; } // Getter del Número de la Carta.

    public Palo getPalo() { return palo; } // Getter del Palo de la Carta.

    public override string ToString() // Sobreescribe la función ToString().
    {
        return String.Format("{0} de: {1}", nombreCarta[getNumero()], getPalo()); // Formatea la Salida, Muestra la Carta en Letras y el Palo.
    }
}