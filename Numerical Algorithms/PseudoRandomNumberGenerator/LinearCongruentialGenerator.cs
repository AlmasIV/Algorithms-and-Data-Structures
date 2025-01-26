namespace PseudoRandomNumberGenerator;

public static class LinearCongruentialGenerator
{
	private static ulong s_modulus = 2147483648;
	private static ulong s_multiplier = 22695477;
	private static ulong s_increment = 1;
	private static ulong s_seed = (ulong)(DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.DayOfYear + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + DateTime.Now.Microsecond);
	public static ulong GenerateNumber()
	{
		s_seed = (s_multiplier * s_seed + s_increment) % s_modulus;
		return s_seed;
	}
	public static void SetConstants(ulong modulus, ulong multiplier, ulong increment, ulong startValue)
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
		if (startValue < 0 || startValue >= modulus)
		{
			throw new ArgumentException("The starting value must be greater than or equal to 0 and must be less than modulus.");
		}
		s_modulus = modulus;
		s_multiplier = multiplier;
		s_increment = increment;
		s_seed = startValue;
	}
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