namespace BinaryHeaps.MaxHeap.Tests;

[TestClass]
public class InsertTests
{
    [TestMethod]
    [DataRow(0)]
    public void Insert_InsertingSingleValue_IncrementsLength(int item)
    {
        MaxHeap<int> maxHeap = new();
        int expected = 1;

        maxHeap.Insert(item);
        int actual = maxHeap.Length;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0)]
    public void Insert_InsertingSingleValue_InsertsTheValue(int item)
    {
        MaxHeap<int> maxHeap = new();

        maxHeap.Insert(item);
        int insertedValue = maxHeap[0];

        Assert.AreEqual(item, insertedValue);
    }

    [TestMethod]
    [DataRow(0, 1, 2, 3)]
    [DataRow(0, 99, -21, 2, 22, 20)]
    public void Insert_InsertValues_InsertsThemCorrectly(params int[] ints)
    {
        MaxHeap<int> heap = new();
        bool expected = true;

        for (int i = 0; i < ints.Length; i++)
        {
            heap.Insert(ints[i]);
        }
        bool actual = MaxHeap<int>.IsMaxHeap(heap.ToArray());

        Assert.AreEqual(expected, actual);
    }
}