using System.Collections;

namespace SinglyLinkedList;

/// <summary>
/// 	Defines an abstract base class for a singly-linked list structures.
/// </summary>
/// <typeparam name="T">
/// 	The type of elements stored in the singly-linked list nodes.
/// </typeparam>
public abstract class SinglyLinkedListAbstract<T> : IEnumerable<T>
{
	/// <summary>
	/// 	The head node of the singly-linked list.
	/// </summary>
	protected Node<T>? _head { get; set; }

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

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? temp = _head;
		while(temp is not null) {
			yield return temp.Value!;
			temp = temp.Next;
		}
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}