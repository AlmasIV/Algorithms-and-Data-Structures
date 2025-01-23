namespace NumberFactorizer;

class Program
{
    static void Main()
    {
        List<ulong> factors = Factorizer.Factorize(1000);
        foreach(ulong factor in factors) {
            Console.WriteLine(factor);
        }
    }
}
