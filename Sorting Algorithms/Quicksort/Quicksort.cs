namespace Quicksort;

public static class Quicksort<T> where T : IComparable<T>
{
	private static Random s_random = new Random(DateTime.Now.Microsecond + DateTime.Now.Day + DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour);
	public static void Sort(T[] input)
	{
		ArgumentNullException.ThrowIfNull(input);
		Sort(input, 0, input.Length - 1);
	}
	private static void Sort(T[] input, int low, int high)
	{
		if (low < high)
		{
			int pivot = Partition(input, low, high);
			Sort(input, low, pivot);
			Sort(input, pivot + 1, high);
		}
	}
	private static int Partition(T[] input, int low, int high)
	{
		T pivot = input[s_random.Next(low, high + 1)];
		int i = low, j = high;
		while (true)
		{
			while (input[i].CompareTo(pivot) < 0)
			{
				i++;
			}
			while (input[j].CompareTo(pivot) > 0)
			{
				j--;
			}
			if (i >= j)
			{
				return j;
			}
			T temp = input[i];
			input[i++] = input[j];
			input[j--] = temp;
		}
	}
}