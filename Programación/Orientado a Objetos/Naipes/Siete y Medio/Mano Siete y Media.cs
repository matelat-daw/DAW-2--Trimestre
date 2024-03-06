public class Mano_Siete_y_Media: Mano
{
    private double player_score = 0.0;
    private double bank_score = 0.0;

    public double CuentaPuntos()
    {
        int player_card = AnadeCarta(Mazo.DaCarta());
        double real_value = 0.0;

        if (player_card > 7)
        {
            real_value = .5;
        }
        else
        {
            real_value = (double)player_card;
        }
        player_score += real_value;
        if (player_score > 7.5)
        {
            Console.WriteLine("\nLo Siento te has Pasado, Pero no Todo está Perdido, A ver que Saca la Banca.");
        }
        else
        {
            Console.WriteLine($"Tienes: {player_score} Puntos.");
            Console.Write("Quieres Otra Carta: s Para Otra Carta, Enter Para Plantarte.");
            string response = Console.ReadLine().ToLower();
            if (response == "s")
            {
                CuentaPuntos();
            }
        }
        return player_score;
    }

    public double CuentaPuntoBanca()
    {
        int bank_card = AnadeCarta(Mazo.DaCarta());
        double real_value = 0.0;

        if (bank_card > 7)
        {
            real_value = .5;
        }
        else
        {
            real_value = (double)bank_card;
        }
        bank_score += real_value;
        if (bank_score > 7.5)
        {
            Console.WriteLine("\nLa Banca Se Ha Pasado.");
        }
        else
        {
            Console.WriteLine("La Banca Tiene: {0}", bank_score);
            if (bank_score < 5)
            {
                CuentaPuntoBanca();
            }
        }
        return bank_score;
    }
}