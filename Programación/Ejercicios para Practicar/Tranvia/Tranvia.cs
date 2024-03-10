namespace Tranvias; // OJO Como Siempre, a Partir de Ahora Hay que Poner Siempre el NameSpace.

public class Tranvia // Clase Tranvía
{
    private readonly List<VagonPasajeros> vagones; // Variable Array de Vagones.
    private int capacidad;

    public Tranvia(): this(4) // Constructor Vacio, Crea un Tranvía de 4 Vagónes.
    { }

    public Tranvia(int numVagones) // Constructor que Recibe el Tamaño del Travía.
    {
        vagones = new List<VagonPasajeros>(numVagones); // Crea el Tranvía.
        FillWagon(numVagones); // Con la Cantidad de Vagones Pasada Como Parámetro.
    }

    private void FillWagon(int length) // Pone los Vagones al Tranvía.
    {
        for (int i = 0; i < length; i++) // Bucle a la Cantidas de Vagónes.
        {
            vagones.Add(new VagonPasajeros(40));
        }
        capacidad = 40;
    }

    public int GetCapacidad(int vagon)
    {
        return vagones[vagon].pasajeros.Count;
    }

    public Pasajero Bajar(string nombre, int vagon) // Método Bajar, Para que los Pasajeros Bajen del Tranvía, Recive el Nombre del Pasajero y el Vagón.
    {
        int i; // Uso i para el Bucle.
        Pasajero pasajero = null; // Variable pasajero a NULL.

        for (i = 0; i < vagones[vagon].pasajeros.Count; i++) // Bucle al Tamaño del Vagón de Pasajeros.
        {
            if (vagones[vagon].pasajeros[i].GetNombre() == nombre) // Si El Nombre Recibido es de algún Pasajero que Está en el Vagón.
            {
                pasajero = new(nombre); // Asigno a psajero el Pasajero Encontrado.
                vagones[vagon].pasajeros.RemoveAt(i); // Pongo a NULL el Asiento en el que Estaba el Psajero.
                i = vagones[vagon].pasajeros.Count; // Igualo i al Tamaño del Array Para Salir del Bucle.
            }
        }
        return pasajero; // Retorno el Pasajero.
    }

    public int Subir(Pasajero pasajero, int vagon) // Método Para Subir Pasajero al Tranvía, Recibe el Pasajero y el Vagón.
    {
        int resultado = -1; // Int resultado es -1;

        for (int i = vagon; i < vagones.Count; i++) // Primer Bucle desde el Vagón Pasado Como Parámetro al Último Vagón.
        {
            if (GetCapacidad(i) < capacidad) // Si la Capacidad de los Vagones no Está Completa.
            {
                vagones[i].pasajeros.Add(pasajero); // Agrego el Psajero al Vagón.
                resultado = i; // Resultado es el Número de Vagón donde Subió el Pasajero.
                i = vagones.Count; // Igual i al tamaño de la Lista para salir de Bucle.
            }
        }
        if (resultado == -1) // Si al Salir del Bucle Anterior, resultado Sigue Siendo -1.
        {
            if (vagon > 0) // Hay que Verificar si el Vagón pasado no era 0.
            {
                for (int i = 0; i < vagon; i++) // Si era Distinto de 0, hay que Hacer Otro Bucle desde 0 al Vagón Pasado.
                {
                    if (GetCapacidad(i) < capacidad) // Si la Capacidad de los Vagones no Está Completa.
                    {
                        vagones[i].pasajeros.Add(pasajero); // Agrego el Psajero al Vagón.
                        resultado = i; // Resultado es el Número de Vagón donde Subió el Pasajero.
                        i = vagon; // Igual i al vagón para salir de Bucle.
                    }
                }
                if (resultado == -1) // Si resultado Sigue Siendo -1, es que ya no Hay Sitio en Ningún Vagón.
                {
                    throw new Exception("El Vagón está Lleno, no Cabe un Alma Más."); // Lanza Excepción, el Vagón Estaba Lleno.
                }
            }
            else // Si el Vagón Pasado Como Parámetro era 0, Ya los Comrpobó Todos y si resultado es -1, es que no Había Sitio en Ningún Vagón.
            {
                throw new Exception("El Vagón está Lleno, no Cabe un Alma Más."); // Lanza Excepción, el Vagón Estaba Lleno.
            }
        }
        return resultado; // Si no se Lanza la Excepción Retorno el Número de Vagón.
    }
}