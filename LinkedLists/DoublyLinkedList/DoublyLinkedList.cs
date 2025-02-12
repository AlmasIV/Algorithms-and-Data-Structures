using System.Collections;

namespace DoublyLinkedList;

public class DoublyLinkedList<T> : IEnumerable<Node<T>>
{
	public ulong Length { get; private set; }
	public Node<T>? Head { get; private set; }
	public Node<T>? Tail { get; private set; }
	public Guid Id { get; private set; } = Guid.NewGuid();
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
		node.LinkedListId = Id;
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
		node.LinkedListId = Id;
		Length++;
	}

	public void DeleteNodeByReference(Node<T> node)
	{
		ArgumentNullException.ThrowIfNull(node);
		if (!IsStandAloneNode(node))
		{
			throw new ArgumentException("The node belongs to another linked list.", nameof(node));
		}
		if (Length > 0 && Head == node)
		{
			DeleteFirst();
		}
		else if (Tail == node)
		{
			DeleteLast();
		}
		else
		{
			Node<T>? temp = Head;
			while (temp is not null)
			{
				if (temp.Next == node)
				{
					temp.Next = temp.Next.Next;
					if (temp.Next is not null)
					{
						temp.Next.Previous = temp;
					}
					ResetNode(node);
					Length--;
					break;
				}
				temp = temp.Next;
			}
		}
	}

	public void DeleteFirst()
	{
		if (Head is not null)
		{
			Node<T> temp = Head;
			Head = Head.Next;
			if (Head is not null)
			{
				Head.Previous = null;
			}
			ResetNode(temp);
			Length--;
		}
	}

	public void DeleteLast()
	{
		if (Tail is not null)
		{
			Node<T> temp = Tail;
			Tail = Tail.Previous;
			ResetNode(temp);
			Length --;
		}
	}

	private bool IsStandAloneNode(Node<T> node)
	{
		return node.Next is null && node.Previous is null && node.LinkedListId == Guid.Empty;
	}

	private void ResetNode(Node<T> node)
	{
		node.Previous = null;
		node.Next = null;
		node.Value = default;
		node.LinkedListId = default;
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