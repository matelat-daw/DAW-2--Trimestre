public class Funciones4
{
    public static bool check(int year) // La Función check(int year) Recibe Como Parámetro un Año y Comprueba si es Bisiesto o No.
    {
        bool result = false; // Se Declara y se Inicializa la Variable Booleana result a false.

        if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) // Si el Año Enviado por Parámetro Cumple Alguna de las Condiciones.
        {
            result = true; // Result se Pone a true ya que el Año es Bisiesto.
        }
        return result; // Devuelve result.
    }
}