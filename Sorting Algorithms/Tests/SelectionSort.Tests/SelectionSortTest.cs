namespace SelectionSort.Tests;

[TestClass]
public class SelectionSortTest
{
	private static bool IsArraySorted(int[] array)
	{
		int smallTemp = array[0];
		for (int i = 1; i < array.Length; i++)
		{
			if (smallTemp > array[i])
			{
				return false;
			}
			smallTemp = array[i];
		}
		return true;
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentNullException))]
	public void Sort_PassNull_ThrowsArgumentNullException()
	{
		SelectionSort<int>.Sort(null!);
	}

	[TestMethod]
	[DataRow(0)]
	[DataRow(1)]
	[DataRow(-99)]
	public void Sort_SortSingleElementArray_DoesNothing(int element)
	{
		int[] input = { element };
		
		SelectionSort<int>.Sort(input);

		Assert.AreEqual(input[0], element);
	}

	[TestMethod]
	[DataRow(0)]
	[DataRow(1)]
	[DataRow(-99)]
	[DataRow(-99, 0, 22, 1, 2, -9202, 2, 0, 21, 22, 2, 66, 78273288, -292187)]
	public void Sort_PassRandomArray_Sorts(params int[] elements)
	{
		bool expected = true;

		SelectionSort<int>.Sort(elements);
		bool actual = IsArraySorted(elements);

		Assert.AreEqual(expected, actual);
	}
}