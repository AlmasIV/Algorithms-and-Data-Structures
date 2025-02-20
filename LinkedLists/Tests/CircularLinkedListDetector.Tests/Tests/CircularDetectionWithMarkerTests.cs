namespace CircularLinkedListDetector.Tests;

[TestClass()]
public class CircularDetectionWithMarkerTests
{
	private const int _maxNumberOfNodes = 100;
	private NodeWithMarker<int> GetCircularLinkedList()
	{
		NodeWithMarker<int>? head = null;
		NodeWithMarker<int>? temp = null, prevTemp = null;
		for (int i = 0; i < _maxNumberOfNodes; i++)
		{
			temp = new NodeWithMarker<int>() { Value = i };
			if (head is null)
			{
				head = temp;
			}
			else
			{
				prevTemp!.Next = temp;
			}
			prevTemp = temp;
		}
		prevTemp!.Next = head;
		return head!;
	}

	[TestMethod()]
	public void HasLoop_CallingOnNullNode_ReturnsFalse()
	{
		NodeWithMarker<int>? head = null;
		bool expected = false;

		bool actual = CircularDetectionWithMarker<int>.HasLoop(head);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnSingleNodeThatRefsNull_ReturnsFalse()
	{
		NodeWithMarker<int> head = new NodeWithMarker<int>();
		bool expected = false;

		bool actual = CircularDetectionWithMarker<int>.HasLoop(head);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnSingleNodeThatRefsItself_ReturnsTrue()
	{
		NodeWithMarker<int> head = new NodeWithMarker<int>();
		head.Next = head;
		bool expected = true;

		bool actual = CircularDetectionWithMarker<int>.HasLoop(head);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnCircularLinkedList_ReturnsTrue()
	{
		NodeWithMarker<int> head = GetCircularLinkedList();
		bool expected = true;

		bool actual = CircularDetectionWithMarker<int>.HasLoop(head);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnSingleNodeThatRefsItselfWithBreak_ReturnsTrue()
	{
		NodeWithMarker<int> head = new NodeWithMarker<int>();
		head.Next = head;
		bool expected = true;

		bool actual = CircularDetectionWithMarker<int>.HasLoop(head);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnSingleNodeThatRefsItselfWithBreak_BreaksLoop()
	{
		NodeWithMarker<int> head = new NodeWithMarker<int>();
		head.Next = head;
		bool expected = true;

		CircularDetectionWithMarker<int>.HasLoop(head, true);
		bool actual = head.Next is null;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void HasLoop_CallingOnCircularLinkedListWithBreak_BreaksLoopCorrectly()
	{
		NodeWithMarker<int> head = GetCircularLinkedList();
		bool expected = false;

		CircularDetectionWithMarker<int>.HasLoop(head, true);
		bool actual = false;
		NodeWithMarker<int>? current = head;
		int counter = 0;

		while (current is not null)
		{
			if(counter > _maxNumberOfNodes) {
				actual = true;
				break;
			}
			current = current.Next;
			counter ++;
		}

		Assert.AreEqual(expected, actual);
	}
}