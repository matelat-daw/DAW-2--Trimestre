namespace Tranvía___1;

public class Tranvia
{
    private readonly List<VagonPasajeros> vagones;

    public Tranvia() : this(4)
    {
    }

    public Tranvia(int numVagones)
    {
        vagones = new List<VagonPasajeros>(numVagones);
        for (int i = 0; i < numVagones; i++)
        {
            vagones.Add(new VagonPasajeros(5));
        }
    }

    public Pasajero? Bajar(string nombre, int vagon)
    {
        return vagones.ElementAt(vagon).Bajar(nombre);
    }

    public int Subir(Pasajero p, int v)
    {
        int pos = v;
        bool subido = false;
        do
        {
            try
            {
                vagones.ElementAt(pos).Subir(p);
                subido = true;
            }
            catch (Exception)
            {
                pos = (pos + 1) % vagones.Count;
                //pos++;
                //if (pos == vagones.Count)
                //    pos = 0;
            }
        } while (!subido && pos != v);
        if (!subido)
            throw new Exception("Todos los vagones están llenos.");
        return pos;
    }

    public override string ToString()
    {
        string aux = "Tranvía\n";
        foreach (VagonPasajeros v in vagones)
            aux += "    - " + v + "\n";
        return aux;
    }
}