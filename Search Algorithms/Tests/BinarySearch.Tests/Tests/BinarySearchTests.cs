namespace BinarySearch.Tests;

[TestClass]
public class BinarySearchTests
{
	[TestMethod]
	[ExpectedException(typeof(ArgumentNullException))]
	public void Search_PassNullArray_ThrowsArgumentNullException()
	{
		BinarySearch<int>.Search(null!, 0);
	}

	[TestMethod]
	[DataRow(new int[] { 0, 1, 2 }, 2)]
	[DataRow(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, }, 9)]
	public void Search_PassRandomArrayAndTarget_ReturnsCorrectIndex(int[] sortedArray, int target)
	{
		int expected = target;

		int actualIndex = BinarySearch<int>.Search(sortedArray, target);
		int actual = sortedArray[actualIndex];

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(new int[] { 0, 1, 2 }, 20)]
	[DataRow(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, }, 90)]
	public void Search_PassRandomArrayAndNonExistentTarget_ReturnsNegative(int[] sortedArray, int target)
	{
		int expected = -1;

		int actual = BinarySearch<int>.Search(sortedArray, target);

		Assert.AreEqual(expected, actual);
	}
}