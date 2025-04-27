using System.Numerics;

namespace Fibonacci;

class Program
{
    static void Main(string[] args)
    {
        ulong input = 5;
        BigInteger nthNumber = Fibonacci.ComputeNth(input);
        Console.WriteLine($"The {input}th fibonacci number is {nthNumber}.");
    }
}
