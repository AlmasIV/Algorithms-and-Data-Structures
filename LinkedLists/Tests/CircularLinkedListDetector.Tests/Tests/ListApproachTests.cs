namespace CircularLinkedListDetector.Tests;

[TestClass()]
public class ListApproachTests
{
	[TestMethod()]
	public void HasLoop_CallingOnNullNode_ReturnsFalse()
	{
		Node<int>? node = null;
		bool expected = false;

		bool actual = ListApproach<int>.HasLoop(node);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnSingleNodeThatRefsNull_ReturnsFalse()
	{
		Node<int>? node = new Node<int>();
		bool expected = false;

		bool actual = ListApproach<int>.HasLoop(node);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnSingleNodeThatRefsItself_ReturnsTrue()
	{
		Node<int>? node = new Node<int>();
		node.Next = node;
		bool expected = true;

		bool actual = ListApproach<int>.HasLoop(node);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnCircularLinkedList_ReturnsTrue()
	{
		Node<int> head = CircularListProvider.GetCircularLinkedList();
		bool expected = true;

		bool actual = ListApproach<int>.HasLoop(head);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnSingleNodeThatRefsItselfWithBreak_ReturnsTrue()
	{
		Node<int>? node = new Node<int>();
		node.Next = node;
		bool expected = true;

		bool actual = ListApproach<int>.HasLoop(node, true);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnSingleNodeThatRefsItselfWithBreak_BreaksLoop()
	{
		Node<int> head = new Node<int>();
		head.Next = head;
		bool expected = true;

		ListApproach<int>.HasLoop(head, true);
		bool actual = head.Next is null;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnCircularLinkedListWithBreak_BreaksLoopCorrectly()
	{
		Node<int> head = CircularListProvider.GetCircularLinkedList();
		bool expected = false;

		ListApproach<int>.HasLoop(head, true);
		bool actual = false;
		Node<int>? current = head;
		int counter = 0;

		while (current is not null)
		{
			if (counter > CircularListProvider._maxNumberOfNodes)
			{
				actual = true;
				break;
			}
			current = current.Next;
			counter++;
		}

		Assert.AreEqual(expected, actual);
	}
}