namespace BinarySearch.Tests;

[TestClass]
public class LeftmostBinarySearchTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Search_PassNull_ThrowsArgumentNullException()
    {
        LeftmostBinarySearch<int>.Search(null!, 1);
    }

    [TestMethod]
    public void Search_PassSingleElementArrayAndExistingTarget_WorksAsExpected()
    {
        int[] sortedArray = { 0 };
        int target = 0;
        int expected = 0;

        int actual = LeftmostBinarySearch<int>.Search(sortedArray, target);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Search_PassSingleElementArrayAndNonExistingTarget_ReturnsNegative()
    {
        int[] sortedArray = { 0 };
        int target = 1;
        int expected = -1;

        int actual = LeftmostBinarySearch<int>.Search(sortedArray, target);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(new int[] { 0, 1, 2 }, 1)]
    [DataRow(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9)]
    [DataRow(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 1)]
    public void Search_PassSortedArrayAndExistingTarget_FindsCorrectIndex(int[] sortedArray, int target)
    {
        int expected = Array.IndexOf(sortedArray, target);

        int actual = LeftmostBinarySearch<int>.Search(sortedArray, target);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(new int[] { 0, 1, 2 }, 10)]
    [DataRow(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -4)]
    public void Search_PassSortedArrayAndNonExistingTarget_ReturnsNegative(int[] sortedArray, int target)
    {
        int expected = Array.IndexOf(sortedArray, target);

        int actual = LeftmostBinarySearch<int>.Search(sortedArray, target);

        Assert.AreEqual(expected, actual);
    }
}