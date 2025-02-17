namespace LinkedListSorter;

public static class InsertionSorter<T> where T : IComparable<T>
{
	public static void Sort(LinkedList<T> linkedList)
	{
		if (linkedList.Count < 2)
		{
			return;
		}
		LinkedListNode<T>? current = linkedList.First!.Next;
		LinkedListNode<T>? previous, currentTemp;
		while (current is not null)
		{
			previous = current.Previous;
			currentTemp = current;
			while (previous is not null && previous.Value.CompareTo(currentTemp.Value) > 0)
			{
				linkedList.Remove(currentTemp);
				linkedList.AddBefore(previous, currentTemp);
				previous = currentTemp.Previous;
			}
			current = current.Next;
		}
	}
}