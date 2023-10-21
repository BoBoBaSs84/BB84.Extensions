using BB84.Extensions;

namespace BB84.ExtensionsTests;

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
