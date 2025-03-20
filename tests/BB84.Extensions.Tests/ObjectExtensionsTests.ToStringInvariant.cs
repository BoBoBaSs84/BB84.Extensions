namespace BB84.Extensions.Tests;

public sealed partial class ObjectExtensionsTests
{
	[DataTestMethod("Object to invariant string test")]
	[DataRow("UnitTest", "UnitTest")]
	[DataRow(null, "")]
	public void ToStringInvariant(object value, string expected)
		=> Assert.AreEqual(expected, value.ToStringInvariant());
}
