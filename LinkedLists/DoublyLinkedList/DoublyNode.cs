using SinglyLinkedList;

namespace DoublyLinkedList;
public class DoublyNode<T> : Node<T>
{
	public DoublyNode(){}
	public DoublyNode(T value) : base(value) {}
	public Node<T>? Previous { get; set; }
}