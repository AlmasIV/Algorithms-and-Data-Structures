namespace SinglyLinkedList.Tests;

[TestClass()]
public abstract class LinkedListTestsAbstract<T> {
	protected abstract LinkedListAbstract<T> InitializeEmptyLinkedList();
	protected abstract LinkedListAbstract<T> InitializeNonEmptyLinkedList();
	protected abstract Node<T> GetNode();

	[TestMethod()]
	public void PrependNode_PrependingOnEmptySinglyLinkedList_PrependedNodeBecomesHead() {
		LinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		T? nodeValue = node.Value;

		linkedList.PrependNode(node);
		T headValue = linkedList.First();

		Assert.AreEqual(nodeValue, headValue);
	}

	[TestMethod()]
	public void PrependNode_PrependingOnNonEmptyLinkedList_PrependedNodeBecomesHead()
	{
		LinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		T? nodeValue = node.Value;

		linkedList.PrependNode(node);
		T headValue = linkedList.First();

		Assert.AreEqual(nodeValue, headValue);
	}

	[TestMethod()]
	public void PrependNode_PrependingOnEmptySinglyLinkedList_IncrementsLength() {
		LinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expectedLength = 1ul;

		linkedList.PrependNode(node);
		ulong actualLength = linkedList.Length;

		Assert.AreEqual(expectedLength, actualLength);
	}

	[TestMethod()]
	public void PrependNode_PrependingOnNonEmptyLinkedList_IncrementsLength() {
		LinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expectedLength = linkedList.Length + 1;

		linkedList.PrependNode(node);
		ulong actualLength = linkedList.Length;

		Assert.AreEqual(expectedLength, actualLength);
	}

	[TestMethod()]
	public void AppendNode_AppendingOnEmtpyLinkedList_AppendedNodeIsTheLastOne() {
		LinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		T? nodeValue = node.Value;

		linkedList.AppendNode(node);
		T headValue = linkedList.Last();

		Assert.AreEqual(nodeValue, headValue);
	}

	[TestMethod()]
	public void AppendNode_AppendingNodeOnNonEmptyLinkedList_AppendedNodeIsTheLastOne() {
		LinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		T? nodeValue = node.Value;

		linkedList.AppendNode(node);
		T lastNodeValue = linkedList.Last();

		Assert.AreEqual(nodeValue, lastNodeValue);
	}

	[TestMethod()]
	public void AppendNode_AppendingOnEmtpyLinkedList_IncrementsLength() {
		LinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expectedLength = 1ul;

		linkedList.AppendNode(node);
		ulong actualLength = linkedList.Length;

		Assert.AreEqual(expectedLength, actualLength);
	}

	[TestMethod()]
	public void AppendNode_AppendingOnNonEmptyLinkedList_IncrementsLength() {
		LinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		ulong expectedLength = linkedList.Length + 1;
		Node<T> node = GetNode();

		linkedList.AppendNode(node);
		ulong actualLength = linkedList.Length;

		Assert.AreEqual(expectedLength, actualLength);
	}
	
	[TestMethod()]
	public void RemoveNodeByReference_RemovingNodeOnEmptyLinkedList_DoesNothing() {
		LinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expectedLength = linkedList.Length;

		linkedList.RemoveNodeByReference(node);
		ulong actualLength = linkedList.Length;

		Assert.AreEqual(expectedLength, actualLength);
	}
}