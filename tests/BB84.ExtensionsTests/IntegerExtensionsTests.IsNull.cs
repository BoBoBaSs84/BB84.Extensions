using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class IntegerExtensionsTests
{
	[DataTestMethod]
	[DataRow(1, false)]
	[DataRow(null, true)]
	public void IsNullTest(int? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNull());
}
