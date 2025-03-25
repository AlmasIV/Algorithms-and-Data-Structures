namespace BinarySearch;

public static class LeftmostBinarySearch<T> where T : IComparable<T>
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
			if (sortedArray[middle].CompareTo(target) < 0)
			{
				left = middle + 1;
			}
			else
			{
				right = middle;
			}
		}
		if (left < sortedArray.Length && sortedArray[left].CompareTo(target) == 0)
		{
			return left;
		}
		else
		{
			return -1;
		}
	}
}