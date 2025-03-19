namespace Quicksort.Tests;

[TestClass]
public class QuicksortTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Sort_PassNull_ThrowsArgumentNullException()
    {
        Quicksort<int>.Sort(null!);
    }

    [TestMethod]
    [DataRow(0)]
    public void Sort_PassSingleElementArray_DoesNothing(int singleItem)
    {
        int[] input = { singleItem };
        int expected = singleItem;

        Quicksort<int>.Sort(input);
        int actual = input[0];

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0, 1, -9)]
    [DataRow(0, 1, 2, 3, 4, 99, -87)]
    [DataRow(-8, 2, 3, 0, -999, 1)]
    [DataRow(1, 1, 1, 1, 1, 1, 1)]
    [DataRow(99, -4, -3, 2, 0, 900)]
    public void Sort_PassRandomArray_Sorts(params int[] inputs)
    {
        bool expected = true;

        Quicksort<int>.Sort(inputs);
        bool actual = IsArraySorted(inputs);

        Assert.AreEqual(expected, actual);
    }

    private static bool IsArraySorted(int[] ints)
    {
        if (ints == null || ints.Length < 2)
        {
            return true;
        }

        for (int i = 1; i < ints.Length; i++)
        {
            if (ints[i] < ints[i - 1])
            {
                return false;
            }
        }
        return true;
    }
}