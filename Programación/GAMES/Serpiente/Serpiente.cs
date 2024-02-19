public class Serpiente
{
    private LinkedList<Anillo> anillos;
    public Direccion direccion = Direccion.Este;
    private bool yaMostrado = false;

    public Serpiente() {
        anillos = new LinkedList<Anillo>();
        anillos.AddFirst(new Anillo(5, 12));
        anillos.AddFirst(new Anillo(6, 12));
        anillos.AddFirst(new Anillo(7, 12));
        anillos.AddFirst(new Anillo(8, 12));
        anillos.AddFirst(new Anillo(9, 12));
        anillos.AddFirst(new Anillo(10, 12, '@'));
    }

    private Anillo Cabeza()
    {
        return anillos.First();
    }
    private Anillo Cola()
    {
        return anillos.Last();
    }
    public void Crecer()
    {
        if (yaMostrado)
        {
            Anillo nuevaCabeza = new Anillo(Cabeza());
            Cabeza().id = '*';
            Cabeza().Mostrar();
            anillos.AddFirst(nuevaCabeza);
            Console.ForegroundColor = ConsoleColor.Green;
            switch (direccion)
            {
                case Direccion.Norte:
                    nuevaCabeza.Norte();
                    break;
                case Direccion.Sur:
                    nuevaCabeza.Sur();
                    break;
                case Direccion.Este:
                    nuevaCabeza.Este();
                    break;
                case Direccion.Oeste:
                    nuevaCabeza.Oeste();
                    break;
            }
            nuevaCabeza.Mostrar();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }

    public void Avanzar()
    {
        Cola().Ocultar();
        anillos.RemoveLast();
        Crecer();

    }
    public void Mostrar()
    {
        if (!yaMostrado)
        {
            foreach (Anillo anillo in anillos)
                anillo.Mostrar();
            yaMostrado = true;
        }
    }
}