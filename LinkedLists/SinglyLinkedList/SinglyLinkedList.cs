namespace SinglyLinkedList;

/// <summary>
/// 	Represents a singly-linked list of type <c><typeparamref name="T"/></c>.
/// </summary>
/// <typeparam name="T">
/// 	The type of elements stored in the singly-linked list nodes.
/// </typeparam>
public class SinglyLinkedList<T> : SinglyLinkedListAbstract<T> {
	/// <summary>
	/// 	Creates a singly-linked list with the specified <c><paramref name="head"/></c>.
	/// </summary>
	/// <param name="head">
	/// 	The head of the singly-linked list.
	/// </param>
	/// <exception cref="ArgumentNullException">
	/// 	Thrown if <c><paramref name="head"/></c> is <c>null</c>.
	/// </exception>
	public SinglyLinkedList(Node<T> head) {
		ArgumentNullException.ThrowIfNull(head);
		base._head = head;
	}
	
	/// <inheritdoc />
	/// <exception cref="ArgumentNullException">
	/// 	Thrown when the <c><paramref name="node"/></c> is <c>null</c>.
	/// </exception>
    public override void PrependNode(Node<T> node)
    {
        ArgumentNullException.ThrowIfNull(node);
		node.Next = base._head;
		base._head = node;
    }
}