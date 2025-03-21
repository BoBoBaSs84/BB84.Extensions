namespace BB84.Extensions.Tests;

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
