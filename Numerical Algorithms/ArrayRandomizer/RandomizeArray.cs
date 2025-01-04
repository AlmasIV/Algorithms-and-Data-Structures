namespace ArrayRandomizer;

internal static class Randomizer {
	internal static void RandomizeArray<T>(T[] array) {
		int length = array.Length;
		Random random = new Random();
		for(int i = 0; i < length; i ++) {
			int j = random.Next(i, length);
			T temp = array[i];
			array[i] = array[j];
			array[j] = temp;
		}
	}
}