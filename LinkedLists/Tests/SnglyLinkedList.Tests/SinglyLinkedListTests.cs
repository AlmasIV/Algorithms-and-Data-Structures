namespace SinglyLinkedList.Tests;

[TestClass()]
public class SinglyLinkedListTests {
	[TestMethod()]
	[DataRow(0)]
	public void PrependNode_PrependingOnEmptySinglyLinkedList_PrependsAsExpected(int nodeValue) {
		SinglyLinkedList<int> ints = new SinglyLinkedList<int>();
		Node<int> node = new Node<int>(nodeValue);

		ints.PrependNode(node);
		int headValue = ints.ToArray()[0];

		Assert.AreEqual(headValue, nodeValue);
	}
}