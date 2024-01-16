internal class Program
{
    static void Main(string[] args)
    {
        string frase = "-La   Cosa  Está que \t Arde. \n- Cierto Así es.";

        Console.WriteLine("Este Programa Cuenta los Items que Hay en una Frase, separandolos por el caracter Espacio ' '.\n");
        Console.WriteLine("La Frase Está Compuesta Por: {0}", Funciones.cuentaItems(frase));
    }
}