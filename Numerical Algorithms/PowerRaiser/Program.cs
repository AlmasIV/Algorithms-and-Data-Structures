namespace PowerRaiser;

class Program
{
    static void Main()
    {
        string sum = StringArithmetic.SumPositiveInts("10", "9");
        Console.WriteLine($"Sum: {sum}");

        string product = StringArithmetic.MultiplyPositiveInts("18446744073709551615", "18446744073709551615");
        Console.WriteLine($"Product: {product}");

        string exponentiation = StringArithmetic.RaisePositiveIntToPower("2", 10);
        Console.WriteLine($"Exponentiation: {exponentiation}");
    }
}