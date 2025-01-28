using SieveOfEratosthenes;

namespace FermatLittleTheorem;

class Program
{
    static void Main()
    {
        ulong maxTestAttempts = 100UL;
        ulong number = 890UL;

        bool isPrime = PrimeChecker.IsProbablyPrime(number, maxTestAttempts);

        string answer = isPrime ? "" : "not";
        Console.WriteLine($"The number {number} is probably {answer} a prime number.");
        
        // Now check with the deterministic algorithm.
        List<ulong> primes = PrimeFinder.FindPrimesUpToUpperBound(number);

        answer = primes.Contains(number) ? "" : "not";
        Console.WriteLine($"The number {number} is for sure {answer} a prime number.");
    }
}
