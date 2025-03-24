namespace LinearSearch;

public static class LinearSearch<T> where T : IComparable<T>
{
	public static int Search(T[] values, T target)
	{
		ArgumentNullException.ThrowIfNull(values);
		
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i].CompareTo(target) == 0)
			{
				return i;
			}
		}
		return -1;
	}
}