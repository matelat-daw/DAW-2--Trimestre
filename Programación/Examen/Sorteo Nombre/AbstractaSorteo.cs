namespace Sorteo_Nombre;

public abstract class AbstractaSorteo
{
    protected int nCandidatos;
    protected String[] candidatos;
    protected static Random alea = new Random();

    public AbstractaSorteo(int numCandidatos)
    {
        candidatos = new String[numCandidatos];
    }

    public abstract void Incluir(String nombre);
    public abstract void Incluir(String[] nombre);

    public abstract String Seleccionar();
    public abstract String[] Seleccionar(int cuantos);

    public void Vaciar()
    {
        nCandidatos = 0;
    }

    public Boolean EstaVacio()
    {
        return nCandidatos == 0;
    }
}
