public class Poligono: Figura
{
    private int size;
    private int number;
    private int radio;

    public Poligono (int x, int y, int size, int number, int radio)
    {
        posicion = new Punto();
        posicion.setX(x);
        posicion.setY(y);
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

    public override double perimetro()
    {
        return number * size;
    }

    public override double area()
    {
        return ((getApotema() * number * size) / 2);
    }

    public double getApotema()
    {
        double apotema;
        apotema = Math.Sqrt(radio * radio - (size / 2) * (size / 2));
        return apotema;
    }

    public override string ToString()
    {
        return String.Format("El Poligono Regular de {0} Lados de Tamaño: {1} y Radio: {2} Tiene un Perímetro de: {3:F2} y un Área de: {4:F2}", getQtty(), getSize(), getRadio(), perimetro(), area());
    }
}