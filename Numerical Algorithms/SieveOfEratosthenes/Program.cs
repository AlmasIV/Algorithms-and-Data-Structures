namespace SieveOfEratosthenes;

class Program
{
    static void Main()
    {
        ulong upperBound = 10000;
        List<ulong> primes = PrimeFinder.FindPrimesUpToUpperBound(upperBound);
        
        foreach(ulong prime in primes) {
            Console.WriteLine(prime);
        }
    }
}
