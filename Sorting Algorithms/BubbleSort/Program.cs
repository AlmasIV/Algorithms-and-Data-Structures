namespace BubbleSort;

class Program
{
    static void Main()
    {
        int[] ints = { 0, 0, -2, 22, 2, 3, 4, 5, 88, -9282, 0, 21 };
        Console.WriteLine($"Before: {string.Join(", ", ints)}.");
        BubbleSort<int>.Sort(ints);
        Console.WriteLine($"After: {string.Join(", ", ints)}.");
    }
}
