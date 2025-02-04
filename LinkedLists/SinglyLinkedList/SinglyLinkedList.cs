
namespace SinglyLinkedList;

/// <summary>
/// 	Represents a singly-linked list of type <c><typeparamref name="T"/></c>.
/// </summary>
/// <typeparam name="T">
/// 	The type of elements stored in the singly-linked list nodes.
/// </typeparam>
public class SinglyLinkedList<T> : LinkedListAbstract<T>
{
	/// <inheritdoc />
	/// <exception cref="ArgumentNullException">
	/// 	Thrown when the <c><paramref name="node"/></c> is <c>null</c>.
	/// </exception>
	public override void PrependNode(Node<T> node)
	{
		ArgumentNullException.ThrowIfNull(node);

		if (base.Head is null)
		{
			base.Head = node;
		}
		else
		{
			node.Next = base.Head;
			base.Head = node;
		}
		base.Length ++;
	}

	/// <inheritdoc />
	/// <exception cref="ArgumentNullException">
	/// 	Thrown when the <c><paramref name="node"/></c> is <c>null</c>.
	/// </exception>
	public override void AppendNode(Node<T> node)
	{
		ArgumentNullException.ThrowIfNull(node);

		if (base.Head is null)
		{
			base.Head = node;
		}
		else
		{
			Node<T> tempNode = base.Head;
			while (tempNode.Next is not null)
			{
				tempNode = tempNode.Next;
			}
			tempNode.Next = node;
		}
		base.Length ++;
	}

	///	<inheritdoc />
	/// <exception cref="ArgumentNullException">
	/// 	Thrown when the <c><paramref name="node"/></c> is <c>null</c>.
	/// </exception>
	public override void RemoveNodeByReference(Node<T> node)
	{
		ArgumentNullException.ThrowIfNull(node);

		if (Head is null)
		{
			return;
		}
		else if (node == base.Head)
		{
			Head = Head.Next;
		}
		else
		{
			Node<T>? temp = base.Head;
			while (temp is not null)
			{
				if (temp.Next == node)
				{
					temp.Next = temp.Next.Next;
					break;
				}
				temp = temp.Next;
			}
		}
		base.Length --;
	}

	public override IEnumerator<T> GetEnumerator()
	{
		Node<T>? temp = Head;
		while (temp is not null)
		{
			yield return temp.Value!;
			temp = temp.Next;
		}
	}
}