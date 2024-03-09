namespace Tranvia; // Hay que Usar NameSpace.

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Pasajeros al Tren");
        Pasajero[] pasajero = new Pasajero[40]; // Crea un Array de 40 Pasajeros.

        for (int i = 0; i < pasajero.Length; i++) // Este Bucle Rellena el Array de 40 Pasajeros.
        {
            pasajero[i] = new($"Viajero-{i}");
        }

        /* VagonPasajeros vagon = new(40);

        for (int i = 0; i < 40; i++) // Este Bucle Sube 40 Pasajeros al Vagón.
        {
            vagon.Subir(pasajero[i]);
        }

        // vagon.Subir(pasajero[3]); // Si se Sube un Pasajero Más Lanza Excepción, El Vagón Estaba Lleno.

        Pasajero viajero = vagon.Bajar("Viajero-20"); // Baja un Pasajero.
        if (viajero != null) // Si el Pasajero Devuelto Está en el Vagón.
        {
            Console.WriteLine($"El Pasajero: {viajero.GetNombre()} Ha Bajado del Tren."); // Ha Bajado
        }
        else // Si No.
        {
            Console.WriteLine("El Nombre Recibido no Corresponde a Ningún Pasajero."); // Recibió NULL.
        } */ // Este Bloque de Código Usa la Clase VagonPasajeros, que solo Crea un Vagón de 40 Pasajeros.

        Tranvia tranvia = new Tranvia(); // Este Constructor de la Clase Tranvia crea un Tranvía de 4 Vagones.
        int j = 0; // Uso j para Llenar los 4 Vagones.

        while (j < 160) // Mientras j sea Menor que 160
        {
            for (int i = 0 + j; i < 40 + j; i++) // Bucle de 0, 40, 80, 120 a 40, 80, 120, 160.
            {
                tranvia.Subir(pasajero[i - j], j / 40); // Sube Pasajeros al Tranvía, Pasajeros de 0 a 39 en los Vagones de 0 a 4.
            }
            j += 40; // Incremento j de 40 en 40.
        }

        Pasajero viajeros = tranvia.Bajar("Viajero-20", 0); // Se Baja el Viajero-20 del Vagón 0.
        Bajaron(viajeros); // Muestra Quien Ha Bajado del Tranvía, Método Privado Tiene que ser static ya que Main es static.
        viajeros = tranvia.Bajar("Viajero-10", 1); // Se Baja el Viajero-10 del Vagón 1.
        Bajaron(viajeros);
        viajeros = tranvia.Bajar("Viajero-15", 2); // Se Baja el Viajero-15 del Vagón 2.
        Bajaron(viajeros);
        viajeros = tranvia.Bajar("Viajero-5", 3); // Se Baja el Viajero-5 del Vagón 3.
        Bajaron(viajeros);

        tranvia.Subir(pasajero[0], 0); // Sube el Viajero-0 al Vagón 0.
        tranvia.Subir(pasajero[0], 1); // Sube el Viajero-0 al Vagón 1.
        tranvia.Subir(pasajero[0], 2); // Sube el Viajero-0 al Vagón 2.
        tranvia.Subir(pasajero[0], 3); // Sube el Viajero-0 al Vagón 3.

        // tranvia.Subir(pasajero[10], 2); // Descomenta Esta Línea y Ejecuta, Dará Error, Mira Como en las Posiciones 20 del Vagón 0, 10 del Vagón 1, 15 del Vagón 2 y 5 del Vagón 3, Ahora está el Viajero-0, Son los Últimos 4 que se Subieron. Y Este Último que Intentó Subir Lanzó una Excepción ya que Todos los Vagones Están Llenos.
    }

    private static void Bajaron(Pasajero viajeros) // Muestra los Viajeros que Han Bajado del Tranvía, Recibe el Pasajero.
    {
        if (viajeros != null) // Si el Pasajero no es NULL.
        {
            Console.WriteLine($"El Pasajero: {viajeros.GetNombre()} Ha Bajado del Tren."); // Muestra Quién Ha Bajado del Tranvía.
        }
        else // Si es NULL.
        {
            Console.WriteLine("El Nombre Recibido no Corresponde a Ningún Pasajero."); // Ese Pasajero No Estaba en el Tranvía.
        }
    }
}