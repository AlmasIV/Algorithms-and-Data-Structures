using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerRaiser.Tests;

[TestClass()]
internal class StringArithmeticTests {
	[TestMethod()]
	[DataRow("0", "0")]
	[DataRow("0", "1")]
	[DataRow("1", "0")]
	internal void SumStringNumbers_SumNumberWithZero_Number(string number1, string number2) {
		string expected = number1 == "0" ? number2 : number1;

		string actual = StringArithmetic.SumStringNumbers(number1, number2);

		Assert.AreEqual(expected, actual);
	}
}