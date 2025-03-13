namespace BinaryHeaps.MaxHeap.Tests;

[TestClass]
public class InsertRemoveTopItemTests
{
	[TestMethod]
	[DataRow(0)]
	public void InsertRemoveTopItem_PerformOnEmptyHeap_ReturnsPassedItem(int item)
	{
		MaxHeap<int> myHeap = new();
		int expected = item;

		int actual = myHeap.InsertRemoveTopItem(item);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(1, new int[] { 1, 2, 3 })]
	[DataRow(10, new int[] { 10, 90, 99, -2 })]
	public void InsertRemoveTopItem_PassSmallItemToRandomHeap_ReturnsMaxItem(int item, int[] ints)
	{
		MaxHeap<int> myHeap = new();
		int expected = ints.Max();
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
	public void InsertRemoveTopItem_PassSmallItemToRandomHeap_StillMaxHeap(int item, int[] ints) {
		MaxHeap<int> myHeap = new();
		bool expected = true;
		foreach (int i in ints)
		{
			myHeap.Insert(i);
		}

		myHeap.InsertRemoveTopItem(item);
		bool actual = MaxHeap<int>.IsMaxHeap(myHeap.ToArray());

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(10, new int[] { 1, 2, 3 })]
	[DataRow(100, new int[] { 10, 90, 99, -2 })]
	public void InsertRemoveTopItem_PassLargestItemToRandomHeap_ReturnsThePassedItem(int item, int[] ints)
	{
		MaxHeap<int> myHeap = new();
		int expected = item;
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
	public void InsertRemoveTopItem_PassLargestItemToRandomHeap_StillMaxHeap(int item, int[] ints)
	{
		MaxHeap<int> myHeap = new();
		bool expected = true;
		foreach (int i in ints)
		{
			myHeap.Insert(i);
		}

		myHeap.InsertRemoveTopItem(item);
		bool actual = MaxHeap<int>.IsMaxHeap(myHeap.ToArray());

		Assert.AreEqual(expected, actual);
	}
}