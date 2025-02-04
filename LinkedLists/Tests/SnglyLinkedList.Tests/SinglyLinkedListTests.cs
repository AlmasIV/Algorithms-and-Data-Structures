namespace SinglyLinkedList.Tests;

[TestClass()]
public class SinglyLinkedListTests {
	public SinglyLinkedList<int> _linkedList = null!;

	public void InitializeSample() {
		_linkedList = new SinglyLinkedList<int>();
		for (int i = 0; i < 100; i ++) {
			_linkedList.AppendNode(new Node<int>(i));
		}
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
	public void PrependNode_PrependingOnEmptySinglyLinkedList_IncrementsLength(int nodeValue) {
		_linkedList = new SinglyLinkedList<int>();
		Node<int> node = new Node<int>(nodeValue);

		_linkedList.PrependNode(node);
		ulong length = _linkedList.Length;

		Assert.AreEqual(length, 1UL);
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
	[DataRow(0)]
	public void PrependNode_PrependingOnNonEmptyLinkedList_IncrementsLength(int nodeValue) {
		InitializeSample();
		Node<int> node = new Node<int>(nodeValue);
		ulong initializedLength = _linkedList.Length;

		_linkedList.PrependNode(node);
		ulong length = _linkedList.Length;

		Assert.AreEqual(length, initializedLength + 1);
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