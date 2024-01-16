using System.Linq.Expressions;

namespace Inc_Dec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            int tope = 0;
            bool ok = false;

            Console.WriteLine("Programa que Incrementa y Decrementa una Variable pasada por Nombre(Referencia), Controlando que sea un Valor Válido y Hasta un Tope Válido\n");
            while (!ok)
            {
                Console.Write("Ingresa Un Número: ");
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number > 9 ||  number < 0)
                    {
                        throw new Exception();
                    }
                    ok = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nEl Número Ingresado NO es Correcto. Inténtalo de Nuevo.");
                }
            }
            while (ok)
            {
                Console.Write("Ingresa el Tope para Incrementar: ");
                try
                {
                    tope = int.Parse(Console.ReadLine());
                    if (tope > 11 || tope < 1)
                    {
                        throw new Exception();
                    }
                    ok = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nEl Tope Ingresado NO es Correcto. Inténtalo de Nuevo.");
                }
            }
            if (number >= tope)
            {
                try
                {
                    throw new Exception("No, EL Tope Bebe ser Mayor que el Número");
                    for (int i = 0; i < 20; i++)
                    {
                        Funciones.incrementa(ref number, ref tope);
                        Funciones.show(number);
                    }
                    for (int i = 0; i < 20; i++)
                    {
                        Funciones.decrementa(ref number, ref tope);
                        Funciones.show(number);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}