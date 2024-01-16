/* Programa que pide un numero hasta que introduce 0.
 * El programa pasará de kilogramos a gramos
 * 
 */
double kg;
do
{
    Console.WriteLine("Introduce los kg");
    kg = Double.Parse(Console.ReadLine());
    if (kg != 0)
    {
        double gramos = kg * 1000;
        Console.WriteLine(gramos + " Grams");
    }
}
while (kg != 0);