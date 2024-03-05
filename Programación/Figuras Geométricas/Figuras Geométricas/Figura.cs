public abstract class Figura(int x, int y)
{
    protected Punto posicion = new(x, y);

    public int GetX() { return posicion.GetX(); }
    public int GetY() { return posicion.GetY(); }


    public abstract void Mostrar();

    public abstract double Area(); // Si la Clase es Abstracta Puede Tener Métodos Abstractos.
    //public virtual double area() // Los Métodos virtual También Permiten override el Método del Mismo Nombre en la Clase Hija.
    //{
    //    return 0.0;
    //    // throw new NotImplementedException(); // No es Necesario Lanzar una Excepción, se Puede Hacer que el Método return 0.0.
    //}


    public abstract double Perimetro();

    public override string ToString()
    {
        return $"La Figura {base.GetType()} Tiene un Perimetro de: {Perimetro():f2} y un Área de: {Area():f2}";
    }
}