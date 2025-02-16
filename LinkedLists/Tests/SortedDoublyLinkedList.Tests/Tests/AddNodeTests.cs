namespace SortedDoublyLinkedList.Tests;

[TestClass()]
public class AddNodeTests
{
	[TestMethod()]
	[DataRow(100)]
	public void AddNode_AddingNode_AddsNode(int value)
	{
		SortedLinkedList<int> ints = new SortedLinkedList<int>();
		int expected = value;

		ints.AddNode(100);
		int actual = ints.First();

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow(100)]
	public void AddNode_AddingNode_IncrementsLength(int value)
	{
		SortedLinkedList<int> ints = new SortedLinkedList<int>();
		ulong expected = 1;

		ints.AddNode(value);
		ulong actual = ints.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow(1, 2)]
	[DataRow(2, 1)]
	[DataRow(100, 1)]
	[DataRow(-99, 1)]
	[DataRow(0, 0)]
	public void AddNode_AddingTwoNodes_AddsThemInSortedOrderByAscending(int a, int b)
	{
		SortedLinkedList<int> ints = new SortedLinkedList<int>();
		bool expected = true;

		ints.AddNode(a);
		ints.AddNode(b);
		bool actual = IsArraySorted(ints.ToArray());

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow(1, 2, 3, 4)]
	[DataRow(1, 3, 2, 4)]
	[DataRow(2, 3, 1, 4)]
	[DataRow(4, 3, 2, 1)]
	[DataRow(-1, 2, -99, 200, 2)]
	[DataRow(5, 5, 5)]
	[DataRow(-1, 2, 99, 200, 3, -890, -9, 0, 1)]
	public void AddNode_AddingSequenceOfNodes_AddsThemInSortedOrderByAscending(params int[] inputs)
	{
		SortedLinkedList<int> ints = new SortedLinkedList<int>();
		bool expected = true;

		foreach(int i in inputs) {
			ints.AddNode(i);
		}
		bool actual = IsArraySorted(ints.ToArray());

		Assert.AreEqual(expected, actual);
	}

	private bool IsArraySorted(int[] ints)
	{
		int small = ints[0];
		for (int i = 1; i < ints.Length; i++)
		{
			if (ints[i] < small)
			{
				return false;
			}
			small = ints[i];
		}
		return true;
	}
}