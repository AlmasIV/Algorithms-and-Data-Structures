namespace NumberFactorizer;

public static class Factorizer
{
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