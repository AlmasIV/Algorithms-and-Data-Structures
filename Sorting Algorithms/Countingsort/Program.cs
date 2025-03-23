namespace Countingsort;

class ExampleSample : IKey
{
    public ushort Key { get; init; }
    public string Value { get; init; }
    public ExampleSample(ushort key, string value)
    {
        Key = key;
        Value = value;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ExampleSample[] examples = {
            new ExampleSample(0, "Red"),
            new ExampleSample(1, "Yellow"),
            new ExampleSample(0, "Green")
        };

        Console.WriteLine("Before sorting: ");
        foreach (var example in examples)
        {
            Console.WriteLine(example.Key + ": " + example.Value);
        }

        examples = Countingsort<ExampleSample>.Sort(examples, 1);
        Console.WriteLine("After sorting: ");
        
        foreach (var example in examples)
        {
            Console.WriteLine(example.Key + ": " + example.Value);
        }
    }
}
