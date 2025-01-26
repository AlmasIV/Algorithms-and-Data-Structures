using System.Text;

namespace PowerRaiser;

/// <summary>
/// 	Contains some of the rational operations that can be performed on integers represented as strings. Supported operations: summation, multiplication, and exponentiation.
/// </summary>
public static class StringArithmetic
{
	private static Dictionary<char, byte> s_charToByte = new Dictionary<char, byte>() {
		{ '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }
	};
	private static Dictionary<byte, char> s_byteToChar = new Dictionary<byte, char>() {
		{ 0, '0' }, { 1, '1' }, { 2, '2' }, { 3, '3' }, { 4, '4' }, { 5, '5' }, { 6, '6' }, { 7, '7' }, { 8, '8' }, { 9, '9' }
	};
	private static readonly string s_inputErrorMessage = "Inputs must contain only digits (special characters, whitespace and letters aren't allowed).";

	/// <summary>
	/// 	Returns the arithmetic sum of two strings that contain positive integers.
	/// </summary>
	/// <param name="number1">
	/// 	The first addend.
	/// </param>
	/// <param name="number2">
	/// 	The second addend.
	/// </param>
	/// <returns>
	/// 	The sum of <c><paramref name="number1"/></c> and <c><paramref name="number2"/></c>.
	/// </returns>
	/// <exception cref="ArgumentException">
	/// 	Thrown if either of the provided integers represented as strings doesn't include only digits.
	/// </exception>
	public static string SumPositiveInts(string number1, string number2)
	{
		if (!IsValidInput(number1) || !IsValidInput(number2))
		{
			throw new ArgumentException(s_inputErrorMessage);
		}
		if (number1 == "0")
		{
			return number2;
		}
		else if (number2 == "0")
		{
			return number1;
		}
		(string longest, string shortest) = OrderByDescending(number1, number2);
		List<char> result = new List<char>(longest.Length + 1);
		byte a, b, sum, remainder = 0;
		int shortestCounter = shortest.Length - 1;

		for (int i = longest.Length - 1; i >= 0; i--)
		{
			a = GetByteRepresentation(longest[i]);
			b = shortestCounter < 0 ? (byte)0 : GetByteRepresentation(shortest[shortestCounter]);
			sum = (byte)(a + b + remainder);
			remainder = (byte)(sum > 9 ? 1 : 0);
			result.Insert(0, GetCharRepresentation(sum > 9 ? (byte)(sum % 10) : sum));
			shortestCounter--;
		}
		if (remainder > 0)
		{
			result.Insert(0, GetCharRepresentation(remainder));
		}
		return new string(result.ToArray());
	}

	/// <summary>
	/// 	Multiplies two positive integers (zero can be used too) represented as strings.
	/// </summary>
	/// <param name="number1">
	/// 	The multiplicand represented as string.
	/// </param>
	/// <param name="number2">
	/// 	The multiplier represented as string.
	/// </param>
	/// <returns></returns>
	/// <exception cref="ArgumentException">
	/// 	Thrown if either of the provided integers doesn't include only digits.
	/// </exception>
	public static string MultiplyPositiveInts(string number1, string number2)
	{
		if (!IsValidInput(number1) || !IsValidInput(number2))
		{
			throw new ArgumentException(s_inputErrorMessage);
		}
		if (number1 == "0" || number2 == "0")
		{
			return "0";
		}
		else if (number1 == "1")
		{
			return number2;
		}
		else if (number2 == "1")
		{
			return number1;
		}
		(string longest, string shortest) = OrderByDescending(number1, number2);
		Stack<char> termA = new Stack<char>();
		Stack<char> termB = new Stack<char>();
		StringBuilder sumResult;
		Stack<char> termRef = termA;
		byte a, b, product, remainder = 0;
		char[] passedParts, tempArray;
		int passedPartCounter = 1;

		for (int i = shortest.Length - 1; i >= 0; i--)
		{
			b = GetByteRepresentation(shortest[i]);
			termRef = termA.Count == 0 ? termA : termB;
			for (int j = longest.Length - 1; j >= 0; j--)
			{
				a = GetByteRepresentation(longest[j]);
				product = (byte)(a * b + remainder);
				remainder = (byte)(product > 9 ? product / 10 : 0);
				termRef.Push(GetCharRepresentation(product > 9 ? (byte)(product % 10) : product));
			}
			if (remainder > 0)
			{
				termRef.Push(GetCharRepresentation(remainder));
				remainder = 0;
			}
			if (termB.Count != 0)
			{
				tempArray = termA.ToArray();
				passedParts = tempArray[^passedPartCounter..];
				sumResult = new StringBuilder(SumPositiveInts(
					new string(tempArray[0..^passedPartCounter]),
					new string(termB.ToArray())
				));
				foreach (char ch in passedParts)
				{
					sumResult.Append(ch);
				}
				termA = new Stack<char>(sumResult.ToString().Reverse());
				termB.Clear();
				passedPartCounter++;
			}
		}
		return new string(termA.ToArray());
	}
	private static (string, string) OrderByDescending(string number1, string number2)
	{
		return (
			number1.Length > number2.Length ? number1 : number2,
			number2.Length < number1.Length ? number2 : number1
		);
	}
	private static bool IsValidInput(string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return false;
		}
		return input.All(IsValidDigit);
	}
	private static bool IsValidDigit(char digit)
	{
		return s_charToByte.ContainsKey(digit);
	}
	private static byte GetByteRepresentation(char digit)
	{
		return s_charToByte[digit];
	}
	private static char GetCharRepresentation(byte digit)
	{
		return s_byteToChar[digit];
	}

	/// <summary>
	/// 	Computes the exponentiation of the integer represented as string.
	/// </summary>
	/// <param name="number">
	/// 	The base of the exponentiation represented as a string.
	/// </param>
	/// <param name="power">
	/// 	The power of the exponentiation.
	/// </param>
	/// <returns>
	/// 	Returns the equivalent string of exponentiation.
	/// </returns>
	/// <exception cref="ArgumentException">
	/// 	Thrown if <c><paramref name="number"/></c> doesn't include only digits.
	/// </exception>
	public static string RaisePositiveIntToPower(string number, ulong power)
	{
		if (!IsValidInput(number))
		{
			throw new ArgumentException(s_inputErrorMessage);
		}
		if (number == "0")
		{
			return "0";
		}
		if (power == 1)
		{
			return number;
		}
		if (power == 0)
		{
			return "1";
		}
		List<KeyValuePair<ulong, string>> powers = new List<KeyValuePair<ulong, string>>() { new KeyValuePair<ulong, string>(1, number) };
		KeyValuePair<ulong, string> lastPower = powers.Last();
		while (lastPower.Key + lastPower.Key < power)
		{
			lastPower = new KeyValuePair<ulong, string>(lastPower.Key + lastPower.Key, MultiplyPositiveInts(lastPower.Value, lastPower.Value));
			powers.Add(lastPower);
		}
		string result = "1";
		ulong currentPower = 0, pointer = (ulong)(powers.Count - 1), pointedPower;
		while (true)
		{
			pointedPower = powers[(int)pointer].Key;
			if (currentPower + pointedPower <= power)
			{
				result = MultiplyPositiveInts(result, powers[(int)pointer].Value);
				if (currentPower + pointedPower < power)
				{
					currentPower += powers[(int)pointer].Key;
					continue;
				}
				return result;
			}
			else
			{
				pointer--;
			}
		}
	}
}