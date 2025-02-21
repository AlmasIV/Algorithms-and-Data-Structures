namespace CircularLinkedListDetector;

public static class ReversingApproach<T>
{
	public static bool HasLoop(Node<T> node)
	{
		bool hasLoop = false;
		if (node is not null && node.Next is not null)
		{
			Node<T> reversed = Reverse(node);
			Reverse(node);
			if (reversed == node)
			{
				hasLoop = true;
			}
		}
		return hasLoop;
	}
	private static Node<T> Reverse(Node<T> node)
	{
		Node<T>? current = node;
		Node<T>? prev = null, next = null;
		while (current is not null)
		{
			next = current.Next;
			current.Next = prev;
			prev = current;
			current = next;
		}
		return prev!;
	}
}