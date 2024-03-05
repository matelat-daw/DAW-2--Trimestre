public class Poligono(int x, int y, int size, int number, int radio) : Figura(x, y)
{
    private readonly int size = size;
    private readonly int number = number;
    private readonly int radio = radio;

    public int GetSize() { return size; } // Getter de los Atributos del Objeto.

    public int GetQtty() { return number; }

    public int GetRadio() { return radio; }

    public override void Mostrar()
    {
        Drawing.ShowOctogon(size, GetApotema());
    }

    public override double Perimetro()
    {
        return number * size;
    }

    public override double Area()
    {
        return ((GetApotema() * number * size) / 2);
    }

    public double GetApotema()
    {
        double apotema;
        apotema = Math.Sqrt(radio * radio - (size / 2) * (size / 2));
        return apotema;
    }

    public override string ToString()
    {
        // return String.Format("\nEl Poligono Regular de {0} Lados de Tamaño: {1} y Radio: {2} Tiene un Perímetro de: {3:F2} y un Área de: {4:F2}", GetQtty(), GetSize(), GetRadio(), Perimetro(), Area());
        return $"\nEl Poligono Regular de {GetQtty()} Lados de Tamaño: {GetSize()} y Radio: {GetRadio()} Tiene un Perímetro de: {Perimetro():F2} y un Área de: {Area():F2}";
    }
}