namespace PseudoRandomNumberGenerator;

class Program
{
    static void Main()
    {
        int counter = 0;
        while(counter < 100) {
            ulong fromRange = LinearCongruentialGenerator.GenerateNumberInRange(0, 100);
            Console.WriteLine(fromRange);
            counter ++;
        }
    }
}
