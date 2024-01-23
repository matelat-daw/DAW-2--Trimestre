public class Program
{
    static void Main(string[] args)
    {
        double[] array = [1.2, 2.3, 3.4, 4.5, 5.6, 6.7, 7.8, 8.9, 9.1, 10.1, 11.2, 12.3, 13.4, 14.5];
        double[] nuevoarray;

        Console.WriteLine("Este Programa Usa una Funciona a la que se le Pasa un Array de Valores de Tipo double y una Posición y Devuelve un Nuevo Array Con los Datos a Partir de la Nueva Posición Más 1.\n");
        nuevoarray = Funciones.filtrarDatos(array, 6);

        Funciones.showForEach(nuevoarray);
    }
}