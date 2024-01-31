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
        milista.mostrar();
        //milista.extraer(1);
        //milista.mostrar();
        //milista.extraer(3);
        //milista.mostrar();
    }

    public class Milista
    {
        private int[] array = new int[10];
        private int qtty = 0;

        public void insertar(int position, int num)
        {
            if (position < 0 || position > qtty)
                throw new Exception("ERROR");
            if (array.Length == qtty)
            {
                int[] array_aux = new int[array.Length + 10];
                for (int i = 0; i < array.Length; i++)
                {
                    array_aux[i] = array[i];
                }
                array = new int[array_aux.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = array_aux[i];
                }
            }
            for (int i = qtty; i > position; i--) // Bucle desde la Última Posición del Array, Hasta la posición + 1, Decrementando el Índice.
            {
                array[i] = array[i - 1]; // Muevo los Elementos del Array de Detrás Para Adelante.
            }
            array[position] = num; // Pongo el Número Pasado Como Parámetro en la Posición Pasada Como Parámetro.
            qtty++; // Incremento la Cantidad de Datos en el Array.

        }

        public int extraer(int position)
        {
            int aux;

            if (position < 0 || position >= qtty)
                throw new Exception();
            aux = array[position];
            for (int i = position + 1; i < qtty; i++) // Bucle desde la Posición Siguiente a la Posición Pasada del Array, Hasta la Última Posición del Array Incrementando el Índice.
            {
                array[i - 1] = array[i]; // Muevo los Elementos del Array de Delante Para atrás.
            }
            qtty--; // Incremento la Cantidad de Datos en el Array.
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