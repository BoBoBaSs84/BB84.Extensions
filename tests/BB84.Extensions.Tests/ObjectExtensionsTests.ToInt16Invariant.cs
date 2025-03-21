namespace BB84.Extensions.Tests;

public sealed partial class ObjectExtensionsTests
{
	[TestMethod("Object to invariant short test")]
	public void ToInt16Invariant()
	{
		object value = short.MaxValue;

		short s = value.ToInt16Invariant();

		Assert.AreEqual(short.MaxValue, s);
	}
}
