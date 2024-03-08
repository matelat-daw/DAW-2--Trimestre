[TestClass]
public class Test_Ejercicio_2
{
    [TestMethod]
    public void OK() // Prueba OK, Array Descendente.
    {
        int[] arrayDescendente = [9, 8, 7, 6, 5, 4, 3, 2, 1]; // Array Oredenado Descendentemente.
        bool boleano = EstaOrdenada(arrayDescendente);
        Assert.AreEqual(true, boleano); // Prueba con el Valor Esperado true.
    }
    [TestMethod]
    public void Error() // Prueba con Error el Array no es Descendente
    {
        int[] arrayNoDescendente = [9, 8, 7, 6, 4, 5, 3, 2, 1]; // Array no Oredenado Descendentemente.
        bool boleano = EstaOrdenada(arrayNoDescendente);
        Assert.AreEqual(true, boleano); // Prueba con el Valor Esperado true, en este Caso Devuelve false.
    }

    public static bool EstaOrdenada(int[] array) // Ya Explicado en el Programa Principal.
    {
        bool result = true;

        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] < array[i + 1])
            {
                result = false;
                i = array.Length;
            }
        }
        return result;
    }
}