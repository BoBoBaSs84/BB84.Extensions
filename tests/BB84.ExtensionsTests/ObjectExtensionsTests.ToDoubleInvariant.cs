using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ObjectExtensionsTests
{
	[TestMethod("Object to invariant double test")]
	public void ToDoubleInvariant()
	{
		object obj = 123.987d;

		double d = obj.ToDoubleInvariant();

		Assert.AreEqual(123.987d, d);
	}
}
