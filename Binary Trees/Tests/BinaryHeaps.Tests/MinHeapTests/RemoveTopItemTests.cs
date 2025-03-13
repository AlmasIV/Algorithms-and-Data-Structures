namespace BinaryHeaps.MinHeap.Tests;

[TestClass]
public class RemoveTopItemTests
{
	[TestMethod]
	[ExpectedException(typeof(InvalidOperationException))]
	public void RemoveTopItem_RemoveOnEmptyHeap_ThrowsInvalidOperationException()
	{
		MinHeap<int> myHeap = new();

		myHeap.RemoveTopItem();
	}

	[TestMethod]
	public void RemoveTopItem_RemoveOnSingleElementHeap_LengthIsZero()
	{
		MinHeap<int> myHeap = new();
		myHeap.Insert(0);
		int expected = 0;

		myHeap.RemoveTopItem();
		int actual = myHeap.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void RemoveTopItem_RemoveOnSingleElementHeap_RemovesTheItem()
	{
		MinHeap<int> myHeap = new();
		int insertedValue = 100;
		myHeap.Insert(insertedValue);
		int expected = insertedValue;

		int actual = myHeap.RemoveTopItem();

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(3, 2, 1)]
	[DataRow(3, 9, 2)]
	[DataRow(3, 2, 9)]
	[DataRow(0, 0, 1, 2, 3, 4)]
	[DataRow(9, 99, 100, -1)]
	public void RemoveTopItem_RemoveOnRandomMinHeap_TheHeapRemainsMinHeap(params int[] itemsToBeInserted)
	{
		MinHeap<int> myHeap = new();
		bool expected = true;
		foreach (int i in itemsToBeInserted)
		{
			myHeap.Insert(i);
		}

		myHeap.RemoveTopItem();
		bool actual = MinHeap<int>.IsMinHeap(myHeap.ToArray());

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(3, 2, 1)]
	[DataRow(2, 99, 99, 0)]
	[DataRow(0, 0, 1, 2, 3, 890)]
	public void RemoveTopItem_RemoveOnRandomMinHeap_TheSmallestItemIsReturned(params int[] itemsToBeInserted)
	{
		MinHeap<int> myHeap = new();
		int expected = itemsToBeInserted.Min();
		foreach (int i in itemsToBeInserted)
		{
			myHeap.Insert(i);
		}

		int actual = myHeap.RemoveTopItem();

		Assert.AreEqual(expected, actual);
	}
}