namespace Tranvias; // Hay que Usar NameSpace.

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Pasajeros al Tren");
        List<Pasajero> pasajeros = new(); // Crea un Array de 40 Pasajeros.

        for (int i = 0; i < 40; i++) // Este Bucle Rellena la List con 40 Pasajeros.
        {
            pasajeros.Add(new Pasajero($"Viajero-{i + 1}"));
        }

        /* VagonPasajeros vagon = new VagonPasajeros(40);

        for (int i = 0; i < 40; i++) // Este Bucle Rellena la List con 40 Pasajeros.
        {
            vagon.Subir(pasajeros[i]);
        }

        Pasajero viajero = vagon.Bajar("Viajero-20"); // Baja un Pasajero.
        if (viajero != null) // Si el Pasajero Devuelto Está en el Vagón.
        {
            Console.WriteLine($"El Pasajero: {viajero.GetNombre()} Ha Bajado del Tren."); // Ha Bajado
        }
        else // Si No.
        {
            Console.WriteLine("El Nombre Recibido no Corresponde a Ningún Pasajero."); // Recibió NULL.
        } // Este Bloque de Código Usa la Clase VagonPasajeros, que solo Crea un Vagón de 40 Pasajeros.

        vagon.Subir(pasajeros[4]); */

        Tranvia tranvia = new(); // Este Constructor de la Clase Tranvia crea un Tranvía de 4 Vagones.
        int j = 0; // Uso j para Llenar los 4 Vagones.

        while (j < 160) // Mientras j sea Menor que 160
        {
            for (int i = 0 + j; i < pasajeros.Count + j; i++) // Bucle de 0, 40, 80, 120 a 40, 80, 120, 160.
            {
                tranvia.Subir(pasajeros[i - j], j / 40); // Sube Pasajeros al Tranvía, Pasajeros de 0 a 39 en los Vagones de 0 a 3.
            }
            j += 40; // Incremento j de 40 en 40.
        }

        Pasajero viajero = tranvia.Bajar("Viajero-20", 0); // Se Baja el Viajero-20 del Vagón 0.
        Bajo(viajero); // Muestra Quien Ha Bajado del Tranvía, Método Privado Tiene que ser static ya que Main es static.
        viajero = tranvia.Bajar("Viajero-10", 1); // Se Baja el Viajero-10 del Vagón 1.
        Bajo(viajero);
        viajero = tranvia.Bajar("Viajero-15", 2); // Se Baja el Viajero-15 del Vagón 2.
        Bajo(viajero);
        viajero = tranvia.Bajar("Viajero-5", 3); // Se Baja el Viajero-5 del Vagón 3.
        Bajo(viajero);
        viajero = tranvia.Bajar("Viajero-6", 3); // Se Baja el Viajero-5 del Vagón 3.
        Bajo(viajero);
        viajero = tranvia.Bajar("Viajero-7", 1); // Se Baja el Viajero-5 del Vagón 3.
        Bajo(viajero);

        int vagon = tranvia.Subir(pasajeros[0], 0); // Sube el Viajero-0 al Vagón 0.
        Subio(pasajeros[0], vagon);
        int vagon1 = tranvia.Subir(pasajeros[0], 1); // Sube el Viajero-0 al Vagón 1.
        Subio(pasajeros[0], vagon1);
        int vagon2 = tranvia.Subir(pasajeros[0], 2); // Sube el Viajero-0 al Vagón 2.
        Subio(pasajeros[0], vagon2);
        int vagon3 = tranvia.Subir(pasajeros[0], 3); // Sube el Viajero-0 al Vagón 3.
        Subio(pasajeros[0], vagon3);

        int vagon4 = tranvia.Subir(pasajeros[0], 3); // Sube el Viajero-0 al Vagón 3.
        Subio(pasajeros[0], vagon4);

        int vagon5 = tranvia.Subir(pasajeros[19], 2); // Sube el Viajero-0 al Vagón 3.
        Subio(pasajeros[19], vagon5);

        Console.WriteLine("Pero Siempre que se Baja uno la Lista se Arregla y al Subir Otro Siempre Sube al Último Asiento.");

        viajero = tranvia.Bajar("Viajero-5", 1); // Se Baja el Viajero-5 del Vagón 3.
        Bajo(viajero);

        int vagon6 = tranvia.Subir(pasajeros[10], 2); // Descomenta Esta Línea y Ejecuta, Dará Error, Mira Como en las Posiciones 20 del Vagón 0, 10 del Vagón 1, 15 del Vagón 2 y 5 del Vagón 3, Ahora está el Viajero-0, Son los Últimos 4 que se Subieron. Y Este Último que Intentó Subir Lanzó una Excepción ya que Todos los Vagones Están Llenos.
        Subio(pasajeros[10], vagon6);
        //int vagon7 = tranvia.Subir(pasajeros[11], 2); // Descomenta Esta Línea y Ejecuta, Dará Error, Mira Como en las Posiciones 20 del Vagón 0, 10 del Vagón 1, 15 del Vagón 2 y 5 del Vagón 3, Ahora está el Viajero-0, Son los Últimos 4 que se Subieron. Y Este Último que Intentó Subir Lanzó una Excepción ya que Todos los Vagones Están Llenos.
        //Subio(pasajeros[11], vagon7);
    }

    private static void Bajo(Pasajero viajero) // Muestra los Viajeros que Han Bajado del Tranvía, Recibe el Pasajero.
    {
        if (viajero != null) // Si el Pasajero no es NULL.
        {
            Console.WriteLine($"El Pasajero: {viajero.GetNombre()} Ha Bajado del Tren."); // Muestra Quién Ha Bajado del Tranvía.
        }
        else // Si es NULL.
        {
            Console.WriteLine("El Nombre Recibido no Corresponde a Ningún Pasajero."); // Ese Pasajero No Estaba en el Tranvía.
        }
    }

    private static void Subio(Pasajero pasajero, int vagon)
    {
        Console.WriteLine($"El Pasajero {pasajero.GetNombre()} se Subió al Vagón: {vagon}.");
    }
}