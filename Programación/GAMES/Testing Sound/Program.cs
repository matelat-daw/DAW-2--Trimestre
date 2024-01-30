using System.Media;

namespace Testing_Sound
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Este Programa Reproduce Sonidos.");

            SoundPlayer voice = new SoundPlayer(Environment.CurrentDirectory + "/audio/voice.wav");
            voice.Play();
            Console.WriteLine("Presiona Cualquier Tecla para Salir.");
            Console.ReadLine();
        }
    }
}