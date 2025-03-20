namespace BB84.Extensions.Tests;

public sealed partial class IntegerExtensionsTests
{
	[TestMethod]
	[Description("Should iterate over an integer array.")]
	public void For()
	{
		int iterationCount = default;
		int value = 15;

		value.For(x => iterationCount++);

		Assert.AreEqual(value, iterationCount);
	}
}
