
namespace SinglyLinkedList.Tests;

[TestClass()]
public class SinglyLinkedListOfIntsTests : LinkedListTestsAbstract<int>
{
    protected override Node<int> GetNode()
    {
        return new Node<int>(1);
    }

    protected override LinkedListAbstract<int> InitializeEmptyLinkedList()
    {
        return new SinglyLinkedList<int>();
    }

    protected override LinkedListAbstract<int> InitializeNonEmptyLinkedList()
    {
        SinglyLinkedList<int> linkedList = new SinglyLinkedList<int>();
        for(int i = 0; i < 100; i ++) {
            linkedList.AppendNode(new Node<int>(i));
        }
        return linkedList;
    }
}