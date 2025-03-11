namespace ConsolePrinter;

class Program
{
    static void Main()
    {
        int[] binaryTree = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        ConsolePrinter<int>.Print(binaryTree);
    }
}
