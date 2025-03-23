namespace Countingsort;

public static class Countingsort<T> where T : IKey
{
	public static T[] Sort(T[] typesWithKeys, ushort maxKeyValue)
	{
		ArgumentNullException.ThrowIfNull(typesWithKeys);

		ushort[] keysCount = new ushort[maxKeyValue + 1];
		T[] output = new T[typesWithKeys.Length];

		for (int i = 0; i < typesWithKeys.Length; i++)
		{
			keysCount[typesWithKeys[i].Key] += 1;
		}

		for (int i = 1; i < keysCount.Length; i++)
		{
			keysCount[i] += keysCount[i - 1];
		}

		for (int i = typesWithKeys.Length - 1; i >= 0; i--)
		{
			ushort key = typesWithKeys[i].Key;
			keysCount[key] -= 1;
			output[keysCount[key]] = typesWithKeys[i];
		}

		return output;
	}
}