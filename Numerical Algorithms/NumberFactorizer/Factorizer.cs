namespace NumberFactorizer;

/// <summary>
/// Provides functionality to perform prime factorization on numbers (ulong).
/// </summary>
public static class Factorizer
{
	/// <summary>
	/// Returns the list of prime factors of the specified number.
	/// </summary>
	/// <param name="number">
	/// 	The number to factorize into prime factors.
	/// </param>
	/// <returns>
	/// 	A list of prime factors of the given number.
	/// </returns>
	/// <remarks>
	/// For numbers ≤ 1, the method returns an empty list. For prime numbers, the returned list contains only the number itself.
	/// </remarks>
	public static List<ulong> Factorize(ulong number)
	{
		List<ulong> factors = new List<ulong>();
		if (number <= 1)
		{
			return factors;
		}
		while (number % 2 == 0)
		{
			factors.Add(2);
			number /= 2;
		}
		ulong odd = 3;
		ulong maxFactor = (ulong)Math.Sqrt(number);
		while (odd <= maxFactor)
		{
			if (number % odd == 0)
			{
				factors.Add(odd);
				number /= odd;
				maxFactor = (ulong)Math.Sqrt(number);
			}
			else
			{
				odd += 2;
			}
		}
		if (number > 1)
		{
			factors.Add(number);
		}
		return factors;
	}
}