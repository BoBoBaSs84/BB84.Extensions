namespace BB84.Extensions.Tests;

public partial class BooleanExtensionsTests
{
	[DataTestMethod]
	[DataRow(true, false)]
	[DataRow(false, true)]
	public void IsFalseTest(bool value, bool expected)
		=> Assert.AreEqual(expected, value.IsFalse());

	[DataTestMethod]
	[DataRow(true, false)]
	[DataRow(false, true)]
	[DataRow(null, false)]
	public void NullableIsFalseTest(bool? value, bool expected)
		=> Assert.AreEqual(expected, value.IsFalse());
}
