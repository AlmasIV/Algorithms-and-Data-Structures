
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
		throw new NotImplementedException();
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