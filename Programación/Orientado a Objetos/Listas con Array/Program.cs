public class Program
{
    static void Main(string[] args)
    {
        int[] array = [22, 33, 44, 55, 66, 77, 0, 0, 0, 0];
        int num = 0;
        int position = -1;
        int qtty = 6;

        Console.WriteLine("Este Programa Pone o Quita un Dato en un Array en la Posición Seleccionada por el Usuario, Moviendo los demás Datos del Array.\n");
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
                    Funciones.mostrar(array, qtty); // Llama a la Función Mostrar de la lase Funciones.
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
        do
        {
            Console.Write("Ingresa la Posición a Eliminar del Array: ");
            try
            {
                position = int.Parse(Console.ReadLine());
                if (position != -1)
                {
                    Console.WriteLine("El Número en la Posición Seleccioanda era: {0}", Funciones.extraer(array, ref qtty, position));
                    Funciones.mostrar(array, qtty); // Llama a la Función Mostrar de la lase Funciones.
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Eso no Parece una Posición Valida. Intentalo de Nuevo.");
            }
        } while (position != -1);
    }
}