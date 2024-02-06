public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio de Lista Dinámica, Inserta Datos, Quita Datos y Expande el Array de 10 en 10.\n");
        Milista milista = new Milista();
        milista.insertar(0, 1);
        milista.insertar(0, 2);
        milista.insertar(0, 3);
        milista.insertar(0, 4);
        milista.insertar(0, 5);
        milista.insertar(2, 88);
        milista.insertar(0, 3);
        milista.insertar(0, 4);
        milista.insertar(0, 5);
        milista.insertar(2, 88);
        milista.insertar(0, 999);
        milista.insertar(0, 1);
        milista.insertar(0, 2);
        milista.insertar(0, 3);
        milista.insertar(0, 4);
        milista.insertar(0, 5);
        milista.insertar(2, 88);
        milista.insertar(0, 3);
        milista.insertar(0, 4);
        milista.insertar(0, 5);
        milista.insertar(2, 88);
        milista.insertar(0, 999);
        milista.insertar(0, 3);
        milista.insertar(0, 4);
        milista.insertar(0, 5);
        milista.insertar(2, 88);
        milista.insertar(0, 3);
        milista.insertar(0, 4);
        milista.insertar(28, 777);
        milista.insertar(29, 888);
        milista.insertar(30, 999);
        milista.mostrar();

        Console.WriteLine("\nEl Tamaño del Array es: {0}", milista.Qtty);

        while (milista.Qtty > 5) // Uso el Valor de qtty, la Cantidad de Datos que Hay en el Array.
        {
            milista.mostrar();
            Console.WriteLine("\n");
            milista.extraer(0);
        }

        milista.mostrar();
        Console.WriteLine("Extrayendo.\n\nEl Tamaño del Array es: {0}", milista.Qtty);
    }
}