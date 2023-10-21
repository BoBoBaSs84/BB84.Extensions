using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ObjectExtensionsTests
{
	[TestMethod("Object to invariant date time test")]
	public void ToDateTimeInvariant()
	{
		object obj = DateTime.MaxValue;

		DateTime dt = obj.ToDateTimeInvariant();

		Assert.AreEqual(DateTime.MaxValue, dt);
	}
}
