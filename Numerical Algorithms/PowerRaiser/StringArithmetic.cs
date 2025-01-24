using System.Text;

namespace PowerRaiser;

public static class StringArithmetic
{
	private static Dictionary<char, byte> s_charToByte = new Dictionary<char, byte>() {
		{ '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }
	};
	private static Dictionary<byte, char> s_byteToChar = new Dictionary<byte, char>() {
		{ 0, '0' }, { 1, '1' }, { 2, '2' }, { 3, '3' }, { 4, '4' }, { 5, '5' }, { 6, '6' }, { 7, '7' }, { 8, '8' }, { 9, '9' }
	};
	private static readonly string s_inputErrorMessage = "Inputs must contain only digits (special characters, whitespace and letters aren't allowed).";
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
	public static string RaisePositiveIntToPower(string number, int power)
	{
		if (!IsValidInput(number))
		{
			throw new ArgumentException(s_inputErrorMessage);
		}
		if (number == "0")
		{
			return "0";
		}
		if (power < 0)
		{
			throw new ArgumentException("Negative powers aren't supported yet.");
		}
		if (power == 1)
		{
			return number;
		}
		if (power == 0)
		{
			return "1";
		}
		List<KeyValuePair<int, string>> powers = new List<KeyValuePair<int, string>>() { new KeyValuePair<int, string>(1, number) };
		KeyValuePair<int, string> lastPower = powers.Last();
		while (lastPower.Key + lastPower.Key < power)
		{
			lastPower = new KeyValuePair<int, string>(lastPower.Key + lastPower.Key, MultiplyPositiveInts(lastPower.Value, lastPower.Value));
			powers.Add(lastPower);
		}
		string result = "1";
		int currentPower = 0, pointer = powers.Count - 1, pointedPower;
		while (true)
		{
			pointedPower = powers[pointer].Key;
			if (currentPower + pointedPower <= power)
			{
				result = MultiplyPositiveInts(result, powers[pointer].Value);
				if (currentPower + pointedPower < power)
				{
					currentPower += powers[pointer].Key;
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
	// private static int CompareTwoPositiveInts(string number1, string number2) {
	// 	if(number1 == number2) {
	// 		return 0;
	// 	}
	// 	else {
	// 		if(number1.Length == number2.Length) {
	// 			byte a, b;
	// 			for(int i = 0; i < number1.Length; i ++) {
	// 				a = GetByteRepresentation(number1[i]);
	// 				b = GetByteRepresentation(number2[i]);
	// 				if(a > b) {
	// 					return 1;
	// 				}
	// 				else if(a < b) {
	// 					return -1;
	// 				}
	// 			}
	// 		}
	// 		return number1.Length > number2.Length ? 1 : -1;
	// 	}
	// }
}