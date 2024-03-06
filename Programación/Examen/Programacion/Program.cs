namespace Programacion;

public class Program
{
    static void Main(string[] args)
    {
        string[,] array = {{"Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"},
        { "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"},
        { "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"},
        { "Hola", "Hola", "Hola", "Chao", "Hola", "Hola", "Hola", "Hola"},
        { "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"},
        { "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"},
        { "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"},
        { "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"} }; // Array de 8 x 8;

        Console.WriteLine("Pruebas de las Clases del Examen de Programación.");
        Punto punto = Busca(array, "Chao"); // Asigno al Punto punto el Resultado de la Llamada al Método.
        if (punto != null) // Si No Devolvió null.
        {
            Console.WriteLine($"Las Coordenadas don de está la palabra Buscada son X: {punto.GetX()} e Y: {punto.GetY()}");
        }
        else
        {
            Console.WriteLine($"Se ha devuelto un Valor null");
        }
    }

    //public static Punto Busca(string[,] array, string frase)
    //{
    //    Punto punto = null;
    //    Punto c1 = new(2, 2);
    //    Punto c2 = new(4, 4);

    //    for (int i = c1.GetY(); i <= c2.GetY(); i++)
    //    {
    //        for (int j = c1.GetX(); j <= c2.GetX(); j++)
    //        {
    //            if (array[i, j] == frase)
    //            {
    //                punto = new(j, i);
    //            }
    //        }
    //    }
    //    return punto;
    //}

    private static Punto Busca(string[,] array, string frase) // Método.
    {
        Punto punto = null; // Incializo punto a null, si no Encuentra la Frase en el Array Devuelve null.
        Punto c1 = new(2, 2); // Creo un punto con las coordenadas 2, 2.
        Punto c2 = new(5, 6); // Creo otro punto con las coordenadas 4, 4.
        int i = c1.GetY(); // Asigno a i la Coordenada Vertical de Inicio (Y).
        int j = c1.GetX(); // Asigno a j la Coodenada Horizontal de Inicio (X).

        while (i <= c2.GetY() && array[i, j] != frase) // Busqueda Lineal en Y.
        {
            j++; // Incremento j ya que ya se Buscó en la Primera Posición.
            while (j <= c2.GetX() && array[i, j] != frase) // Busqueda Lineal en X.
            {
                j++; // Si no Encuentra la Frase o j aun no Superó el Limite Superior, Incrementa j.
            }
            if (array[i, j] == frase) // A la Salida del while Para j hay que Verificar si la Frase Está en Esas Coordenadas.
            {
                punto = new(j, i); // Si Está la Frase, Creo el Punto con las Coordenadas.
                i = c2.GetY(); // Igual i al Límite Superior.
            }
            i++; // Incrementa i
            j = c1.GetX(); // Reincio j a la Coordenada de Inicio.
        }
        if (array[i, j] == frase) // A la Salida Hay que Volver a Comprobar si La Frase Está en Esas Coordenadas, por si la Encontró Cuando Cambió i. El Problema de esto es que Si la Coordenada Final es la Última del Array al Salir sin Encontrar, i Será Mayor que la Cantidad de Items en el Array y Dará Index Out of Range Exception por ejemplo si i llega a 7 que es la Última Posición en la que se Puede Buscar en el Array y no se Puede Buscar i < c2.GetY(), Porque Estáriamos Dejando Afuera la Última Posición que se Desea Buscar, se Puede Solucionar Preguntando si la Última posición del Rango en el que se quiere Buscar la Frase es la Última, en ese caso hay que hacer el Bucle a i < c2.GetY().
        {
            punto = new(j, i);
        }
        return punto; // Con el Doble Bucle for Es Mucho más Sencillo, Método que está Comentado Arriba, Pruebenlo.
    }
}