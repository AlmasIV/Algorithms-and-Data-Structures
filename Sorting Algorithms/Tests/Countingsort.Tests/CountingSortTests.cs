namespace Countingsort.Tests;

[TestClass]
public class CountingsortTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Sort_PassNull_ThrowsArgumentNullException()
    {
        Countingsort<SampleTest>.Sort(null!, 0);
    }

    [TestMethod]
    public void Sort_PassSingleElementArray_DoesNothing()
    {
        var singleElement = new SampleTest(0, "Data");

        var output = Countingsort<SampleTest>.Sort(new SampleTest[] { singleElement }, 0);

        Assert.AreEqual(singleElement, output[0]);
    }

    [TestMethod]
    public void Sort_PassRandomArray_ReturnsSortedArray()
    {
        SampleTest[] arrayToSort = new SampleTest[] {
            new SampleTest(0, "Data"),
            new SampleTest(1, "Data 1"),
            new SampleTest(0, "Data"),
            new SampleTest(2, "Data 2"),
            new SampleTest(1, "Data 1")
        };
        bool expected = true;

        SampleTest[] output = Countingsort<SampleTest>.Sort(arrayToSort, 2);
        bool actual = IsSorted(output);

        Assert.AreEqual(expected, actual);
    }
    bool IsSorted(IKey[] array)
    {
        if (array is null || array.Length == 1)
        {
            return true;
        }
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i].Key < array[i - 1].Key)
            {
                return false;
            }
        }
        return true;
    }
    class SampleTest : IKey
    {
        public ushort Key { get; init; }
        public string Data { get; init; }
        public SampleTest(ushort key, string data)
        {
            Key = key;
            Data = data;
        }
    }
}