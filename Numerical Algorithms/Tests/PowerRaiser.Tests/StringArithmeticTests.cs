namespace PowerRaiser.Tests;

[TestClass()]
public class StringArithmeticTests
{
	[TestMethod()]
	[DataRow("0", "0", "0")]
	[DataRow("0", "1", "1")]
	[DataRow("1", "0", "1")]
	public void SumPositiveInts_SumNumberWithZero_ReturnsTheNumber(string number1, string number2, string expected)
	{
		string actual = StringArithmetic.SumPositiveInts(number1, number2);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow("18446744073709551615", "18446744073709551615", "36893488147419103230")]
	public void SumPositiveInts_SumMaxULongIntegers_ReturnsTheSum(string num1, string num2, string expected)
	{
		string actual = StringArithmetic.SumPositiveInts(num1, num2);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow("0", "0", "0")]
	[DataRow("0", "1", "0")]
	[DataRow("1", "0", "0")]
	public void MultiplyPositiveInts_MultiplyByZero_ReturnsZero(string num1, string num2, string expected) {
		string actual = StringArithmetic.MultiplyPositiveInts(num1, num2);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow("1", "1", "1")]
	[DataRow("1", "100", "100")]
	[DataRow("100", "1", "100")]
	public void MultiplyPositiveInts_NaturalNumberMultipliedToOne_ReturnsNaturalNumber(string num1, string num2, string expected) {
		string actual = StringArithmetic.MultiplyPositiveInts(num1, num2);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow("18446744073709551615", "18446744073709551615", "340282366920938463426481119284349108225")]
	public void MultiplyPositiveInts_MultiplyMaxULongNumbers_ReturnsTheProduct(string num1, string num2, string expected) {
		string actual = StringArithmetic.MultiplyPositiveInts(num1, num2);
		
		Assert.AreEqual(expected, actual);
	}

	// It should be undefined though. But for simplicity, let it be this way.
	[TestMethod()]
	[DataRow("0", 0, "0")]
	public void RaisePositiveIntToPower_PowerOfZero_ReturnsZero(string number, int power, string expected) {
		string actual = StringArithmetic.RaisePositiveIntToPower(number, power);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod()]
	[DataRow("1", 0, "1")]
	[DataRow("1000", 0, "1")]
	[DataRow("18446744073709551615", 0, "1")]
	public void RaisePositiveIntToPower_RaiseNumbersToZero_ReturnsOne(string number, int power, string expected) {
		string actual = StringArithmetic.RaisePositiveIntToPower(number, power);

		Assert.AreEqual(actual, expected);
	}

	[TestMethod()]
	[DataRow("1", 2, "1")]
	[DataRow("2", 2, "4")]
	[DataRow("3", 2, "9")]
	[DataRow("4", 2, "16")]
	[DataRow("5", 2, "25")]
	[DataRow("6", 2, "36")]
	[DataRow("7", 2, "49")]
	[DataRow("8", 2, "64")]
	[DataRow("9", 2, "81")]
	public void RaisePositiveIntToPower_SquareDigits_ReturnsTheSquaredResult(string number, int power, string expected) {
		string actual = StringArithmetic.RaisePositiveIntToPower(number, power);

		Assert.AreEqual(expected, actual);
	}
}