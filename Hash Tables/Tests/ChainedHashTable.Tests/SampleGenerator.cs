namespace ChainedHashTable.Tests;

internal static class SampleGenerator
{
	public static KeyValuePair<int, string>[] GetRandomData(int count)
	{
		Random random = new();
		KeyValuePair<int, string>[] keyValuePairs = new KeyValuePair<int, string>[count];
		for (int i = 0; i < count; i++)
		{
			int key = random.Next();
			KeyValuePair<int, string> keyValuePair = new(key, $"Test Number {key}.");
			if (!keyValuePairs.Any(pair => pair.Key == key))
			{
				keyValuePairs[i] = keyValuePair;
			}
		}
		return keyValuePairs;
	}
}