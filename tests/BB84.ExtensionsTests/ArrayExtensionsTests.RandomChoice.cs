namespace BB84.Extensions.Tests;

public sealed partial class ArrayExtensionsTests
{
	[TestMethod]
	public void RandomChoice()
	{
		int[] ints = { 1, 2, 3 };

		int i = ints.RandomChoice();

		Assert.IsTrue(ints.Contains(i));
	}
}
