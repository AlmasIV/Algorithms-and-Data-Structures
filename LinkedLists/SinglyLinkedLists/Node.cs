namespace SinglyLinkedLists;

/// <summary>
/// 	Represents a node of a singly-linked list.
/// </summary>
/// <typeparam name="T">
/// 	The type of the value that the node stores.
/// </typeparam>
public class Node<T> {
	public T? Value { get; set; }
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