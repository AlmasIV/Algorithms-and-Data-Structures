namespace BinaryHeaps.MinHeap.Tests;

[TestClass]
public class IsMinHeapTests
{
	[TestMethod]
	[ExpectedException(typeof(ArgumentNullException))]
	public void IsMinHeap_PassingNull_ThrowsArgumentNullException()
	{
		MinHeap<int>.IsMinHeap(null!);
	}

	[TestMethod]
	public void IsMinHeap_PassingEmptyBinaryTree_ReturnsFalse()
	{
		int[] sample = new int[0];
		bool expected = false;

		bool actual = MinHeap<int>.IsMinHeap(new int[0]);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(0)]
	[DataRow(9)]
	[DataRow(-2)]
	public void IsMinHeap_PassingSingleElementBinaryTree_ReturnsTrue(int element)
	{
		int[] input = { element };
		bool expected = true;
		
		bool actual = MinHeap<int>.IsMinHeap(input);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(99, 8, 9)]
	[DataRow(100, 99, 9, 2, 1, 300)]
	[DataRow(1000, 10, 35, 99)]
	[DataRow(1, -2, -3, -5, 5)]
	[DataRow(7, 6, 5, 4, 3, 2, 1, 10)]
	[DataRow(7, 6, 5, 4, 3, 2, 1, 0, -1, -2, 100)]
	public void IsMinHeap_PassingNonMinHeapBinaryTree_ReturnsFalse(params int[] binaryTree)
	{
		bool expected = false;

		bool actual = MinHeap<int>.IsMinHeap(binaryTree);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(0, 1, 2)]
	[DataRow(0, 1, 2, 3)]
	[DataRow(0, 1, 2, 3, 4)]
	[DataRow(0, 1, 2, 3, 4, 5)]
	[DataRow(0, 1, 2, 3, 4, 5, 6)]
	public void IsMinHeap_PassingMinHeapBinaryTree_ReturnsTrue(params int[] binaryTree)
	{
		bool expected = true;

		bool actual = MinHeap<int>.IsMinHeap(binaryTree);

		Assert.AreEqual(expected, actual);
	}
}