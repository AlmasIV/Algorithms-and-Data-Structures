namespace SortedDoublyLinkedList.Tests;

[TestClass()]
public class CopyTests
{
	[TestMethod()]
	public void Copy_CopyingEmptyList_CopiesIt()
	{
		SortedLinkedList<int> ints = new SortedLinkedList<int>();

		SortedLinkedList<int> copy = ints.Copy();

		Assert.AreNotEqual(ints, copy);
	}

	[TestMethod()]
	public void Copy_CopyingEmptyList_LengthIsSetCorrectly()
	{
		SortedLinkedList<int> ints = new SortedLinkedList<int>();
		ulong expected = 0;

		SortedLinkedList<int> copy = ints.Copy();
		ulong actual = copy.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow(1, 2, 3, 4, 5)]
	[DataRow(2, 3, 1, 1, 22, 34, -99)]
	public void Copy_CopyingNonEmptyList_CopiesListCorrectly(params int[] inputs)
	{
		SortedLinkedList<int> ints = new();
		bool expected = true;

		foreach (int i in inputs)
		{
			ints.AddNode(i);
		}
		SortedLinkedList<int> copy = ints.Copy();
		bool actual = IsTwoArraysContainTheSameElements(ints.ToArray(), copy.ToArray());

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow(1, 2, 3, 4, 5)]
	[DataRow(2, 3, 1, 1, 22, 34, -99)]
	public void Copy_CopyingNonEmptyList_SameLengthIsSet(params int[] inputs)
	{
		SortedLinkedList<int> ints = new();
		ulong expected = (ulong)inputs.Length;

		foreach (int i in inputs)
		{
			ints.AddNode(i);
		}
		SortedLinkedList<int> copy = ints.Copy();
		ulong actual = copy.Length;

		Assert.AreEqual(expected, actual);
	}

	private bool IsTwoArraysContainTheSameElements(int[] array1, int[] array2)
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
}