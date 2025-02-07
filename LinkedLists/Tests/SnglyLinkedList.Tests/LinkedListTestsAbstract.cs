namespace SinglyLinkedList.Tests;

[TestClass()]
public abstract class LinkedListTestsAbstract<T>
{
	protected abstract LinkedListAbstract<T> InitializeEmptyLinkedList();
	protected abstract LinkedListAbstract<T> InitializeNonEmptyLinkedList();
	protected abstract Node<T> GetNode();

	[TestMethod()]
	public void PrependNode_PrependingOnEmptySinglyLinkedList_PrependedNodeBecomesHead()
	{
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
	public void PrependNode_PrependingOnEmptySinglyLinkedList_IncrementsLength()
	{
		LinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expected = 1ul;

		linkedList.PrependNode(node);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void PrependNode_PrependingOnNonEmptyLinkedList_IncrementsLength()
	{
		LinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expected = linkedList.Length + 1;

		linkedList.PrependNode(node);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void AppendNode_AppendingOnEmtpyLinkedList_AppendedNodeIsTheLastOne()
	{
		LinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		T? nodeValue = node.Value;

		linkedList.AppendNode(node);
		T headValue = linkedList.Last();

		Assert.AreEqual(nodeValue, headValue);
	}

	[TestMethod()]
	public void AppendNode_AppendingNodeOnNonEmptyLinkedList_AppendedNodeIsTheLastOne()
	{
		LinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		T? nodeValue = node.Value;

		linkedList.AppendNode(node);
		T lastNodeValue = linkedList.Last();

		Assert.AreEqual(nodeValue, lastNodeValue);
	}

	[TestMethod()]
	public void AppendNode_AppendingOnEmtpyLinkedList_IncrementsLength()
	{
		LinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expected = 1ul;

		linkedList.AppendNode(node);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void AppendNode_AppendingOnNonEmptyLinkedList_IncrementsLength()
	{
		LinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		ulong expected = linkedList.Length + 1;
		Node<T> node = GetNode();

		linkedList.AppendNode(node);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void RemoveNodeByReference_RemovingNodeOnEmptyLinkedList_DoesNothing()
	{
		LinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expected = linkedList.Length;

		linkedList.RemoveNodeByReference(node);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void RemoveNodeByReference_RemovingNodeOnNonEmptyLinkedList_RemovesNode()
	{
		LinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		linkedList.AppendNode(node);
		bool expected = false;

		linkedList.RemoveNodeByReference(node);
		bool actual = linkedList.ContainsNode(node);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void RemoveNodeByReference_RemovingNodeOnNonEmptyLinkedList_DecrementsLength()
	{
		LinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expected = linkedList.Length;
		linkedList.AppendNode(node);

		linkedList.RemoveNodeByReference(node);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void RemoveNodeByValue_RemovingNodeOnEmptyLinkedList_DoesNothing() {
		LinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expected = linkedList.Length;

		linkedList.RemoveNodeByValue(node.Value!);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void RemoveNodeByValue_RemovingNodeOnNonEmptyLinkedList_RemovesNode()
	{
		LinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		linkedList.AppendNode(node);
		bool expected = false;

		linkedList.RemoveNodeByValue(node.Value!);
		bool actual = linkedList.ContainsNode(node);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void RemoveNodeByValue_RemovingNodeOnNonEmptyLinkedList_DecrementsLength()
	{
		LinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expected = linkedList.Length;
		linkedList.AppendNode(node);

		linkedList.RemoveNodeByValue(node.Value!);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void ContainsNode_CheckingEmptyLinkedList_ReturnsFalse()
	{
		LinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		bool expected = false;

		bool actual = linkedList.ContainsNode(node);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void ContainsNode_CheckingNonEmptyLinkedListIfItContainsNonExistentNode_ReturnsFalse() {
		LinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		bool expected = false;

		bool actual = linkedList.ContainsNode(node);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void ContainsNode_CheckingNonEmptyLinkedListIfItContainsAppendedNode_ReturnsTrue() {
		LinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		linkedList.AppendNode(node);
		bool expected = true;

		bool actual = linkedList.ContainsNode(node);

		Assert.AreEqual(expected, actual);
	}
}