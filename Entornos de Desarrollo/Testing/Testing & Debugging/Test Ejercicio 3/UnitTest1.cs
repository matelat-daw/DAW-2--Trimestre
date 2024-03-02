namespace Test_Ejercicio_3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_OK()
        {
            bool result = ComprobarPassword("holA@3");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod_ERROR1()
        {
            bool result = ComprobarPassword("hola33");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod_ERROR2()
        {
            bool result = ComprobarPassword("HolaXR");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod_ERROR3()
        {
            bool result = ComprobarPassword("Holaaaa");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod_ERROR4()
        {
            bool result = ComprobarPassword("hiTler");
            Assert.AreEqual(true, result);
        }

        public static bool ComprobarPassword(String pass)
        {
            bool result = false;
            bool all_check = false;
            bool caps_check = false;
            bool cadena = false;

            if (pass.Length >= 4 && pass.Length <= 10)
            {
                string digit = string.Join("", pass.ToCharArray().Where(Char.IsDigit));
                if (int.TryParse(digit, out int number))
                {
                    for (int i = 0; i < pass.Length; i++)
                    {
                        if (pass.Any(char.IsUpper))
                        {
                            caps_check = true;
                        }
                    }
                    if (caps_check)
                    {
                        all_check = true;
                        cadena = pass.ToLower().Contains("hitler");
                    }
                    if (!cadena && all_check)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}