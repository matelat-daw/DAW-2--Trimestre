[TestClass]
public class Test_Ejercicio_3
{
    [TestMethod]
    public void OK()
    {
        bool result = ComprobarPassword("holA@3"); // Compruebo una Contraseña Correcta.
        Assert.AreEqual(true, result); // Devuelve true el Resultado Esperado.
    }

    [TestMethod]
    public void ERROR1()
    {
        bool result = ComprobarPassword("hola33"); // Error por Falta de Mayúscula.
        Assert.AreEqual(true, result); // Da Error Devuelve false.
    }

    [TestMethod]
    public void ERROR2()
    {
        bool result = ComprobarPassword("HolaXR"); // Error por Falta de Dígito.
        Assert.AreEqual(true, result); // Da Error Devuelve false.
    }

    [TestMethod]
    public void ERROR3()
    {
        bool result = ComprobarPassword("Holaaaa"); // Error por Tamaño.
        Assert.AreEqual(true, result); // Da Error Devuelve false.
    }

    [TestMethod]
    public void ERROR4()
    {
        bool result = ComprobarPassword("hiTler"); // Error por Cadena Prohibida hitler.
        Assert.AreEqual(true, result); // Da Error Devuelve false.
    }

    public static bool ComprobarPassword(string pass) // Ya Explicado en el Programa Principal, en las Pruebas no Muestro los Resultados Parciales.
    {
        bool result = false;
        bool some_check = false;
        bool caps_check = false;
        bool lower_check = false;
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

                    if (pass.Any(char.IsLower))
                    {
                        lower_check = true;
                    }
                }
                if (caps_check && lower_check)
                {
                    some_check = true;
                    cadena = pass.ToLower().Contains("hitler");
                }
                if (!cadena && some_check)
                {
                    result = true;
                }
            }
        }
        return result;
    }
}