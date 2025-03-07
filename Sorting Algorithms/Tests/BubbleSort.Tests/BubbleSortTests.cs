namespace BubbleSort.Tests;

[TestClass]
public class BubbleSortTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Sort_PassingNull_ThrowsArgumentNullException()
    {
        BubbleSort<int>.Sort(null!);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(1)]
    [DataRow(-9)]
    [DataRow(99)]
    public void Sort_PassingSingleElementArray_DoesNothing(int number)
    {
        int[] input = { number };

        BubbleSort<int>.Sort(input);

        Assert.AreEqual(number, input[0]);
    }

    [TestMethod]
    [DataRow(0, -99, 2, -82, 2, 222, 34, 1, 1, 1, 0, 2132, 0)]
    [DataRow(1, 2, 234, 6, -928232, -8, 0, 213)]
    public void Sort_PassingRandomArray_Sortss(params int[] ints)
    {
        bool expected = true;

        BubbleSort<int>.Sort(ints);
        bool actual = IsArraySorted(ints);

        Assert.AreEqual(expected, actual);
    }

    private static bool IsArraySorted(int[] array)
    {
        int tempSmall = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if(tempSmall > array[i]) {
                return false;
            }
        }
        return true;
    }
}