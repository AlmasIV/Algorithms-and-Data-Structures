namespace ChainedHashTable.Tests;

[TestClass]
public class ContainsByKeyTests
{
	[TestMethod]
	public void ContainsByKey_CheckEmptyHashTable_ReturnsFalse()
	{
		ChainedHashTable<int, string> myHashTable = new();
		bool expected = false;

		bool actual = myHashTable.ContainsByKey(10);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void ContainsByKey_PassNonExistingKey_ReturnsFalse()
	{
		ChainedHashTable<int, string> myHashTable = new();
		myHashTable.Set(1, "Hello");
		myHashTable.Set(2, "World!");
		bool expected = false;

		bool actual = myHashTable.ContainsByKey(10);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void ContainsByKey_PassExistingKey_ReturnsTrue()
	{
		ChainedHashTable<int, string> myHashTable = new();
		KeyValuePair<int, string>[] samples = SampleGenerator.GetRandomData(10000);
		bool expected = true;
		foreach (KeyValuePair<int, string> sample in samples)
		{
			myHashTable.Set(sample);
		}

		bool actual = myHashTable.ContainsByKey(samples[0].Key);

		Assert.AreEqual(expected, actual);
	}
}