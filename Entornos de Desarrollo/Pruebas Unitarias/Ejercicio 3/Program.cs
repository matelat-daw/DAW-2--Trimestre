public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Este Programa Recibe una Contraseña y la Valida con Respacto a Ciertas Condiciones.");
        Console.WriteLine($"El resultado es: {ComprobarPassword("hiT3er")}");
    }

    public static bool ComprobarPassword(string pass) // Métdo que Comprueba si la Contraseña es Válida.
    {
        bool result = false; // Para Retornar el Resultado.
        bool some_check = false; // Se Pone a true si la Contraseña Tiene Mayúscula, Minúscula y Dígito.
        bool caps_check = false; // Se Pone a true si la Contraseña Tiene Mayúscula.
        bool lower_check = false; // Se Pone a true si la Contraseña Tiene Minúscula.
        bool cadena = false; // Se Pone a true si la Contraseña no contiene la Cadena hitler/Hitler/hiTler/etc.

        if (pass.Length >= 4 && pass.Length <= 6) // Compruebo que el Tamaño de la Contraseña Esté Entre 4 y 6 Caracteres.
        {
            string digit = string.Join("", pass.ToCharArray().Where(Char.IsDigit)); // Asigno a la string digit un Caracter que sea un Dígito de la Contraseña.
            if (int.TryParse(digit, out int number)) // Intento Convertir a int el string digit y se lo asigno a la variable number.
            {
                Console.WriteLine("Sí, contiene el dígito: {0}", number); // Si se Puede Convertir a int, Muestro en Pantalla que la Contraseña Cumple la Condición que Tiene un Dígito.
                for (int i = 0; i < pass.Length; i++) // Bucle al tamaño de la contraseña.
                {
                    if (pass.Any(char.IsUpper)) // Compruebo si Algún Caracter de la Contraseña es una Mayúscula.
                    {
                        caps_check = true; // Si se Cumple Pongo caps_check a true.
                    }

                    if (pass.Any(char.IsLower)) // Compruebo si Algún Caracter de la Contraseña es una Minúscula.
                    {
                        lower_check = true; // Si se Cumple Pongo lower_check a true.
                    }
                }
                if (caps_check && lower_check) // Compruebo si caps_check y lower_check están a true.
                {
                    Console.WriteLine("Sí, Tiene la Mayúscula: {0}", caps_check); // Si Está, Muestro en Pantalla que la Contraseña Cumple con el Requisito que Tiene al Menos una Mayúscula.
                    some_check = true; // Pongo some_check a true, ya se que la Contraseña Tiene un Dígito y una Mayúscula y una Minúscula.
                    cadena = pass.ToLower().Contains("hitler"); // Asigno al booleano cadena el resultado de Comprobar si la cadena hitler Está Contenida en la Contraseña pasada a Lower Case.
                }
                if (!cadena && some_check) // Si cadena Está a false y some_check Está a true.
                {
                    Console.WriteLine($"La Contraseña No Contiene la Cadena hitler: {!cadena}"); // Muestro que la Contraseña no Contiene la Cadena hitler.
                    result = true; // Asigno a result true.
                }
            }
        }
        return result; // Retorno result.
    }
}