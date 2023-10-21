using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ObjectExtensionsTests
{
	[TestMethod("Object to invariant decimal test")]
	public void ToDecimalInvariant()
	{
		object obj = 3765.2343m;

		decimal d = obj.ToDecimalInvariant();

		Assert.AreEqual(3765.2343m, d);
	}
}
