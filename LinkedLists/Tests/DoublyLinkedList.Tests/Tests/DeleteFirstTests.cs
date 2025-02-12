namespace DoublyLinkedList.Tests;

[TestClass()]
public class DeleteFirstTests
{
	private Node<Guid> _newNode => SUTInitializer.NewNode;
	private Func<DoublyLinkedList<Guid>> InitializeNonEmptyLinkedList = SUTInitializer.InitializeNonEmptyLinkedList;

	[TestMethod()]
	public void DeleteFirst_DeletingOnEmptyLinkedList_DoesNothing()
	{
		DoublyLinkedList<Guid> linkedList = new DoublyLinkedList<Guid>();
		ulong expectedLength = linkedList.Length;

		linkedList.DeleteFirst();
		ulong actualLength = linkedList.Length;

		Assert.AreEqual(expectedLength, actualLength);
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
}