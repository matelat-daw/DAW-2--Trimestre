using System.Runtime.Serialization;

public class Rectangulo // Rectángulos y Cuadrados.
{
    private int ancho;
    private int alto;
    private Punto posicion;

    public Rectangulo (int x, int y, int ancho, int alto)
    {
        posicion = new Punto();
        posicion.setX(x);
        posicion.setY(y);
        this.ancho = Math.Abs(ancho);
        this.alto = Math.Abs(alto);
    }

    public int getAncho() { return ancho; }

    public int getAlto() { return alto; }

    public int getX() { return posicion.getX(); }
    public int getY() { return posicion.getY(); }

    public static void pruebaRectangulo()
    {
        int area_total;
        Rectangulo[] array = [
            new Rectangulo(80, 5, 10, 10),
            new Rectangulo(95, 5, 15, 15),
            new Rectangulo(115, 5, 20, 20)
            ];
        area_total = areas(array);
        Console.SetCursorPosition(76, 25);
        Console.WriteLine("El Area de Todos Los Cuadrados es: {0}", area_total);
        Console.SetCursorPosition(76, 27);
        Console.WriteLine("El Perimetro Individual es: {0}, {1} y {2}", array[0].perimetro(), array[1].perimetro(), array[2].perimetro());
        Console.SetCursorPosition(76, 29);
        Console.WriteLine("Y el Área Individual es: {0}, {1} y {2}", array[0].area(), array[1].area(), array[2].area());
    }

    private static int areas(Rectangulo[] array)
    {
        int result = 0;

        for (int i = 0; i < array.Length; i++)
        {
            result += array[i].area();
            array[i].mostrar();
        }
        return result;
    }

    public void mostrar()
    {
        //Drawing.showRectangle(posicion.getX(), posicion.getY(), ancho, alto); // Para Mi la Forma Correcta.
        Drawing.showRectangle(getX(), getY(), getAncho(), getAlto());
    }

    public int perimetro()
    {
        return ancho * 2 + alto * 2;
    }

    public int area()
    {
        return ancho * alto;
    }

    public override string ToString()
    {
        string figure;
        if (getAlto() != getAncho())
        {
            figure = "Rectángulo";
        }
        else
        {
            figure = "Cuadrado";
        }
        return String.Format("El {0} de Ancho: {1} y Alto: {2} Tiene un Perímetro de: {3} y un Área de: {4}", figure, getAncho(), getAlto(), perimetro(), area());
    }
}