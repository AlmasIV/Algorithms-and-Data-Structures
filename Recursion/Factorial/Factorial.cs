using System.Numerics;

namespace Factorial;

public static class Factorial
{
	public static BigInteger Compute(ulong number)
	{
		if(number == 0) {
			return 1;
		}
		return Compute(number - 1) * number;
	}
}