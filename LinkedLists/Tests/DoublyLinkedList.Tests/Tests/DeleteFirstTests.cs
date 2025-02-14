namespace DoublyLinkedList.Tests;

[TestClass()]
public class DeleteFirstTests
{
	private Node<Guid> _newNode => SUTInitializer.NewNode;
	private Func<DoublyLinkedList<Guid>> InitializeNonEmptyLinkedList = SUTInitializer.InitializeNonEmptyLinkedList;

	[TestMethod()]
	[ExpectedException(typeof(InvalidOperationException), "Deleting on empty linked list should throw an exception.")]
	public void DeleteFirst_DeletingOnEmptyLinkedList_ThrowsInvalidOperationException()
	{
		DoublyLinkedList<Guid> linkedList = new DoublyLinkedList<Guid>();

		linkedList.DeleteFirst();
	}

	[TestMethod()]
	public void DeleteFirst_DeletingOnNonEmptyLinkedList_DecrementsLength()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		ulong expectedLength = linkedList.Length - 1;

		linkedList.DeleteFirst();
		ulong actualLength = linkedList.Length;

		Assert.AreEqual(expectedLength, actualLength);
	}

	[TestMethod()]
	public void DeleteFirst_DeletingOnNonEmptyLinkedList_DeletesFirstNode()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> headNode = linkedList.Head!;

		linkedList.DeleteFirst();
		Node<Guid> newHeadNode = linkedList.Head!;

		Assert.AreNotEqual(headNode, newHeadNode);
	}

	[TestMethod()]
	public void DeleteFirst_DeletingOnNonEmptyLinkedList_DeletedNodeNextIsNull()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> headNode = linkedList.Head!;

		linkedList.DeleteFirst();

		Assert.IsNull(headNode.Next);
	}

	[TestMethod()]
	public void DeleteFirst_DeletingOnNonEmptyLinkedList_DeletedNodePreviousIsNull()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> headNode = linkedList.Head!;

		linkedList.DeleteFirst();

		Assert.IsNull(headNode.Previous);
	}

	[TestMethod()]
	public void DeleteFirst_DeletingOnNonEmptyLinkedList_DeletedNodeLinkedListIdIsDefault()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> headNode = linkedList.Head!;

		linkedList.DeleteFirst();

		Assert.AreEqual(headNode.LinkedListId, default);
	}

	[TestMethod()]
	public void DeleteFirst_DeletingOnNonEmptyLinkedList_DeletedNodeValueIsDefault()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> headNode = linkedList.Head!;

		linkedList.DeleteFirst();

		Assert.AreEqual(headNode.Value, default);
	}

	[TestMethod()]
	public void DeleteFirst_DeletingOnLinkedListOfLengthOf1_SetsTheTailToNull()
	{
		DoublyLinkedList<Guid> linkedList = new();
		Node<Guid> node = _newNode;
		linkedList.AppendNode(node);
		Node<Guid>? expectedTail = null;

		linkedList.DeleteFirst();
		Node<Guid>? actualTail = linkedList.Tail;

		Assert.AreEqual(expectedTail, actualTail);
	}

	[TestMethod()]
	public void DeleteFirst_DeletingOnLinkedListOfLengthOf1_SetsTheHeadToNull()
	{
		DoublyLinkedList<Guid> linkedList = new();
		Node<Guid> node = _newNode;
		linkedList.AppendNode(node);
		Node<Guid>? expectedHead = null;

		linkedList.DeleteFirst();
		Node<Guid>? actualHead = linkedList.Head;

		Assert.AreEqual(expectedHead, actualHead);
	}

	[TestMethod()]
	public void DeleteFirst_DeletingOnLinkedListOfLengthOf1_DecrementsLength()
	{
		DoublyLinkedList<Guid> linkedList = new();
		Node<Guid> node = _newNode;
		linkedList.AppendNode(node);
		ulong expectedLength = linkedList.Length - 1;

		linkedList.DeleteFirst();
		ulong actualLength = linkedList.Length;

		Assert.AreEqual(expectedLength, actualLength);
	}
}