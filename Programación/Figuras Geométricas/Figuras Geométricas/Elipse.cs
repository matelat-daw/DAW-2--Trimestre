public class Elipse: Figura
{
    private int radio_menor;
    private int radio_mayor;

    public Elipse(int x, int y, int radio_menor, int radio_mayor)
    {
        posicion = new Punto();
        posicion.setX(x);
        posicion.setY(y);
        this.radio_menor = radio_menor;
        this.radio_mayor = radio_mayor;
    }

    public int getRadioMenor() { return radio_menor; }

    public int getRadioMayor() { return radio_mayor; }

    public override double perimetro() // Formula Para Calcular el Perímetro de la Elipse.
    {
        double h = ((radio_menor - radio_mayor) * (radio_menor - radio_mayor)) / ((radio_menor + radio_mayor) * (radio_menor + radio_mayor));

        return Math.PI * (radio_menor + radio_mayor) * (1 + 3 * h / (10 + Math.Sqrt(4 - 3 * h)));
    }

    public override double area() // Área de la Elipse, Radio Menor x Radio Mayor x PI.
    {
        return Math.PI * radio_menor * radio_mayor;
    }

    public override string ToString()
    {
        return String.Format("La Elipse de Radio Menor: {0} y Radio Mayor: {1} Tiene un Perímetro de: {2:F2} y un Área de: {3:F2}", getRadioMenor(), getRadioMayor(), perimetro(), area());
    }
}