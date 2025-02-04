namespace SinglyLinkedList;

class Program {
	static void Main() {
		SinglyLinkedList<int> _linkedList = new SinglyLinkedList<int>();
		for (int i = 0; i < 100; i++)
		{
			_linkedList.AppendNode(new Node<int>(i));
		}
		foreach(var v in _linkedList) {
			Console.WriteLine(v);
		}
	}
}