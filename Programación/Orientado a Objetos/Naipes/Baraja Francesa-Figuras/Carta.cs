public class Carta
{
    public static string[] nombreCarta = ["A", "J", "Q", "K"];
    private int numero;
    private Palo palo;

    public Carta(int numero, Palo palo)
    {
        this.numero = numero;
        this.palo = palo;
    }

    public int getNumero() { return numero; }

    public Palo getPalo() { return palo; }
}