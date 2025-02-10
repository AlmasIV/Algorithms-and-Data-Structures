using SinglyLinkedList;

namespace DoublyLinkedList;

public class DoublyLinkedList<T> : SinglyLinkedList<T> {
	protected new DoublyNode<T>? Head { get; set; }
	protected DoublyNode<T>? Tail { get; set; }
    public override void PrependNode(Node<T> node)
    {
        base.PrependNode(node);
    }
}