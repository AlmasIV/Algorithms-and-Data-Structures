
namespace SinglyLinkedList.Tests;

[TestClass()]
public class SinglyLinkedListOfGuidsTests : LinkedListTestsAbstract<Guid>
{
    protected override Node<Guid> GetNode()
    {
        return new Node<Guid>(Guid.NewGuid());
    }

    protected override LinkedListAbstract<Guid> InitializeEmptyLinkedList()
    {
        return new SinglyLinkedList<Guid>();
    }

    protected override LinkedListAbstract<Guid> InitializeNonEmptyLinkedList()
    {
        SinglyLinkedList<Guid> linkedList = new SinglyLinkedList<Guid>();
        for(int i = 0; i < 100; i ++) {
            linkedList.AppendNode(new Node<Guid>(Guid.NewGuid()));
        }
        return linkedList;
    }
}