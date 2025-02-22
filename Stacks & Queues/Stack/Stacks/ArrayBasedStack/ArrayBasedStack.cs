namespace Stack;

public class ArrayBasedStack<T>
{
	private const int _defaultSize = 8;
	private T?[] __items;
	public ArrayBasedStack()
	{
		__items = new T?[_defaultSize];
	}
	public ArrayBasedStack(int size)
	{
		if (size < 0)
		{
			throw new InvalidOperationException("The size of an array cannot be a negative number.");
		}
		__items = new T?[Math.Max(size, _defaultSize)];
	}
	public int Length { get; private set; } = 0;
	public void Push(T? value)
	{
		if (Length == __items.Length)
		{
			ModifyToSize((int)Math.Ceiling(__items.Length * 1.5));
		}
		__items[Length] = value;
		Length++;
	}
	public T? Pop()
	{
		if (Length == 0)
		{
			throw new InvalidOperationException("Popping on an empty stack is not possible.");
		}
		T? poppedItem = __items[Length - 1];
		__items[Length - 1] = default;
		Length--;
		if ((Length < __items.Length / 4) && (__items.Length / 2 > _defaultSize))
		{
			ModifyToSize(Math.Max(Length, __items.Length / 2));
		}
		return poppedItem;
	}
	private void ModifyToSize(int newSize)
	{
		newSize = Math.Max(newSize, _defaultSize);
		T?[] newArray = new T?[newSize];
		Array.Copy(__items, newArray, Length);
		__items = newArray;
	}
}