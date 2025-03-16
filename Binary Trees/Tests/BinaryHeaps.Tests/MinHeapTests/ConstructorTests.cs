namespace BinaryHeaps.MinHeap.Tests;

[TestClass]
public class ConstructorTests
{
	[TestMethod]
	[ExpectedException(typeof(ArgumentNullException))]
	public void Constructor_PassNull_ThrowsArgumentNullException()
	{
		MinHeap<int> myHeap = new(null!);
	}

	[TestMethod]
	[DataRow(0, 1, 2)]
	[DataRow(2, 1, 0)]
	[DataRow(0, 1, 2, 3, 4, 5, 6)]
	[DataRow(0, 1, 2, 3, 4, 5, 6, 7, -9, 2, 0)]
	public void Constructor_PassRandomArray_CreatesMinHeapFromArray(params int[] ints)
	{
		MinHeap<int> myHeap = new(ints);
		bool expected = true;

		bool actual = MinHeap<int>.IsMinHeap(myHeap.ToArray());

		Assert.AreEqual(expected, actual);
	}
}