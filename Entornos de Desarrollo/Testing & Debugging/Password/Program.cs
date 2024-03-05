public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Este Programa Recive una Contraseña y la Valida con Respacto a Ciertas Condiciones.");
        bool result = ComprobarPassword("Hay6hiTler");
        Console.WriteLine("El resultado es: {0}", result);
    }

    public static bool ComprobarPassword(String pass)
    {
        bool result = false;
        bool all_check = false;
        bool caps_check = false;
        bool cadena = false;

        if (pass.Length >= 4 && pass.Length <= 6)
        {
            string digit = string.Join("", pass.ToCharArray().Where(Char.IsDigit));
            if (int.TryParse(digit, out int number))
            {
                Console.WriteLine("Sí, contiene el dígito: {0}", number);
                for (int i = 0; i < pass.Length; i++)
                {
                    if (pass.Any(char.IsUpper))
                    {
                        caps_check = true;
                    }
                }
                if (caps_check)
                {
                    Console.WriteLine("Sí, Tiene la Mayúscula: {0}", caps_check);
                    all_check = true;
                    cadena = pass.ToLower().Contains("hitler");
                }
                if (!cadena && all_check)
                {
                    Console.WriteLine("No, contiene el la string hitler: {0}", cadena);
                    result = true;
                }
            }
        }
        return result;
    }
}