namespace Tranvía___2;

public class Tranvia
{
    private VagonPasajeros[] vagones;

    public Tranvia() : this(4)
    {
    }

    public Tranvia(int numVagones)
    {
        vagones = new VagonPasajeros[numVagones];
        for (int i = 0; i < vagones.Length; i++)
        {
            vagones[i] = new VagonPasajeros(5);
        }
    }

    public Pasajero? Bajar(string nombre, int vagon)
    {
        return vagones[vagon].Bajar(nombre);
    }

    public int Subir(Pasajero p, int v)
    {
        int pos = v;
        bool subido = false;
        do
        {
            try
            {
                vagones[pos].Subir(p);
                subido = true;
            }
            catch (Exception)
            {
                pos++;
                if (pos == vagones.Length)
                    pos = 0;
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