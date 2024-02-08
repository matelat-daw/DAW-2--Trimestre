public class MainLinkedList
{
    enum Months
    {
        January,    // 0
        February,   // 1
        March = 6,    // 6
        April,      // 7
        May,        // 8
        June,       // 9
        July        // 10
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Months myNum = Months.April;
        Console.WriteLine(myNum);
}
}