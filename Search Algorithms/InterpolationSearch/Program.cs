namespace InterpolationSearch;

class Program
{
    static void Main(string[] args)
    {
        Data[] dataArray = {
            new Data(1, "Payload 1"),
            new Data(2, "Payload 2"),
            new Data(3, "Payload 3")
        };

        int index = InterpolationSearch<Data>.Search(dataArray, 2);

        Console.WriteLine(dataArray[index].Payload);
    }

    private class Data : IKey
    {
        public int Key { get; init; }
        public string Payload { get; init; }

        public Data(int key, string payload)
        {
            Key = key;
            Payload = payload;
        }
    }
}
