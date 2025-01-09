namespace PowerRaiser;

class Program
{
    static void Main()
    {
        string sum = StringArithmetic.SumPositiveInts("10", "9");
        Console.WriteLine(sum);

        string product = StringArithmetic.MultiplyPositiveInts("21", "2");
        Console.WriteLine(product);
    }
}
