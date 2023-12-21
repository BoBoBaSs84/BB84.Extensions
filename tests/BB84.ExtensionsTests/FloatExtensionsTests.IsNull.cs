using BB84.Extensions;

namespace BB84.ExtensionsTests;

public partial class FloatExtensionsTests
{
	[DataTestMethod]
	[DataRow(1.67f, false)]
	[DataRow(null, true)]
	public void IsNullTest(float? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNull());
}
