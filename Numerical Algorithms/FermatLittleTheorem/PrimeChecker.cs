using PowerRaiser;
using PseudoRandomNumberGenerator;

/// <summary>
/// 	Defines a method that tries to determine if the passed number is prime or not. The method uses Fermat's little theorem. The algorithm is probabilistic.
/// </summary>
public static class PrimeChecker {
	/// <summary>
	/// 	Tries to determine wheter the passed <c><paramref name="number" /></c> is prime or not. It runs tests <c><paramref name="maxAttemptsForTest" /></c> times on the passed number.
	/// </summary>
	/// <param name="number">
	/// 	The number that is being tested.
	/// </param>
	/// <param name="maxAttemptsForTest">
	/// 	Max number of tests. The more tests you run the more precise guess you get.
	/// </param>
	/// <returns>
	/// 	Returns <c>true</c> if <paramref name="number" /> is probably a prime number, otherwise <c>false</c>.
	/// </returns>
	public static bool IsProbablyPrime(ulong number, ulong maxAttemptsForTest) {
		if(number < 2) {
			return false;
		}

		for(ulong i = 0; i < maxAttemptsForTest; i ++) {
			if(ulong.Parse(StringArithmetic.RaisePositiveIntToPower(LinearCongruentialGenerator.GenerateNumberInRange(1, number).ToString(), number - 1)) % number != 1) {
				return false;
			}
		}

		// 1/2 in power of maxAttemptsForTest => This is the probability that the number is not a prime. Which means the function is probabilistic.
		return true;
	}
}