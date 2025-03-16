namespace Heapsort.Tests;

[TestClass]
public class HeapsortTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Sort_PassNull_ThrowsArgumentNullException()
    {
        Heapsort<int>.Sort(null!);
    }

    [TestMethod]
    [DataRow(0, 1, 2, 3, 4)]
    [DataRow(-99, -92, 0, 1, 2, 900)]
    public void Sort_PassSortedArray_DoesNothing(params int[] array)
    {
        bool expected = true;

        Heapsort<int>.Sort(array);
        bool actual = IsArraySorted(array);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0, -1)]
    [DataRow(0, -1, 99, -92832)]
    [DataRow(900, 90, 20, 22, -9, 0, 1, 2, 3, 4)]
    [DataRow(0, 1, 2, -2, -3, -4, -5, -6, -7, -8, -9, 9, 0, 1, 2)]
    public void Sort_PassRandomArray_Sorts(params int[] array)
    {
        bool expected = true;

        Heapsort<int>.Sort(array);
        bool actual = IsArraySorted(array);

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