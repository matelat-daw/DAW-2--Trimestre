public class Pila
{
    public static void apilar(string[] pila, ref int cima, string dato) // Función que recibe la pila, la cima y la string.
    {
        if (llena(pila, cima)) // Llamo a la función llena para saber si aun caben datos en la pipla.
        {
            try
            {
                throw new Exception();
            }
            catch (Exception e)
            {
                Console.WriteLine("La Pila Estaba Llena no se Puede Agregar Ningún Dato Más.");
            }
        }
        else
        {
            pila[++cima] = dato; // Guardo el dato en la pila.
        }
    }

    public static string desapilar(string[] pila, ref int cima) // Función desapilar, recie la pila y la cima.
    {
        string result = "";

        if (!vacia(cima)) // Llamo a la función vacia pasandole la cima
        {
            result = pila[cima--];
        }
        return result; // Devuelve el valor que está en la pila en la cima antes de decrementarla.
    }

    public static bool vacia(int cima) // Función vacia, recibe la cima.
    {
        /* Edad de Piedra.
        if (cima != -1) // Si la cima no es -1.
        {
            return false; // Devuelve false, la pila no está vacia.
        }
        return true; // Si cima es -1 devuelve true, la pila está vacía. */

        /* Edad Media
        return cima == -1 ? true : false; */

        /* Right Now */
        return cima == -1;
    }

    public static bool llena(string[] pila, int cima) // Función Llena, recive la pila y la cima.
    {
        /* Edad de Piedra
        if (pila.Length - 1 == cima) // Si el tamaño de la pila -1 (La última posición de la pila) es igual a la cima.
        {
            return true; // Devuelve true, la pila está llena.
        }
        return false; // Si no, devuelve false, la pila no está llena. */

        /* Edad Media
        return pila.Length - 1 == cima ? true : false;
        */

        /* Right Now */
        return pila.Length - 1 == cima;
    }
}