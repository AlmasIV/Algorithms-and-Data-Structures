namespace SinglyLinkedList.Tests;

[TestClass()]
public class SinglyLinkedListTests {
	public SinglyLinkedList<int> _linkedList = null!;

	public void InitializeSample() {
		Node<int> head = new Node<int>(0);
		Node<int> temp = head;
		for (int i = 1; i < 100; i ++) {
			temp.Next = new Node<int>(i);
			temp = temp.Next;
		}
		_linkedList = new SinglyLinkedList<int>(head);
	}

	[TestMethod()]
	[DataRow(0)]
	public void PrependNode_PrependingOnEmptySinglyLinkedList_PrependedNodeBecomesHead(int nodeValue) {
		_linkedList = new SinglyLinkedList<int>();
		Node<int> node = new Node<int>(nodeValue);

		_linkedList.PrependNode(node);
		int headValue = _linkedList.First();

		Assert.AreEqual(headValue, nodeValue);
	}

	[TestMethod()]
	[DataRow(0)]
	public void PrependNode_PrependingOnNonEmptyLinkedList_PrependedNodeBecomesHead(int nodeValue) {
		InitializeSample();
		Node<int> node = new Node<int>(nodeValue);

		_linkedList.PrependNode(node);
		int headValue = _linkedList.First();

		Assert.AreEqual(headValue, nodeValue);
	}

	[TestMethod()]
	[DataRow(1)]
	public void AppendNode_AppendingOnEmtpyLinkedList_AppendedNodeIsTheLastOne(int nodeValue) {
		_linkedList = new SinglyLinkedList<int>();
		Node<int> node = new Node<int>(nodeValue);

		_linkedList.AppendNode(node);
		int headValue = _linkedList.Last();

		Assert.AreEqual(headValue, nodeValue);
	}

	[TestMethod()]
	[DataRow(100)]
	public void AppendNode_AppendingNodeOnNonEmptyLinkedList_AppendedNodeIsTheLastOne(int nodeValue) {
		InitializeSample();
		Node<int> node = new Node<int>(nodeValue);

		_linkedList.AppendNode(node);
		int lastNodeValue = _linkedList.Last();

		Assert.AreEqual(lastNodeValue, nodeValue);
	}
}