namespace Tranvía___1;

public class VagonPasajeros
{
    private int nAsientos;
    private List<Pasajero> pasajerosSentados;

    public VagonPasajeros() : this(20)
    {
    }
    public VagonPasajeros(int capacidad)
    {
        this.nAsientos = capacidad;
        this.pasajerosSentados = new List<Pasajero>();
    }

    public void Subir(Pasajero pasajero)
    {
        if (nAsientos == pasajerosSentados.Count)
            throw new Exception("No hay asientos libres en ese vagón");
        pasajerosSentados.Add(pasajero);
    }

    public Pasajero? Bajar(string nombre)
    {
        Pasajero? queBaja = null;
        int pos = 0;
        while (pos < pasajerosSentados.Count - 1 & pasajerosSentados.ElementAt(pos).GetNombre() != nombre)
            pos++;
        if (pasajerosSentados.ElementAt(pos).GetNombre() == nombre)
        {
            queBaja = pasajerosSentados.ElementAt(pos);
            pasajerosSentados.RemoveAt(pos);
        }
        return queBaja;
    }

    public override string ToString()
    {
        String aux = "VagonPasajeros\n";
        for (int i = 0; i < pasajerosSentados.Count; i++)
            aux += "  - " + pasajerosSentados.ElementAt(i) + "\n";
        return aux;
    }
}