namespace Tranvía___2;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Trnavía de Fernando - 2");

        Tranvia t = new Tranvia(2);
        Console.WriteLine(t);
        t.Subir(new Pasajero("Juana"), 1);
        t.Subir(new Pasajero("Mari"), 1);
        t.Subir(new Pasajero("Rubén"), 1);
        t.Subir(new Pasajero("Pablo"), 1);
        t.Subir(new Pasajero("Alberta"), 1);
        t.Subir(new Pasajero("Kika"), 1);
        t.Subir(new Pasajero("Laura"), 1);
        Console.WriteLine(t);

        t.Bajar("Pablo", 1);
        Console.WriteLine(t);
    }
}