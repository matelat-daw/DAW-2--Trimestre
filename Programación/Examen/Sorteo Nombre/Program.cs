namespace Sorteo_Nombre;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        PruebaSorteo();
        PruebaSorteoSinDuplicados();
    }

    private static void PruebaSorteo()
    {
        string[] nombresArray = ["Pedro", "Anastasia", "Ludovico"];

        Sorteo s = new Sorteo();
        s.Incluir("Ana");
        s.Incluir(nombresArray);
        s.Incluir("Mararía");
        s.Incluir("Mararía");
        s.Incluir("Mararía");
        Console.WriteLine($"Candidatos: {s}.\n");
        Console.WriteLine("Los tres seleccionados son:");
        for (int i = 0; i < 3; i++)
            Console.WriteLine($" - {s.Seleccionar()}");
        Console.WriteLine($"Los no seleccionado fueron:\n{s}");
    }

    private static void PruebaSorteoSinDuplicados()
    {
        string[] nombres = ["Pedro", "Pedro", "Anastasia", "Ludovico", "Pedro", "Pedro"];

        Sorteo s = new SorteoSinDuplicados();
        s.Incluir("Ana");
        s.Incluir(nombres);
        s.Incluir("Mararía");
        s.Incluir("Mararía");
        s.Incluir("Mararía");
        Console.WriteLine($"Candidatos: {s}.\n");
        Console.WriteLine("Los tres seleccionados son:");
        for (int i = 0; i < 3; i++)
            Console.WriteLine($" - {s.Seleccionar()}");
        Console.WriteLine($"Los no seleccionado fueron:\n{s}");
    }
}