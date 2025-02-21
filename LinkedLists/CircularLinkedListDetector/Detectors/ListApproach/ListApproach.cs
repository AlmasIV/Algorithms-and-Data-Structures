namespace CircularLinkedListDetector;

public static class ListApproach<T>
{
	public static bool HasLoop(Node<T> node, bool detachIfHasLoop = false)
	{
		bool hasLoop = false;
		List<Node<T>> visitedNodes = new();
		Node<T>? temp = node;
		while (temp is not null)
		{
			if (visitedNodes.Contains(temp))
			{
				hasLoop = true;
				if(detachIfHasLoop){
					int index = visitedNodes.IndexOf(temp);
					index = index == 0 ? visitedNodes.Count - 1 : index - 1;
					visitedNodes[index].Next = null;
				}
				break;
			}
			visitedNodes.Add(temp);
			temp = temp.Next;
		}
		return hasLoop;
	}
}