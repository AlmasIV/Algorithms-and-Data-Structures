using SinglyLinkedList;

namespace DoublyLinkedList;

/// <summary>
/// 	Defines an abstract base class for a doubly linked list structures.
/// </summary>
/// <inheritdoc />
public class DoublyLinkedList<T> : SinglyLinkedList<T> {
	protected new DoublyNode<T>? Head { get; set; }
	protected DoublyNode<T>? Tail { get; set; }
}