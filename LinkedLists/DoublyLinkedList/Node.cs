namespace DoublyLinkedList;

public class Node<T>
{
	public T? Value { get; set; }
	public Node<T>? Next { get; internal set; }
	public Node<T>? Previous { get; internal set; }
	public Node(){}
	public Node(T? value) {
		Value = value;
	}
}