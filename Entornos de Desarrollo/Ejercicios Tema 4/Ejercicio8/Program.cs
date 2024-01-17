namespace Ejercicio8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nombre de la Madre: ");
            String mName = Console.ReadLine();
            Console.Write("\nNombre del Padre: ");
            String fName = Console.ReadLine();
            Console.Write("\nSexo del bebé? M o F: ");
            String genero = Console.ReadLine();

            String mitad1 = sacarMitadNombre(mName);
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
        }

        static String sacarMitadNombre(String nombre)
        {
            int indiceMedio = (nombre.Length + 1) / 2;
            String mitad = nombre.Substring(0, indiceMedio);
            return mitad;
        }
    }
}