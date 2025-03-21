namespace BB84.Extensions.Tests;

public sealed partial class EnumerableExtensionsTests
{
	[TestMethod]
	public void TakeRandom()
	{
		IEnumerable<int> ints = [1, 2, 3, 4, 5];

		int i = ints.TakeRandom();

		Assert.IsTrue(ints.Contains(i));
	}
}
