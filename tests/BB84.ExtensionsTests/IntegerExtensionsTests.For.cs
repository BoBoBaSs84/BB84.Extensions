using BB84.Extensions;

namespace BB84.ExtensionsTests;

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
