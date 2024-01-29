public class Program
{
    static void Main(string[] args)
    {
        int selection = 0;

        Menu menu = new Menu();
        menu.añedir("Carne Fiesta");
        menu.añedir("Pollo Con Papas");
        menu.añedir("Pescado con Arroz");
        menu.añedir("Verduras Asadas");
        menu.añedir("Sushi Maky");
        while (selection != -1)
        {
            Console.WriteLine("Este Programa Crea un Menú con 10 Opciones.\n");
            menu.mostrar();
            Console.Write("Que Posición del Menú Quieres Consultar?: ");
            selection = int.Parse(Console.ReadLine());

            menu.mostrar(selection);
            Console.WriteLine("\nPresiona Cualquier Tecla");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public class Menu
    {
        int position;
        List<string> list = new List<string>();

        public void añedir(string data)
        {
            list.Add(data);
            position++;
        }

        public void mostrar(int position)
        {
            if (position > this.position || position == -1)
            {
                throw new Exception();
            }
            Console.WriteLine("{0}", list[position]);
        }

        public void mostrar()
        {
            for (int i  = 0; i < list.Count; i++)
            {
                Console.WriteLine("\n{0}): {1}", i, list[i]);
            }
        }
    }
}