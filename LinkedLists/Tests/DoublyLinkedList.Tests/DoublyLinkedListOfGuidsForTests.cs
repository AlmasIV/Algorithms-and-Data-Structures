using SinglyLinkedList;

namespace DoublyLinkedList.Tests;

[TestClass()]
public class DoublyLinkedListOfGuidsForTests : DoublyLinkedListTestsAbstract<Guid>
{
    protected override Node<Guid> GetNode()
    {
        return new DoublyNode<Guid>();
    }

    protected override SinglyLinkedListAbstract<Guid> InitializeEmptyLinkedList()
    {
        throw new NotImplementedException();
    }

    protected override SinglyLinkedList.SinglyLinkedListAbstract<Guid> InitializeNonEmptyLinkedList()
    {
        throw new NotImplementedException();
    }
}