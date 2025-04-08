
namespace OpenAddressedHashTable;

public class LinearProbingHashTable<K, V> : HashTableAbstract<K, V> where K : IComparable<K>
{
	public LinearProbingHashTable() : base() { }
	public LinearProbingHashTable(int initialBucketSize) : base(initialBucketSize) { }
	public override void Add(K key, V value)
	{
		ArgumentNullException.ThrowIfNull(key, nameof(key));
		ArgumentNullException.ThrowIfNull(value, nameof(value));

		int hashedKey = _HashKey(key);
		int index = hashedKey;
		int firstTombstone = -1;
		do
		{
			KeyValuePair<K, (bool, V)>? probe = _buckets[index];
			if (probe.HasValue)
			{
				if (probe.Value.Value.Item1 is true)
				{
					firstTombstone = firstTombstone < 0 ? index : firstTombstone;
				}
				else if (probe.Value.Key.CompareTo(key) == 0)
				{
					throw new ArgumentException("The item with the specified key already exists!");
				}

				index = (index + 1) & (_buckets.Length - 1);
			}
			else
			{
				break;
			}
		} while (hashedKey != index);

		index = firstTombstone < 0 ? index : firstTombstone;
		_buckets[index] = new KeyValuePair<K, (bool, V)>(key, (false, value));

		Count++;
		if (_loadFactor >= 0.75)
		{
			_Resize(_buckets.Length << 1);
		}
	}

	public override void Add(KeyValuePair<K, V> item)
	{
		Add(item.Key, item.Value);
	}

	public override void Clear()
	{
		Count = 0;
		_buckets = new KeyValuePair<K, (bool, V)>?[_defaultBucketSize];
	}

	public override bool ContainsByKey(K key)
	{
		int hashedKey = _HashKey(key);
		KeyValuePair<K, (bool, V)>? probe = _buckets[hashedKey];
		while (probe.HasValue && (probe.Value.Value.Item1 || probe.Value.Key.CompareTo(key) != 0))
		{
			hashedKey = (hashedKey + 1) & (_buckets.Length - 1);
			probe = _buckets[hashedKey];
		}

		return probe.HasValue && probe.Value.Value.Item1 is false;
	}

	public override bool Remove(K key)
	{
		throw new NotImplementedException();
	}

	public override bool TryGetValue(K key, out V? value)
	{
		throw new NotImplementedException();
	}
}