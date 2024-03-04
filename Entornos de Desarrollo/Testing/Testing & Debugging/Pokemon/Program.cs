public class Program
{
    private static string? directorioBase; // Carpeta de Destino, Documentos.
    private static string? pathFile; // Está Compuesta por la Carpeta de Destino y el Nombre del Fichero.
    private static List<string> listLines; // Contiene la Líneas de Cada Pokemon, los Datos Separados por , Línea a Línea.

    static void Main(string[] args)
    {
        Console.WriteLine("Este Programa te Mostrará el Pokemon con Más Potencia de Ataque de la Generación que Elijas.");
        Console.Write("Ingresa el Número de Generación que Prefieras(1-6): ");
        int generation = int.Parse(Console.ReadLine()); // Entrada por Teclado de la Generación
        if (generation > 0 && generation < 7) // Verifico que esté entre 1 y 6.
        {
            directorioBase = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + Path.DirectorySeparatorChar + "Documents" + Path.DirectorySeparatorChar;
            string result = StrongestPokemon("pokemon.csv", generation); // Llama al Método para saber Cual es el Pokemos com más Ataque de su Generación.
            Console.WriteLine("El Pokemon de la Generación: {0} que más Ataque tiene es: {1}", generation, result); // Muestra el Resutado.

            FilterPokemon(directorioBase); // Llama al Método que Almacena en un Fechero los Pokemon que Son de 2 Tipos.
        }
        else // Si No.
        {
            Console.WriteLine("La Generación es un Número entre 1 y 6, Intentalo de Nuevo.");
        }
    }

    public static String StrongestPokemon(string rutaFichero, int generation) // Método para Saber Cual es el Pokemon con más Ataque, recibe el fichero y la generación.
    {
        int i; // Uso i Para un Bucle for.
        int j = 0; // Uso j Para un Bucle for.
        string result = ""; // El Resutlado se Asignará a esta Variable.

        List<int> attack = []; // Contiene Solo el Ataque de los Pokemos de la Generación Deseada.
        List<string> datos = []; // Constiene Todos los Datos de los Pokemon, Separados.
        
        pathFile = directorioBase + rutaFichero; // Asigna a pathfile la Carpeta + el Nombre del Fichero.

        listLines = [.. File.ReadAllLines(pathFile)]; // Leo desde el Fichero Línea a Línea y Asigno cada Línea a listLines.
        for (i = 0; i < listLines.Count; i++) // Bucle al Tamaño de listLines.
        {
            string[] aux = listLines[i].Split(','); // Hago un split por la , de cada Línea en listLines y se lo Asigno al Array de Strings aux.
            for (j = 0; j < aux.Length; j++) // Bucle al Tamaño del Array aux.
                datos.Add(aux[j]); // Almaceno en datos Cada Valor por Separado de los Pokemon.
        }
        for (i = 24; i < datos.Count; i+= 13) // Bucle Empezando Desde 24 que es el Primer Valor de Generación que me Interesa e Incrementando en 13, la Cantidad d Datos de Cada Pokemon.
        {
            if (int.Parse(datos[i]) == generation) // Compruebo que el Dato en datos en la Posición i sea Igual que la Generación Pasada por Parámetro(Seleccionada).
            {
                if (datos[i + 1].ToLower() != "true") // Compruebo que la Siguiente posición, Legendario, no Esté a true.
                {
                    attack.Add(int.Parse(datos[i - 5])); // Asigno a attack todos los datos en el Índice i - 5, convirtiendolo a int, ahí está el Ataque de los Pokemon.
                }
            }
        }
        int numero = attack.Max(); // Obtengo el Valor más alto de la Lista atack.
        for (i = 24; i < datos.Count; i+=13) // Vuelvo a Hacer un Bucle Completo a Todos los datos.
        {
            if (int.Parse(datos[i - 5]) == numero && int.Parse(datos[i]) == generation) // Compruebo que el Ataque más Alto Obtenido Anteriormente lo Tiene un Pokemon de la Generación Seleccionada.
            {
                result = datos[i - 10]; // Le asigno la posición en la que está el Nombre del Pokemon a result.
            }
        }
        return result; // Retorna result.
    }

    public static void FilterPokemon(string rutaFichero) // Método para Guardar los Pokemon de 2 Tipos en un Fichero.
    {
        string filename = "pokemonDosTipos.csv"; // Nombre del Fichero.

        using StreamWriter outputFile = new(Path.Combine(rutaFichero, filename)); // Crea un StreamWriter, para Almacenar en un Fichero.
        foreach (string line in listLines) // Para Cada Línea de listLines (Lista en la que Están las Líneas Separadas por , de los Pokemon).
        {
            string[] aux = line.Split(','); // Hago un split por la , en el Array de Strings aux.
            if (aux[2] != "" && aux[3] != "") // Compruebo si los Índices 2 y 3 en el Array aux no están Vacios.
            {
                outputFile.WriteLine(line); // Escribe en el Fichero la Linea Completa.
            }
        }
    }
}