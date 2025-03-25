namespace BinarySearch;

class Program
{
    static void Main(string[] args)
    {
        int[] sortedInts = { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
        int index = BinarySearch<int>.Search(sortedInts, 19);
        Console.WriteLine($"Is it there? {sortedInts[index] == 19}");
    }
}
