using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class DoubleExtensionsTests
{
	[DataTestMethod]
	[DataRow(1.67d, false)]
	[DataRow(null, true)]
	public void IsNullTest(double? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNull());
}
