internal class Program
{
    static void Main(string[] args)
    {
        string frase = "-La   Cosa  Está que \t Arde. \n- Cierto Así es.";
        string triming;
        string[] result;

        Console.WriteLine("Este Programa Cuenta los Items que Hay en una Frase, separandolos por el caracter Espacio ' '.\n");
        Console.WriteLine("La Frase Está Compuesta Por: {0}", Funciones.cuentaItems(frase));
        triming = Console.ReadLine();

        Console.WriteLine("La Frase es: {0} y el tamaño es: {1}", Funciones.trim(triming), Funciones.trim(triming).Length);

        result = Funciones.split(frase);

        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine("\n{0}", result[i]);
        }
    }
}