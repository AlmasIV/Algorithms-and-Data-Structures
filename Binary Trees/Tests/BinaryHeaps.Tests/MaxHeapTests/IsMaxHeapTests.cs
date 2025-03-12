namespace BinaryHeaps.MaxHeap.Tests;

[TestClass]
public class IsMaxHeapTests
{
	[TestMethod]
	[ExpectedException(typeof(ArgumentNullException))]
	public void IsMaxHeap_PassingNull_ThrowsArgumentNullException()
	{
		MaxHeap<int>.IsMaxHeap(null!);
	}

	[TestMethod]
	public void IsMaxHeap_PassingEmptyBinaryTree_ReturnsFalse()
	{
		int[] sample = new int[0];
		bool expected = false;

		bool actual = MaxHeap<int>.IsMaxHeap(new int[0]);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(0)]
	[DataRow(9)]
	[DataRow(-2)]
	public void IsMaxHeap_PassingSingleElementBinaryTree_ReturnsTrue(int element)
	{
		int[] input = { element };
		bool expected = true;
		
		bool actual = MaxHeap<int>.IsMaxHeap(input);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(0, 1, 2)]
	[DataRow(100, 99, 9, 2, 1, 300)]
	[DataRow(1000, 10, 35, 99)]
	[DataRow(1, -2, -3, -5, 5)]
	[DataRow(7, 6, 5, 4, 3, 2, 1, 10)]
	[DataRow(7, 6, 5, 4, 3, 2, 1, 0, -1, -2, 100)]
	public void IsMaxHeap_PassingNonMaxHeapBinaryTree_ReturnsFalse(params int[] binaryTree)
	{
		bool expected = false;

		bool actual = MaxHeap<int>.IsMaxHeap(binaryTree);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(10, 9, 8)]
	[DataRow(10, 9, 8, 7)]
	[DataRow(10, 9, 8, 7, 6)]
	[DataRow(10, 9, 8, 7, 6, 5)]
	[DataRow(10, 9, 8, 7, 6, 5, 4)]
	[DataRow(10, 9, 8, 7, 6, 5, 4, 3)]
	[DataRow(10, 9, 8, 7, 6, 5, 4, 3, 2)]
	[DataRow(10, 9, 8, 7, 6, 5, 4, 3, 2, 1)]
	public void IsMaxHeap_PassingMaxHeapBinaryTree_ReturnsTrue(params int[] binaryTree)
	{
		bool expected = true;

		bool actual = MaxHeap<int>.IsMaxHeap(binaryTree);

		Assert.AreEqual(expected, actual);
	}
}