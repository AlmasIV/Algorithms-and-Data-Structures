namespace BinarySearch;

public static class BinarySearch<T> where T : IComparable<T>
{
	public static int Search(T[] sortedArray, T target)
	{
		ArgumentNullException.ThrowIfNull(sortedArray, nameof(sortedArray));
		ArgumentNullException.ThrowIfNull(target, nameof(target));

		int left = 0;
		int right = sortedArray.Length - 1;

		while (left <= right)
		{
			int middle = (left + right) / 2;
			if (sortedArray[middle].CompareTo(target) > 0)
			{
				right = middle - 1;
			}
			else if (sortedArray[middle].CompareTo(target) < 0)
			{
				left = middle + 1;
			}
			else
			{
				return middle;
			}
		}

		return -1;
	}
}