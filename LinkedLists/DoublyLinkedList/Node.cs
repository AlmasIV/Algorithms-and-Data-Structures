namespace DoublyLinkedList;

public class Node<T>
{
	public T? Value { get; set; }
	public Node<T>? Next { get; internal set; } = null;
	public Node<T>? Previous { get; internal set; } = null;
	public Guid? LinkedListId { get; internal set; } = null;
	public Node(){}
	public Node(T? value) {
		Value = value;
	}
}