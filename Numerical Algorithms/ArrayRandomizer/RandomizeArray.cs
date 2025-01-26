namespace ArrayRandomizer;

/// <summary>
/// Provides a method to shuffle an array in place using the Fisher-Yates algorithm.
/// </summary>
public static class Randomizer
{
	/// <summary>
	/// 	Shuffles the specified array in place.
	/// </summary>
	/// <typeparam name="T">
	/// 	The type of elements in the array.
	/// </typeparam>
	/// <param name="array">
	/// 	The array to be shuffled.
	/// </param>
	/// <remarks>
	/// 	This method uses the Fisher-Yates algorithm to ensure a uniform shuffle.
	/// </remarks>
	public static void RandomizeArray<T>(T[] array)
	{
		int length = array.Length;
		Random random = new Random();
		for (int i = 0; i < length; i++)
		{
			int j = random.Next(i, length);
			T temp = array[i];
			array[i] = array[j];
			array[j] = temp;
		}
	}
}