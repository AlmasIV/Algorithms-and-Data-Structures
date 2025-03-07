namespace BubbleSort;

public static class BubbleSort<T> where T : IComparable<T>
{
	public static void Sort(T[] inputs)
	{
		ArgumentNullException.ThrowIfNull(inputs);
		if (inputs.Length < 2)
		{
			return;
		}
		bool isSorted = false;
		int upperBound = inputs.Length;
		while (!isSorted)
		{
			isSorted = true;
			for (int i = 1; i < upperBound; i++)
			{
				if(inputs[i].CompareTo(inputs[i - 1]) < 0) {
					T temp = inputs[i];
					inputs[i] = inputs[i - 1];
					inputs[i - 1] = temp;
					isSorted = false;
				}
			}
			upperBound --;
		}
	}
}