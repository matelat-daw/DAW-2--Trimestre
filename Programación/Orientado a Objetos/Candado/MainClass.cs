public class MainClass
{
    static void Main(string[] args)
    {
        int code;
        int cont = 0;

        Console.WriteLine("Programa Para Abrir y Cerrar un Candado con un Código Desconocido.\n");
        Candado candado = new Candado();
        Console.WriteLine("El Candado está: {0}", candado.tuString());
        do
        {
            cont++;
            Console.Write("Ingresa el Código (Número de 0 a 10): ");
            code = int.Parse(Console.ReadLine());
            candado.abrir(code);
        } while (!candado.estaCerrado());
        Console.WriteLine("Lo Has Conseguido en: {0} Intentos.", cont);
        Console.WriteLine(candado.tuString());
    }
}