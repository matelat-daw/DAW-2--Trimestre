public class Poligono
{
    private Punto centro;
    private int size;
    private int number;
    private int radio;

    public Poligono (int x, int y, int size, int number, int radio)
    {
        centro = new Punto();
        centro.setX(x);
        centro.setY(y);
        this.size = size;
        this.number = number;
        this.radio = radio;
    }

    public int getSize() { return size; } // Getter de los Atributos del Objeto.

    public int getQtty() { return number; }

    public int getRadio() { return radio; }

    public void mostrar()
    {
        Drawing.showOctogon(size, getApotema());
    }

    public int perimetro()
    {
        return number * size;
    }

    public double area()
    {
        return ((getApotema() * number * size) / 2);
    }

    public double getApotema()
    {
        double apotema;
        apotema = Math.Sqrt(radio * radio - (size / 2) * (size / 2));
        return apotema;
    }
}