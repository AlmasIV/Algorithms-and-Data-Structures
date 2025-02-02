namespace SinglyLinkedList.Tests;

[TestClass()]
public class SinglyLinkedListTests {
	public SinglyLinkedList<int> _linkedList = new SinglyLinkedList<int>();
	
	[TestInitialize()]
	public void InitializeSample() {
		_linkedList = new SinglyLinkedList<int>();
		Node<int> temp = new Node<int>(0);
		for(int i = 1; i < 100; i ++) {
			temp.Next = new Node<int>(i);
			temp = temp.Next;
		}
	}

	[TestMethod()]
	[DataRow(0)]
	public void PrependNode_PrependingOnEmptySinglyLinkedList_PrependsAsExpected(int nodeValue) {
		_linkedList = new SinglyLinkedList<int>();
		Node<int> node = new Node<int>(nodeValue);

		_linkedList.PrependNode(node);
		int headValue = _linkedList.ToArray()[0];

		Assert.AreEqual(headValue, nodeValue);
	}

	[TestMethod()]
	[DataRow(0)]
	public void PrependNode_PrependingOnNonEmptyLinkedList_PrependedNodeBecomesHead(int nodeValue) {
		Node<int> node = new Node<int>(nodeValue);

		_linkedList.PrependNode(node);
		int headValue = _linkedList.ToArray()[0];

		Assert.AreEqual(headValue, nodeValue);
	}

	[TestMethod()]
	[DataRow(1)]
	public void AppendNode_AppendingOnEmtpyLinkedList_AppendsAsExpected(int nodeValue) {
	}
}