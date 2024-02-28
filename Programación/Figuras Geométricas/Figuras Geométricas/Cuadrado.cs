public class Cuadrado: Rectangulo
{
    public Cuadrado(int x, int y, int ancho, int alto) : base(x, y, ancho, alto)
    {
        posicion = new Punto();
        posicion.setX(x);
        posicion.setY(y);
    }
}