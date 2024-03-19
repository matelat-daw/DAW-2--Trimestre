namespace Baraja;

public class Carta
{
    private static string[] nombreCarta = { "1", "2", "3", "4", "5", "6", "7", "Sota", "Caballo", "Rey" };
    private int valor;
    private Palo palo;

    public Carta(int valor, Palo palo)
    {
        this.valor = valor;
        this.palo = palo;
    }

    public Palo GetPalo()
    {
        return palo;
    }

    public int GetValor()
    {
        return valor;
    }

    public override String ToString()
    {
        return nombreCarta[valor - 1] + " de " + palo;
    }

    public override bool Equals(object? obj)
    {
        Carta objCarta = (Carta)obj;

        return this.palo == objCarta.palo && this.valor == objCarta.valor;
    }

}