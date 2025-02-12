using System.Collections;

namespace DoublyLinkedList;

public class DoublyLinkedList<T> : IEnumerable<Node<T>>
{
	public ulong Length { get; private set; }
	public Node<T>? Head { get; private set; }
	public Node<T>? Tail { get; private set; }

	public void AppendNode(Node<T> node)
	{
		ArgumentNullException.ThrowIfNull(node);
		if (!IsStandAloneNode(node))
		{
			throw new ArgumentException("The node belongs to another linked list.", nameof(node));
		}
		if (Head is null)
		{
			Head = node;
			Tail = node;
		}
		else
		{
			Tail!.Next = node;
			node.Previous = Tail;
			Tail = node;
		}
		Length++;
	}

	public void PrependNode(Node<T> node)
	{
		ArgumentNullException.ThrowIfNull(node);
		if (!IsStandAloneNode(node))
		{
			throw new ArgumentException("The node belongs to another linked list.", nameof(node));
		}
		if (Head is null)
		{
			Head = node;
			Tail = node;
		}
		else
		{
			Head.Previous = node;
			node.Next = Head;
			Head = node;
		}
		Length++;
	}

	private bool IsStandAloneNode(Node<T> node)
	{
		return node.Next is null && node.Previous is null;
	}

	public IEnumerator<Node<T>> GetEnumerator()
	{
		Node<T>? temp = Head;
		while (temp is not null)
		{
			yield return temp;
			temp = temp.Next;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}