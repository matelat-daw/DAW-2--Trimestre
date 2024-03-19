namespace Tranvía___1;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Primer Tanvía de Fernando.");
        Tranvia t = new();
        Console.WriteLine(t);
        t.Subir(new Pasajero("Garcia"), 2);
        t.Subir(new Pasajero("Jana"), 2);
        t.Subir(new Pasajero("Felipe"), 2);
        t.Subir(new Pasajero("Ana"), 2);
        t.Subir(new Pasajero("Alba"), 2);
        t.Subir(new Pasajero("Gustavo"), 2);
        Console.WriteLine(t);

        Pasajero? p = t.Bajar("Gustavo", 2);
        Console.WriteLine(t.Subir(p, 0));
    }
}