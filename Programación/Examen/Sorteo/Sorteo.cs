namespace Sorteo;

public class Sorteo
{
    private int secreto;
    public static bool acertado = false;
    Random random = new();

    public Sorteo(int numero)
    {
        secreto = random.Next(numero + 1); // OJO este Random Genera un Número Entre 0 y el que le Pases.
    }

    public Sorteo(int numero1, int numero2)
    {
        secreto = random.Next(numero1, numero2); // Este Genera un Número Entre el Primero que le Pases y uno Menos que el Segundo que le Pases.
    }

    private int GetSecreto() // El Método Debe ser Privado para que se Pueda Usar Solo en la Clase.
    {
        return secreto; // Retorna el Número Secreto.
    }

    public int Intentar(int numero) // Método Intentar para Suponer el Número Secreto.
    {
        int resultado = -1; // Asigno a resultado -1;

        if (numero == GetSecreto()) // Si el Número Elejido es Igual al Número Secreto.
        {
            resultado = 0; // Asigno a Resultado 0, es lo que se Pide que Devuelva si se Acierta.
            acertado = true; // Uso el Booleano static acertado, para saber en el Método sobreescrito ToString() si se Acerto o No.
        }
        return resultado; // Retorno resultado.
    }

    public override string ToString() // Método ToString().
    {
        string result = null; // Asingo a la string result null.

        if (acertado) // Si el Booleano static acertado está a true es que se ha acertado el Número Secreto.
        {
            result = GetSecreto().ToString(); // Asigno a result el Número Secreto.ToString(), Hay que Convertirlo ya que la variable result es String.
        }
        return result; // Retorno result.
    }
}