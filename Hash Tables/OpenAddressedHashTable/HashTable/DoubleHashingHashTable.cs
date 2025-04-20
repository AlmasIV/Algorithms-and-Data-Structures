
namespace OpenAddressedHashTable;

public class DoubleHashingHashTable<K, V> : HashTableAbstract<K, V> where K : IComparable<K>
{
	public DoubleHashingHashTable() : base() { }
	public DoubleHashingHashTable(int initialBucketSize) : base(initialBucketSize) { }
	public override void Add(K key, V? value)
	{
		ArgumentNullException.ThrowIfNull(key);
		int index = _HashKey(key);
		int step = _HashKeyProbe(key);
		int firstTombstone = -1;
		int limit = _buckets.Length;
		int attemptCount = 0;
		do
		{
			KeyValuePair<K, (bool, V?)>? probe = _buckets[index];
			if (probe.HasValue is false)
			{
				break;
			}
			if (probe.Value.Key.CompareTo(key) == 0)
			{
				if (probe.Value.Value.Item1 is false)
				{
					throw new ArgumentException("The element with the same key already exists!", nameof(key));
				}
				firstTombstone = firstTombstone == -1 ? index : firstTombstone;
			}
			index = (index + step) & (limit - 1);
			attemptCount++;
		} while (attemptCount < limit);
		index = firstTombstone == -1 ? index : firstTombstone;
		_buckets[index] = new KeyValuePair<K, (bool, V?)>(key, (false, value));
		Count++;
		if (_loadFactor >= 0.75)
		{
			_Resize(_buckets.Length << 1);
		}
	}

	public override void Add(KeyValuePair<K, V?> item)
	{
		Add(item.Key, item.Value);
	}

	public override void Clear()
	{
		if (Count > 0)
		{
			_buckets = new KeyValuePair<K, (bool, V?)>?[_defaultBucketSize];
			Count = 0;
		}
	}

	public override bool ContainsByKey(K key)
	{
		ArgumentNullException.ThrowIfNull(key);
		return GetIndexByKey(key) >= 0;
	}

	public override bool Remove(K key)
	{
		ArgumentNullException.ThrowIfNull(key);
		bool isRemoved = false;
		if (Count > 0)
		{
			int index = GetIndexByKey(key);
			if (index >= 0)
			{
				_buckets[index] = new KeyValuePair<K, (bool, V?)>(key, (true, default));
				isRemoved = true;
				Count--;
				if (_loadFactor <= 0.25)
				{
					_Resize(_buckets.Length >> 1);
				}
			}
		}
		return isRemoved;
	}

	public override bool TryGetValue(K key, out V? value)
	{
		ArgumentNullException.ThrowIfNull(key);
		bool isFound = false;
		value = default;
		if (Count > 0)
		{
			int index = GetIndexByKey(key);
			if (index >= 0)
			{
				isFound = true;
				value = _buckets[index]!.Value.Value.Item2;
			}
		}
		return isFound;
	}

	private protected override int GetIndexByKey(K key)
	{
		if (Count > 0)
		{
			int index = _HashKey(key);
			int step = _HashKeyProbe(key);
			int limit = _buckets.Length;
			int attemptCount = 0;
			do
			{
				KeyValuePair<K, (bool, V?)>? probe = _buckets[index];
				if (probe.HasValue is false)
				{
					break;
				}
				if (probe.Value.Key.CompareTo(key) == 0)
				{
					if (probe.Value.Value.Item1 is false)
					{
						return index;
					}
					break;
				}
				attemptCount++;
				index = (index + step) & (limit - 1);
			} while (attemptCount < limit);
		}
		return -1;
	}
	private int _HashKeyProbe(K key)
	{
		int rawHash = key.GetHashCode();

		rawHash ^= (rawHash >> 20) ^ (rawHash >> 12);
		rawHash ^= (rawHash >> 7) ^ (rawHash >> 4);

		rawHash &= 0x7FFFFFFF;

		return 1 + (rawHash % (_buckets.Length - 1));
	}
}