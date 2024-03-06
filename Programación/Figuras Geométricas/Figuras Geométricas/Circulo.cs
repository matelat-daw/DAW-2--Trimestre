public class Circulo(int x, int y, int radio) : Figura(x, y) // Círculos.
{
    private readonly int radio = radio;

    public int GetRadio() { return radio; }

    public override double Perimetro()
    {
        return 2 * Math.PI * radio;
    }

    public override double Area()
    {
        return Math.PI * radio * radio;
    }

    public override void Mostrar()
    {
        Drawing.ShowCircle(radio);
    }

    //public override string ToString()
    //{
    //    // return String.Format("El Circulo de Radio: {0} Tiene un Perímetro de: {1:F2} y un Área de: {2:F2}", GetRadio(), Perimetro(), Area());
    //    return $"El Circulo de Radio: {GetRadio()} Tiene un Perímetro de: {Perimetro():F2} y un Área de: {Area():F2}";
    //}
}