namespace SelectionSort;

public static class SelectionSort<T> where T : IComparable<T>
{
	public static void Sort(T[] inputs)
	{
		ArgumentNullException.ThrowIfNull(inputs);
		for (int i = 0; i < inputs.Length; i++)
		{
			T smallest = inputs[i];
			int pointer = i;
			for (int j = i + 1; j < inputs.Length; j++)
			{
				if (inputs[j].CompareTo(smallest) < 0)
				{
					smallest = inputs[j];
					pointer = j;
				}
			}
			inputs[pointer] = inputs[i];
			inputs[i] = smallest;
		}
	}
}