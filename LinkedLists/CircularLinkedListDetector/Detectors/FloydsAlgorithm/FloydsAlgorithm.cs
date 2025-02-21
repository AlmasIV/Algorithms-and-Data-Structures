namespace CircularLinkedListDetector;

public static class FloydsAlgorithm<T>
{
	public static bool HasLoop(Node<T> node, bool detachIfHasLoop = false)
	{
		if (node is null || node.Next is null)
		{
			return false;
		}
		bool isFirstGo = true, stop = false;
		Node<T>? first = node, hair = first, tortoise = first;
		while (hair is not null)
		{
			if (hair == tortoise)
			{
				if (isFirstGo)
				{
					hair = first;
					isFirstGo = false;
					if (!detachIfHasLoop)
					{
						return true;
					}
				}
				else
				{
					stop = true;
				}
			}
			if (detachIfHasLoop && stop && tortoise!.Next == hair)
			{
				tortoise.Next = null;
				return true;
			}
			tortoise = tortoise?.Next;
			if (isFirstGo)
			{
				hair = hair?.Next?.Next;
			}
			else if (!stop)
			{
				hair = hair?.Next;
			}
		}
		return false;
	}
}