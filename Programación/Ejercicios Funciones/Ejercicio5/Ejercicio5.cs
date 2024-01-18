public class Ejercicio5
{
    static void Main(string[] args)
    {
        int num; // Se Pide el Número a COntar las Cifras Por Teclado.

        Console.WriteLine("Este Programa Llama a la Función cifras() Pasándole un Número Entro Mayor que 0 y Muestra de Cuantas Cifras Está Compuesto.\n");
        num = int.Parse(Console.ReadLine()); // Se Pide el Número.

        Console.WriteLine("El Número de Cifras del Número: {0}, es: {1}", num, Funciones5.cifras(num)); // Muestra el Resultado de la Función cifras(num) que Devuelve Cuantas Cifras tiene el Número Pasado por Parámetro.
    }
}