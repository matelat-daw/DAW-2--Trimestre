public class MainPila{
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