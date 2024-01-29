public class Program
{
    static void Main(string[] args)
    {
        int selection;

        Menu menu = new Menu();
        menu.añadir("Carne Fiesta");
        menu.añadir("Pollo Con Papas");
        menu.añadir("Pescado con Arroz");
        menu.añadir("Verduras Asadas");
        menu.añadir("Sushi Maky");
        Console.WriteLine("Este Programa Crea un Menú de Opciones.\n");
        menu.show();
        Console.Write("Que Posición del Menú Quieres Consultar?(0 Para Salir): ");
        selection = int.Parse(Console.ReadLine());
        Console.WriteLine();
        while (selection > 0)
        {
            menu.mostrar(selection);
            Console.WriteLine("\nPresiona Cualquier Tecla");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Este Programa Crea un Menú de Opciones.\n");
            menu.show();
            Console.Write("Que Posición del Menú Quieres Consultar?(0 Para Salir): ");
            selection = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }
    }

    public class Menu
    {
        int position;
        List<string> list = new List<string>();

        public void añadir(string data)
        {
            list.Add(data);
            position++;
        }

        public void mostrar(int position)
        {
            if (position > this.position)
            {
                throw new Exception();
            }
            Console.WriteLine("{0}", list[position - 1]);
        }

        public void show()
        {
            for (int i  = 0; i < list.Count; i++)
            {
                Console.WriteLine("\n{0}): {1}", i + 1, list[i]);
            }
            Console.WriteLine();
        }
    }
}