namespace Queue;

public enum Priority
{
	Minimum,
	Average,
	Maximum
}
public class PriorityQueue<T>
{
	private LinkedList<Item> _elements = new();
	public int Length => _elements.Count;
	public void Enqueue(T item, Priority priority = Priority.Minimum)
	{
		Item enqueuedItem = new(priority, item);
		LinkedListNode<Item>? temp = _elements.First;
		if (temp is null || temp.Value.Priority >= priority)
		{
			_elements.AddFirst(enqueuedItem);
		}
		else
		{
			while (temp!.Next is not null && temp.Value.Priority <= priority)
			{
				temp = temp.Next;
			}
			_elements.AddAfter(temp, enqueuedItem);
		}
	}
	public T Dequeue()
	{
		if (_elements.Count == 0)
		{
			throw new InvalidOperationException("The queue is empty.");
		}
		T value = _elements.Last!.Value.Value;
		_elements.RemoveLast();
		return value;
	}

	private class Item
	{
		public Priority Priority { get; set; }
		public T Value { get; set; }
		public Item(Priority priority, T value)
		{
			Priority = priority;
			Value = value;
		}
	}
}