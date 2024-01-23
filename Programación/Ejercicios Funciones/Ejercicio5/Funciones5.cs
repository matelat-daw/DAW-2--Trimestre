public class Funciones5
{
    public static int cifras(int num) // Función cifras(int num), Recibe un Número.
    {
        int counter = 0; // Declaro la Variable counter y le Asigno 0.

        do
        {
            num /= 10; // Divide el Número por 10 y Asigna el Resultado a Si Mismo.
            counter++; // Incrementa counter.
        } while (num > 0) ; // Mientras el Número Sea de Más de Una Cifra.

        return counter; // Devuelve counter que Contiene la Cantidad de Cifras que Tiene el Número.
    }
}