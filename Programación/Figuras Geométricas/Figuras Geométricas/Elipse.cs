public class Elipse: Figura
{
    private readonly int radio_menor;
    private readonly int radio_mayor;

    public Elipse(int x, int y, int radio_menor, int radio_mayor) : base(x, y)
    {
        this.radio_menor = radio_menor;
        this.radio_mayor = radio_mayor;
    }

    public int GetRadioMenor() { return radio_menor; }

    public int GetRadioMayor() { return radio_mayor; }

    public override double Perimetro() // Formula Para Calcular el Perímetro de la Elipse.
    {
        double h = ((radio_menor - radio_mayor) * (radio_menor - radio_mayor)) / ((radio_menor + radio_mayor) * (radio_menor + radio_mayor));

        return Math.PI * (radio_menor + radio_mayor) * (1 + 3 * h / (10 + Math.Sqrt(4 - 3 * h)));
    }

    public override double Area() // Área de la Elipse, Radio Menor x Radio Mayor x PI.
    {
        return Math.PI * radio_menor * radio_mayor;
    }

    public override string ToString()
    {
        // return String.Format("La Elipse de Radio Menor: {0} y Radio Mayor: {1} Tiene un Perímetro de: {2:F2} y un Área de: {3:F2}", GetRadioMenor(), GetRadioMayor(), Perimetro(), Area());
        return $"La Elipse de Radio Menor: {GetRadioMenor()} y Radio Mayor: {GetRadioMayor()} Tiene un Perímetro de: {Perimetro():F2} y un Área de: {Area():F2}";
    }

    public override void Mostrar(){ }
}