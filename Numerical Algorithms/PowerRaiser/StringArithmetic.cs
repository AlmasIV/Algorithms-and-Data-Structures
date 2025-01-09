using System.Text;

namespace PowerRaiser;

internal static class StringArithmetic
{
	private static Dictionary<char, byte> s_charToByte = new Dictionary<char, byte>() {
		{ '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }
	};
	private static readonly string s_inputErrorMessage = "Inputs must contain only digits (special characters, whitespace and letters aren't allowed).";
	internal static string SumPositiveInts(string number1, string number2)
	{
		if (number1 == "0")
		{
			return number2;
		}
		else if (number2 == "0")
		{
			return number1;
		}
		(string longest, string shortest) = OrderByDescending(number1, number2);
		StringBuilder result = new StringBuilder(longest.Length + 1);
		int a, b, sum, remainder = 0, shortestCounter = shortest.Length - 1;

		for (int i = longest.Length - 1; i >= 0; i--)
		{
			if (!IsValidDigit(longest[i]) || !(shortestCounter < 0) && !IsValidDigit(shortest[shortestCounter]))
			{
				throw new ArgumentException(s_inputErrorMessage);
			}
			a = GetByteRepresentation(longest[i]);
			b = shortestCounter < 0 ? 0 : GetByteRepresentation(shortest[shortestCounter]);
			sum = a + b + remainder;
			remainder = sum > 9 ? 1 : 0;
			result.Append(sum > 9 ? sum % 10 : sum);
			shortestCounter--;
		}
		if (remainder > 0)
		{
			result.Append(remainder);
		}
		return new string(result.ToString().Reverse().ToArray());
	}
	internal static string MultiplyPositiveInts(string number1, string number2)
	{
		if (number1 == "0" || number2 == "0")
		{
			return "0";
		}
		(string longest, string shortest) = OrderByDescending(number1, number2);
		StringBuilder result = new StringBuilder();
		int a, b, product, remainder = 0, shortestCounter = shortest.Length - 1;

		for (int i = longest.Length - 1; i >= 0; i--)
		{
			if(!IsValidDigit(longest[i]) || !(shortestCounter < 0) && !IsValidDigit(shortest[shortestCounter])) {
				throw new ArgumentException(s_inputErrorMessage);
			}
			a = GetByteRepresentation(longest[i]);
			b = shortestCounter < 0 ? 1 : GetByteRepresentation(shortest[shortestCounter]);
			product = a * b + remainder;
			remainder = product > 9 ? product / 10 : 0;
			result.Append(product > 9 ? product % 10 : product);
			shortestCounter --;
		}
		if(remainder > 0) {
			result.Append(remainder);
		}
		return new string(result.ToString().Reverse().ToArray());
	}
	private static (string, string) OrderByDescending(string number1, string number2)
	{
		return (
			number1.Length > number2.Length ? number1 : number2,
			number2.Length < number1.Length ? number2 : number1
		);
	}
	private static bool IsValidDigit(char digit)
	{
		return s_charToByte.ContainsKey(digit);
	}
	private static byte GetByteRepresentation(char digit)
	{
		return s_charToByte[digit];
	}
}