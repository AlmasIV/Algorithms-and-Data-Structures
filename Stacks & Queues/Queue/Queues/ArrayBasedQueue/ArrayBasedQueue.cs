namespace Queue;

public class ArrayBasedQueue<T>
{
	private const int _defaultSize = 8;
	private T?[] __items;
	public ArrayBasedQueue()
	{
		__items = new T?[_defaultSize];
	}
	public ArrayBasedQueue(int size)
	{
		if (size < 0)
		{
			throw new InvalidOperationException("The size of an array cannot be a negative number.");
		}
		__items = new T?[Math.Max(size, _defaultSize)];
	}
	public int Length { get; private set; } = 0;
	private int _pointer = 0;
	public void Enqueue(T? value)
	{
		if (Length == __items.Length)
		{
			ModifyToSize((int)Math.Ceiling(__items.Length * 1.5));
		}
		__items[Length] = value;
		Length++;
	}
	public T? Dequeue()
	{
		if (Length == 0)
		{
			throw new InvalidOperationException("Dequeuing on an empty queue is impossible.");
		}
		T? dequeuedItem = __items[_pointer];
		__items[_pointer] = default;
		_pointer ++;
		Length--;
		if ((Length < __items.Length / 4) && (__items.Length / 2 > _defaultSize))
		{
			ModifyToSize(Math.Max(Length, __items.Length / 2));
		}
		return dequeuedItem;
	}
	private void ModifyToSize(int newSize)
	{
		newSize = Math.Max(newSize, _defaultSize);
		T?[] newArray = new T?[newSize];
		Array.Copy(__items, newArray, Length);
		__items = newArray;
	}
}