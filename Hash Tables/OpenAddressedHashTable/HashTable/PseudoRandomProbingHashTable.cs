
namespace OpenAddressedHashTable;

public class PseudoRandomProbingHashTable<K, V> : HashTableAbstract<K, V> where K : IComparable<K>
{
	public PseudoRandomProbingHashTable() : base() { }
	public PseudoRandomProbingHashTable(int initialBucketSize) : base(initialBucketSize) { }
	public override void Add(K key, V? value)
	{
		ArgumentNullException.ThrowIfNull(key);
		int[] offsets = _GetOffsets(key);
		int index = _HashKey(key);
		int firstTombstone = -1;
		for (int i = 0; i < offsets.Length; i++)
		{
			index = (index + offsets[i]) & (_buckets.Length - 1);
			KeyValuePair<K, (bool, V?)>? probe = _buckets[index];
			if (probe.HasValue is false)
			{
				break;
			}
			else if (probe.Value.Value.Item1 is true)
			{
				firstTombstone = firstTombstone == -1 ? index : firstTombstone;
			}
			if (probe.Value.Key.CompareTo(key) == 0)
			{
				throw new ArgumentException("The item with the specified key exists!");
			}
		}
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
		bool doesExist = false;
		if (Count > 0)
		{
			int index = GetIndexByKey(key);
			if (index >= 0)
			{
				doesExist = true;
			}
		}
		return doesExist;
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
				Count--;
				isRemoved = true;
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
		bool doesExist = false;
		value = default;
		if (Count > 0)
		{
			int index = GetIndexByKey(key);
			if (index >= 0)
			{
				doesExist = true;
				value = _buckets[index]!.Value.Value.Item2;
			}
		}
		return doesExist;
	}

	private protected override int GetIndexByKey(K key)
	{
		ArgumentNullException.ThrowIfNull(key);
		if (Count > 0)
		{
			int[] offsets = _GetOffsets(key);
			int index, hashedKey = _HashKey(key);
			for (int i = 0; i < offsets.Length; i++)
			{
				index = (hashedKey + offsets[i]) & (_buckets.Length - 1);
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
			}
		}
		return -1;
	}

	private int[] _GetOffsets(K key)
	{
		int length = _buckets.Length;
		int hashedKey = _HashKey(key);
		int[] offsets = Enumerable.Range(0, length).ToArray();
		Random random = new(hashedKey);
		int tempIndex;
		for (int i = length - 1; i > 0; i--)
		{
			tempIndex = random.Next(i + 1);
			(offsets[i], offsets[tempIndex]) = (offsets[tempIndex], offsets[i]);
		}
		return offsets;
	}
}