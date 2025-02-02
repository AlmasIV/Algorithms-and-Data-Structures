namespace SinglyLinkedList.Tests;

[TestClass()]
public class SinglyLinkedListTests {
	[TestMethod()]
	[DataRow(1)]
	public void PrependNode_PrependingNode_PushesFirstNode(int initialHeadValue) {
		SinglyLinkedList<int> intsLinkedList = new SinglyLinkedList<int>(new Node<int>(initialHeadValue));

		intsLinkedList.PrependNode(new Node<int>(99));
		int previousHead = intsLinkedList.ToArray()[1];

		Assert.AreEqual(previousHead, initialHeadValue);
	}

	[TestMethod()]
	[DataRow(0)]
	public void PrependNode_PrependingNode_PrependedNodeBecomesNewHead(int nodeToBePrepended) {
		SinglyLinkedList<int> ints = new(new Node<int>(nodeToBePrepended));

		int headValue = ints.First();

		Assert.AreEqual(headValue, nodeToBePrepended);
	}
}