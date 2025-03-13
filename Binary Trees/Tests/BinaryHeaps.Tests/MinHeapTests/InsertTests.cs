namespace BinaryHeaps.MinHeap.Tests;

[TestClass]
public class InsertTests
{
    [TestMethod]
    [DataRow(0)]
    public void Insert_InsertingSingleValue_IncrementsLength(int item)
    {
        MinHeap<int> myHeap = new();
        int expected = 1;

        myHeap.Insert(item);
        int actual = myHeap.Length;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0)]
    public void Insert_InsertingSingleValue_InsertsTheValue(int item)
    {
        MinHeap<int> myHeap = new();

        myHeap.Insert(item);
        int insertedValue = myHeap[0];

        Assert.AreEqual(item, insertedValue);
    }

    [TestMethod]
    [DataRow(0, 1, 2, 3)]
    [DataRow(0, 99, -21, 2, 22, 20)]
    public void Insert_InsertValues_InsertsThemCorrectly(params int[] ints)
    {
        MinHeap<int> heap = new();
        bool expected = true;

        for (int i = 0; i < ints.Length; i++)
        {
            heap.Insert(ints[i]);
        }
        bool actual = MinHeap<int>.IsMinHeap(heap.ToArray());

        Assert.AreEqual(expected, actual);
    }
}