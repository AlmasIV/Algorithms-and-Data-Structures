namespace InterpolationSearch.Tests;

[TestClass]
public class InterpolationSearchTests
{
	[TestMethod]
	[ExpectedException(typeof(ArgumentNullException))]
	public void Search_PassNull_ThrowsArgumentNullException()
	{
		InterpolationSearch<Data>.Search(null!, 0);
	}

	[TestMethod]
	public void Search_PassRandomArrayAndNonExistentTargetKey_ReturnsNegative()
	{
		Data[] sortedDataArray = {
			new Data(0, "Payload 0"),
			new Data(1, "Payload 1"),
			new Data(2, "Payload 2")
		};
		int expected = -1;
		int nonExistentKey = 100;

		int actual = InterpolationSearch<Data>.Search(sortedDataArray, nonExistentKey);

		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void Search_PassRandomArrayAndExistentTargetKey_ReturnsCorrectIndex()
	{
		Data[] sortedDataArray = {
			new Data(0, "Payload 0"),
			new Data(1, "Payload 1"),
			new Data(2, "Payload 2")
		};
		int expected = 1;
		int existentKey = 1;

		int actual = InterpolationSearch<Data>.Search(sortedDataArray, existentKey);

		Assert.AreEqual(expected, actual);
	}

	public class Data : IKey
	{
		public int Key { get; init; }
		public string Payload { get; init; }

		public Data(int key, string payload)
		{
			Key = key;
			Payload = payload;
		}
	}
}