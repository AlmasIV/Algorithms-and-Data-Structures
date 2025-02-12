namespace DoublyLinkedList.Tests;

[TestClass()]
public class PrependNodeTests
{
	private Node<Guid> _newNode => SUTInitializer.NewNode;
	private Func<DoublyLinkedList<Guid>> InitializeNonEmptyLinkedLsit = SUTInitializer.InitializeNonEmptyLinkedList;

	[TestMethod()]
	[ExpectedException(typeof(ArgumentNullException), "Passing null should throw an exception.")]
	public void PrependNode_PrependingNull_ThrowsArgumentNullException()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedLsit();
		Node<Guid>? node = null;

		linkedList.AppendNode(node!);
	}

	[TestMethod()]
	public void PrependNode_PrependingOnEmptyLinkedList_HeadPointsToTheNode()
	{
		DoublyLinkedList<Guid> linkedList = new DoublyLinkedList<Guid>();
		Node<Guid> node = _newNode;

		linkedList.PrependNode(node);

		Assert.AreEqual(linkedList.Head, node, "Head should point to the node.");
	}

	[TestMethod()]
	public void PrependNode_PrependingOnEmptyLinkedList_TailPointsToTheNode()
	{
		DoublyLinkedList<Guid> linkedList = new DoublyLinkedList<Guid>();
		Node<Guid> node = _newNode;

		linkedList.PrependNode(node);

		Assert.AreEqual(linkedList.Tail, node, "Tail should point to the node.");
	}

	[TestMethod()]
	public void PrependNode_PrependingOnEmptyLinkedList_IncrementsLength()
	{
		DoublyLinkedList<Guid> linkedList = new DoublyLinkedList<Guid>();
		Node<Guid> node = _newNode;

		linkedList.PrependNode(node);

		Assert.AreEqual(1ul, linkedList.Length, "Length should equal to 1.");
	}

	[TestMethod()]
	public void PrependNode_PrependingOnNonEmptyLinkedList_HeadPointsToTheNode()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedLsit();
		Node<Guid> node = _newNode;

		linkedList.PrependNode(node);

		Assert.AreEqual(linkedList.Head, node, "Head should point to the prepended node.");
	}

	[TestMethod()]
	public void PrependNode_PrependingOnNonEmptyLinkedList_IncrementsLength()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedLsit();
		Node<Guid> node = _newNode;
		ulong expectedLength = linkedList.Length + 1;

		linkedList.PrependNode(node);

		Assert.AreEqual(expectedLength, linkedList.Length, "Length should be incremented when prepending a node.");
	}

	[TestMethod()]
	public void PrependNode_PrependingOnNonEmptyLinkedList_HeadPreviousPointsToNull()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedLsit();
		Node<Guid> node = _newNode;

		linkedList.PrependNode(node);

		Assert.AreEqual(null, linkedList.First().Previous, "Prepended hode has no node before itself.");
	}
}