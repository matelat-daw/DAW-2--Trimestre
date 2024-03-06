public class Trapecio(int x, int y, int altura, int anchoMayor, int anchoMenor) : Figura(x, y)
{
    private readonly int altura = Math.Abs(altura);
    private readonly int anchoMayor = Math.Abs(anchoMayor);
    private readonly int anchoMenor = Math.Abs(anchoMenor);

    public int GetAnchoMayor() { return anchoMayor; }

    public int GetAnchoMenor() { return anchoMenor; }

    public int GetAltura() { return altura; }

    public override double Area()
    {
        return (anchoMayor + anchoMenor) * altura / 2;
    }

    public override double Perimetro()
    {
        double _base = (anchoMayor - anchoMenor) / 2.0;
        double hipo = Math.Sqrt(_base * _base + altura * altura);
        double result = anchoMayor + anchoMenor + hipo * 2;
        return result;
    }

    public override string ToString()
    {
        return $"El Trapecio de Altura: {GetAltura()}, Ancho Mayor: {GetAnchoMayor()} y Ancho Menor: {GetAnchoMenor()} Tiene un Perímetro de: {Perimetro():F2} y un Área de: {Area():F2}";
    }

    public override void Mostrar()
    {

    }
}