namespace Batalla_Naval_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string coord;

            Funciones.fillTablero();
            Funciones.showTablero(false);
            do
            {
                Console.Write("\n\nIngresa las Coordenadas Ej: A1, E5, J10 (0 en Cualquier Momento para Salir.): ");
                coord = Console.ReadLine().ToUpper();
                if (coord != "0")
                {
                    try
                    {
                        Funciones.disparo(coord);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("NO, La Coordenada No es Correcta, Inténtalo de Nuevo.\n Presiona ENTER para Continuar.");
                        Console.ReadKey();
                    }
                }
                Funciones.showTablero(false);
            }
            while (coord != "0");
            Funciones.showTablero(true);
        }
    }
}