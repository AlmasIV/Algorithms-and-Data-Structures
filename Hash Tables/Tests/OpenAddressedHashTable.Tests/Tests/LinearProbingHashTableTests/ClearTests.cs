
using OpenAddressedHashTable.Tests;

namespace OpenAddressedHashTable.LinearProbingHashTable.Tests;

[TestClass]
public class ClearTests
{
	[TestMethod]
	[ExpectedException(typeof(InvalidOperationException))]
	public void Clear_CallOnEmptyHashTable_ThrowsInvalidOperationException()
	{
		LinearProbingHashTable<int, string> myHashTable = new();

		myHashTable.Clear();
	}

	[TestMethod]
	public void Clear_CallClear_SetsCountToZero()
	{
		LinearProbingHashTable<int, string> myHashTable = new();
		KeyValuePair<int, string>[] samples = SampleGenerator.GetRandomData(100);
		int expected = 0;
		foreach (KeyValuePair<int, string> sample in samples)
		{
			myHashTable.Add(sample!);
		}

		myHashTable.Clear();
		int actual = myHashTable.Count;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void Clear_CallClear_LINQReturnsEmptyArray()
	{
		LinearProbingHashTable<int, string> myHashTable = new();
		KeyValuePair<int, string>[] samples = SampleGenerator.GetRandomData(100);
		int expected = 0;
		foreach (KeyValuePair<int, string> sample in samples)
		{
			myHashTable.Add(sample!);
		}

		myHashTable.Clear();
		int actual = myHashTable.ToArray()!.Length;

		Assert.AreEqual(expected, actual);
	}
}