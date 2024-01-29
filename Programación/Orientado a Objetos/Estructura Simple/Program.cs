public class Program
{
    static void Main(string[] args)
    {
        Pila p;
        p = new Pila();
        p.desapilar();
        p.apilar("Hola");
        p.apilar("Chau");
        p.apilar("Adios");
        p.apilar("Me Voy");
        while (!p.vacia())
        {
            Console.WriteLine("En la Pila hay: {0}", p.desapilar());
        }
        Pila p2;
        p2 = new Pila();
        p2.apilar("Ford");
        p2.apilar("Toyota");
        p2.apilar("Ferrari");
        p2.apilar("Lamborghini");
        while (!p2.vacia())
        {
            Console.WriteLine("En la Pila hay: {0}", p2.desapilar());
        }

    }
}

class Pila
{
    public string[] datosPila = new string[100];
    public int cima = -1;

    public void apilar(string dato) // Función apilar, Recibe la String a Apilar (dato).
    {
        if (llena()) // Llamo a la función llena para saber si aun caben datos en la pila, Siempre Hay que Verificar si la Pila Está Llena Antes de Apilar.
        {
            try
            {
                throw new Exception();
            }
            catch (Exception e)
            {
                Console.WriteLine("La Pila Estaba Llena no se Puede Agregar Ningún Dato Más. Cometiste el Error: {0}", e);
            }
        }
        else
        {
            datosPila[++cima] = dato; // Guardo el dato en la pila.
        }
    }

    public string desapilar() // Función desapilar.
    {
        string result = "";
        if (vacia()) // Siempre Hay que Verificar si la Pila Está Vacía Antes de Desapilar.
        {
            try
            {
                throw new Exception();
            }
            catch (Exception e)
            {
                Console.WriteLine("La Pila Estaba Vacía no se Puede Desapilar Ningún Dato. Cometiste el Error: {0}", e);
            }
        }
        else
        {
            result = datosPila[cima--];
        }
        return result;
    }

    public bool vacia() // Función vacia.
    {
        return cima == -1;
    }

    public bool llena() // Función Llena.
    {
        return datosPila.Length - 1 == cima;
    }
}