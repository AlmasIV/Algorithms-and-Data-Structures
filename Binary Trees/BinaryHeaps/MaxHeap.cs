using System.Collections;

namespace BinaryHeaps;

public class MaxHeap<T> : IEnumerable<T> where T : IComparable<T>
{
	private const int _defaultSize = 8;
	private T[] _items;
	public int Length { get; private set; } = 0;
	public T this[int index]
	{
		get {
			if(index < 0) {
				throw new ArgumentOutOfRangeException(nameof(index), "The index cannot be negative.");
			}
			if(index >= Length) {
				throw new ArgumentOutOfRangeException(nameof(index), "The index is out of range.");
			}
			return _items[index];
		}
	}
	public MaxHeap()
	{
		_items = new T[_defaultSize];
	}
	public MaxHeap(int size)
	{
		if (size < 0)
		{
			throw new InvalidOperationException("The size cannot be negative.");
		}
		_items = new T[Math.Max(size, _defaultSize)];
	}
	public void Insert(T value)
	{
		if (Length == _items.Length)
		{
			Resize((int)Math.Ceiling(_items.Length * 1.5));
		}
		_items[Length++] = value;
		int valuePointer = Length - 1;
		int parentIndex = (valuePointer - 1) / 2;
		while (parentIndex >= 0 && _items[parentIndex].CompareTo(value) < 0)
		{
			T temp = _items[parentIndex];
			_items[parentIndex] = value;
			_items[valuePointer] = temp;
			valuePointer = parentIndex;
			parentIndex = (valuePointer - 1) / 2;
		}
	}
	private void Resize(int newSize)
	{
		newSize = Math.Max(newSize, _defaultSize);
		T[] newArray = new T[newSize];
		Array.Copy(_items, newArray, Length);
	}

	public static bool IsMaxHeap(T[] binaryTree)
	{
		int left, right;
		int maxParentIndex = (binaryTree.Length - 2) / 2;
		for (int i = 0; i <= maxParentIndex; i++)
		{
			left = 2 * i + 1;
			right = 2 * i + 2;
			if (left < binaryTree.Length && binaryTree[i].CompareTo(binaryTree[left]) < 0)
			{
				return false;
			}
			if (right < binaryTree.Length && binaryTree[i].CompareTo(binaryTree[right]) < 0)
			{
				return false;
			}
		}
		return true;
	}

	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < Length; i++)
		{
			yield return _items[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}