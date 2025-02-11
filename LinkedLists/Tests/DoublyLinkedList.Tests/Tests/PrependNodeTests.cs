namespace DoublyLinkedList.Tests;

[TestClass()]
public class PrependNodeTests
{
	private Node<Guid> _newNode => SUTInitializer.NewNode;
	private Func<DoublyLinkedList<Guid>> InitializeNonEmptyLinkedLsit = SUTInitializer.InitializeNonEmptyLinkedList;

	[TestMethod()]
	[ExpectedException(typeof(ArgumentNullException))]
	public void PrependNode_PrependingNull_ThrowsArgumentNullException()
	{
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedLsit();
		Node<Guid>? node = null;

		linkedList.AppendNode(node!);
	}
}