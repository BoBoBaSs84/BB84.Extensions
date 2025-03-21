namespace BB84.Extensions.Tests;

public sealed partial class ArrayExtensionsTests
{
	[TestMethod]
	public void TakeRandom()
	{
		int[] ints = [1, 2, 3];

		int i = ints.TakeRandom();

		Assert.IsTrue(ints.Contains(i));
	}
}
