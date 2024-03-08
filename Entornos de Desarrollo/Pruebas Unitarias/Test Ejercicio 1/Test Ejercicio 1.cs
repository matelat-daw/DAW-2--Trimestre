[TestClass]
public class Test_Ejercicio_1
{
    [TestMethod]
    public void OK()
    {
        int[] array = [1, 5, 7, 3, 9, 20, 76, 34, 65, 89];
        int valor = NumMenosMedia(array);
        Assert.AreEqual(6, valor); // Prueba con el Valor Esperado.
    }
    [TestMethod]
    public void Error()
    {
        int[] array = [1, 5, 7, 3, 9, 20, 76, 34, 65, 89];
        int valor = NumMenosMedia(array);
        Assert.AreEqual(7, valor); // Prueba con un Valor Distinto al Esperado.
    }
    public static int NumMenosMedia(int[] array) // Ya Explicado en el Programa Principal.
    {
        int suma = 0;
        int contador = 0;

        for (int i = 0; i < array.Length; i++)
        {
            suma += array[i];
        }
        int media = suma / array.Length;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < media)
            {
                contador++;
            }
        }
        return contador;
    }
}