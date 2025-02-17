using System.Collections;

namespace SortedDoublyLinkedList;

public sealed class SortedLinkedList<T> : IEnumerable<T> where T : IComparable<T>
{
	private Node? Head { get; set; }
	public ulong Length { get; set; } = 0;
	public void AddNode(T value)
	{
		ArgumentNullException.ThrowIfNull(value);
		Node node = new Node() { Value = value };
		Node? temp = Head;
		if (temp is null)
		{
			Head = node;
			Length ++;
		}
		else
		{
			while (temp is not null)
			{
				if (temp.Value.CompareTo(value) == 1)
				{
					if (temp.Previous is null)
					{
						node.Next = temp;
						temp.Previous = node;
						Head = node;
					}
					else
					{
						temp.Previous.Next = node;
						node.Previous = temp.Previous;
						temp.Previous = node;
						node.Next = temp;
					}
					Length ++;
					break;
				}
				else
				{
					if (temp.Next is null)
					{
						node.Previous = temp;
						temp.Next = node;
						Length ++;
						break;
					}
				}
				temp = temp.Next;
			}
		}
	}
	public SortedLinkedList<T> Copy()
	{
		SortedLinkedList<T> copy = new SortedLinkedList<T>();

		Node? temp = Head;

		while (temp is not null)
		{
			copy.AddNode(temp.Value);
			temp = temp.Next;
		}

		return copy;
	}
	public IEnumerator<T> GetEnumerator()
	{
		Node? temp = Head;
		while (temp is not null)
		{
			yield return temp.Value!;
			temp = temp.Next;
		}
	}
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
	private class Node
	{
		public required T Value { get; init; }
		public Node? Next { get; set; }
		public Node? Previous { get; set; }
	}
}