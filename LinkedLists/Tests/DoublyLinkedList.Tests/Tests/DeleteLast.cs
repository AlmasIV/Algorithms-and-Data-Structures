namespace DoublyLinkedList.Tests;

[TestClass()]
public class DeleteLastTests
{
	private Node<Guid> _newNode => SUTInitializer.NewNode;
	private Func<DoublyLinkedList<Guid>> InitializeNonEmptyLinkedList = SUTInitializer.InitializeNonEmptyLinkedList;

	[TestMethod()]
	[ExpectedException(typeof(InvalidOperationException), "Deleting on empty linked list should throw an exception.")]
	public void DeleteLast_DeletingOnEmptyLinkedList_ThrowsInvalidOperationException()
	{
		DoublyLinkedList<Guid> linkedList = new DoublyLinkedList<Guid>();

		linkedList.DeleteLast();
	}

	[TestMethod()]
	public void DeleteLast_DeletingOnNonEmptyLinkedList_DecrementsLength()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		ulong expectedLength = linkedList.Length - 1;

		linkedList.DeleteLast();
		ulong actualLength = linkedList.Length;

		Assert.AreEqual(expectedLength, actualLength);
	}

	[TestMethod()]
	public void DeleteLast_DeletingOnNonEmptyLinkedList_DeletesLastNode()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> tailNode = linkedList.Tail!;

		linkedList.DeleteLast();
		Node<Guid> newTailNode = linkedList.Tail!;

		Assert.AreNotEqual(tailNode, newTailNode);
	}

	[TestMethod()]
	public void DeleteLast_DeletingOnNonEmptyLinkedList_DeletedNodeNextIsNull()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> tailNode = linkedList.Tail!;

		linkedList.DeleteLast();

		Assert.IsNull(tailNode.Next);
	}

	[TestMethod()]
	public void DeleteLast_DeletingOnNonEmptyLinkedList_DeletedNodePreviousIsNull()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> tailNode = linkedList.Tail!;

		linkedList.DeleteLast();

		Assert.IsNull(tailNode.Previous);
	}

	[TestMethod()]
	public void DeleteLast_DeletingOnNonEmptyLinkedList_DeletedNodeLinkedListIdIsDefault()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> tailNode = linkedList.Tail!;

		linkedList.DeleteLast();

		Assert.AreEqual(tailNode.LinkedListId, default);
	}

	[TestMethod()]
	public void DeleteLast_DeletingOnNonEmptyLinkedList_DeletedNodeValueIsDefault()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> tailNode = linkedList.Tail!;

		linkedList.DeleteLast();

		Assert.AreEqual(tailNode.Value, default);
	}

	[TestMethod()]
	public void DeleteLast_DeletingOnLinkedListOfLengthOf1_SetsTheHeadToNull()
	{
		DoublyLinkedList<Guid> linkedList = new();
		Node<Guid> node = _newNode;
		linkedList.AppendNode(node);
		Node<Guid>? expectedHead = null;

		linkedList.DeleteLast();
		Node<Guid>? actualHead = linkedList.Head;

		Assert.AreEqual(expectedHead, actualHead);
	}

	[TestMethod()]
	public void DeleteLast_DeletingOnLinkedListOfLengthOf1_SetsTheTailToNull()
	{
		DoublyLinkedList<Guid> linkedList = new();
		Node<Guid> node = _newNode;
		linkedList.AppendNode(node);
		Node<Guid>? expectedTail = null;

		linkedList.DeleteLast();
		Node<Guid>? actualTail = linkedList.Tail;

		Assert.AreEqual(expectedTail, actualTail);
	}

	[TestMethod()]
	public void DeleteLast_DeletingOnLinkedListOfLengthOf1_DecrementsLength()
	{
		DoublyLinkedList<Guid> linkedList = new();
		Node<Guid> node = _newNode;
		linkedList.AppendNode(node);
		ulong expectedLength = linkedList.Length - 1;

		linkedList.DeleteLast();
		ulong actualLength = linkedList.Length;

		Assert.AreEqual(expectedLength, actualLength);
	}
}