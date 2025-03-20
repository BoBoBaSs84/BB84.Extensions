namespace BB84.Extensions.Tests;

public sealed partial class ObjectExtensionsTests
{
	[TestMethod("Object to invariant long test")]
	public void ToInt64Invariant()
	{
		object value = long.MaxValue;

		long l = value.ToInt64Invariant();

		Assert.AreEqual(long.MaxValue, l);
	}
}
