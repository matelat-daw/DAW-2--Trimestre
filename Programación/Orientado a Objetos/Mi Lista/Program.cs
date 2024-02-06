public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio de Lista Dinámica, Inserta Datos, Quita Datos y Expande el Array de 10 en 10.\n");
        Milista milista = new Milista();
        milista.insertar(0, 1);
        milista.insertar(0, 2);
        milista.insertar(0, 3);
        milista.insertar(0, 4);
        milista.insertar(0, 5);
        milista.insertar(2, 88);
        milista.insertar(0, 3);
        milista.insertar(0, 4);
        milista.insertar(0, 5);
        milista.insertar(2, 88);
        milista.insertar(0, 999);
        milista.insertar(0, 1);
        milista.insertar(0, 2);
        milista.insertar(0, 3);
        milista.insertar(0, 4);
        milista.insertar(0, 5);
        milista.insertar(2, 88);
        milista.insertar(0, 3);
        milista.insertar(0, 4);
        milista.insertar(0, 5);
        milista.insertar(2, 88);
        milista.insertar(0, 999);
        milista.insertar(0, 3);
        milista.insertar(0, 4);
        milista.insertar(0, 5);
        milista.insertar(2, 88);
        milista.insertar(0, 3);
        milista.insertar(0, 4);
        milista.insertar(28, 777);
        milista.insertar(29, 888);
        milista.insertar(30, 999);
        milista.mostrar();

        Console.WriteLine("\nEl Tamaño del Array es: {0}", milista.Qtty);

        while (milista.Qtty > 5) // Uso el Valor de qtty, la Cantidad de Datos que Hay en el Array.
        {
            Console.WriteLine("Se Exatrjo el Valor:{0} de la posición: {1}", milista.extraer(0), milista.Qtty);
        }

        milista.mostrar();
        Console.WriteLine("Extrayendo.\n\nEl Tamaño del Array es: {0}", milista.Qtty);

        // Console.WriteLine("{0}", Milista.TAM_INI); // Para Acceder a un atributo de otra clase que sea const o static además tiene que ser public.
    }

    public class Milista
    {
        // private const int TAM_INI = 10;
        public const int TAM_INI = 10;
        private const int TAM_CREC = 10;
        private int[] array = new int[TAM_INI];
        private int qtty = 0;

        public int Qtty // Getter de la Variable Privada qtty.
        {
            get { return qtty; }
        }

        public void insertar(int position, int num)
        {
            if (position < 0 || position > qtty)
                throw new Exception("ERROR");
            if (array.Length == qtty)
            {
                expand();
            }
            for (int i = qtty; i > position; i--) // Bucle desde la Última Posición del Array, Hasta la posición + 1, Decrementando el Índice.
            {
                array[i] = array[i - 1]; // Muevo los Elementos del Array de Detrás Para Adelante.
            }
            array[position] = num; // Pongo el Número Pasado Como Parámetro en la Posición Pasada Como Parámetro.
            qtty++; // Incremento la Cantidad de Datos en el Array.

        }

        private void expand() // Expande el Array Original.
        {
            int[] array_aux = new int[array.Length + TAM_CREC]; // Primero creo un array auxiliar con 10 datos más que el original.
            for (int i = 0; i < array.Length; i++) // Hago un bucle hasta el tamaño del array original.
            {
                array_aux[i] = array[i]; // Paso los valores del array original al auxiliar.
            }
            array = array_aux; // Así se asigna el array nuevo(auxiliar) al original, no hace falta crear el original de nuevo con el tamaño del auxiliar y pasarle los datos en un bucle.
        }

        public int extraer(int position) // Extrae el valor en la posición pasada por parametro(Lo quita del array y reordena).
        {
            int aux;

            if (position < 0 || position > qtty)
                throw new Exception();
            aux = array[position];
            for (int i = position + 1; i < qtty; i++) // Bucle desde la Posición Siguiente a la Posición Pasada del Array, Hasta la Última Posición del Array Incrementando el Índice.
            {
                array[i - 1] = array[i]; // Muevo los Elementos del Array de Delante Para atrás.
            }
            qtty--; // Decremento la Cantidad de Datos en el Array.
            if (qtty < 0)
            {
                qtty = 0;
            }
            return aux;
        }

        public void mostrar() // Método que Muestra el Contenido del Array.
        {
            for (int i = 0; i < qtty; i++) // Bucle desde 0 Hasta el tamaño del Array - 1.
            {
                Console.WriteLine("En la Posición {0} del Array hay: {1}", i, array[i]); // Muestro los Datos.
            }
            Console.WriteLine();
        }
    }
}