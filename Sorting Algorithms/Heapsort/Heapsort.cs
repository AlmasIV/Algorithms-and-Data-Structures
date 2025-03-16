using BinaryHeaps;

namespace Heapsort;

public static class Heapsort<T> where T : IComparable<T>
{
	public static void Sort(T[] inputs)
	{
		ArgumentNullException.ThrowIfNull(inputs);
		MaxHeap<T> maxHeap = new(inputs);

		for (int i = maxHeap.Length - 1; i >= 0; i--)
		{
			T largest = maxHeap.RemoveTopItem();
			inputs[i] = largest;
		}
	}
}