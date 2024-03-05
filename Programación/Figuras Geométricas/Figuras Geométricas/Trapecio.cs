public class Trapecio: Figura
{
    private readonly int altura;
    private readonly int anchoMayor;
    private readonly int anchoMenor;


    public Trapecio(int x, int y, int altura, int anchoMayor, int anchoMenor) : base(x, y)
    {
        this.altura = Math.Abs(altura);
        this.anchoMayor = Math.Abs(anchoMayor);
        this.anchoMenor = Math.Abs(anchoMenor);
    }

    public int GetAnchoMayor() { return anchoMayor; }

    public int GetAnchoMenor() { return anchoMenor; }

    public int GetAltura() { return altura; }

    public override double Area()
    {
        double result = 0.0;

        result = (anchoMayor + anchoMenor) * altura / 2;
        return result;
    }

    public override double Perimetro()
    {
        double result = 0.0;

        double _base = (anchoMayor - anchoMenor) / 2.0;
        double hipo = Math.Sqrt(_base * _base + altura * altura);
        result = anchoMayor + anchoMenor + hipo * 2;
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