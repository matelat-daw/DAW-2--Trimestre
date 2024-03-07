namespace Programacion;

public class Program
{
    static void Main(string[] args)
    {
        string[,] array = {{"Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"},
        { "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"},
        { "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"},
        { "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"},
        { "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"},
        { "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Chao", "Hola"},
        { "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"},
        { "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola", "Hola"} }; // Array de 8 x 8;

        Console.WriteLine("Pruebas de las Clases del Examen de Programación.");
        Punto punto = Busca(array, "Chao"); // Asigno al Punto punto el Resultado de la Llamada al Método.
        if (punto != null) // Si No Devolvió null.
        {
            Console.WriteLine($"Las Coordenadas donde está la Frase Buscada son X: {punto.GetX()} e Y: {punto.GetY()}");
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
        Punto c2 = new(7, 7); // Creo otro punto con las coordenadas 4, 4.
        int i_aux = -1; // Uso el i_aux Para Conservar el Valor de i si Encuentro la Cadena en j.
        int j_aux = -1; // Uso j_aux Para Conservar el Valor de j si Encuentro la Cadena en j, ya que el Salir del Bucle j se Reinícia.
        bool encontrado = false; // El Booleano se pone a true si Encuentra la Cadena en j.
        int i = c1.GetY(); // Asigno a i la Coordenada Vertical de Inicio (Y).
        int j = c1.GetX(); // Asigno a j la Coodenada Horizontal de Inicio (X).

        while (i <= c2.GetY() && array[i, j] != frase) // Busqueda Lineal en Y.
        {
            j++; // Incremento j ya que ya se Buscó en la Primera Posición.
            while (j <= c2.GetX() && array[i, j] != frase) // Busqueda Lineal en X.
            {
                j++; // Si no Encuentra la Frase o j aun no Superó el Limite Superior, Incrementa j.
            }
            if (j <= c2.GetX()) // A la Salida del while Para j hay que Verificar si j no es Mayor que el Límite Máximo de Busqueda.
            {
                encontrado = true; // Si se Encontró la Frase, Pongo encontrado a true.
                i_aux = i; // Asigno el Valor de i a i_aux, para Tener el Valor de i Donde Está la Frase.
                j_aux = j; // Asigno el Valor de j a j_aux, para Tener el Valor de j Donde Está la Frase.
                i = c2.GetY(); // Igualo i al Límite Superior, Para Salir del Bucle Exterior.
            }
            i++; // Incrementa i
            j = c1.GetX(); // Reincio j a la Coordenada de Inicio.
        }
        if (i > c2.GetY() && encontrado) // Si Salió del Bucle Externo con i Mayor que el Límite pero encontrando la Frase.
        {
            punto = new(j_aux, i_aux); // Creo el Punto punto con las Coordenadas j_aux(X), i_aux(Y).
        }
        else if (i <= c2.GetY()) // Si no se Cumple la Condición Anterior, Compruebo si i es Menor que el Límite de Busqueda
        {
            punto = new(j, i); // Si es así es que Encontró la Frase en j, i, Instancio el Punto con las Coordenadas j(X) e i(Y).
        }
        return punto; // Devuelvo el punto.
    }
}