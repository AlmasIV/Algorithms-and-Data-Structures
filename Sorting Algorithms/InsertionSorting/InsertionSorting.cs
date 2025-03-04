namespace InsertionSorting;

public static class InsertionSorting<T> where T : IComparable<T>
{
	public static void Sort(T[] values)
	{
		ArgumentNullException.ThrowIfNull(values);

		if (values.Length < 2)
		{
			return;
		}
		else
		{
			for (int i = 1; i < values.Length; i++)
			{
				int j = i - 1;
				while (j >= 0 && values[j].CompareTo(values[j + 1]) > 0)
				{
					T temp = values[j + 1];
					values[j + 1] = values[j];
					values[j] = temp;
					j --;
				}
			}
		}
	}
}