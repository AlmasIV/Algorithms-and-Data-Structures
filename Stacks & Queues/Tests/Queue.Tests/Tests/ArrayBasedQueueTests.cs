namespace Queue.Tests;

[TestClass]
public class ArrayBasedQueueTests
{
	[TestMethod]
	[DataRow(0)]
	[DataRow(0, 1, 2, 3)]
	[DataRow(-100, 2000, 2, 3, 4)]
	public void Enqueue_EnqueueElements_IncrementsLength(params int[] elements)
	{
		ArrayBasedQueue<int> queue = new();
		int expected = elements.Length;

		for (int i = 0; i < elements.Length; i++)
		{
			queue.Enqueue(elements[i]);
		}
		int actual = queue.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(1, 2, 3)]
	[DataRow(0, 100, 22, 3, 4)]
	public void Dequeue_DequeueAnElement_DecrementsLength(params int[] elements)
	{
		ArrayBasedQueue<int> queue = new();
		for (int i = 0; i < elements.Length; i++)
		{
			queue.Enqueue(elements[i]);
		}
		int expected = elements.Length - 1;

		queue.Dequeue();
		int actual = queue.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(1, 2, 3)]
	[DataRow(0, 100, 22, 3, 4)]
	public void Dequeue_DequeueAnElement_ReturnsFirstElement(params int[] elements)
	{
		ArrayBasedQueue<int> queue = new();
		for (int i = 0; i < elements.Length; i++)
		{
			queue.Enqueue(elements[i]);
		}
		int expected = elements.First();

		int actual = queue.Dequeue();

		Assert.AreEqual(expected, actual);
	}
}