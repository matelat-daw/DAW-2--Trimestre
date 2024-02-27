public class Cuadrado: Rectangulo
{
    public Cuadrado(int x, int y, int ancho, int alto)
    {
        posicion = new Punto();
        posicion.setX(x);
        posicion.setY(y);
        ancho = ancho;
        alto = alto;
    }
}