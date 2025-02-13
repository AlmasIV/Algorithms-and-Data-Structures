namespace DoublyLinkedList.Tests;

[TestClass()]
public class DeleteNodeByReferenceTests
{
	private Node<Guid> _newNode => SUTInitializer.NewNode;
	private Func<DoublyLinkedList<Guid>> InitializeNonEmptyLinkedList = SUTInitializer.InitializeNonEmptyLinkedList;

	[TestMethod()]
	[ExpectedException(typeof(ArgumentNullException), "Passing null should throw an exception.")]
	public void DeleteNodeByReference_DeletingNull_ThrowsArgumentNullException()
	{
		DoublyLinkedList<Guid> linkedList = new();
		Node<Guid>? node = null;

		linkedList.DeleteNodeByReference(node!);
	}

	[TestMethod()]
	[ExpectedException(typeof(ArgumentException), "Passing a node that belongs to another linked list should throw an exception.")]
	public void DeleteNodeByReference_DeletingNodeThatBelongsToAnotherLinkedList_ThrowsArgumentException()
	{
		DoublyLinkedList<Guid> linkedList1 = new();
		DoublyLinkedList<Guid> linkedList2 = new();
		Node<Guid> node = _newNode;
		linkedList1.AppendNode(node);

		linkedList2.DeleteNodeByReference(node);
	}

	[TestMethod()]
	[ExpectedException(typeof(ArgumentException), "Deleting node that doesn't belong should throw an exception.")]
	public void DeleteNodeByReference_DeletingNodeThatDoesNotBelong_ThrowsArgumentException()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> node = _newNode;

		linkedList.DeleteNodeByReference(node);
	}

	[TestMethod()]
	public void DeleteNodeByReference_DeletingFirstNode_DeletesHeadNode()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> head = linkedList.First();
		ulong expectedLength = linkedList.Length - 1;

		linkedList.DeleteNodeByReference(head);
		ulong actualLength = linkedList.Length;

		Assert.AreEqual(expectedLength, actualLength);
	}
}