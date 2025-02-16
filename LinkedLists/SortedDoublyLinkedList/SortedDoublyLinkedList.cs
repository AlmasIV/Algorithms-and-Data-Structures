using System.Collections;

namespace SortedDoublyLinkedList;

public sealed class SortedLinkedList<T> : IEnumerable<T> where T : IComparable<T>
{
	private Node? Head { get; set; }
	private Node? Tail { get; set; }
	public ulong Length { get; set; } = 0;
	public void AddNode(T value)
	{
		ArgumentNullException.ThrowIfNull(value);
		Node node = new Node() { Value = value };
		Node? temp = Head;
		if(temp is null) {
			Head = node;
			Tail = Head;
		}
		else {
			while(temp is not null) {
				if(temp.Value.CompareTo(value) == -1) {
					node.Next = temp.Next;
					node.Previous = temp;
					if(node.Next is not null) {
						node.Next.Previous = node;
					}
					temp.Next = node;
				}
				else {
					if(temp.Next is null) {
						node.Previous = temp;
						temp.Next = node;
					}
				}
			}
		}
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