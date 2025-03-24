namespace LinearSearch.Tests;

[TestClass]
public class LinearSearchTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Search_PassNullArray_ThrowsArgumentNullException()
    {
        LinearSearch<int>.Search(null!, 0);
    }

    [TestMethod]
    public void Search_SearchForNonExistentValue_ReturnsMinus1()
    {
        int[] ints = new int[] {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 0
        };
        int target = 10;
        int expected = -1;

        int actual = LinearSearch<int>.Search(ints, target);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1)]
    [DataRow(new int[] { 100, 200, -9, 2, 0, 1, 1, 1, 222, 20 }, 0)]
    public void Search_SearchForExistentValue_ReturnsCorrectIndex(int[] ints, int target)
    {
        int expected = Array.IndexOf(ints, target);

        int actual = LinearSearch<int>.Search(ints, target);

        Assert.AreEqual(expected, actual);
    }
}