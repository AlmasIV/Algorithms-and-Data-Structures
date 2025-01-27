namespace SieveOfEratosthenes;

/// <summary>
/// 	Contains the method that uses the sieve of Eratosthenes to find prime numbers up to the specified boundary.
/// </summary>
public static class PrimeFinder
{
	/// <summary>
	/// 	Computes a list of prime numbers up to the specified <c><paramref name="upperBound"/></c>.
	/// </summary>
	/// <param name="upperBound">
	/// 	The upper bound till which to compute prime numbers. Must be greater than 1.
	/// </param>
	/// <returns>
	/// 	The list of computed prime numbers up to the specified boundary.
	/// </returns>
	/// <exception cref="ArgumentException">
	/// 	Thrown if the <c><paramref name="upperBound"/></c> is not greater than 1.
	/// </exception>
	public static List<ulong> FindPrimesUpToUpperBound(ulong upperBound)
	{
		if (upperBound < 2)
		{
			throw new ArgumentException("The prime numbers start at 2. Set an appropriate upper bound.");
		}
		bool[] isIndexComposite = new bool[upperBound + 1];
		ulong startIndex = 2, j;

		while (startIndex * startIndex <= upperBound)
		{
			if (!isIndexComposite[startIndex])
			{
				for (j = startIndex * startIndex; j <= upperBound; j += startIndex)
				{
					isIndexComposite[j] = true;
				}
			}
			startIndex++;
		}

		List<ulong> primes = new List<ulong>(isIndexComposite.Count(composite => composite == false));

		for (ulong i = 2; i < upperBound + 1; i++)
		{
			if (!isIndexComposite[i])
			{
				primes.Add(i);
			}
		}

		return primes;
	}
}