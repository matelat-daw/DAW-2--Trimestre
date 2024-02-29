public class Punto // Coordenadas de las Figuras.
{
    private int x;
    private int y;

    public Punto() { } // Contructor Vacio para Instanciar un Objeto sin Ningún Dato.

    //public Punto(int x, int y) // Constructor que Recive dos Parámetro, Para Crear un Objeto con sus Propiedades.
    //{
    //    this.x = x;
    //    this.y = y;
    //}

    public int GetX() { return x; } // Getter para Obtener los Datos del Objeto.

    public int GetY() { return y; }

    public void SetX(int x) { this.x = x; } // Setter para asignar los datos al Objeto Creado con el Constructor Vacio.

    public void SetY(int y) { this.y = y; }
}