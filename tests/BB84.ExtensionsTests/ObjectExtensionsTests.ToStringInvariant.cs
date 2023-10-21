using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ObjectExtensionsTests
{
	[TestMethod("Object to invariant string test")]
	public void ToStringInvariant()
	{
		object obj = "UnitTest";

		string s = obj.ToStringInvariant();

		Assert.AreEqual("UnitTest", s);
	}
}
