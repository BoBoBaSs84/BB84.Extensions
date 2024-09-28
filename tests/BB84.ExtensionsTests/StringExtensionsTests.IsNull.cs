using BB84.Extensions;

namespace BB84.ExtensionsTests;

public partial class StringExtensionsTests
{
	[DataTestMethod]
	[DataRow("Test", false)]
	[DataRow(null, true)]
	[DataRow("", false)]
	[DataRow(" ", false)]
	public void IsNullTest(string? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNull());

	[DataTestMethod]
	[DataRow("Test", false)]
	[DataRow(null, true)]
	[DataRow("", true)]
	[DataRow(" ", false)]
	public void IsNullOrEmptyTest(string? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNullOrEmpty());

	[DataTestMethod]
	[DataRow("Test", false)]
	[DataRow(null, true)]
	[DataRow("", true)]
	[DataRow(" ", true)]
	public void IsNullOrWhiteSpaceTest(string? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNullOrWhiteSpace());
}
