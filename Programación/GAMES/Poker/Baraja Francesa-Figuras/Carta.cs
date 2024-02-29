public class Carta(int numero, Palo palo)
{
    public static string[] nombreCarta = ["A", "J", "Q", "K"];
    private readonly int numero = numero;
    private readonly Palo palo = palo;

    public int GetNumero() { return numero; }

    public Palo GetPalo() { return palo; }
}