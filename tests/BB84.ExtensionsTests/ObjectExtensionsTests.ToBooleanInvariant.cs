using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ObjectExtensionsTests
{
	[TestMethod("Object to invariant bool test")]
	public void ToBooleanInvariant()
	{
		object obj = true;

		bool b = obj.ToBooleanInvariant();

		Assert.IsTrue(b);
	}
}
