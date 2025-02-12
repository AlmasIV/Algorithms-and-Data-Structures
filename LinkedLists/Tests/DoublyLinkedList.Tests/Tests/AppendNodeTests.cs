namespace DoublyLinkedList.Tests;

[TestClass()]
public class AppendNodeTests
{
	private Node<Guid> _newNode => SUTInitializer.NewNode;
	private Func<DoublyLinkedList<Guid>> InitializeNonEmptyLinkedList = SUTInitializer.InitializeNonEmptyLinkedList;
	private void TestAppendingOnEmptyList(Action<DoublyLinkedList<Guid>, Node<Guid>> test)
	{
		DoublyLinkedList<Guid> linkedList = new();
		Node<Guid> node = _newNode;

		linkedList.AppendNode(node);

		test(linkedList, node);
	}

	[TestMethod()]
	public void AppendNode_AppendingOnEmptyLinkedList_HeadPointsToNode()
	{
		TestAppendingOnEmptyList((linkedList, appendedNode) =>
		{
			Assert.AreEqual(linkedList.Head, appendedNode, "Head should point to the appended node.");
		});
	}

	[TestMethod()]
	public void AppendNode_AppendingOnEmptyLinkedList_TailPointsToNode()
	{
		TestAppendingOnEmptyList((linkedList, appendedNode) =>
		{
			Assert.AreEqual(linkedList.Tail, appendedNode, "Tail should point to the appended node.");
		});
	}

	[TestMethod()]
	public void AppendNode_AppendingOnEmptyLinkedList_IncrementsLength()
	{
		TestAppendingOnEmptyList((linkedList, appendedNode) =>
		{
			Assert.AreEqual(1ul, linkedList.Length, "Length should equal to 1.");
		});
	}

	[TestMethod()]
	public void AppendNode_AppendingOnNonEmptyLinkedList_TailPointsToTheAppendedNode()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> node = _newNode;

		linkedList.AppendNode(node);

		Assert.AreEqual(linkedList.Tail, node, "Tail should point to the appended node.");
	}

	[TestMethod()]
	public void AppendNode_AppendingOnNonEmptyLinkedList_IncrementsLength()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> node = _newNode;
		ulong expectedLength = linkedList.Length + 1;

		linkedList.AppendNode(node);
		ulong actualLength = linkedList.Length;

		Assert.AreEqual(expectedLength, actualLength, "Appended node should increment the length.");
	}

	[TestMethod()]
	public void AppendNode_AppendingOnNonEmptyLinkedList_AppendedNodePreviousPointsToTheElementBeforeItself()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> node = _newNode;
		Node<Guid> expected = linkedList.Last();

		linkedList.AppendNode(node);
		Node<Guid> actual = linkedList.Last().Previous!;

		Assert.AreEqual(expected, actual, "Appended node should point to the node before itself.");
	}

	[TestMethod()]
	[ExpectedException(typeof(ArgumentNullException), "Appending null should throw an exception.")]
	public void AppendNode_AppendingNull_ThrowsArgumentNullException()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid>? node = null;

		linkedList.AppendNode(node!);
	}

	[TestMethod()]
	public void AppendNode_AppendingOnNonEmptyLinkedList_AppendedNodeNextShouldBeNull()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> node = _newNode;

		linkedList.AppendNode(node);

		Assert.AreEqual(null, linkedList.Last().Next, "Appended node should point to null.");
	}
}