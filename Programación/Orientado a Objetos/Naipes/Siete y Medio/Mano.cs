namespace Siete_y_Medio;

using Naipes;

public abstract class Mano
{
    public int numCartas = 0;
    public Carta[] cartas;
    private const int TOPE = 20;

    public Mano() : this(TOPE) { }

    public Mano(int num)
    {
        if (num > TOPE)
        {
            throw new Exception($"No se aceptan más de {TOPE} cartas en la Mano.");
        }
        cartas = new Carta[num];
    }

    public void DescartaTodas()
    {
        numCartas = 0;
    }

    public void AnadeCarta(Carta carta)
    {
        cartas[numCartas++] = carta;
    }

    public int NumeroCartas()
    {
        return numCartas;
    }

    protected abstract double CuentaPuntos();
}