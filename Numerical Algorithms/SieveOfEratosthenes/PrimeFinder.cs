namespace SieveOfEratosthenes;

internal static class PrimeFinder {
	public static List<ulong> FindPrimesUpToUpperBound(ulong upperBound) {
		if(upperBound < 2) {
			throw new ArgumentException("The prime numbers start at 2. Set an appropriate upper bound.");
		}
		bool[] isIndexComposite = new bool[upperBound + 1];
		ulong startIndex = 2, j;

		while(startIndex * startIndex <= upperBound) {
			if(!isIndexComposite[startIndex]) {
				for(j = startIndex * startIndex; j <= upperBound; j += startIndex) {
					isIndexComposite[j] = true;
				}
			}
			startIndex ++;
		}

		List<ulong> primes = new List<ulong>(isIndexComposite.Count(composite => composite == false));

		for(ulong i = 2; i < upperBound + 1; i ++) {
			if(!isIndexComposite[i]) {
				primes.Add(i);
			}
		}

		return primes;
	}
}