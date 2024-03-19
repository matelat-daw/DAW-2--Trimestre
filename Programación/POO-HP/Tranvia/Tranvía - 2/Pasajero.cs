namespace Tranvía___2;

public class Pasajero
{
    private string nombre;
    public Pasajero(string nombre)
    {
        this.nombre = nombre;
    }
    public string GetNombre()
    {
        return nombre;
    }

    public override string ToString()
    {
        return $"Pasajero: {nombre}";
    }
}