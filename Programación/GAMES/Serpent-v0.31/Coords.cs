public class Coords // Clase Coords, Se Crean las Coordenadas de la Serpiente.
{
    private int x; // Cooredenada X
    private int y; // Coordenada Y.

    public Coords (int x, int y) // Constructor de la Clase, Recibe los Puntos X (Horizontal) e Y (Vertical).
    {
        this.x = x; // Asigna a las Variables Privadas de la Clase los Valores Pasados Como Parámetros.
        this.y = y;
    }

    public int xValue // Getter del Punto X, Se Usa en la Clase Serpent.
    {
        get { return x; } // Retorna el Punto X.
    }

    public int yValue // Getter del Punto Y, Se Usa en la Clase Serpent.
    {
        get { return y; } // Retorna el Punto Y.
    }
}