namespace Baraja;

public abstract class Mano
{
    protected int numCartas = 0;
    protected Carta[] cartas;
    private const int TOPE = 20;

    public Mano() : this(TOPE)
    {
    }
    public Mano(int num)
    {
        if (num > TOPE)
            throw new Exception($"No se aceptan más de {TOPE} cartas en la mano.");
        if (num == 0)
            throw new Exception($"Mano de tamaño cero, no podría aceptar cartas.");
        cartas = new Carta[num];
    }
    public void DescartaTodas()
    {
        numCartas = 0;
    }
    public virtual void AñadeCarta(Carta c)
    {
        if (numCartas == cartas.Length)
            throw new Exception("No cabe más cartas en la mano.");
        cartas[numCartas++] = c;
    }

    public int GetNumeroCartas()
    {
        return numCartas;
    }

    public abstract double CuentaPuntos();

    public override string ToString()
    {
        int i;
        string temp = "{";
        for (i = 0; i < numCartas - 1; i++)
        {
            temp = temp + $"\"{cartas[i]}\",";
        }
        if (numCartas > 0)
        {
            temp = temp + $"\"{cartas[i]}\"";
        }
        temp += "}";
        return temp;
    }
}