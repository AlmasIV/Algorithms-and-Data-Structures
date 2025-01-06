using System.Text;

namespace PowerRaiser;

internal static class StringArithmetic {
	private static Dictionary<char, byte> s_charToByte = new Dictionary<char, byte>() {
		{ '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }
	};
	private static readonly string s_inputErrorMessage = "Inputs must contain only digits (special characters, whitespace and letters aren't allowed).";
	internal static string SumStringNumbers(string number1, string number2) {
		if(number1 == "0") {
			return number2;
		}
		else if(number2 == "0") {
			return number1;
		}
		string longest = number1.Length > number2.Length ? number1 : number2;
		string shortest = number2.Length < number1.Length ? number2 : number1;
		StringBuilder result = new StringBuilder(longest.Length + 1);
		int a, b, sum, remainder = 0, shortestCounter = shortest.Length - 1;

		for(int i = longest.Length - 1; i >= 0; i --) {
			if(!IsValidDigit(longest[i]) || !(shortestCounter < 0) && !IsValidDigit(shortest[shortestCounter])) {
				throw new ArgumentException(s_inputErrorMessage);
			}
			a = GetByteRepresentation(longest[i]);
			b = shortestCounter < 0 ? 0 : GetByteRepresentation(shortest[shortestCounter]);
			sum = a + b + remainder;
			remainder = sum > 9 ? 1 : 0;
			result.Insert(i, sum > 9 ? sum % 10 : sum);
			shortestCounter --;
		}
		return result.ToString();
	}
	private static bool IsValidDigit(char digit) {
		return s_charToByte.ContainsKey(digit);
	}
	private static byte GetByteRepresentation(char digit) {
		return s_charToByte[digit];
	}
}