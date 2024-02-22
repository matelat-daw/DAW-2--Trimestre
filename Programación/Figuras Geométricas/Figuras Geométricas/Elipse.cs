public class Elipse
{
    private Punto centro;
    private int radio1;
    private int radio2;

    public Elipse(int x, int y, int radio1, int radio2)
    {
        centro = new Punto();
        centro.setX(x);
        centro.setY(y);
        this.radio1 = radio1;
        this.radio2 = radio2;
    }

    public int getRadio1()
    {
        return radio1;
    }

    public int getRadio2()
    {
        return radio2;
    }

    public double perimetro() // Formula Para Calcular el Perímetro de la Elipse.
    {
        double h = ((radio1 - radio2) * (radio1 - radio2)) / ((radio1 + radio2) * (radio1 + radio2));

        return Math.PI * (radio1 + radio2) * (1 + 3 * h / (10 + Math.Sqrt(4 - 3 * h)));
    }

    public double area() // Área de la Elipse, Radio Menor x Radio Mayor x PI.
    {
        return Math.PI * radio1 * radio2;
    }
}