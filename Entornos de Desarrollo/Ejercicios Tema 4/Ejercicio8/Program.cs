Console.Write("Nombre de la Madre: ");
String mName = Console.ReadLine();
Console.Write("\nNombre del Padre: ");
String fName = Console.ReadLine();
Console.Write("\nSexo del Bebé? M o F: ");
String genero = Console.ReadLine();

String mitad1 = sacarMitadNombre(mName); // Asigna a la variable mitad1 de tipo String el resultado de la llamada a la función sacerMitadNombre(mName) que recibe como parámetro una string.
String mitad2 = sacarMitadNombre(fName);
String nombre = "";
if (genero.ToUpper().StartsWith("M"))
{
    nombre = mitad2 + mitad1;
}
else
{
    nombre = mitad1 + mitad2;
}
Console.WriteLine("Nombre sugerido: {0}", nombre.ToUpper());

static String sacarMitadNombre(String nombre) // La Función sacarMitadNombre recibe una String y con substring obtiene la primera mitas de la String.
{
    int indiceMedio = (nombre.Length + 1) / 2; // Asigna a la variable de tipo entero indiceMedio el tamaño de la String recibida incrementada en 1 y divida por 2.
    String mitad = nombre.Substring(0, indiceMedio); // Asigna a la variable de tipo String mitad, el resultado de aplicar substring desde 0 a indiceMedio a la String recibida.
    return mitad; // Devuelve la String mitad.
}