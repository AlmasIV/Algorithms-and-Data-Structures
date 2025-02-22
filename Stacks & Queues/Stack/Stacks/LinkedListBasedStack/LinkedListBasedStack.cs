namespace Stack;

public class LinkedListBasedStack<T>
{
	private LinkedList<T?> _values { get; set; } = new();
	public int Length
	{
		get
		{
			return _values.Count;
		}
	}
	public void Push(T? value)
	{
		_values.AddLast(value);
	}
	public T? Pop()
	{
		if(Length == 0) {
			throw new InvalidOperationException("The pop is not possible on an empty stack.");
		}
		T? last = _values.Last!.Value;
		_values.RemoveLast();
		return last;
	}
}