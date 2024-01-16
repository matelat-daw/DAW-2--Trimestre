internal class Program
{
    static void Main(string[] args)
    {
        string[] pila; // Tabla que contendrá la pila.
        int size; // Variable para saber el tamaño de la pila.
        int cima = -1; // La cimase inicializa a -1.

        Console.WriteLine("Programa que Rellena y Comprueba una Pila de Strings.\n");
        Console.Write("Ingresa el Tamaño de la Pila: ");
        size = int.Parse(Console.ReadLine()); // Pido el tamaño de la pila
        pila = new string[size]; // Creo una tabla de strings, pila con el tamaño ingresado por teclado.

        Pila.apilar(pila, ref cima, "Plutón"); // Apila datos en la pila.

        if (Pila.vacia(cima)) // Llama a la función vacia que devuelve un booleano.
        {
            Console.WriteLine("La Pila está Vacía. Llamada al Método vacia.");
        }
        else
        {
            Console.WriteLine("La Pila NO está Vacía. Llamada al Método vacia.");
        }

        Pila.apilar(pila, ref cima, "Mercurio"); // Apila datos en la pila.
        Pila.apilar(pila, ref cima, "Venus");
        Pila.apilar(pila, ref cima, "Tierra");
        Pila.apilar(pila, ref cima, "Marte");
        Pila.apilar(pila, ref cima, "Júpiter");
        Pila.apilar(pila, ref cima, "Saturno");
        Pila.apilar(pila, ref cima, "Urano");
        Pila.apilar(pila, ref cima, "Neptuno");

        if (Pila.llena(pila, cima)) // Llama a la función llena que devuelve un booleano.
        {
            Console.WriteLine("La Pila Está Llena. Llamada al Método llena.");
        }
        else
        {
            Console.WriteLine("La Pila NO Está Llena. Llamada al Método llena.");
        }

        while (!Pila.vacia(cima)) // Minetras la pila no esté vacia.
        {
            Console.WriteLine(Pila.desapilar(pila, ref cima)); // Llama a la función desapilar, la variable cima se decrementa y al pasarla por referencia cambia su valor en cada llamada hasta que sea -1, cuando la pila estará vacía y abandonará el bucle.
        }
    }
}