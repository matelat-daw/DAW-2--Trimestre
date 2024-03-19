namespace Baraja;

public class ManoSieteyMedia : Mano
{
    private const int TOPE = 16;

    public ManoSieteyMedia() : base(TOPE) { }

    public override double CuentaPuntos()
    {
        double total = 0;
        for (int i = 0; i < numCartas; i++)
        {
            int v = cartas[i].GetValor();
            total += (v < 8) ? (v) : (0.5);
        }
        return total;
    }
    public override void AñadeCarta(Carta c)
    {
        base.AñadeCarta(c);
        if (CuentaPuntos() > 7.5)
            throw new Exception("Se pasó de siete y media.");
    }
}