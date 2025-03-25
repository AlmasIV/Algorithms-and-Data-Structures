namespace BinarySearch;

public static class RightmostBinarySearch<T> where T : IComparable<T>
{
	public static int Search(T[] sortedArray, T target)
	{
		ArgumentNullException.ThrowIfNull(sortedArray, nameof(sortedArray));
		ArgumentNullException.ThrowIfNull(target, nameof(target));

		int left = 0;
		int right = sortedArray.Length;

		while (left < right)
		{
			int middle = (left + right) / 2;
			if (sortedArray[middle].CompareTo(target) > 0)
			{
				right = middle;
			}
			else
			{
				left = middle + 1;
			}
		}

		right --;
		if (right > -1 && right < sortedArray.Length && sortedArray[right].CompareTo(target) == 0)
		{
			return right;
		}
		else
		{
			return -1;
		}
	}
}