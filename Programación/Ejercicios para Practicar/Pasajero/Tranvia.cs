namespace Tranvia; // OJO Como Siempre, a Partir de Ahora Hay que Poner Siempre el NameSpace.

public class Tranvia // Clase Tranvía
{
    private VagonPasajeros[] vagones; // Variable Array de Vagones.

    public Tranvia() // Construcotr Vacio, Crea un Tranvía de 4 Vagónes.
    {
        this.vagones = new VagonPasajeros[4]; // Crea el Tranvía.
        FillWagon(vagones.Length); // Con Vagones de 40 Pasajeros.
    }

    public Tranvia(int numVagones) // Constructor que Recibe el Tamaño del Travía.
    {
        this.vagones = new VagonPasajeros[numVagones]; // Crea el Tranvía.
        FillWagon(vagones.Length); // Con la Cantidad de Vagones Pasada Como Parámetro.
    }

    private void FillWagon(int length) // Pone los Vagones al Tranvía.
    {
        for (int i = 0; i < length; i++) // Bucle a la Cantidas de Vagónes.
        {
            vagones[i] = new(40); // Llama a la Clase VagonPasajeros y Crea los Vagones de 40 Pasajeros en Cada Vagón del Array en la Posición i.
        }
    }

    public Pasajero Bajar(string nombre, int vagon) // Método Bajar, Para que los Pasajeros Bajen del Tranvía, Recive el Nombre del Pasajero y el Vagón.
    {
        int i; // Uso i para el Bucle.
        Pasajero pasajero = null; // Variable pasajero a NULL.

        for (i = 0; i < vagones[vagon].pasajeros.Length; i++) // Bucle al Tamaño del Vagón de Pasajeros.
        {
            if (vagones[vagon].pasajeros[i].GetNombre() == nombre) // Si El Nombre Recibido es de algún Pasajero que Está en el Vagón.
            {
                pasajero = new(nombre); // Asigno a psajero el Pasajero Encontrado.
                vagones[vagon].pasajeros[i] = null; // Pongo a NULL el Asiento en el que Estaba el Psajero.
                i = vagones[vagon].pasajeros.Length; // Igualo i al Tamaño del Array Para Salir del Bucle.
            }
        }
        return pasajero; // Retorno el Pasajero.
    }

    public int Subir(Pasajero pasajero, int vagon) // Método Para Subir Pasajero al Tranvía, Recibe el Pasajero y el Vagón.
    {
        int resultado = -1; // Int resultado es -1;
        for (int i = 0; i < vagones[vagon].pasajeros.Length; i++) // Bucle al Tamaño del Vagón de Pasajeros.
        {
            if (vagones[vagon].pasajeros[i] == null) // Si el Asiento Está a NULL, Está Vacio.
            {
                vagones[vagon].pasajeros[i] = pasajero; // Pongo al Pasajero en el Asiento.
                i = vagones[vagon].pasajeros.Length; // Igualo i al Tamaño del Array Para Salir del Bucle.
                resultado = vagon; // Asigno a resultado el Número de Vagón.
            }
        }
        if (resultado == -1) // Si resultado no Cambió el Primer Valor Asignado (-1), es que ya no Hay Más Asientos en el Vagón para Subir Pasajeros.
        {
            throw new Exception("Tren Lleno, NO Cabe un Alma."); // Lanzo una Excepción.
        }
        return resultado; // Si no se Lanza la Excepción Retorno el Número de Vagón.
    }
}