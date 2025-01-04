namespace PseudoRandomNumberGenerator;

class Program
{
    static void Main()
    {
        int counter = 0;
        //LinearCongruentialGenerator.SetConstants(11, 7, 5, 0);
        while(counter < 100) {
            ulong fromRange = LinearCongruentialGenerator.GenerateNumberInRange(0, 100);
            Console.WriteLine(fromRange);
            counter ++;
        }
    }
}
