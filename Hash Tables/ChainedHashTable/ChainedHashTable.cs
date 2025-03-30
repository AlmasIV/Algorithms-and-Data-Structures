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
public class ChainedHashTable<K, V> : IEnumerable<KeyValuePair<K, V>> where K : IComparable<K>
{
	public int Count { get; private set; } = 0;
	private const int _defaultSize = 16;
	private LinkedList<KeyValuePair<K, V>>[] _buckets = new LinkedList<KeyValuePair<K, V>>[_defaultSize];
	public void Set(KeyValuePair<K, V> keyValuePair)
	{
		Set(keyValuePair.Key, keyValuePair.Value);
	}
	public void Set(K key, V item)
	{
		ArgumentNullException.ThrowIfNull(key);
		ArgumentNullException.ThrowIfNull(item);

		int hashedKey = _HashKey(key);
		KeyValuePair<K, V> itemToBeInserted = new KeyValuePair<K, V>(key, item);

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