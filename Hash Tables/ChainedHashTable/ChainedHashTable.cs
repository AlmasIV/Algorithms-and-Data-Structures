using System.Collections;

namespace ChainedHashTable;
/*
	Quick Summary:
		1) Not designed for multi-threaded environment.
		2) Maintains sorted order for keys with the same hash. To improve searching.
		3) Replaces item references completely if the keys are the same. Although the value reassignment would be acceptable too.
		4) Doesn't accept 'null' as values.
		5) Doesn't have error handling.
*/
public class ChainedHashTable<K, V> : IEnumerable<KeyValuePair<K, V>> where K : IComparable<K>
{
	public int Count { get; private set; } = 0;
	private const int _defaultSize = 16;
	private LinkedList<KeyValuePair<K, V>>[] _buckets = new LinkedList<KeyValuePair<K, V>>[_defaultSize];
	public void Set(K key, V value)
	{
		ArgumentNullException.ThrowIfNull(key);
		ArgumentNullException.ThrowIfNull(value);

		Set(new KeyValuePair<K, V>(key, value));
	}
	public void Set(KeyValuePair<K, V> itemToBeInserted)
	{
		ArgumentNullException.ThrowIfNull(itemToBeInserted);
		ArgumentNullException.ThrowIfNull(itemToBeInserted.Key);
		ArgumentNullException.ThrowIfNull(itemToBeInserted.Value);

		int hashedKey = _HashKey(itemToBeInserted.Key);

		LinkedList<KeyValuePair<K, V>>? linkedListAtIndex = _buckets[hashedKey];

		if (linkedListAtIndex is null)
		{
			linkedListAtIndex = new LinkedList<KeyValuePair<K, V>>();
			_buckets[hashedKey] = linkedListAtIndex;
			linkedListAtIndex.AddFirst(itemToBeInserted);
		}
		else
		{
			LinkedListNode<KeyValuePair<K, V>>? tempNode = linkedListAtIndex.First;
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
	public bool TryGetValue(K key, out V? value)
	{
		ArgumentNullException.ThrowIfNull(key);

		int hashedKey = _HashKey(key);
		LinkedList<KeyValuePair<K, V>>? linkedListAtIndex = _buckets[hashedKey];
		value = default;
		bool found = false;
		if (linkedListAtIndex is not null)
		{
			LinkedListNode<KeyValuePair<K, V>>? tempNode = linkedListAtIndex.First;
			while (tempNode is not null)
			{
				if (tempNode.Value.Key.CompareTo(key) == 0)
				{
					value = tempNode.Value.Value;
					found = true;
					break;
				}

				if (tempNode.Value.Key.CompareTo(key) > 0)
				{
					break;
				}

				tempNode = tempNode.Next;
			}
		}
		return found;
	}
	private int _HashKey(K key)
	{
		ArgumentNullException.ThrowIfNull(key);
		return (key.GetHashCode() & 0x7FFFFFFF) % _buckets.Length;
	}
	public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
	{
		foreach (LinkedList<KeyValuePair<K, V>> bucket in _buckets)
		{
			LinkedListNode<KeyValuePair<K, V>>? tempNode = bucket?.First;
			while (tempNode is not null)
			{
				yield return tempNode.Value;
				tempNode = tempNode.Next;
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}