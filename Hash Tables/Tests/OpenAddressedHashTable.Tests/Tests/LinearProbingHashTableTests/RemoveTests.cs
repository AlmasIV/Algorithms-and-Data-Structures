namespace OpenAddressedHashTable.LinearProbingHashTable.Tests;

[TestClass]
public class RemoveTests
{
	[TestMethod]
	public void Remove_RemoveOnEmptyHashTable_ReturnsFalse()
	{
		LinearProbingHashTable<int, string> myHashTable = new();
		bool expected = false;

		bool actual = myHashTable.Remove(1);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(0, 1, 2, 3, 4)]
	public void Remove_RemoveNonExistentItem_ReturnsFalse(int nonExistentKey, params int[] keys)
	{
		LinearProbingHashTable<int, string> myHashTable = new();
		bool expected = false;
		string sample = "Hello World!";
		foreach (int key in keys)
		{
			myHashTable.Add(key, sample);
		}

		bool actual = myHashTable.Remove(nonExistentKey);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(1, 1, 2, 3, 4, 5)]
	public void Remove_RemoveExistingItem_ReturnsTrue(int existingKey, params int[] keys)
	{
		LinearProbingHashTable<int, string> myHashTable = new();
		bool expected = true;
		string sample = "Hello World!";
		foreach (int key in keys)
		{
			myHashTable.Add(key, sample);
		}

		bool actual = myHashTable.Remove(existingKey);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(1, 1, 2, 3, 4, 5)]
	public void Remove_RemoveExistingItem_RemovesItem(int existingKey, params int[] keys)
	{
		LinearProbingHashTable<int, string> myHashTable = new();
		bool expected = false;
		string sample = "Hello World!";
		foreach (int key in keys)
		{
			myHashTable.Add(key, sample);
		}

		myHashTable.Remove(existingKey);
		bool actual = myHashTable.ToArray().Any(kvp => kvp.Key == existingKey);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(0, 1, 2, 3, 4, 5)]
	public void Remove_RemoveNonExistingItem_CountIsSame(int nonExistentKey, params int[] keys)
	{
		LinearProbingHashTable<int, string> myHashTable = new();
		int expected = keys.Length;
		string sample = "Hello World!";
		foreach (int key in keys)
		{
			myHashTable.Add(key, sample);
		}

		myHashTable.Remove(nonExistentKey);
		int actual = myHashTable.Count;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(1, 1, 2, 3, 4, 5)]
	public void Remove_RemoveExistingItem_DecrementsCount(int existingKey, params int[] keys)
	{
		LinearProbingHashTable<int, string> myHashTable = new();
		int expected = keys.Length - 1;
		string sample = "Hello World!";
		foreach (int key in keys)
		{
			myHashTable.Add(key, sample);
		}

		myHashTable.Remove(existingKey);
		int actual = myHashTable.Count;

		Assert.AreEqual(expected, actual);
	}
}