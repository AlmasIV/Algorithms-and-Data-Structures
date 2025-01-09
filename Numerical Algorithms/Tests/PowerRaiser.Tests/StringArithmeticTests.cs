using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerRaiser.Tests;

[TestClass()]
public class StringArithmeticTests {
	[TestMethod()]
	[DataRow("0", "0")]
	[DataRow("0", "1")]
	[DataRow("1", "0")]
	public void SumStringNumbers_SumNumberWithZero_ReturnsTheNumber(string number1, string number2) {
		string expected = number1 == "0" ? number2 : number1;

		string actual = StringArithmetic.SumStringNumbers(number1, number2);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow("18446744073709551615", "18446744073709551615")]
	public void SumStringNumbers_SumMaxULongIntegers_ReturnsTheSum(string num1, string num2) {
		string expected = "36893488147419103230";

		string actual = StringArithmetic.SumStringNumbers(num1, num2);

		Assert.AreEqual(expected, actual);
	}
}