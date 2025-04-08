using System.Collections;

namespace OpenAddressedHashTable;
public abstract class HashTableAbstract<K, V> : IEnumerable<KeyValuePair<K, V?>> where K : IComparable<K>
{
	private protected double _loadFactor => (double)Count / _buckets.Length;
	private protected const int _defaultBucketSize = 64;
	private protected KeyValuePair<K, (bool, V?)>?[] _buckets;
	public HashTableAbstract()
	{
		_buckets = new KeyValuePair<K, (bool, V?)>?[_defaultBucketSize];
	}
	public HashTableAbstract(int initialBucketSize)
	{
		if (initialBucketSize < 0)
		{
			throw new ArgumentException("The size cannot be negative.", nameof(initialBucketSize));
		}
		initialBucketSize = Math.Max(_defaultBucketSize, initialBucketSize);
		_buckets = new KeyValuePair<K, (bool, V?)>?[initialBucketSize];
	}
	public int Count { get; private protected set; }
	public abstract void Add(K key, V? value);
	public abstract void Add(KeyValuePair<K, V?> item);
	public abstract bool Remove(K key);
	public abstract bool ContainsByKey(K key);
	public abstract bool TryGetValue(K key, out V? value);
	public abstract void Clear();
	private protected void _Resize(int newBucketSize)
	{
		newBucketSize = Math.Max(newBucketSize, _defaultBucketSize);
		if (newBucketSize != _buckets.Length)
		{
			KeyValuePair<K, (bool, V?)>?[] oldBuckets = _buckets;
			_buckets = new KeyValuePair<K, (bool, V?)>?[newBucketSize];
			Count = 0;
			foreach (KeyValuePair<K, (bool, V?)>? item in oldBuckets)
			{
				if (item.HasValue && item.Value.Value.Item1 is false)
				{
					Add(item.Value.Key, item.Value.Value.Item2);
				}
			}
		}
	}
	private protected int _HashKey(K key)
	{
		ArgumentNullException.ThrowIfNull(key, nameof(key));
		// 1) Get the raw 32‑bit hash code
		int h = key.GetHashCode();

		// 2) Mix (or “spread”) the high bits down into the low bits:
		//    - (h >> 20) shifts the top 12 bits down to positions 0–11
		//    - (h >> 12) shifts the top 20 bits down to positions 0–19
		//    XORing those with h smears high‐bit entropy into the lower bits.
		h ^= (h >> 20) ^ (h >> 12);

		// 3) Do a second round of mixing with different shifts:
		//    - (h >> 7)  shifts bits 7–31 down to 0–24
		//    - (h >> 4)  shifts bits 4–31 down to 0–27
		h ^= (h >> 7) ^ (h >> 4);

		// 4) Clear the sign bit so we have a non‑negative integer:
		//    (h & 0x7FFFFFFF) zeroes out the highest bit.
		// 5) Mask off the low bits to get an index in [0, bucketCount):
		//    If bucketCount is a power of two, bucketCount-1 is 0b…1111,
		//    so h & (bucketCount-1) is equivalent to h % bucketCount but much faster.
		return (h & 0x7FFFFFFF) & (_buckets.Length - 1);
	}

	public virtual IEnumerator<KeyValuePair<K, V?>> GetEnumerator()
	{
		foreach (KeyValuePair<K, (bool, V?)>? item in _buckets)
		{
			if (item.HasValue && item.Value.Value.Item1 is false)
			{
				yield return new KeyValuePair<K, V?>(item.Value.Key, item.Value.Value.Item2);
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}