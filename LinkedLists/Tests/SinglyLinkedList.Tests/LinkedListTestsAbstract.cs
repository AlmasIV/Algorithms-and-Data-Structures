namespace SinglyLinkedList.Tests;

[TestClass()]
public abstract class LinkedListTestsAbstract<T>
{
	protected abstract SinglyLinkedListAbstract<T> InitializeEmptyLinkedList();
	protected abstract SinglyLinkedListAbstract<T> InitializeNonEmptyLinkedList();
	protected abstract Node<T> GetNode();

	[TestMethod()]
	public void PrependNode_PrependingOnEmptySinglyLinkedList_PrependedNodeBecomesHead()
	{
		SinglyLinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		T? nodeValue = node.Value;

		linkedList.PrependNode(node);
		T? headValue = linkedList.First().Value;

		Assert.AreEqual(nodeValue, headValue);
	}

	[TestMethod()]
	public void PrependNode_PrependingOnNonEmptyLinkedList_PrependedNodeBecomesHead()
	{
		SinglyLinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		T? nodeValue = node.Value;

		linkedList.PrependNode(node);
		T? headValue = linkedList.First().Value;

		Assert.AreEqual(nodeValue, headValue);
	}

	[TestMethod()]
	public void PrependNode_PrependingOnEmptySinglyLinkedList_IncrementsLength()
	{
		SinglyLinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expected = 1ul;

		linkedList.PrependNode(node);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void PrependNode_PrependingOnNonEmptyLinkedList_IncrementsLength()
	{
		SinglyLinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expected = linkedList.Length + 1;

		linkedList.PrependNode(node);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void AppendNode_AppendingOnEmtpyLinkedList_AppendedNodeIsTheLastOne()
	{
		SinglyLinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		T? nodeValue = node.Value;

		linkedList.AppendNode(node);
		T? headValue = linkedList.Last().Value;

		Assert.AreEqual(nodeValue, headValue);
	}

	[TestMethod()]
	public void AppendNode_AppendingNodeOnNonEmptyLinkedList_AppendedNodeIsTheLastOne()
	{
		SinglyLinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		T? nodeValue = node.Value;

		linkedList.AppendNode(node);
		T? lastNodeValue = linkedList.Last().Value;

		Assert.AreEqual(nodeValue, lastNodeValue);
	}

	[TestMethod()]
	public void AppendNode_AppendingOnEmtpyLinkedList_IncrementsLength()
	{
		SinglyLinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expected = 1ul;

		linkedList.AppendNode(node);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void AppendNode_AppendingOnNonEmptyLinkedList_IncrementsLength()
	{
		SinglyLinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		ulong expected = linkedList.Length + 1;
		Node<T> node = GetNode();

		linkedList.AppendNode(node);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void RemoveNodeByReference_RemovingNodeOnEmptyLinkedList_DoesNothing()
	{
		SinglyLinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expected = linkedList.Length;

		linkedList.RemoveNodeByReference(node);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void RemoveNodeByReference_RemovingNodeOnNonEmptyLinkedList_RemovesNode()
	{
		SinglyLinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
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
		SinglyLinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expected = linkedList.Length;
		linkedList.AppendNode(node);

		linkedList.RemoveNodeByReference(node);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void RemoveNodeByValue_RemovingNodeOnEmptyLinkedList_DoesNothing() {
		SinglyLinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		ulong expected = linkedList.Length;

		linkedList.RemoveNodeByValue(node.Value!);
		ulong actual = linkedList.Length;

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void RemoveNodeByValue_RemovingNodeOnNonEmptyLinkedList_RemovesNode()
	{
		SinglyLinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
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
		SinglyLinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
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
		SinglyLinkedListAbstract<T> linkedList = InitializeEmptyLinkedList();
		Node<T> node = GetNode();
		bool expected = false;

		bool actual = linkedList.ContainsNode(node);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void ContainsNode_CheckingNonEmptyLinkedListIfItContainsNonExistentNode_ReturnsFalse() {
		SinglyLinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		bool expected = false;

		bool actual = linkedList.ContainsNode(node);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	public void ContainsNode_CheckingNonEmptyLinkedListIfItContainsAppendedNode_ReturnsTrue() {
		SinglyLinkedListAbstract<T> linkedList = InitializeNonEmptyLinkedList();
		Node<T> node = GetNode();
		linkedList.AppendNode(node);
		bool expected = true;

		bool actual = linkedList.ContainsNode(node);

		Assert.AreEqual(expected, actual);
	}
}