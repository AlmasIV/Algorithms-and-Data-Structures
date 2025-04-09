namespace OpenAddressedHashTable.LinearProbingHashTable.Tests;

[TestClass]
public class RemoveTests
{
	[TestMethod]
	[ExpectedException(typeof(InvalidOperationException))]
	public void Remove_RemoveOnEmptyHashTable_ThrowsInvalidOperationException()
	{
		LinearProbingHashTable<int, string> myHashTable = new();

		myHashTable.Remove(1);
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
}