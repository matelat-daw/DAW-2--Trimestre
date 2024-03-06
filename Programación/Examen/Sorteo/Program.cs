namespace Sorteo;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Prueba de la Clase Sorteo.");
        Console.Write("\nIngrea un Numero para generar el Número Secreto:");
        int secreto = int.Parse(Console.ReadLine());
        Sorteo sorteo = new Sorteo(secreto);
        Console.Write("\nIngrea Tú Numero para Jugar:");
        int numero = int.Parse(Console.ReadLine());
        int resultado = sorteo.Intentar(numero);
        if (resultado == 0)
        {
            Console.WriteLine($"Has Acertado. El Número Secreto Era: {sorteo.ToString()}");
        }
        else
        {
            Console.WriteLine($"Fallaste, Recibiste: {resultado}");
        }
    }
}