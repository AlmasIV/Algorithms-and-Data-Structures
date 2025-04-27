using System.Numerics;

namespace Factorial;

class Program
{
    static void Main()
    {
        ulong input = 5;
        BigInteger factorial = Factorial.Compute(input);
        Console.WriteLine($"The factorial of the {input} is {factorial}.");
    }
}
