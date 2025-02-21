namespace CircularLinkedListDetector.Tests;

[TestClass()]
public class ReversingApproach
{
	[TestMethod()]
	public void HasLoop_CallingOnNullNode_ReturnsFalse()
	{
		Node<int>? node = null;
		bool expected = false;

		bool actual = ReversingApproach<int>.HasLoop(node!);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnSingleNodeThatRefsNull_ReturnsFalse()
	{
		Node<int>? node = new Node<int>();
		bool expected = false;

		bool actual = ReversingApproach<int>.HasLoop(node);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnSingleNodeThatRefsItself_ReturnsTrue()
	{
		Node<int>? node = new Node<int>();
		node.Next = node;
		bool expected = true;

		bool actual = ReversingApproach<int>.HasLoop(node);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnCircularLinkedList_ReturnsTrue()
	{
		Node<int> head = CircularListProvider.GetCircularLinkedList();
		bool expected = true;

		bool actual = ReversingApproach<int>.HasLoop(head);

		Assert.AreEqual(expected, actual);
	}
}