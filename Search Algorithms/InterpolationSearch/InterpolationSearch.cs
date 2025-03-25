namespace InterpolationSearch;

public static class InterpolationSearch<T> where T : IKey
{
	public static int Search(T[] sortedArray, int targetKey)
	{
		ArgumentNullException.ThrowIfNull(sortedArray);

		int low = 0;
		int high = sortedArray.Length - 1;

		while (low <= high && targetKey >= sortedArray[low].Key && targetKey <= sortedArray[high].Key)
		{
			if (low == high)
			{
				if (sortedArray[low].Key == targetKey)
				{
					return low;
				}
				else
				{
					return -1;
				}
			}

			int possibleIndex = low + (targetKey - sortedArray[low].Key) * (high - low) / (sortedArray[high].Key - sortedArray[low].Key);

			if (sortedArray[possibleIndex].Key == targetKey)
			{
				return possibleIndex;
			}
			else if (sortedArray[possibleIndex].Key < targetKey)
			{
				low = possibleIndex + 1;
			}
			else
			{
				high = possibleIndex - 1;
			}
		}

		return -1;
	}
}