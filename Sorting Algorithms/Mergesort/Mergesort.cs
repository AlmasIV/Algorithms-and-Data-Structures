namespace Mergesort;

public static class Mergesort<T> where T : IComparable<T>
{
	public static void Sort(T[] input)
	{
		ArgumentNullException.ThrowIfNull(input);
		Sort(input, 0, input.Length - 1);
	}
	private static void Sort(T[] input, int low, int high)
	{
		if (low < high)
		{
			int middle = (low + high) / 2;
			Sort(input, low, middle);
			Sort(input, middle + 1, high);
			Merge(input, low, middle, high);
		}
	}
	private static void Merge(T[] input, int low, int middle, int high)
	{
		int leftSize = middle - low + 1;
		int rightSize = high - middle;

		T[] left = new T[leftSize];
		T[] right = new T[rightSize];

		for (int i = 0; i < leftSize; i++)
		{
			left[i] = input[low + i];
		}
		for (int i = 0; i < rightSize; i++)
		{
			right[i] = input[middle + 1 + i];
		}

		int leftIndex = 0, rightIndex = 0, pointer = low;
		while (leftIndex < leftSize && rightIndex < rightSize)
		{
			if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
			{
				input[pointer] = left[leftIndex++];
			}
			else
			{
				input[pointer] = right[rightIndex++];
			}
			pointer++;
		}

		while (leftIndex < leftSize)
		{
			input[pointer++] = left[leftIndex++];
		}

		while (rightIndex < rightSize)
		{
			input[pointer++] = right[rightIndex++];
		}
	}
}