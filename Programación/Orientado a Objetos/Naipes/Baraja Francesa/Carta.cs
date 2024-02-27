public class Carta
{
    public static string[] nombreCarta = ["A", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve", "Diez", "J", "Q", "K"];
    private int numero;
    private Palo palo;

    public Carta(int numero, Palo palo)
    {
        this.numero = numero;
        this.palo = palo;
    }

    public int getNumero() { return numero; }

    public Palo getPalo() { return palo; }

    public override string ToString()
    {
        return nombreCarta[getNumero()] + " de: " + getPalo();
    }
}