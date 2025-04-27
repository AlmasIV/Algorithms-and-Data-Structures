using System.Numerics;

namespace Fibonacci;

public static class Fibonacci {
	public static BigInteger ComputeNth(ulong input) {
		if(input <= 1) {
			return input;
		}
		return ComputeNth(input - 1) + ComputeNth(input - 2);
	}
}