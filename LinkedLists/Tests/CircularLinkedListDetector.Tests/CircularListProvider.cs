namespace CircularLinkedListDetector.Tests;

public static class CircularListProvider
{
	public static readonly int _maxNumberOfNodes = 100;
	public static Node<int> GetCircularLinkedList()
	{
		Node<int>? head = null;
		Node<int>? temp = null, prevTemp = null;
		for (int i = 0; i < _maxNumberOfNodes; i++)
		{
			temp = new Node<int>() { Value = i };
			if (head is null)
			{
				head = temp;
			}
			else
			{
				prevTemp!.Next = temp;
			}
			prevTemp = temp;
		}
		prevTemp!.Next = head;
		return head!;
	}
}