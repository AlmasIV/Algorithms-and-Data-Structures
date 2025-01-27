namespace PseudoRandomNumberGenerator;

/// <summary>
/// 	Defines methods that use linear congruential generator to compute a random number.
/// </summary>
/// <remarks>
/// 	This implementation uses current date and time to compute the initial value of the <c>seed</c>. Default constant values: <c>modulus = 2147483648</c>, <c>multiplier = 22695477</c>, <c>increment = 1</c>.
/// </remarks>
public static class LinearCongruentialGenerator
{
	private static ulong s_modulus = 2147483648;
	private static ulong s_multiplier = 22695477;
	private static ulong s_increment = 1;
	private static ulong s_seed = (ulong)(DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.DayOfYear + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + DateTime.Now.Microsecond);

	/// <summary>
	/// 	Generates a random number using LCG.
	/// </summary>
	/// <returns>
	/// 	Generated random number.
	/// </returns>
	public static ulong GenerateNumber()
	{
		s_seed = (s_multiplier * s_seed + s_increment) % s_modulus;
		return s_seed;
	}

	/// <summary>
	/// 	Sets constants of the LCG.
	/// </summary>
	/// <param name="modulus">
	/// 	Must be greater than 0.
	/// </param>
	/// <param name="multiplier">
	/// 	Multiplier, must be greater than 0, and less than <c><paramref name="modulus"/></c>.
	/// </param>
	/// <param name="increment">
	/// 	Must be greater than or equal to 0, and less than <c><paramref name="modulus"/></c>.
	/// </param>
	/// <param name="seed">
	/// 	The initial seed value that must be greater than or equal to 0, and less than <c><paramref name="modulus"/></c>.
	/// </param>
	/// <exception cref="ArgumentException">
	/// 	Thrown if any of the passed values are in incorrect range.
	/// </exception>
	public static void SetConstants(ulong modulus, ulong multiplier, ulong increment, ulong seed)
	{
		if (modulus <= 0)
		{
			throw new ArgumentException("The modulus must be greater than 0.");
		}
		if (multiplier <= 0 || multiplier >= modulus)
		{
			throw new ArgumentException("The multiplier must be greater than 0 and must be less than modulus.");
		}
		if (increment < 0 || increment >= modulus)
		{
			throw new ArgumentException("The increment must be greater than or equal to 0 and must be less than modulus.");
		}
		if (seed < 0 || seed >= modulus)
		{
			throw new ArgumentException("The starting value must be greater than or equal to 0 and must be less than modulus.");
		}
		s_modulus = modulus;
		s_multiplier = multiplier;
		s_increment = increment;
		s_seed = seed;
	}

	/// <summary>
	/// 	Computes a random value in range.
	/// </summary>
	/// <param name="min">
	/// 	The minimum value that can be randomly selected. The value is inclusive.
	/// </param>
	/// <param name="max">
	/// 	The maximum value that can be randomly selected. The value is exclusive.
	/// </param>
	/// <returns></returns>
	/// <exception cref="ArgumentException">
	/// 	Thrown if <c><paramref name="min"/></c> is less than <c><paramref name="max"/></c>.
	/// </exception>
	public static ulong GenerateNumberInRange(ulong min, ulong max)
	{
		if (min > max)
		{
			throw new ArgumentException("Min value cannot be greater than max value.");
		}
		ulong generatedNumber = GenerateNumber();
		ulong range = max - min;
		return min + (generatedNumber % range);
	}
}