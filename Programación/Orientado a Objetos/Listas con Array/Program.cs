public class Program
{
    static void Main(string[] args)
    {
        int[] array = [22, 33, 44, 55, 66, 77, 0, 0, 0, 0];
        int num = 0;
        int position = -1;
        int qtty = 6;

        Console.WriteLine("Este Programa Pone un Dato en un Array en la Posición Seleccionada por el Usuario, Moviendo los demás Datos Hacia el Fondo de Array.\n");
        do
        {
            Console.Write("Ingresa el Número a Introducir en el Array: ");
            try
            {
                num = int.Parse(Console.ReadLine()); // Intenta Convertir la Entrada por Teclado a Entero.
                if (num != 0) // Si el Número es Distinto de 0.
                {
                    Console.Write("Ingresa la Posición del Número en el Array: ");
                    try
                    {
                        position = int.Parse(Console.ReadLine()); // Intenta Convertir la Entrada por Teclado a Entero.
                    }
                    catch (Exception e) // Si no se Puede Convertir.
                    {
                        Console.WriteLine("Eso no Parece una Posición Valida. Intentalo de Nuevo.");
                    }
                    Funciones.insertar(array, ref qtty, position, num); // Si toda ha ido Bien Llama a la Función insertar de la Clase Funciones, Pasándole los Parámetros.
                    Funciones.mostrar(array); // Llama a la Función Mostrar de la lase Funciones.
                }
            }
            catch (Exception e) // Si no se Puede Convertir.
            {
                string errMsg = e.GetBaseException().Message;
                if (errMsg == "ERROR")
                {
                    Console.WriteLine("Eso no Parece una Posición Valida. Intentalo de Nuevo.");
                }
                else
                {
                    Console.WriteLine("Eso no Parece un Número Valido. Intentalo de Nuevo.");
                    num = -1; // Si Hubo El Error al COnvertir el Número se le Asigna un Valor Numerico Distinto de 0 para Volver a Solicitar los Datos.
                }
            }
        } while (num != 0);
    }
}