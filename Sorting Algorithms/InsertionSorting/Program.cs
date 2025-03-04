namespace InsertionSorting;

class Program
{
    static void Main()
    {
        int[] myArray = { 1, -1, 100, 9999, 99, 2, 3, -22, 2, 0, 232 };
        string before = string.Join(", ", myArray);
        Console.WriteLine($"Before sorting: {before}.");
        InsertionSorting<int>.Sort(myArray);
        string after = string.Join(", ", myArray);
        Console.WriteLine($"After sorting: {after}.");
    }
}
