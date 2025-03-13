using System.Collections;

namespace BinaryHeaps;

public class MaxHeap<T> : IEnumerable<T> where T : IComparable<T>
{
	private const int _defaultSize = 8;
	private T[] _items;
	public int Length { get; private set; } = 0;
	public T this[int index]
	{
		get
		{
			if (index < 0 || index >= Length)
			{
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
		HeapifyUp(Length - 1);
	}
	public T RemoveTopItem()
	{
		if (Length == 0)
		{
			throw new InvalidOperationException("The heap is empty.");
		}
		T result = _items[0];
		_items[0] = _items[--Length];
		HeapifyDown(0);
		return result;
	}

	// Why? Because this is more efficient than calling Insert then RemoveTopItem.
	public T InsertRemoveTopItem(T value)
	{
		if (Length == 0 || _items[0].CompareTo(value) <= 0)
		{
			return value;
		}
		T result = _items[0];
		_items[0] = value;
		HeapifyDown(0);
		return result;
	}
	private void HeapifyUp(int index)
	{
		int parentIndex = (index - 1) / 2;
		while (index > 0 && _items[parentIndex].CompareTo(_items[index]) < 0)
		{
			T temp = _items[parentIndex];
			_items[parentIndex] = _items[index];
			_items[index] = temp;
			index = parentIndex;
			parentIndex = (index - 1) / 2;
		}
	}
	private void HeapifyDown(int index)
	{
		int left, right, largestIndex;
		while (true)
		{
			left = 2 * index + 1;
			right = 2 * index + 2;
			largestIndex = index;

			if (left < Length && _items[largestIndex].CompareTo(_items[left]) < 0)
			{
				largestIndex = left;
			}
			if (right < Length && _items[largestIndex].CompareTo(_items[right]) < 0)
			{
				largestIndex = right;
			}

			if (largestIndex == index)
			{
				break;
			}

			T temp = _items[largestIndex];
			_items[largestIndex] = _items[index];
			_items[index] = temp;
			index = largestIndex;
		}
	}
	private void Resize(int newSize)
	{
		newSize = Math.Max(newSize, _defaultSize);
		T[] newArray = new T[newSize];
		Array.Copy(_items, newArray, Length);
		_items = newArray;
	}

	public static bool IsMaxHeap(T[] binaryTree)
	{
		ArgumentNullException.ThrowIfNull(binaryTree);
		if (binaryTree.Length == 0)
		{
			return false;
		}
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