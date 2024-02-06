public class Candado
{
    private bool abierto = false; // Si quiero usar valores NULL se usa la Clase Padre Boolean, si no bool se inicializa a false.
    private int codigo;
    private static Random pass;

    public Candado()
    {
        pass = new Random();
        codigo = pass.Next(0, 11);
    }

    public void abrir(int codigo)
    {
        if (this.codigo == codigo)
        {
            abierto = true;
        }
    }

    public void cerrar()
    {
        if (abierto)
        {
            abierto = false;
            codigo = pass.Next(0, 11);
        }
    }

    public bool estaCerrado()
    {
        return abierto;
    }

    public string tuString()
    {
        return estaCerrado() == false ? "Cerrado" : "Abierto Código: " + codigo;
    }
}