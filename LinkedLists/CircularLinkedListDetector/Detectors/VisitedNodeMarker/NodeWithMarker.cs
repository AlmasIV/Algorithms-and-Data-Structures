namespace CircularLinkedListDetector;

public class NodeWithMarker<T>
{
	public NodeWithMarker<T>? Next { get; set; }
	public T? Value { get; set; }
	internal Guid Marker { get; set; } = Guid.Empty;
}