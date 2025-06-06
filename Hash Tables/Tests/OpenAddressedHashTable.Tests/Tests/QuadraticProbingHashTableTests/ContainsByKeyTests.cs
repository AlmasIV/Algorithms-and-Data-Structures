namespace OpenAddressedHashTable.QuadraticProbingHashTable.Tests;

[TestClass]
public class ContainsByKeyTests
{
    [TestMethod]
    public void ContainsByKey_PassKeyOnEmptyHashTable_ReturnsFalse()
    {
        QuadraticProbingHashTable<int, string> myHashTable = new();
        bool expected = false;

        bool actual = myHashTable.ContainsByKey(0);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0, 1, 2, 3, 4, 5)]
    [DataRow(99, 100, 1, 2, 3, 4)]
    public void ContainsByKey_PassNonExistingKey_ReturnsFalse(int nonExistentKey, params int[] keys)
    {
        QuadraticProbingHashTable<int, string> myHashTable = new();
        bool expected = false;
        string sample = "Hello World!";
        foreach (int key in keys)
        {
            myHashTable.Add(key, sample);
        }

        bool actual = myHashTable.ContainsByKey(nonExistentKey);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(1, 1, 2, 3, 4, 5)]
    [DataRow(100, 100, 1, 2, 3, 4)]
    public void ContainsByKey_PassExistingKey_ReturnsTrue(int existentKey, params int[] keys)
    {
        QuadraticProbingHashTable<int, string> myHashTable = new();
        bool expected = true;
        string sample = "Hello World!";
        foreach (int key in keys)
        {
            myHashTable.Add(key, sample);
        }

        bool actual = myHashTable.ContainsByKey(existentKey);

        Assert.AreEqual(expected, actual);
    }
}