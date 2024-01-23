public class Funciones4
{
    public static bool check(int year) // La Función check(int year) Recibe Como Parámetro un Año y Comprueba si es Bisiesto o No.
    {   
        return (year % 4 == 0 && year % 100 != 0 || year % 400 == 0);
    }
}