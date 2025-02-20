namespace CircularLinkedListDetector;

public static class CircularDetectionWithMarker<T>
{
	public static bool HasLoop(NodeWithMarker<T> node, bool detachIfHasLoop = false)
	{
		bool hasLoop = false;
		Guid marker = Guid.NewGuid();
		NodeWithMarker<T>? temp = node, prev = null;

		while (temp is not null)
		{
			if (temp.Marker == marker)
			{
				if(detachIfHasLoop) {
					prev!.Next = null;
				}
				hasLoop = true;
				break;
			}
			temp.Marker = marker;
			prev = temp;
			temp = temp.Next;
		}

		return hasLoop;
	}
}