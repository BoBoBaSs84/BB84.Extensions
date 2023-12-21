using BB84.Extensions;

namespace BB84.ExtensionsTests;

public partial class BooleanExtensionsTests
{
	[DataTestMethod]
	[DataRow(true, false)]
	[DataRow(false, true)]
	public void IsFalseTest(bool value, bool expected)
		=> Assert.AreEqual(expected, value.IsFalse());
}
