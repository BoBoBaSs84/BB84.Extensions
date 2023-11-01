using BB84.Extensions;

namespace BB84.ExtensionsTests;

public partial class StringExtensionsTests
{
	[DataTestMethod]
	[DataRow("Unit Test", "UnitTest")]
	[DataRow("Unit  Test", "UnitTest")]
	public void RemoveWhitespaceTest(string value, string expected)
		=> Assert.AreEqual(expected, value.RemoveWhitespace());
}
