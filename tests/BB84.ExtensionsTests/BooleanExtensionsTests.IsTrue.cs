using BB84.Extensions;

namespace BB84.ExtensionsTests;

public partial class BooleanExtensionsTests
{
	[DataTestMethod]
	[DataRow(true, true)]
	[DataRow(false, false)]
	public void IsTrueTest(bool value, bool expected)
		=> Assert.AreEqual(expected, value.IsTrue());

	[DataTestMethod]
	[DataRow(true, true)]
	[DataRow(false, false)]
	[DataRow(null, false)]
	public void NullableIsTrueTest(bool? value, bool expected)
		=> Assert.AreEqual(expected, value.IsTrue());
}
