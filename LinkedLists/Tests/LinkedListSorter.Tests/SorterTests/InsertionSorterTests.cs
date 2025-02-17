namespace LinkedListSorter.Tests;

[TestClass()]
public class InsertionSorterTests
{
	[TestMethod()]
	public void Sort_SortingEmptyLinkedList_DoesNothing()
	{
		LinkedList<int> ints = new LinkedList<int>();
		int expected = ints.Count;

		InsertionSorter<int>.Sort(ints);
		int actual = ints.Count;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow(1, 2, 3, 4, 5, 6)]
	[DataRow(-1, 0, 2, 22, 100, 199)]
	public void Sort_SortingAlreadySortedList_DoesNothing(params int[] inputs)
	{
		LinkedList<int> ints = new LinkedList<int>(inputs);
		int[] initialArray = ints.ToArray();
		bool expected = true;

		InsertionSorter<int>.Sort(ints);
		bool actual = IsItemsInTheSameOrder(initialArray, ints.ToArray());

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow(1, 2, 1)]
	[DataRow(2, 2, 2)]
	[DataRow(99, -1, 0)]
	[DataRow(1029, -99, 0, 1, 2, 55, -89, 0)]
	public void Sort_SortingLinkedList_SortsTheArray(params int[] inputs)
	{
		LinkedList<int> ints = new(inputs);
		bool expected = true;

		InsertionSorter<int>.Sort(ints);
		bool actual = IsArraySorted(ints.ToArray());

		Assert.AreEqual(expected, actual);
	}

	private bool IsItemsInTheSameOrder(int[] array1, int[] array2)
	{
		if (array1.Length != array2.Length)
		{
			return false;
		}
		for (int i = 0; i < array1.Length; i++)
		{
			if (array1[i] != array2[i])
			{
				return false;
			}
		}
		return true;
	}

	private bool IsArraySorted(int[] array)
	{
		int smaller = array[0];
		for (int i = 1; i < array.Length; i++)
		{
			if(smaller > array[i]) {
				return false;
			}
			smaller = array[i];
		}
		return true;
	}
}