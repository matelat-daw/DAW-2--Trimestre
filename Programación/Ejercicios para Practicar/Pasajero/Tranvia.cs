using System.Diagnostics.CodeAnalysis;

namespace Tranvia; // OJO Como Siempre, a Partir de Ahora Hay que Poner Siempre el NameSpace.

public class Tranvia // Clase Tranvía
{
    private VagonPasajeros[] vagones; // Variable Array de Vagones.
    private int capacidad;

    public Tranvia() : this(4) // Construcotr Vacio, Crea un Tranvía de 4 Vagónes.
    { }

    public Tranvia(int numVagones) // Constructor que Recibe el Tamaño del Travía.
    {
        this.vagones = new VagonPasajeros[numVagones]; // Crea el Tranvía.
        FillWagon(vagones.Length); // Con la Cantidad de Vagones Pasada Como Parámetro.
    }

    private void FillWagon(int length) // Pone los Vagones al Tranvía.
    {
        for (int i = 0; i < length; i++) // Bucle a la Cantidas de Vagones.
        {
            vagones[i] = new(40); // Llama a la Clase VagonPasajeros y Crea los Vagones de 40 Pasajeros en Cada Vagón del Array en la Posición i.
        }
        this.capacidad = 40;
    }

    public Pasajero Bajar(string nombre, int vagon) // Método Bajar, Para que los Pasajeros Bajen del Tranvía, Recive el Nombre del Pasajero y el Vagón.
    {
        int i; // Uso i para el Bucle.
        Pasajero pasajero = null; // Variable pasajero a NULL.

        for (i = 0; i < vagones[vagon].pasajeros.Length; i++) // Bucle al Tamaño del Vagón de Pasajeros.
        {
            if (vagones[vagon].pasajeros[i] != null)
            {
                if (vagones[vagon].pasajeros[i].GetNombre() == nombre) // Si El Nombre Recibido es de algún Pasajero que Está en el Vagón.
                {
                    pasajero = new(nombre); // Asigno a pasajero el Pasajero Encontrado.
                    vagones[vagon].pasajeros[i] = null; // Pongo a NULL el Asiento en el que Estaba el Psajero.
                    i = vagones[vagon].pasajeros.Length; // Igualo i al Tamaño del Array Para Salir del Bucle.
                }
            }
        }
        return pasajero; // Retorno el Pasajero.
    }

    public int Subir(Pasajero pasajero, int vagon) // Método Para Subir Pasajero al Tranvía, Recibe el Pasajero y el Vagón.
    {
        int resultado = -1; // Int resultado es -1;

        for (int i = vagon; i < vagones.Length; i++) // Bucle al Tamaño del Array de Vagónes de Pasajeros.
        {
            for (int j = 0; j < vagones[i].pasajeros.Length; j++) // Bucle a la Cantidad de Pasajeros en Cada Vagón.
            {
                if (vagones[i].pasajeros[j] == null) // Si el Asiento Está a NULL, Está Vacio.
                {
                    vagones[i].pasajeros[j] = pasajero; // Pongo al Pasajero en el Asiento.
                    j = vagones[i].pasajeros.Length; // Igualo j al Tamaño del Array para Salir del Bucle. OJO al Orden, Primero el Array Interno.
                    resultado = i; // Asigno a resultado el Número de Vagón.
                }
            }
            if (resultado != -1)
            {
                i = vagones.Length; // Igualo i al Tamaño del Array Para Salir del Bucle.
            }
        }
        if (resultado == -1) // Si resultado no Cambió el Primer Valor Asignado (-1), es que ya no Hay Más Asientos en el Vagón para Subir Pasajeros.
        {
            if (vagon > 0)
            {
                for (int i = 0; i < vagon; i++) // Bucle al Tamaño del Vagón de Pasajeros.
                {
                    for (int j = 0; j < vagones[i].pasajeros.Length; j++)
                    {
                        if (vagones[i].pasajeros[j] == null) // Si el Asiento Está a NULL, Está Vacio.
                        {
                            vagones[i].pasajeros[j] = pasajero; // Pongo al Pasajero en el Asiento.
                            j = vagones[i].pasajeros.Length; // Igualo j al Tamaño del Array para Salir del Bucle. OJO al Orden, Primero el Array Interno.
                            resultado = i; // Asigno a resultado el Número de Vagón.
                        }
                    }
                    if (resultado != -1)
                    {
                        i = vagon; // Igualo i al Tamaño del Array Para Salir del Bucle.
                    }
                }
                if (resultado == -1) // Si resultado no Cambió el Primer Valor Asignado (-1), es que ya no Hay Más Asientos en el Vagón para Subir Pasajeros.
                {
                    throw new Exception("Tren Lleno, NO Cabe un Alma."); // Lanzo una Excepción.
                }
            }
            else
            {
                throw new Exception("Tren Lleno, NO Cabe un Alma."); // Lanzo una Excepción.
            }
        }
        return resultado; // Si no se Lanza la Excepción Retorno el Número de Vagón.
    }
}