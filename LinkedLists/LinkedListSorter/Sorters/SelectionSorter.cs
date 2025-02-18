namespace LinkedListSorter;

public static class SelectionSorter<T> where T : IComparable<T>
{
	public static void Sort(LinkedList<T> linkedList)
	{
		if (linkedList.Count < 2)
		{
			return;
		}
		LinkedListNode<T>? smallest;
		LinkedListNode<T>? pointer = linkedList.First;
		T? tempValue;

		while (pointer is not null)
		{
			smallest = FindSmallest(pointer);
			if (smallest != pointer)
			{
				tempValue = pointer.Value;
				pointer.Value = smallest.Value;
				smallest.Value = tempValue;
			}
			pointer = pointer.Next;
		}
	}
	private static LinkedListNode<T> FindSmallest(LinkedListNode<T>? start)
	{
		ArgumentNullException.ThrowIfNull(start);
		LinkedListNode<T>? smallest = start;
		start = start.Next;
		while (start is not null)
		{
			if (smallest.Value.CompareTo(start.Value) > 0)
			{
				smallest = start;
			}
			start = start.Next;
		}
		return smallest;
	}
}