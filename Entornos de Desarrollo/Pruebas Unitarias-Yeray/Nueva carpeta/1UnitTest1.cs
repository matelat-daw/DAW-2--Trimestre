using System;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testcorrecto()
        {
            int[] array = { 0, 1, 2, 4, 9, 20, 76, 34, 65, 89 };
            int valor = numMenosMedia(array);
            Assert.AreEqual(6,valor);
        }
        [TestMethod]
        public void testincorrecto()
        {
            int[] array = { 0, 1, 2, 4, 9, 20, 76, 34, 65, 89 };
            int valor = numMenosMedia(array);
            Assert.AreEqual(7, valor);
        }
        public int numMenosMedia(int[] array)
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
}