namespace ArrayRandomizer;

class Program
{
    static void Main()
    {
        int[] ints = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        Console.WriteLine("Numbers before shuffle:");
        foreach(int i in ints) {
            Console.Write(i + " ");
        }
        Console.WriteLine("\nNumbers after shuffle:");
        Randomizer.RandomizeArray<int>(ints);
        foreach(int i in ints) {
            Console.Write(i + " ");
        }
        Console.Write("\n");
    }
}
