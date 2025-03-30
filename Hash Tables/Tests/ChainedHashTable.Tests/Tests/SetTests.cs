namespace ChainedHashTable.Tests;

[TestClass]
public class SetTests
{
	[TestMethod]
	[ExpectedException(typeof(ArgumentNullException))]
	public void Set_PassNullValue_ThrowsArgumentNullException()
	{
		ChainedHashTable<int, string> myHashTable = new();

		myHashTable.Set(1, null!);
	}

	[TestMethod]
	[DataRow(1)]
	[DataRow(10)]
	[DataRow(90)]
	public void Set_SetItems_UpdatesCountAccordingly(int count)
	{
		KeyValuePair<int, string>[] keyValuePairs = GetRandomData(count);
		ChainedHashTable<int, string> myHashTable = new ChainedHashTable<int, string>();
		int expected = count;

		foreach (KeyValuePair<int, string> keyValuePair in keyValuePairs)
		{
			myHashTable.Set(keyValuePair.Key, keyValuePair.Value);
		}
		int actual = myHashTable.Count();

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(1)]
	[DataRow(10)]
	[DataRow(90)]
	public void Set_SetItems_Works(int count)
	{
		KeyValuePair<int, string>[] keyValuePairs = GetRandomData(count);
		ChainedHashTable<int, string> myHashTable = new ChainedHashTable<int, string>();
		int expected = keyValuePairs.Length;

		foreach (KeyValuePair<int, string> keyValuePair in keyValuePairs)
		{
			myHashTable.Set(keyValuePair.Key, keyValuePair.Value);
		}
		int actual = myHashTable.Count();

		Assert.AreEqual(expected, actual);
	}

	private KeyValuePair<int, string>[] GetRandomData(int count)
	{
		Random random = new();
		KeyValuePair<int, string>[] keyValuePairs = new KeyValuePair<int, string>[count];
		for (int i = 0; i < count; i++)
		{
			int key = random.Next();
			KeyValuePair<int, string> keyValuePair = new KeyValuePair<int, string>(key, $"Test Number {key}.");
			if(!keyValuePairs.Any(pair => pair.Key == key)) {
				keyValuePairs[i] = keyValuePair;
			}
		}
		return keyValuePairs;
	}
}
