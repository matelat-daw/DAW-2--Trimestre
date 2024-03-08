namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodCorrecto()
        {
            int[] arrayDescendente = { 10, 8, 6, 4, 2 };
            bool boleano = estaOrdenada(arrayDescendente);
            Assert.AreEqual(true,boleano);
        }
        [TestMethod]
        public void TestMethodIncorrecto()
        {
            int[] arrayNoDescendente = { 5, 3, 7, 1, 9 };
            bool boleano = estaOrdenada(arrayNoDescendente);
            Assert.AreEqual(true,boleano);
        }

        public static bool estaOrdenada(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}