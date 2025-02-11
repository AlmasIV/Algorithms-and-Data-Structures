namespace DoublyLinkedList.Tests;

internal static class SUTInitializer {
	public static Node<Guid> NewNode => new Node<Guid>(Guid.NewGuid());
	public static DoublyLinkedList<Guid> InitializeNonEmptyLinkedList()
	{
		DoublyLinkedList<Guid> linkedList = new DoublyLinkedList<Guid>();
		for (int i = 0; i < 100; i++)
		{
			linkedList.AppendNode(NewNode);
		}
		return linkedList;
	}
}