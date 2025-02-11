
namespace DoublyLinkedList.Tests;

[TestClass()]
public class DoublyLinkedListTests
{
	private Node<Guid> _newNode => new Node<Guid>(Guid.NewGuid());
	private DoublyLinkedList<Guid> InitializeNonEmptyLinkedList()
	{
		DoublyLinkedList<Guid> linkedList = new DoublyLinkedList<Guid>();
		for (int i = 0; i < 100; i++)
		{
			linkedList.AppendNode(_newNode);
		}
		return linkedList;
	}

	private void TestAppendingOnEmptyList(Action<DoublyLinkedList<Guid>, Node<Guid>> test) {
		DoublyLinkedList<Guid> linkedList = new();
		Node<Guid> node = _newNode;

		linkedList.AppendNode(node);

		test(linkedList, node);
	}

	[TestMethod()]
	public void AppendNode_AppendingOnEmptyLinkedList_HeadPointsToNode()
	{
		TestAppendingOnEmptyList((linkedList, appendedNode) => {
			Assert.AreEqual(linkedList.Head, appendedNode, "Head should point to the appended node.");
		});
	}

	[TestMethod()]
	public void AppendNode_AppendingOnEmptyLinkedList_TailPointsToNode()
	{
		TestAppendingOnEmptyList((linkedList, appendedNode) => {
			Assert.AreEqual(linkedList.Tail, appendedNode, "Tail should point to the appended node.");
		});
	}

	[TestMethod()]
	public void AppendNode_AppendingOnEmptyLinkedList_IncrementsLength() {
		TestAppendingOnEmptyList((linkedList, appendedNode) => {
			Assert.AreEqual(1ul, linkedList.Length, "Length should equal to 1.");
		});
	}

	private void TestAppendingOnNonEmptyList(Action<DoublyLinkedList<Guid>, Node<Guid>> test) {
		DoublyLinkedList<Guid> linkedList = InitializeNonEmptyLinkedList();
		Node<Guid> node = _newNode;

		linkedList.AppendNode(node);

		test(linkedList, node);
	}

	[TestMethod()]
	public void AppendNode_AppendingOnNonEmptyLinkedList_TailPointsToTheAppendedNode() {
		
	}
}