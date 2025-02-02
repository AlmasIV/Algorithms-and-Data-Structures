namespace SinglyLinkedLists;

class Program
{
    static void Main()
    {
        SinglyLinkedList<int> ints = new SinglyLinkedList<int>(new Node<int>(1));
        foreach(int i in ints) {
            Console.WriteLine(i);
        }
    }
}
