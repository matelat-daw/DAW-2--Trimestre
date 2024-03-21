namespace Baraja;

public class Carta(int valor, Palo palo)
{
    private static readonly string[] nombreCarta = ["1", "2", "3", "4", "5", "6", "7", "Sota", "Caballo", "Rey"];
    private readonly int valor = valor;
    private readonly Palo palo = palo;

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
        Carta? objCarta = obj as Carta;

        return this.palo == objCarta.palo && this.valor == objCarta.valor;
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}