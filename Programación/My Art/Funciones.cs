
namespace My_Art
{
    internal class Funciones
    {
        static List<List<char>> board;
        static char empty = ' ';
        const int width = 20;

        internal static void draw(char caracter)
        {

            board = new List<List<char>>();

            //for M we will use 4 points each with a width of [width]
            Func<int, int, bool> p1 = (row, col) => {
                int startX = width - 1 - row;
                return (col > startX && col <= (startX + width));
            };
            Func<int, int, bool> p2 = (row, col) => {
                int startX = width - 1 + row;
                return (col > startX && col <= (startX + width));
            };
            Func<int, int, bool> p3 = (row, col) => {
                int startX = (3 * width) - 1 - row;
                return (col > startX && col <= (startX + width));
            };
            Func<int, int, bool> p4 = (row, col) => {
                int startX = (3 * width) - 1 + row;
                return (col > startX && col <= (startX + width));
            };



            for (int row = 0; row <= width; row++)
            {
                var rowChars = new List<char>();
                for (int col = 0; col < (width * 5); col++)
                    rowChars.Add((p1(row, col) || p2(row, col) || p3(row, col) || p4(row, col)) ? caracter : empty);
                board.Add(rowChars);
            }
            ShowOutput();


        }

        internal static void ShowOutput()
        {
            var sb = new System.Text.StringBuilder();
            foreach (List<char> row in board)
                sb.AppendLine(string.Join("", row.ToArray()));

            Console.Write(sb.ToString());
        }
    }
}