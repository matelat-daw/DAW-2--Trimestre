int numero;
int divisor = 5;
int resultado;

String nombre = "Leonor de Borbón";
Console.WriteLine("Hola " + nombre + " dime número y te digo si son múltiplos de " + divisor);
do
{
    numero = Int32.Parse(Console.ReadLine());
    if (numero != 0)
    {
        resultado = numero % divisor;
        if (resultado == 0) Console.WriteLine("Si, el número " + numero + " es divisble por " + divisor);

        else Console.WriteLine("NO!!!, el numero " + numero + " NO es divisble por " + divisor);
        Console.WriteLine("Introduce otro numero");
    }
}
while (numero != 0);