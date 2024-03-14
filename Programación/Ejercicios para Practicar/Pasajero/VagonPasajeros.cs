namespace Tranvia; // OJO el NameSpace Tiene que Aparecer Desde Ahora.

public class VagonPasajeros // Clase VagonPsajeros.
{
    public Pasajero[] pasajeros; // Variable Privada Array de Pasajero.

    public VagonPasajeros(int capacidad) // Cosntructor de la Clase, Recibe la Capacidad del Vagón.
    {
        this.pasajeros = new Pasajero[capacidad]; // Crea un Vagón (Array de Pasajeros) de la Capacidad Pasada Como Parámeetro.
    }

    public void Subir(Pasajero pasajero) // Método Subir, Recibe al Pasajero.
    {
        bool lleno = true; // Se Usa para Saber si el Vagón Está Lleno.

        for (int i = 0; i < pasajeros.Length; i++) // Bucle a la Cantidad de Asientos.
        {
            if (pasajeros[i] == null) // Si en ese Asiento no hay Ningún Pasajero, Está a NULL.
            {
                pasajeros[i] = pasajero; // Agrega el Pasajero Pasado Como Parámetro.
                i = pasajeros.Length; // Iguala i al Tamaño del Array Para Salir del Bucle.
                lleno = false; // Pone lleno a false, Aun Quedaba Sitio.
            }
        }
        if (lleno) // Si lleno está a true, Es que el Vagón ya Está Lleno.
        {
            throw new Exception("El Vagón está Lleno, no Cabe un Alma Más."); // Lanza Excepción, el Vagón Estaba Lleno.
        }
    }

    public Pasajero Bajar(string nombre) // Método Bajar, Recibe el Nombre de un Pasajero.
    {
        Pasajero pasajero = null; // Variable pasajero a null.

        for (int i = 0; i < pasajeros.Length; i++) // Bucle al Tamaño del Array de Pasajeros.
        {
            if (pasajeros[i].GetNombre() == nombre) // Si el Nombre Pasado como Parámetro es uno de los Que está en el Array.
            {
                pasajero = pasajeros[i]; // Lo Asigna a pasajero.
                pasajeros[i] = null; // Pone la Posición a NULL, queda un Espacio Vacío.
                i = pasajeros.Length; // Igualo i al Tamaño del Array para Salir del Bucle.
            }
        }
        return pasajero; // Retorna el Pasajero.
    }
}