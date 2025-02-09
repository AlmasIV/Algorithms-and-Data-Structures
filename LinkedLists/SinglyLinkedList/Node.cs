namespace SinglyLinkedList;

/// <summary>
/// 	Represents a node of a singly-linked list.
/// </summary>
/// <typeparam name="T">
/// 	The type of the value that the node stores.
/// </typeparam>
public class Node<T> {
	/// <summary>
	/// 	Gets or sets the value of the node.
	/// </summary>
	public T? Value { get; set; }

	/// <summary>
	/// 	Gets or sets the next node.
	/// </summary>
	public Node<T>? Next { get; set; }

	/// <summary>
	/// 	Creates a node with default properties.
	/// </summary>
	public Node(){}

	/// <summary>
	/// 	Creates a node with the specified <c><paramref name="value"/></c>.
	/// </summary>
	/// <param name="value">
	/// 	The value that the node stores.
	/// </param>
	public Node(T value) {
		Value = value;
	}
}