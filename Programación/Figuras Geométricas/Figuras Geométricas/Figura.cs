public abstract class Figura
{
    protected Punto posicion;

    public int getX() { return posicion.getX(); }
    public int getY() { return posicion.getY(); }


    public abstract double area();
    //public virtual double area()
    //{
    //    throw new NotImplementedException();
    //}


    public abstract double perimetro();
    //public virtual double perimetro()
    //{
    //    throw new NotImplementedException();
    //}
}