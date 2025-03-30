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
		ChainedHashTable<int, string> myHashTable = new();
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
	public void Set_SetItems_ItemsAreActuallySet(int count)
	{
		KeyValuePair<int, string>[] keyValuePairs = GetRandomData(count);
		ChainedHashTable<int, string> myHashTable = new();
		bool expected = true;

		foreach (KeyValuePair<int, string> keyValuePair in keyValuePairs)
		{
			myHashTable.Set(keyValuePair.Key, keyValuePair.Value);
		}
		bool actual = ContainsIdenticalItems(keyValuePairs, myHashTable.ToArray());

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void Set_PassDuplicateKey_ItemRewritten()
	{
		ChainedHashTable<int, string> myHashTable = new();
		KeyValuePair<int, string> keyValuePair1 = new(1, "Item 1");
		KeyValuePair<int, string> keyValuePair2 = new(1, "Rewritten");
		string expected = keyValuePair2.Value;

		myHashTable.Set(keyValuePair1.Key, keyValuePair1.Value);
		myHashTable.Set(keyValuePair2.Key, keyValuePair2.Value);
		string actual = myHashTable.ToArray().First().Value;

		Assert.AreEqual(expected, actual);
	}

	private KeyValuePair<int, string>[] GetRandomData(int count)
	{
		Random random = new();
		KeyValuePair<int, string>[] keyValuePairs = new KeyValuePair<int, string>[count];
		for (int i = 0; i < count; i++)
		{
			int key = random.Next();
			KeyValuePair<int, string> keyValuePair = new(key, $"Test Number {key}.");
			if (!keyValuePairs.Any(pair => pair.Key == key))
			{
				keyValuePairs[i] = keyValuePair;
			}
		}
		return keyValuePairs;
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
