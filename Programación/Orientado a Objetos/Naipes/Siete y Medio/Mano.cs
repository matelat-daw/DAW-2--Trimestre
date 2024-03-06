
public abstract class Mano
{
    public Mano() { }

    public Mano(int num)
    {

    }

    public static void DescartaTodas()
    {
        Mazo mazo = new();
    }

    protected int AnadeCarta(Carta carta)
    {
        return carta.getNumero() + 1;
    }
}