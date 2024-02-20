public class Circulo
{
    private int radio;
    private Point posicion;

    public Circulo (int x, int y, int radio)
    {
        posicion = new Point();
        posicion.setX(x);
        posicion.setY(y);
        this.radio = radio;
    }

    public int getRadio()
    {
        return radio;
    }

    public double perimetro()
    {
        return 2 * Math.PI * radio;
    }

    public double area()
    {
        return Math.PI * radio * radio;
    }

    public void mostrar()
    {
        double thickness = 0.4; // Espesor del borde
        double rIn = radio - thickness, rOut = radio + thickness; // Al Borde del Radio Interno se le resta el Espesor y al Externo de le Suma.

        Console.ForegroundColor = ConsoleColor.Green; // Cambio el color del Pincel a Verde.
        for (double y = radio; y >= -radio; --y) // Bucle Desde el radio Hasta el radio Negativo Predecrementando y la Vertical.
        {
            for (double x = -radio; x < rOut; x += 0.5) // Bucle Desde el Radio Negativo Hasta el radio + el Espesor Post Incrementando en .5.
            {
                double value = x * x + y * y; // Asigno a la Variable value la Suma de x al Cuadrado + y al Cuadrado.
                if (value >= rIn * rIn && value <= rOut * rOut) // Si value es Mayor o Igual que el Radio Interno al Cuadrado Y es Menor o Igual que el Radio Externo al Caudrado.
                {
                    Console.Write('*'); // Pinto el Asterisco, Cuerpo de la Circunferencia.
                }
                else // Si No.
                {
                    Console.Write(' '); // Pinto un Espacio.
                }
            }
            Console.WriteLine(); // Salto de Línea.
        }
        Console.ForegroundColor = ConsoleColor.Gray; // Cambio el Color del Pincel a Gris, el Estandar de la Consola.
    }
}