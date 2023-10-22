using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class IntegerExtensionsTests
{
	[TestMethod]
	[Description("Should iterate over an integer array.")]
	public void For()
	{
		int iterationCount = default;
		int start = 1;
		int end = 3;

		start.For(end, x => iterationCount++);

		Assert.AreEqual(end, iterationCount);
	}
}
