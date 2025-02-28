namespace Queue;

public class LinkedListBasedQueue<T>
{
	private LinkedList<T> _values = new LinkedList<T>();
	public int Length {
		get {
			return _values.Count;
		}
	}
	public void Enqueue(T value)
	{
		ArgumentNullException.ThrowIfNull(value);
		_values.AddFirst(value);
	}
	public T Dequeue()
	{
		if(_values.Count < 1) {
			throw new InvalidOperationException("The queue is empty.");
		}
		T first = _values.Last!.Value;
		_values.RemoveLast();
		return first;
	}
}