
namespace OpenAddressedHashTable;

public class QuadraticProbingHashTable<K, V> : HashTableAbstract<K, V> where K : IComparable<K>
{
    public QuadraticProbingHashTable() : base() { }
    public QuadraticProbingHashTable(int initialBucketSize) : base(initialBucketSize) { }
    public override void Add(K key, V? value)
    {
        ArgumentNullException.ThrowIfNull(key, nameof(key));

        int hashedKey = _HashKey(key);
        int index = hashedKey, attemptCount = 0, multiplier = 1;
        int firstTombstone = -1;
        do
        {
            KeyValuePair<K, (bool, V?)>? probe = _buckets[index];
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

                index = (index + multiplier * multiplier) & (_buckets.Length - 1);
                attemptCount++;
                multiplier++;
            }
            else
            {
                break;
            }
        } while (attemptCount < _buckets.Length);

        if (attemptCount == _buckets.Length)
        {
            _Resize(_buckets.Length << 1);
            Add(key, value);
        }
        else
        {
            index = firstTombstone < 0 ? index : firstTombstone;
            _buckets[index] = new KeyValuePair<K, (bool, V?)>(key, (false, value));

            Count++;
            if (_loadFactor >= 0.75)
            {
                _Resize(_buckets.Length << 1);
            }
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
            Count = 0;
            _buckets = new KeyValuePair<K, (bool, V?)>?[_defaultBucketSize];
        }
    }

    public override bool ContainsByKey(K key)
    {
        ArgumentNullException.ThrowIfNull(key, nameof(key));
        bool doesExist = false;
        if (Count > 0)
        {
            int index = GetIndexByKey(key);
            if (index > -1)
            {
                doesExist = true;
            }
        }
        return doesExist;
    }

    public override bool Remove(K key)
    {
        ArgumentNullException.ThrowIfNull(key, nameof(key));
        bool isRemoved = false;
        if (Count > 0)
        {
            int index = GetIndexByKey(key);
            if (index > -1)
            {
                _buckets[index] = new KeyValuePair<K, (bool, V?)>(key, (true, default));
                isRemoved = true;
                Count--;
            }
        }
        if (_loadFactor <= 0.25)
        {
            _Resize(_buckets.Length >> 1);
        }
        return isRemoved;
    }

    public override bool TryGetValue(K key, out V? value)
    {
        ArgumentNullException.ThrowIfNull(key, nameof(key));
        bool doesExist = false;
        value = default;
        if (Count > 0)
        {
            int index = GetIndexByKey(key);
            if (index > -1)
            {
                value = _buckets[index]!.Value.Value.Item2;
                doesExist = true;
            }
        }
        return doesExist;
    }
    private protected override int GetIndexByKey(K key)
    {
        ArgumentNullException.ThrowIfNull(key);
        if (Count > 0)
        {
            int currentIndex = _HashKey(key);
            int attemptCount = 0, limit = _buckets.Length, multiplier = 1;
            do
            {
                KeyValuePair<K, (bool, V?)>? probe = _buckets[currentIndex];

                if (probe.HasValue is false)
                {
                    break;
                }

                if (probe.Value.Key.CompareTo(key) == 0)
                {
                    if (probe.Value.Value.Item1 is false)
                    {
                        return currentIndex;
                    }
                    break;
                }

                currentIndex = (currentIndex + multiplier * multiplier) & (_buckets.Length - 1);
                attemptCount++;
                multiplier++;
            } while (attemptCount < limit);
        }
        return -1;
    }
}