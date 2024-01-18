public class Ejercicio6
{
    static void Main(string[] args)
    {
        int size = 5;

        Console.WriteLine("Este Programa Calcula la Media de los Valores de un Array que se Rellena con la Función fill() del Ejercicio3.\n");

        Console.Write("El Array es: ");
        Funciones3.fill(size); // Llamo a la Función fill(size) de la Clase Función3 que está en el Proyecto Ejercicio3, Para Poder Usar un Método que Está en una Clase en Otro Proyecto Hay que Agregar la Referencia al Proyecto: Botón Derecho sobre el Proyecto Ejercicio6 Add o Agregar, Project Reference o Referencia a Proyecto y en la Ventana que se Abre hay que Seleccionar el Proyecto que se Necesite Referenciar, en Este Caso el Proyecto Ejercicio3.
        Console.WriteLine("\n");
        Funciones6.calcula(Funciones3.array); // Llamo a la Función calcula(Funcione3.array) Pasándole Como Parámetro el Array Creado y Rellenado en el Proyecto Ejercicio3.
    }
}