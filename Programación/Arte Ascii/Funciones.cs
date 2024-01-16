using System.Drawing;
using System.Drawing.Imaging;

namespace Arte_Ascii
{
    internal class Funciones
    {
        internal static Image GetLetterImage(char letter)
        {
            Stream imageStream = new MemoryStream();
            using (Bitmap board = new(100, 100))
            using (var g = Graphics.FromImage(board))
            using (Font drawFont = new("Arial", 64))
            {
                g.DrawString(letter.ToString(), drawFont, Brushes.White, 0, 0);

                board.Save(imageStream, ImageFormat.Jpeg);
            }
            return Image.FromStream(imageStream);
        }

        internal static Bitmap ResizImage(Image image, int width)
        {
            Bitmap bitmap = new(image);
            int height = (int)Math.Ceiling((double)(bitmap.Height * width) / bitmap.Width);

            return new Bitmap(bitmap, width, (height / 2) + (width / 4));
        }

        internal static void ConvertToAscii(Bitmap bitmap, char caracter)
        {
            // char[] ascii = { '#', '@', '%', 'W', 'w', '=', '+', '*', ':', '-', ',', '.', ' ' }; // Original, Dibuja un Tablero con la Letra Dibujada con Espacios Dentro.
            char[] ascii = { ' ', caracter };

            for (var h = 0; h < bitmap.Height; h++)
            {
                for (var w = 0; w < bitmap.Width; w++)
                {
                    var pixel = bitmap.GetPixel(w, h);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    int alpha = pixel.A == 255 ? 1 : 0;
                    int index = (int)(gray * ascii.Length / 255);
                    if (index == ascii.Length)
                    {
                        index--;
                    }
                    Console.Write(ascii[(alpha == 0 ? ascii.Length - 1 : index)]);
                }
                Console.WriteLine();
            }
        }
    }
}