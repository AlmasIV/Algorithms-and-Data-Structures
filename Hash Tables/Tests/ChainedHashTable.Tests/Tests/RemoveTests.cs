namespace ChainedHashTable.Tests;

[TestClass]
public class RemoveTests
{
	[TestMethod]
	public void Remove_RemoveOnEmptyHashTable_ReturnsFalse()
	{
		ChainedHashTable<int, string> myHashTable = new();
		bool expected = false;

		bool actual = myHashTable.Remove(1);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void Remove_RemoveOnEmptyHashTable_DoesNotChangeCount()
	{
		ChainedHashTable<int, string> myHashTable = new();
		int expected = myHashTable.Count;

		myHashTable.Remove(1);
		int actual = myHashTable.Count;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void Remove_RemoveNonExistentKey_ReturnsFalse()
	{
		ChainedHashTable<int, string> myHashTable = new();
		myHashTable.Set(10, "Hello");
		myHashTable.Set(11, "World!");
		bool expected = false;

		bool actual = myHashTable.Remove(1);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void Remove_RemoveNonExistingKey_DoesNotChangeCount()
	{
		ChainedHashTable<int, string> myHashTable = new();
		myHashTable.Set(10, "Hello");
		myHashTable.Set(11, "World!");
		int expected = myHashTable.Count;

		myHashTable.Remove(1);
		int actual = myHashTable.Count;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void Remove_RemoveExistentKey_ReturnsTrue()
	{
		ChainedHashTable<int, string> myHashTable = new();
		KeyValuePair<int, string> sample = new(2, "Value 2");
		myHashTable.Set(0, "Value 0");
		myHashTable.Set(1, "Value 1");
		myHashTable.Set(sample);
		bool expected = true;

		bool actual = myHashTable.Remove(sample.Key);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void Remove_RemoveExistentKey_DecrementsCount()
	{
		ChainedHashTable<int, string> myHashTable = new();
		KeyValuePair<int, string> sample = new(2, "Value 2");
		myHashTable.Set(0, "Value 0");
		myHashTable.Set(1, "Value 1");
		myHashTable.Set(sample);
		int expected = myHashTable.Count - 1;

		myHashTable.Remove(sample.Key);
		int actual = myHashTable.Count;

		Assert.AreEqual(expected, actual);
	}
}