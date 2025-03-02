namespace Queue.Tests;

[TestClass]
public class PriorityQueueTests
{
	[TestMethod]
	[DataRow(0)]
	[DataRow(0, 1, 2, 3, 4, 5)]
	public void Enqueue_EnqueuingAnElement_IncrementsLengthCorrespondingly(params int[] ints)
	{
		PriorityQueue<int> queue = new();
		int expected = ints.Length;

		foreach (int i in ints)
		{
			queue.Enqueue(i);
		}
		int actual = queue.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void Dequeue_DequeuingAnElement_DecrementsLengthCorrespondingly()
	{
		PriorityQueue<int> queue = new();
		queue.Enqueue(0);
		int expected = 0;

		queue.Dequeue();
		int actual = queue.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(0)]
	[DataRow(0, 1, 2, 3, 4, 5)]
	public void Enqueue_EnqueuingFirstElementWithAveragePriorityAndOthersWithMinimum_AverageItemIsReturnedAsTheFirst(params int[] ints)
	{
		PriorityQueue<int> queue = new();
		int expected = ints[0];

		queue.Enqueue(ints[0], Priority.Average);
		for (int i = 1; i < ints.Length; i++)
		{
			queue.Enqueue(ints[i]);
		}
		int actual = queue.Dequeue();

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(0)]
	[DataRow(0, 1, 2, 3, 4, 5)]
	public void Enqueue_EnqueuingFirstElementWithMaxPriorityAndOthersWithMinimum_MaxItemIsReturnedAsTheFirst(params int[] ints)
	{
		PriorityQueue<int> queue = new();
		int expected = ints[0];

		queue.Enqueue(ints[0], Priority.Maximum);
		for (int i = 1; i < ints.Length; i++)
		{
			queue.Enqueue(ints[i]);
		}
		int actual = queue.Dequeue();

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[DataRow(0)]
	[DataRow(0, 1, 2, 3, 4, 5)]
	public void Enqueue_EnqueuingFirstElementWithAveragePriorityAndOthersWithMax_AverageItemIsReturnedAsTheLast(params int[] ints)
	{
		PriorityQueue<int> queue = new();
		int expected = ints[0];

		queue.Enqueue(ints[0], Priority.Average);
		for (int i = 1; i < ints.Length; i++)
		{
			queue.Enqueue(ints[i], Priority.Maximum);
		}
		int actual = 0;
		for(int i = 0; i < ints.Length; i ++) {
			actual = queue.Dequeue();
		}

		Assert.AreEqual(expected, actual);
	}
}