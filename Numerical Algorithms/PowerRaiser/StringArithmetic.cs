using System.Text;

namespace PowerRaiser;

internal static class StringArithmetic
{
	private static Dictionary<char, byte> s_charToByte = new Dictionary<char, byte>() {
		{ '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }
	};
	private static Dictionary<byte, char> s_byteToChar = new Dictionary<byte, char>() {
		{ 0, '0' }, { 1, '1' }, { 2, '2' }, { 3, '3' }, { 4, '4' }, { 5, '5' }, { 6, '6' }, { 7, '7' }, { 8, '8' }, { 9, '9' }
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
		List<char> result = new List<char>(longest.Length + 1);
		byte a, b, sum, remainder = 0;
		int shortestCounter = shortest.Length - 1;

		for (int i = longest.Length - 1; i >= 0; i--)
		{
			if (!IsValidDigit(longest[i]) || !(shortestCounter < 0) && !IsValidDigit(shortest[shortestCounter]))
			{
				throw new ArgumentException(s_inputErrorMessage);
			}
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
	internal static string MultiplyPositiveInts(string number1, string number2)
	{
		if (number1 == "0" || number2 == "0")
		{
			return "0";
		}
		else if(number1 == "1") {
			return number2;
		}
		else if(number2 == "1") {
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
		
		for(int i = shortest.Length - 1; i >= 0; i --) {
			if(!IsValidDigit(shortest[i])) {
				throw new ArgumentException(s_inputErrorMessage);
			}
			b = GetByteRepresentation(shortest[i]);
			termRef = termA.Count == 0 ? termA : termB;
			for(int j = longest.Length - 1; j >= 0; j --) {
				if(!IsValidDigit(longest[j])) {
					throw new ArgumentException(s_inputErrorMessage);
				}
				a = GetByteRepresentation(longest[j]);
				product = (byte)(a * b + remainder);
				remainder = (byte)(product > 9 ? product / 10 : 0);
				termRef.Push(GetCharRepresentation(product > 9 ? (byte)(product % 10) : product));
			}
			if(remainder > 0) {
				termRef.Push(GetCharRepresentation(remainder));
				remainder = 0;
			}
			if(termB.Count != 0) {
				tempArray = termA.ToArray();
				passedParts = tempArray[^passedPartCounter..];
				sumResult = new StringBuilder(SumPositiveInts(
					new string(tempArray[0..^passedPartCounter]),
					new string(termB.ToArray())
				));
				foreach(char ch in passedParts) {
					sumResult.Append(ch);
				}
				termA = new Stack<char>(sumResult.ToString().Reverse());
				termB.Clear();
				passedPartCounter ++;
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
	private static bool IsValidDigit(char digit)
	{
		return s_charToByte.ContainsKey(digit);
	}
	private static byte GetByteRepresentation(char digit)
	{
		return s_charToByte[digit];
	}
	private static char GetCharRepresentation(byte digit) {
		return s_byteToChar[digit];
	}
}