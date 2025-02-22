namespace Stack.Tests;

[TestClass]
public class LinkedListBasedStackTests
{
	[TestMethod]
	[DataRow(1)]
	[DataRow(1, 2, 3, 4, 5)]
	[DataRow()]
	[DataRow(-1, -2220, 222, int.MaxValue, 2213)]
	public void Push_PushingElementsToAnEmptyStack_LengthGetsUpdates(params int[] items)
	{
		LinkedListBasedStack<int> stack = new();
		int expected = items.Length;

		for (int i = 0; i < items.Length; i++)
		{
			stack.Push(items[i]);
		}
		int actual = stack.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	[ExpectedException(typeof(InvalidOperationException))]
	public void Pop_PoppingOnEmptyStack_ThrowsInvalidOperationException()
	{
		LinkedListBasedStack<int> stack = new();

		stack.Pop();
	}

	[TestMethod]
	[DataRow(1)]
	[DataRow(1, 2, 3, 4 , 5)]
	[DataRow(2, 2, 99, -12)]
	public void Pop_PoppingOnStack_GetsLastlyAddedElement(params int[] items)
	{
		LinkedListBasedStack<int> stack = new();
		int expected = items[^1];

		for (int i = 0; i < items.Length; i++)
		{
			stack.Push(items[i]);
		}
		int actual = stack.Pop();

		Assert.AreEqual(expected, actual);
	}
}