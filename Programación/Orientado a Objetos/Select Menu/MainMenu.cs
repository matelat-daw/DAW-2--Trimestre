public class MainMenu
{
    static void Main(string[] args)
    {
        int selection = 0;

        Menu menu = new Menu();
        menu.añadir("Carne Fiesta");
        menu.añadir("Pollo Con Papas");
        menu.añadir("Pescado con Arroz");
        menu.añadir("Verduras Asadas");
        menu.añadir("Sushi Maky");
        Console.WriteLine("Este Programa Crea un Menú de Opciones.\n");
        Console.WriteLine("Tienes: {0} Opciones.\n", menu.getOpciones());
        menu.show();
        Console.Write("Que Posición del Menú Quieres Consultar?(0 Para Salir): ");
        try
        {
            selection = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Eso no parece ser un Número Intentalo de Nuevo.", ex.ToString());
            selection = 6;
        }

        selection = menu.insert();

        Console.WriteLine();
        while (selection > 0)
        {
            Console.WriteLine("{0}", menu.mostrar(selection));
            Console.WriteLine("\nPresiona Cualquier Tecla");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Este Programa Crea un Menú de Opciones.\n");
            menu.show();
            selection = menu.insert();
            Console.WriteLine();
        }
    }
}