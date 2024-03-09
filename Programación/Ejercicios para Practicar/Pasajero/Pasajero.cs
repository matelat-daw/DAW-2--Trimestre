namespace Tranvia; // OJO el NameSpace ahora Hay que Usarlo y en Todas las Clases que Necesitan Relacionarse se Llama Igual.

public class Pasajero // Clase Pasajero
{
    private string nombre; // Variable Privada nombre.

    public Pasajero(string nombre) // Constructor, Recibe el Nombre del Pasajero.
    {
        this.nombre = nombre; // Lo Crea con el Nombre Recibido.
    }

    public string GetNombre() { return nombre; } // Método GetNombre(), Para Saber el Nombre del Pasajero.
}