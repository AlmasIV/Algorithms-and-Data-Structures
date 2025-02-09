using SinglyLinkedList;

namespace DoublyLinkedList;

/// <summary>
/// 	Represents a node of a doubly linked list.
/// </summary>
/// <inheritdoc />
public class DoublyNode<T> : Node<T>
{
	/// <inheritdoc />
	public DoublyNode(){}

	/// <inheritdoc />
	public DoublyNode(T value) : base(value) {}

	/// <summary>
	/// 	Gets or sets the previous node.
	/// </summary>
	public Node<T>? Previous { get; set; }
}