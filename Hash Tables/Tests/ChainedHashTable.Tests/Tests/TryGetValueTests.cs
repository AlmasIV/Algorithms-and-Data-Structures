namespace ChainedHashTable.Tests;

[TestClass]
public class TryGetValueTests
{
	[TestMethod]
	public void TryGetValue_TryGettingItemOnEmptyHashTable_ReturnsFalseAndOutsDefault()
	{
		ChainedHashTable<int, string> myHashTable = new();
		(bool, string?) expected = (false, default);

		bool doesExist = myHashTable.TryGetValue(0, out string? actualOutput);
		(bool, string?) actual = (doesExist, actualOutput);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TryGetValue_TryGettingItem_ReturnsTrueAndOutsCorrectItem()
	{
		ChainedHashTable<int, string> myHashTable = new();
		myHashTable.Set(1, "Hello");
		myHashTable.Set(2, "Jay");
		(bool, string?) expected = (true, "Jay");

		bool doesExist = myHashTable.TryGetValue(2, out string? value);
		(bool, string?) actual = (doesExist, value);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TryGetValue_TryGettingItemOnLongHashTable_ReturnsTrueAndOutsCorrectItem()
	{
		ChainedHashTable<int, string> myHashTable = new();
		KeyValuePair<int, string>[] samples = SampleGenerator.GetRandomData(10000);
		foreach (KeyValuePair<int, string> sample in samples)
		{
			myHashTable.Set(sample);
		}
		int targetIndex = 100;
		int targetKey = samples[targetIndex].Key;
		(bool, string?) expected = (true, samples[targetIndex].Value);

		bool doesExist = myHashTable.TryGetValue(targetKey, out string? value);
		(bool, string?) actual = (doesExist, value);

		Assert.AreEqual(expected, actual);
	}
}