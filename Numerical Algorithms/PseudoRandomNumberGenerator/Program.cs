namespace PseudoRandomNumberGenerator;

class Program
{
    static void Main()
    {
        ulong randomNumber = 0;
        while(true) {
            randomNumber = LinearCongruentialGenerator.GenerateNumber();
            Console.WriteLine($"\nYour number is: {randomNumber}.");

            MessageLoop:
            Console.WriteLine("Hit 'Enter' to keep generating a number.\nHit 'space' to stop generating a number.");
            ConsoleKeyInfo answer = Console.ReadKey();
            if(answer.Key == ConsoleKey.Enter) {
                continue;
            }
            else if(answer.Key == ConsoleKey.Spacebar) {
                Console.Clear();
                break;
            }
            else {
                goto MessageLoop;
            }
        }
    }
}
