using OpenAddressedHashTable.Tests;

namespace OpenAddressedHashTable.QuadraticProbingHashTable.Tests;

[TestClass]
public class AddTests
{
    [TestMethod]
    [DataRow(0)]
    [DataRow(0, 1, 2)]
    [DataRow(0, 1, 2, 3, 4)]
    [DataRow(0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
    public void Add_AddItems_IncrementsCount(params int[] keys)
    {
        QuadraticProbingHashTable<int, string> myHashTable = new();
        int expected = keys.Length;
        string sampleValue = "Hello World!";

        foreach (int key in keys)
        {
            myHashTable.Add(key, sampleValue);
        }
        int actual = myHashTable.Count;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(100)]
    [ExpectedException(typeof(ArgumentException))]
    public void Add_AddDuplicateKeys_ThrowsArgumentException(int key)
    {
        QuadraticProbingHashTable<int, string> myHashTable = new();
        string sample = "Hello World!";

        myHashTable.Add(key, sample);
        myHashTable.Add(key, sample);
    }

    [TestMethod]
    public void Add_AddItems_LINQReturnedItemsAreIdenticalToAdded()
    {
        QuadraticProbingHashTable<int, string> myHashTable = new();
        KeyValuePair<int, string>[] samples = SampleGenerator.GetRandomData(100);
        bool expected = true;

        foreach (KeyValuePair<int, string> sample in samples)
        {
            myHashTable.Add(sample!);
        }
        KeyValuePair<int, string>[] payload = myHashTable.ToArray()!;
        bool actual = ContainsIdenticalItems(samples, payload);

        Assert.AreEqual(expected, actual);
    }

    private bool ContainsIdenticalItems(KeyValuePair<int, string>[] keyValuePairs1, KeyValuePair<int, string>[] keyValuePairs2)
    {
        if (keyValuePairs1.Length != keyValuePairs2.Length)
        {
            return false;
        }

        KeyValuePair<int, string>[] sorted1 = keyValuePairs1.OrderBy(kv => kv.Key).ToArray();
        KeyValuePair<int, string>[] sorted2 = keyValuePairs2.OrderBy(kv => kv.Key).ToArray();

        for (int i = 0; i < sorted1.Length; i++)
        {
            if (!sorted1[i].Equals(sorted2[i]))
            {
                return false;
            }
        }
        return true;
    }
}