using System.Collections;

namespace ChainedHashTable;
/*
	Quick Summary:
		1) Not designed for multi-threaded environment.
		2) Maintains sorted order for keys. To improve searching.
		3) Replaces item references completly if the keys are the same. Although the value reassignment is acceptable too.
		4) Doesn't accept 'null' as values.
		5) Doesn't have error handling.
*/
public class ChainedHashTable<K, T> : IEnumerable<T> where K : IComparable<K>
{
	public int Count { get; private set; } = 0;
	private const int _defaultSize = 16;
	private LinkedList<KeyValuePair<K, T>>[] _buckets = new LinkedList<KeyValuePair<K, T>>[_defaultSize];
	public void Set(K key, T item)
	{
		ArgumentNullException.ThrowIfNull(key);
		ArgumentNullException.ThrowIfNull(item);

		int hashedKey = _HashKey(key);
		KeyValuePair<K, T> itemToBeInserted = new KeyValuePair<K, T>(key, item);

		LinkedList<KeyValuePair<K, T>>? linkedListAtIndex = _buckets[hashedKey];

		if (linkedListAtIndex is null)
		{
			linkedListAtIndex = new LinkedList<KeyValuePair<K, T>>();
			_buckets[hashedKey] = linkedListAtIndex;
			linkedListAtIndex.AddFirst(itemToBeInserted);
		}
		else
		{
			LinkedListNode<KeyValuePair<K, T>>? tempNode = linkedListAtIndex.First;
			while (tempNode is not null && tempNode.Value.Key.CompareTo(itemToBeInserted.Key) < 0)
			{
				tempNode = tempNode.Next;
			}
			if (tempNode is null)
			{
				linkedListAtIndex.AddLast(itemToBeInserted);
			}
			else if (tempNode.Value.Key.CompareTo(itemToBeInserted.Key) == 0)
			{
				linkedListAtIndex.AddBefore(tempNode, itemToBeInserted);
				linkedListAtIndex.Remove(tempNode);
				return;
			}
			else
			{
				linkedListAtIndex.AddBefore(tempNode, itemToBeInserted);
			}
		}
		Count++;
	}
	private int _HashKey(K key)
	{
		ArgumentNullException.ThrowIfNull(key);
		return (key.GetHashCode() & 0x7FFFFFFF) % _buckets.Length;
	}
	public IEnumerator<T> GetEnumerator()
	{
		foreach (LinkedList<KeyValuePair<K, T>> bucket in _buckets)
		{
			LinkedListNode<KeyValuePair<K, T>>? tempNode = bucket?.First;
			while (tempNode is not null)
			{
				yield return tempNode.Value.Value;
				tempNode = tempNode.Next;
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}