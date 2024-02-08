using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ObjectExtensionsTests
{
	[DataTestMethod("Object to invariant string test")]
	[DataRow("UnitTest", "UnitTest")]
	[DataRow(null, "")]
	public void ToStringInvariant(object value, string expected)
		=> Assert.AreEqual(expected, value.ToStringInvariant());
}
