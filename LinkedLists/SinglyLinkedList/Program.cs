namespace SinglyLinkedList;

class Program {
	static void Main() {
		Node<int> head = new Node<int>(0);
		Node<int> temp = head;
		for (int i = 1; i < 100; i++)
		{
			temp.Next = new Node<int>(i);
			temp = temp.Next;
		}
		SinglyLinkedList<int> _linkedList = new SinglyLinkedList<int>(head);
		foreach(var v in _linkedList) {
			Console.WriteLine(v);
		}
	}
}