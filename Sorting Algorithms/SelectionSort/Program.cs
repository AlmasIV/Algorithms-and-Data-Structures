namespace SelectionSort;

class Program
{
    static void Main()
    {
        int[] ints = { 1, -1, 0, 22, 99, -923, 2, 3, 2, 3, 77, -99, 0, 21 };
        string before = string.Join(", ", ints);
        Console.WriteLine($"Before: {before}.");

        SelectionSort<int>.Sort(ints);

        string after = string.Join(", ", ints);
        Console.WriteLine($"Before: {after}.");
    }
}
