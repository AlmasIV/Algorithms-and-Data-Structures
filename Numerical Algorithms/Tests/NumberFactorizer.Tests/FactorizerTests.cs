namespace NumberFactorizer.Tests;

[TestClass()]
public class FactorizerTests
{
	[TestMethod()]
	[DataRow(1000UL, "2, 2, 2, 5, 5, 5")]
	[DataRow(2555UL, "5, 7, 73")]
	[DataRow(24UL, "2, 2, 2, 3")]
	[DataRow(18446744073709551615UL, "3, 5, 17, 257, 641, 65537, 6700417")]
	public void Factorize_RandomNumbersAsInputs_ReturnsCorrectFactors(ulong number, string expectedAsText)
	{
		List<ulong> expected = expectedAsText
			.Split(", ")
			.Select(num => ulong.Parse(num))
			.ToList();

		List<ulong> actual = Factorizer.Factorize(number);

		CollectionAssert.AreEqual(expected, actual);
	}
}