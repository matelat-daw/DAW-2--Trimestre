public class Program
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
        //try
        //{
        //    selection = int.Parse(Console.ReadLine());
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Eso no parece ser un Número Intentalo de Nuevo.", ex.ToString());
        //    selection = 6;
        //}

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

    public class Menu
    {
        private int counter = 0;
        private int position;
        private string[] list = new string[10];

        public void añadir(string data)
        {
            if (full())
            {
                throw new Exception();
            }
            list[position] = data;
            position++;
        }

        public string mostrar(int position)
        {
            if (position > this.position)
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception e)
                {
                    if (counter > 2)
                    {
                        throw new Exception();
                    }
                    counter++;
                    Console.WriteLine("Esa Opción no está Disponible, Intentalo de Nuevo. Cuidado te Quedan: {0} Opciones.", 3 - counter);
                }
            }
            return list[position - 1];
        }

        public void show()
        {
            for (int i  = 0; i < position; i++)
            {
                Console.WriteLine("\n{0}): {1}", i + 1, list[i]);
            }
            Console.WriteLine();
        }

        public int getOpciones()
        {
            return position;
        }

        private bool full()
        {
            return list.Length == position;
        }

        public int insert()
        {
            int result;

            try
            {
                result = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eso no parece ser un Número Intentalo de Nuevo.", ex.ToString());
                result = 6;
            }
            return result;
        }
    }
}