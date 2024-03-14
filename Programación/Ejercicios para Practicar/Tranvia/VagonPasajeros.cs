namespace Tranvias; // OJO el NameSpace Tiene que Aparecer Desde Ahora.

public class VagonPasajeros // Clase VagonPsajeros.
{
    public readonly List<Pasajero> pasajeros; // Variable Privada Array de Pasajero.
    public static int capacidad;

    public VagonPasajeros(int capacidad) // Cosntructor de la Clase, Recibe la Capacidad del Vagón.
    {
        this.pasajeros = new List<Pasajero>(capacidad); // Crea un Vagón (List de Pasajeros) de la Capacidad Pasada Como Parámetro.
        capacidad = capacidad;
    }

    public int GetCapacidad()
    {
        return pasajeros.Count;
    }

    public void Subir(Pasajero pasajero) // Método Subir, Recibe al Pasajero.
    {
        if (GetCapacidad() < capacidad)
        {
            pasajeros.Add(pasajero);
        }
        else // Si No, Es que el Vagón ya Está Lleno.
        {
            throw new Exception("El Vagón está Lleno, no Cabe un Alma Más."); // Lanza Excepción, el Vagón Estaba Lleno.
        }
    }

    public Pasajero Bajar(string nombre) // Método Bajar, Recibe el Nombre de un Pasajero.
    {
        Pasajero pasajero = null; // Variable pasajero a null.

        for (int i = 0; i < pasajeros.Count; i++) // Bucle al Tamaño de la Lista de Pasajeros.
        {
            if (pasajeros[i].GetNombre() == nombre) // Si el Nombre Pasado como Parámetro es uno de los Que está en la Lista.
            {
                pasajero = pasajeros[i]; // Lo Asigna a pasajero.
                pasajeros.RemoveAt(i); // Remueve el Pasajero de su Posición, queda un Espacio Vacío, Pero al Final de la Lista.
                i = pasajeros.Count; // Igualo i al Tamaño del Array para Salir del Bucle.
            }
        }
        return pasajero; // Retorna el Pasajero.
    }
}