public class Food // Clase Food Crea un Objeto Food (Comida)
{
    private int x_food; // Coordenada X de la Comida.
    private int y_food; // Coordenada Y de la Comida.
    private Random coords = new Random();

    public Food() // Constructor de la Clase Food, No Recibe Parámetros, Asigna Valores Aleatorios a las Variables.
    {
        this.x_food = coords.Next(20, 101); // Asigna a X un Valor Aleatorio Entre los Limites Horizontales del Tablero.
        this.y_food = coords.Next(5, 31); // Asigna a Y un Valor Aleatorio Entre los Limites Verticales del Tablero.
    }

    public int getx_food // Get Para la Coordenada X, lo Necesita la Clase Serpent.
    {
        get { return x_food; } // Devuelve el Valor de X.
    }

    public int gety_food // Get Para la Coordenada Y, lo Necesita la Clase Serpent.
    {
        get { return y_food; } // Devuelve el Valor de Y.
    }
}