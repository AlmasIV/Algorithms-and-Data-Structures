using System.Collections;

namespace SinglyLinkedList;

/// <summary>
/// 	Defines an abstract base class for a linked list structures.
/// </summary>
/// <typeparam name="T">
/// 	The type of elements stored in the linked list nodes.
/// </typeparam>
public abstract class SinglyLinkedListAbstract<T> : IEnumerable<Node<T>>
{
	/// <summary>
	/// 	The head node of the linked list.
	/// </summary>
	protected Node<T>? Head { get; set; }

	/// <summary>
	/// 	The length of the linked list.
	/// </summary>
	public ulong Length { get; set; }

	/// <summary>
	/// 	Adds the specified <c><paramref name="node"/></c> to the beginning of the list.
	/// </summary>
	/// <param name="node">
	/// 	The node to be prepended to the list.
	/// </param>
	public abstract void PrependNode(Node<T> node);

	/// <summary>
	/// 	Adds the specified <c><paramref name="node"/></c> to the end of the list.
	/// </summary>
	/// <param name="node">
	/// 	The node to be appended to the list.
	/// </param>
	public abstract void AppendNode(Node<T> node);

	/// <summary>
	/// 	Removes the specified <c><paramref name="node"/></c> from the linked list.
	/// </summary>
	/// <param name="node">
	/// 	The node to be removed.
	/// </param>
	public abstract void RemoveNodeByReference(Node<T> node);

	/// <summary>
	/// 	Removes a first node with the specified <c><paramref name="value"/></c> from the linked list.
	/// </summary>
	/// <param name="value">
	/// 	The value of the node to be removed.
	/// </param>
	public abstract void RemoveNodeByValue(T value);

	/// <summary>
	/// 	Checks whether the linked list contains the specified <c><paramref name="node"/></c>.
	/// </summary>
	/// <param name="node">
	/// 	The node to be checked.
	/// </param>
	/// <returns>
	/// 	<c>true</c> if the passed <c><paramref name="node"/></c> is part of the linked list. Otherwise <c>false</c>.
	/// </returns>
	public abstract bool ContainsNode(Node<T> node);

	/// <summary>
	/// 	Inserts <c><paramref name="nodeToBeInserted"/></c> after <c><paramref name="node"/></c>.
	/// </summary>
	/// <param name="node">
	/// 	The node that must come before the <c><paramref name="nodeToBeInserted"/></c>.
	/// </param>
	/// <param name="nodeToBeInserted">
	/// 	The node that to be inserted.
	/// </param>
	public abstract void InsertAfter(Node<T> node, Node<T> nodeToBeInserted);

	public abstract IEnumerator<Node<T>> GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}