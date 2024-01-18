public class Ejercicio4
{
    static void Main(string[] args)
    {
        Console.WriteLine("Este Programa Llama a la Función check() Pasándole un Año y Nos Dirá si es un Año Bisiesto o No.\n");

        if (Funciones4.check(1968)) // Llama a la Función check(1968) a la que le Pasa un Número que es un Año y Devuelve true o false.
        {
            Console.WriteLine("Bisiesto."); // Si Devuelve True, es Año Bisiesto.
        }
        else // Si Devuelve False.
        {
            Console.WriteLine("El Año no es Bisiesto."); // No es Bisiesto.
        }
    }
}