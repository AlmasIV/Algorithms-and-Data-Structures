namespace OpenAddressedHashTable.QuadraticProbingHashTable.Tests;

[TestClass]
public class TryGetValueTests
{
	[TestMethod]
	public void TryGetValue_TryOnEmptyHashTable_ReturnsFalse()
	{
		LinearProbingHashTable<int, string> myHashTable = new();
		bool expected = false;

		bool actual = myHashTable.TryGetValue(0, out string? value);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(0, 1, 2, 3, 4)]
	public void TryGetValue_TryGetNonExistingKey_ReturnsFalse(int nonExistentKey, params int[] keys)
	{
		LinearProbingHashTable<int, string> myHashTable = new();
		bool expected = false;
		string sample = "Hello World!";
		foreach (int key in keys)
		{
			myHashTable.Add(key, sample);
		}

		bool actual = myHashTable.TryGetValue(nonExistentKey, out string? value);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(0, 1, 2, 3, 4)]
	public void TryGetValue_TryGetNonExistingKey_OutsNull(int nonExistentKey, params int[] keys)
	{
		LinearProbingHashTable<int, string> myHashTable = new();
		bool expected = true;
		string sample = "Hello World!";
		foreach (int key in keys)
		{
			myHashTable.Add(key, sample);
		}

		myHashTable.TryGetValue(nonExistentKey, out string? value);
		bool actual = value is null;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(1, 1, 2, 3, 4)]
	public void TryGetValue_TryGetExistingKey_ReturnsTrue(int nonExistentKey, params int[] keys)
	{
		LinearProbingHashTable<int, string> myHashTable = new();
		bool expected = true;
		string sample = "Hello World!";
		foreach (int key in keys)
		{
			myHashTable.Add(key, sample);
		}

		bool actual = myHashTable.TryGetValue(nonExistentKey, out string? value);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(1, 1, 2, 3, 4)]
	public void TryGetValue_TryGetExistingKey_OutsValue(int nonExistentKey, params int[] keys)
	{
		LinearProbingHashTable<int, string> myHashTable = new();
		bool expected = true;
		string sample = "Hello World!";
		foreach (int key in keys)
		{
			myHashTable.Add(key, sample);
		}

		myHashTable.TryGetValue(nonExistentKey, out string? value);
		bool actual = value == sample;

		Assert.AreEqual(expected, actual);
	}
}