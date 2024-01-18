
using System;

public class Funciones8
{
    public static int[] positions(string frase, char letter) // La Función positions(string frase, char letter), Recibe una String y una Letra y Busca las Posiciones donde están las Coincidencias con la Letra Buscada, en la String.
    {
        int[] positions = new int[frase.Length]; // Por si Acaso Hay que Crear el Array positions al Tamaño Máximo de la String.
        for (int i = 0; i < positions.Length; i++) // Bucle al Tamaño del Array positions.
        {
            positions[i] = -1; // Relleno el Array con -1 Para Poder Controlar Cuando no Hay Más Coincidencias.
        }
        int index = 0; // Declaro index y le Asigno el Valor 0.

        for (int i = 0; i < frase.Length; i++) // Bucle al Tamaño de la String.
        {
            if (letter == frase[i]) // Si la Letra Está en la Posición i en la String.
            {
                positions[index] = i; // Asigno a la Posición index del Array positions el Valor de i.
                index++; // Incremento index.
            }
        }
        return positions; // Devuelvo el Array positions.
    }

    public static void showPositions(int[] positions) // Función showPositions(int[] positions), Recibe un Array y Muestra por Pantalla las Posiciones de las Letras Encontradas en la String.
    {
        int index = 0; // Declaro index y le Asigno el Valor 0, será el Índice del Array positions.

        while (index < positions.Length && positions[index] != -1) // Mientras index no llegue al Final del Array y no Haya un -1 en la Posición index del Array positions.
        {
            Console.WriteLine("\nLa Posición de la {0}ª Coincidencia Es: {1}", index + 1, positions[index]); // Muestra por Pantalla la Posición de la Letra en la Cadena.
            index++; // Incrementa index
        }
        if (index == 0) // Si a la Salida index es Igual a 0.
        {
            Console.WriteLine("\nNo se Ha Encontrado Ninguna Coincidencia."); // No Hubo Ninguna Coincidencia.
        }
    }
}