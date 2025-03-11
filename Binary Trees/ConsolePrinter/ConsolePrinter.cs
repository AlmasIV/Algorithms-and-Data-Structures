using System.Text;

namespace ConsolePrinter;

/*
	1) Only works for complete binary trees.
	2) Not tested for large binary trees.
*/
public static class ConsolePrinter<T>
{
	private static int s_defaultSpaceSize = 8;
	private static int CalculateDepth(int size)
	{
		return (int)Math.Floor(Math.Log2(size));
	}
	private static string Repeat(string str, int times)
	{
		StringBuilder output = new StringBuilder();
		for (int i = 0; i < times; i++)
		{
			output.Append(str);
		}
		return output.ToString();
	}
	public static void Print(T[] binaryTree)
	{
		ArgumentNullException.ThrowIfNull(binaryTree);
		if (binaryTree.Length == 0)
		{
			return;
		}
		StringBuilder output = new StringBuilder();
		int spaceDrawn = 0;
		int maxDepth = CalculateDepth(binaryTree.Length);
		int currentDepth = 0;
		int maxSpace = (int)Math.Pow(2, currentDepth) * 2;
		string space = Repeat(" ", s_defaultSpaceSize);
		for (int i = 0; i < binaryTree.Length; i++)
		{
			output.Append(space);
			spaceDrawn++;

			output.Append(binaryTree[i]);

			output.Append(space);
			spaceDrawn++;

			if (spaceDrawn >= maxSpace)
			{
				output.Append("\n");
				spaceDrawn = 0;
				currentDepth ++;
				maxSpace = (int)Math.Pow(2, currentDepth) * 2;
				s_defaultSpaceSize /= 2;
				space = Repeat(" ", s_defaultSpaceSize);
			}
		}
		Console.WriteLine(output.ToString());
	}
}