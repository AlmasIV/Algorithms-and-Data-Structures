using ConsolePrinter;

namespace BinaryHeaps;

class Program
{
    static void Main()
    {
        int[] ints = { 0, 2, 3, 11, 20 };
        MaxHeap<int> heap = new();
        Console.WriteLine("Before:");
        ConsolePrinter<int>.Print(ints);
        foreach(var v in ints) {
            heap.Insert(v);
        }
        Console.WriteLine("After:");
        ConsolePrinter<int>.Print(heap.ToArray());
    }
}
