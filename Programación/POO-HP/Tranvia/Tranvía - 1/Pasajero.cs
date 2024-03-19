namespace Tranvía___1;

public class Pasajero
{
    private static readonly List<String> nombreUsados = [];
    private readonly string nombre;
    public Pasajero(string nombre)
    {
        if (nombreUsados.Contains(nombre))
            throw new ArgumentException();
        this.nombre = nombre;
        nombreUsados.Add(nombre);
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