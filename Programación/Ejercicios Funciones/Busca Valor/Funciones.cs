public class Funciones
{
    public static int buscarElemento(double[] array, double value)
    {
        int index = 0;

        while (index < array.Length && value != array[index]) // Busqueda Lineal, La Mejor.
        {
            index++;
        }
        return index == array.Length ? -1 : index;

        //while (index < array.Length && value != array[index]) // Busqueda Lineal, Solución Menos Usada.
        //{
        //    index++;
        //}
        //if (index == array.Length)
        //{
        //    index = -1;
        //}
        //return index;

        //while (index < array.Length - 1 && value != array[index]) // Busqueda Lineal.
        //{
        //    index++;
        //}
        //return array[index] == value ? index : -1; // Retorna index si no llegó al final, o -1, No me Gusta Tanto.
    }
}