using BB84.Extensions;

namespace BB84.ExtensionsTests;

public partial class BooleanExtensionsTests
{
	[DataTestMethod]
	[DataRow(true, false)]
	[DataRow(false, false)]
	[DataRow(null, true)]
	public void IsNullTest(bool? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNull());
}
