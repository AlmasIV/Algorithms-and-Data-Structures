namespace InsertionSorting.Tests;

[TestClass]
public class InsertionSortingTests
{
	private static bool IsArraySorted(int[] array)
	{
		int tempSmall = array[0];
		for (int i = 1; i < array.Length; i++)
		{
			if (tempSmall > array[i])
			{
				return false;
			}
			tempSmall = array[i];
		}
		return true;
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentNullException))]
	public void Sort_PassNull_ThrowsArgumentNullException()
	{
		int[] ints = null;

		InsertionSorting<int>.Sort(ints!);
	}
	[TestMethod]
	[DataRow(0)]
	[DataRow(1)]
	public void Sort_PassOneElementArray_DoesNothing(int num)
	{
		int[] input = { num };
		bool expected = input[0] == num;

		InsertionSorting<int>.Sort(input);
		bool actual = input[0] == num;
		
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(0)]
	[DataRow(1, 2, 3, 4, 5)]
	[DataRow(1, 2, 3, 4, 5, 0, -22321, 22, 30339, -9, -9, 0, 22, 2)]
	public void Sort_PassRandomArray_Sorts(params int[] ints)
	{
		bool expected = true;

		InsertionSorting<int>.Sort(ints);
		bool actual = IsArraySorted(ints);

		Assert.AreEqual(expected, actual);
	}
}