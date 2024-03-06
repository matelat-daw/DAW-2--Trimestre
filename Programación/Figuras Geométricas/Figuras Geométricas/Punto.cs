public class Punto(int x, int y) // Coordenadas de las Figuras.
{
    private int x = x;
    private int y = y;

    public int GetX() { return x; } // Getter para Obtener los Datos del Objeto.

    public int GetY() { return y; }

    public void SetX(int x) { this.x = x; } // Setter para asignar los datos al Objeto Creado con el Constructor Vacio.

    public void SetY(int y) { this.y = y; }
}