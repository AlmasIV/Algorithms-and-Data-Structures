using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerRaiser.Tests;

[TestClass()]
public class StringArithmeticTests
{
	[TestMethod()]
	[DataRow("0", "0")]
	[DataRow("0", "1")]
	[DataRow("1", "0")]
	public void SumPositiveInts_SumNumberWithZero_ReturnsTheNumber(string number1, string number2)
	{
		string expected = number1 == "0" ? number2 : number1;

		string actual = StringArithmetic.SumPositiveInts(number1, number2);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow("18446744073709551615", "18446744073709551615")]
	public void SumPositiveInts_SumMaxULongIntegers_ReturnsTheSum(string num1, string num2)
	{
		string expected = "36893488147419103230";

		string actual = StringArithmetic.SumPositiveInts(num1, num2);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow("0", "0")]
	[DataRow("0", "1")]
	[DataRow("1", "0")]
	public void MultiplyPositiveInts_MultiplyByZero_ReturnsZero(string num1, string num2) {
		string expected = "0";

		string actual = StringArithmetic.MultiplyPositiveInts(num1, num2);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow("1", "1")]
	[DataRow("1", "100")]
	[DataRow("100", "1")]
	public void MultiplyPositiveInts_NaturalNumberMultipliedToOne_ReturnsNaturalNumber(string num1, string num2) {
		string expected = num1 == "1" ? num2 : num1;

		string actual = StringArithmetic.MultiplyPositiveInts(num1, num2);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow("18446744073709551615", "18446744073709551615")]
	public void MultiplyPositiveInts_MultiplyMaxULongNumbers_ReturnsTheProduct(string num1, string num2) {
		string expected = "340282366920938463426481119284349108225";

		string actual = StringArithmetic.MultiplyPositiveInts(num1, num2);

		Assert.AreEqual(expected, actual);
	}
}