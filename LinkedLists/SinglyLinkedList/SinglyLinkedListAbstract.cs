using System.Collections;

namespace SinglyLinkedList;

/// <summary>
/// 	Defines an abstract base class for a linked list structures.
/// </summary>
/// <typeparam name="T">
/// 	The type of elements stored in the linked list nodes.
/// </typeparam>
public abstract class LinkedListAbstract<T> : IEnumerable<T>
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

	public abstract IEnumerator<T> GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}