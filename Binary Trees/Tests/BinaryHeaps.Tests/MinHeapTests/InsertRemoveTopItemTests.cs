namespace BinaryHeaps.MinHeap.Tests;

[TestClass]
public class InsertRemoveTopItemTests
{
	[TestMethod]
	[DataRow(0)]
	public void InsertRemoveTopItem_PerformOnEmptyHeap_ReturnsPassedItem(int item)
	{
		MinHeap<int> myHeap = new();
		int expected = item;

		int actual = myHeap.InsertRemoveTopItem(item);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(1, new int[] { 1, 2, 3 })]
	[DataRow(10, new int[] { 10, 90, 99, -2 })]
	public void InsertRemoveTopItem_PassSmallItemToRandomHeap_ReturnsSmallestItem(int item, int[] ints)
	{
		MinHeap<int> myHeap = new();
		int expected = ints.Min();
		foreach (int i in ints)
		{
			myHeap.Insert(i);
		}

		int actual = myHeap.InsertRemoveTopItem(item);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(1, new int[] { 1, 2, 3, 4 })]
	[DataRow(9, new int[] { 0, 1, 2, 3, 90, 99, -2 })]
	public void InsertRemoveTopItem_PassSmallItemToRandomHeap_StillMinHeap(int item, int[] ints) {
		MinHeap<int> myHeap = new();
		bool expected = true;
		foreach (int i in ints)
		{
			myHeap.Insert(i);
		}

		myHeap.InsertRemoveTopItem(item);
		bool actual = MinHeap<int>.IsMinHeap(myHeap.ToArray());

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(10, new int[] { 1, 2, 3 })]
	[DataRow(100, new int[] { 10, 90, 99, -2 })]
	public void InsertRemoveTopItem_PassLargestItemToRandomHeap_ReturnsTheMinItem(int item, int[] ints)
	{
		MinHeap<int> myHeap = new();
		int expected = ints.Min();
		foreach (int i in ints)
		{
			myHeap.Insert(i);
		}

		int actual = myHeap.InsertRemoveTopItem(item);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(10, new int[] { 1, 2, 3, 4 })]
	[DataRow(900, new int[] { 0, 1, 2, 3, 90, 99, -2 })]
	public void InsertRemoveTopItem_PassLargestItemToRandomHeap_StillMinHeap(int item, int[] ints)
	{
		MinHeap<int> myHeap = new();
		bool expected = true;
		foreach (int i in ints)
		{
			myHeap.Insert(i);
		}

		myHeap.InsertRemoveTopItem(item);
		bool actual = MinHeap<int>.IsMinHeap(myHeap.ToArray());

		Assert.AreEqual(expected, actual);
	}
}